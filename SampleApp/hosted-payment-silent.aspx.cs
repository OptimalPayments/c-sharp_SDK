using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using OptimalPayments;
using OptimalPayments.HostedPayment;

namespace SampleApp
{
    public partial class hosted_payment_silent : System.Web.UI.Page
    {
        protected string payment_id = null;

        protected string silent_post_url = null;

        protected string order_id = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo ui = System.Globalization.CultureInfo.CurrentUICulture;

            string[] monthNames = ui.DateTimeFormat.MonthNames;
            int monthsInYear = ui.Calendar.GetMonthsInYear(DateTime.Now.Year);

            int monthNumber = 0;
            var monthsDataSource = monthNames.Take(monthsInYear).Select(monthName => new
            {
                Name = monthName,
                Value = ++monthNumber
            });

            this.cardExpiryMonth.DataTextField = "Name";
            this.cardExpiryMonth.DataValueField = "Value";
            this.cardExpiryMonth.DataSource = monthsDataSource;

            this.cardExpiryMonth.DataBind();
            if (Request.Form["card_expiry_month"] == null)
            {
                this.cardExpiryMonth.SelectedValue = DateTime.Now.Month.ToString();
            }

            for (int i = 0; i < 5; i++)
            {
                String year = (DateTime.Today.Year + i).ToString();
                ListItem li = new ListItem(year, year);
                this.cardExpiryYear.Items.Add(li);
            }


            if (Request.QueryString["id"] != null)
            {
                checkOrder();
            }
            else
            {
                btnSubmit.Click += new System.EventHandler(this.submit);
            }
        }

        protected void submit(object sender, System.EventArgs e)
        {
            string apiKey = System.Configuration.ConfigurationManager.AppSettings["ApiKey"];
            string apiSecret = System.Configuration.ConfigurationManager.AppSettings["ApiSecret"];
            string accountNumber = System.Configuration.ConfigurationManager.AppSettings["accountNumber"];
            int currencyBaseUnitsMultiplier = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["CurrencyBaseUnitsMultiplier"]);
            string currencyCode = System.Configuration.ConfigurationManager.AppSettings["CurrencyCode"];
            string pageUrl = HttpContext.Current.Request.Url.AbsoluteUri;

            OptimalApiClient client = new OptimalApiClient(apiKey, apiSecret, OptimalPayments.Environment.TEST, accountNumber);
            Order order = client.hostedPaymentService().processOrder(Order.Builder()
                .merchantRefNum(Request.Form["merchant_ref_num"])
                .currencyCode(currencyCode)
                .totalAmount(Convert.ToInt32(Double.Parse(Request.Form["amount"]) * currencyBaseUnitsMultiplier))
                .addExtendedOption()
                    .key("silentPost")
                    .value(true)
                    .Done()
                .addRedirect()
                    .rel("on_success")
                    .uri(pageUrl)
                    .addReturnKey("id")
                    .Done()
                .addRedirect()
                    .rel("on_decline")
                    .uri(pageUrl)
                    .addReturnKey("id")
                    .Done()
                .addRedirect()
                    .rel("on_error")
                    .uri(pageUrl)
                    .addReturnKey("id")
                    .Done()
                .profile()
                    .firstName(Request.Form["first_name"])
                    .lastName(Request.Form["last_name"])
                    .Done()
                .billingDetails()
                    .street(Request.Form["street"])
                    .city(Request.Form["city"])
                    .state(Request.Form["state"])
                    .country(Request.Form["country"])
                    .zip(Request.Form["zip"])
                    .Done()
                .Build());
            Session["order"] = order;
            this.silent_post_url = order.getLink("hosted_payment").uri();
            this.silentPostForm.Action = silent_post_url;
            this.order_id = order.id();
        }

        protected void checkOrder()
        {
            string apiKey = System.Configuration.ConfigurationManager.AppSettings["ApiKey"];
            string apiSecret = System.Configuration.ConfigurationManager.AppSettings["ApiSecret"];
            string accountNumber = System.Configuration.ConfigurationManager.AppSettings["accountNumber"];
            int currencyBaseUnitsMultiplier = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["CurrencyBaseUnitsMultiplier"]);
            string currencyCode = System.Configuration.ConfigurationManager.AppSettings["CurrencyCode"];
            string pageUrl = HttpContext.Current.Request.Url.AbsoluteUri;

            if (Session["order"] == null)
            {
                throw new Exception("No pending order found.");
            }
            Order sessionOrder = (Order)Session["order"];
            Session.Remove("order");

            if (sessionOrder.id() != Request.QueryString["id"])
            {
                throw new Exception("Invalid id");
            }

            OptimalApiClient client = new OptimalApiClient(apiKey, apiSecret, OptimalPayments.Environment.TEST, accountNumber);
            Order order = client.hostedPaymentService().getOrder(new Order(Request.QueryString["id"]));

            if (order.transaction().status().Equals("success"))
            {
                if (sessionOrder.totalAmount() != order.totalAmount())
                {
                    throw new Exception("Invalid amount");
                }
                this.payment_id = order.id();
            }
            else
            {
                throw new Exception("Unexpected transaction status: " + order.transaction().status());
            }
        }
    }
}