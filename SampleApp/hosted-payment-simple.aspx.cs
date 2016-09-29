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
    public partial class hosted_payment_simple : System.Web.UI.Page
    {
        protected string payment_id = null;

        protected void Page_Load(object sender, EventArgs e)
        {
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
            try
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
                Response.Redirect(order.getLink("hosted_payment").uri());
            }
            catch (Exception ex)
            {
                Response.Write("<font style=\"color: #FF0000;\">Error Message is : " + ex.Message + "</font>\n");
            }
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