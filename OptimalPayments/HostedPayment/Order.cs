/*
 * Copyright (c) 2014 Optimal Payments
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and
 * associated documentation files (the "Software"), to deal in the Software without restriction,
 * including without limitation the rights to use, copy, modify, merge, publish, distribute,
 * sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all copies or
 * substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT
 * NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
 * DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OptimalPayments.Common;

namespace OptimalPayments.HostedPayment
{
    public class Order : JSONObject
    {

        /// <summary>
        /// Gets the array key to access the array of orders
        /// </summary>
        /// <returns>The key to be checked in the returning JSON</returns>
        public static string getPageableArrayKey()
        {
            return "records";
        }

        /// <summary>
        /// Initialize the Authorization object with some set of properties
        /// </summary>
        /// <param name="properties">Dictionary<string, object></param>
        public Order(Dictionary<string, object> properties = null)
            : base(fieldTypes, properties)
        {
        }

        /// <summary>
        /// Initialize an order object with an id
        /// </summary>
        /// <param name="id"></param>
        public Order(String id)
            : base(fieldTypes)
        {
            this.id(id);
        }

        private static new Dictionary<string, object> fieldTypes = new Dictionary<string, object>
        {
            {HostedPaymentConstants.id, STRING_TYPE},
            {HostedPaymentConstants.merchantRefNum, STRING_TYPE},
            {HostedPaymentConstants.currencyCode, STRING_TYPE},
            {HostedPaymentConstants.totalAmount, INT_TYPE},
            {HostedPaymentConstants.customerIp, STRING_TYPE},
            {HostedPaymentConstants.customerNotificationEmail, EMAIL_TYPE},
            {HostedPaymentConstants.merchantNotificationEmail, EMAIL_TYPE},
            {HostedPaymentConstants.dueDate, STRING_TYPE},
            {HostedPaymentConstants.profile, typeof(Profile)},
            {HostedPaymentConstants.shoppingCart, typeof(List<ShoppingCartItem>)},
            {HostedPaymentConstants.ancillaryFees, typeof(List<AncillaryFee>)},
            {HostedPaymentConstants.billingDetails, typeof(BillingDetails)},
            {HostedPaymentConstants.shippingDetails, typeof(ShippingDetails)},
            {HostedPaymentConstants.callback, typeof(List<Callback>)},
            {HostedPaymentConstants.redirect, typeof(List<Redirect>)},
            {HostedPaymentConstants.link, typeof(List<Link>)},
            {HostedPaymentConstants.mode, STRING_TYPE},
            {HostedPaymentConstants.type, STRING_TYPE},
            {HostedPaymentConstants.paymentMethod, typeof(List<string>)},
            {HostedPaymentConstants.addendumData, typeof(List<KeyValuePair>)},
            {HostedPaymentConstants.locale, HostedPaymentConstants.enumLocale},
            {HostedPaymentConstants.extendedOptions, typeof(List<KeyValuePair>)},
            {HostedPaymentConstants.associatedTransactions, typeof(List<Transaction>)},
            {HostedPaymentConstants.transaction, typeof(Transaction)},
            {HostedPaymentConstants.error, typeof(OptError)}
        };

        public OptimalPayments.HostedPayment.Link getLink(string linkName)
        {
            if (this.link().Count > 0)
            {
                foreach (OptimalPayments.HostedPayment.Link link in this.link())
                {

                    if (link.rel() == linkName)
                    {
                        return link;
                    }
                }
            }

            throw new OptimalException("Link " + linkName + " Not found in order.");
        }


        /// <summary>
        /// Get the id
        /// </summary>
        /// <returns>string</returns>
        public string id()
        {
            return this.getProperty(HostedPaymentConstants.id);
        }

        /// <summary>
        /// Set the id
        /// </summary>
        /// <returns>void</returns>
        public void id(string data)
        {
            this.setProperty(HostedPaymentConstants.id, data);
        }

        /// <summary>
        /// Get the merchantRefNum
        /// </summary>
        /// <returns>string</returns>
        public string merchantRefNum()
        {
            return this.getProperty(HostedPaymentConstants.merchantRefNum);
        }

        /// <summary>
        /// Set the merchantRefNum
        /// </summary>
        /// <returns>void</returns>
        public void merchantRefNum(string data)
        {
            this.setProperty(HostedPaymentConstants.merchantRefNum, data);
        }

        /// <summary>
        /// Get the currencyCode
        /// </summary>
        /// <returns>string</returns>
        public string currencyCode()
        {
            return this.getProperty(HostedPaymentConstants.currencyCode);
        }

        /// <summary>
        /// Set the currencyCode
        /// </summary>
        /// <returns>void</returns>
        public void currencyCode(string data)
        {
            this.setProperty(HostedPaymentConstants.currencyCode, data);
        }

        /// <summary>
        /// Get the totalAmount
        /// </summary>
        /// <returns>int</returns>
        public int totalAmount()
        {
            return this.getProperty(HostedPaymentConstants.totalAmount);
        }

        /// <summary>
        /// Set the totalAmount
        /// </summary>
        /// <returns>void</returns>
        public void totalAmount(int data)
        {
            this.setProperty(HostedPaymentConstants.totalAmount, data);
        }

        /// <summary>
        /// Get the customerIp
        /// </summary>
        /// <returns>string</returns>
        public string customerIp()
        {
            return this.getProperty(HostedPaymentConstants.customerIp);
        }

        /// <summary>
        /// Set the customerIp
        /// </summary>
        /// <returns>void</returns>
        public void customerIp(string data)
        {
            this.setProperty(HostedPaymentConstants.customerIp, data);
        }

        /// <summary>
        /// Get the customerNotificationEmail
        /// </summary>
        /// <returns>string</returns>
        public string customerNotificationEmail()
        {
            return this.getProperty(HostedPaymentConstants.customerNotificationEmail);
        }

        /// <summary>
        /// Set the customerNotificationEmail
        /// </summary>
        /// <returns>void</returns>
        public void customerNotificationEmail(string data)
        {
            this.setProperty(HostedPaymentConstants.customerNotificationEmail, data);
        }

        /// <summary>
        /// Get the merchantNotificationEmail
        /// </summary>
        /// <returns>string</returns>
        public string merchantNotificationEmail()
        {
            return this.getProperty(HostedPaymentConstants.merchantNotificationEmail);
        }

        /// <summary>
        /// Set the merchantNotificationEmail
        /// </summary>
        /// <returns>void</returns>
        public void merchantNotificationEmail(string data)
        {
            this.setProperty(HostedPaymentConstants.merchantNotificationEmail, data);
        }

        /// <summary>
        /// Get the dueDate
        /// </summary>
        /// <returns>string</returns>
        public string dueDate()
        {
            return this.getProperty(HostedPaymentConstants.dueDate);
        }

        /// <summary>
        /// Set the dueDate
        /// </summary>
        /// <returns>void</returns>
        public void dueDate(string data)
        {
            this.setProperty(HostedPaymentConstants.dueDate, data);
        }

        /// <summary>
        /// Get the profile
        /// </summary>
        /// <returns>Profile</returns>
        public Profile profile()
        {
            return this.getProperty(HostedPaymentConstants.profile);
        }

        /// <summary>
        /// Set the profile
        /// </summary>
        /// <returns>void</returns>
        public void profile(Profile data)
        {
            this.setProperty(HostedPaymentConstants.profile, data);
        }

        /// <summary>
        /// Get the shoppingCart
        /// </summary>
        /// <returns>List<OptimalPayments.HostedPayment.CartItem></returns>
        public List<OptimalPayments.HostedPayment.ShoppingCartItem> shoppingCart()
        {
            return this.getProperty(HostedPaymentConstants.shoppingCart);
        }

        /// <summary>
        /// Set the shoppingCart
        /// </summary>
        /// <returns>void</returns>
        public void shoppingCart(List<OptimalPayments.HostedPayment.ShoppingCartItem> data)
        {
            this.setProperty(HostedPaymentConstants.shoppingCart, data);
        }

        /// <summary>
        /// Get the ancillaryFees
        /// </summary>
        /// <returns>List<OptimalPayments.HostedPayment.AncillaryFee></returns>
        public List<OptimalPayments.HostedPayment.AncillaryFee> ancillaryFees()
        {
            return this.getProperty(HostedPaymentConstants.ancillaryFees);
        }

        /// <summary>
        /// Set the ancillaryFees
        /// </summary>
        /// <returns>void</returns>
        public void ancillaryFees(List<OptimalPayments.HostedPayment.AncillaryFee> data)
        {
            this.setProperty(HostedPaymentConstants.ancillaryFees, data);
        }

        /// <summary>
        /// Get the billingDetails
        /// </summary>
        /// <returns>BillingDetails</returns>
        public BillingDetails billingDetails()
        {
            return this.getProperty(HostedPaymentConstants.billingDetails);
        }

        /// <summary>
        /// Set the billingDetails
        /// </summary>
        /// <returns>void</returns>
        public void billingDetails(BillingDetails data)
        {
            this.setProperty(HostedPaymentConstants.billingDetails, data);
        }

        /// <summary>
        /// Get the shippingDetails
        /// </summary>
        /// <returns>ShippingDetails</returns>
        public ShippingDetails shippingDetails()
        {
            return this.getProperty(HostedPaymentConstants.shippingDetails);
        }

        /// <summary>
        /// Set the shippingDetails
        /// </summary>
        /// <returns>void</returns>
        public void shippingDetails(ShippingDetails data)
        {
            this.setProperty(HostedPaymentConstants.shippingDetails, data);
        }

        /// <summary>
        /// Get the callback
        /// </summary>
        /// <returns>List<OptimalPayments.HostedPayment.Callback></returns>
        public List<OptimalPayments.HostedPayment.Callback> callback()
        {
            return this.getProperty(HostedPaymentConstants.callback);
        }

        /// <summary>
        /// Set the callback
        /// </summary>
        /// <returns>void</returns>
        public void callback(List<OptimalPayments.HostedPayment.Callback> data)
        {
            this.setProperty(HostedPaymentConstants.callback, data);
        }

        /// <summary>
        /// Get the redirect
        /// </summary>
        /// <returns>List<OptimalPayments.HostedPayment.Redirect></returns>
        public List<OptimalPayments.HostedPayment.Redirect> redirect()
        {
            return this.getProperty(HostedPaymentConstants.redirect);
        }

        /// <summary>
        /// Set the redirect
        /// </summary>
        /// <returns>void</returns>
        public void redirect(List<OptimalPayments.HostedPayment.Redirect> data)
        {
            this.setProperty(HostedPaymentConstants.redirect, data);
        }

        /// <summary>
        /// Get the link
        /// </summary>
        /// <returns>List<OptimalPayments.HostedPayment.Link></returns>
        public List<OptimalPayments.HostedPayment.Link> link()
        {
            return this.getProperty(HostedPaymentConstants.link);
        }

        /// <summary>
        /// Set the link
        /// </summary>
        /// <returns>void</returns>
        public void link(List<OptimalPayments.HostedPayment.Link> data)
        {
            this.setProperty(HostedPaymentConstants.link, data);
        }

        /// <summary>
        /// Get the paymentMethod
        /// </summary>
        /// <returns>List<string></returns>
        public List<string> paymentMethod()
        {
            return this.getProperty(HostedPaymentConstants.paymentMethod);
        }

        /// <summary>
        /// Set the paymentMethod
        /// </summary>
        /// <returns>void</returns>
        public void paymentMethod(List<string> data)
        {
            this.setProperty(HostedPaymentConstants.paymentMethod, data);
        }

        /// <summary>
        /// Get the addendumData
        /// </summary>
        /// <returns>List<OptimalPayments.HostedPayment.KeyValuePair></returns>
        public List<OptimalPayments.HostedPayment.KeyValuePair> addendumData()
        {
            return this.getProperty(HostedPaymentConstants.addendumData);
        }

        /// <summary>
        /// Set the addendumData
        /// </summary>
        /// <returns>void</returns>
        public void addendumData(List<OptimalPayments.HostedPayment.KeyValuePair> data)
        {
            this.setProperty(HostedPaymentConstants.addendumData, data);
        }

        /// <summary>
        /// Get the locale
        /// </summary>
        /// <returns>Locale</returns>
        public String locale()
        {
            return this.getProperty(HostedPaymentConstants.locale);
        }

        /// <summary>
        /// Set the locale
        /// </summary>
        /// <returns>void</returns>
        public void locale(String data)
        {
            this.setProperty(HostedPaymentConstants.locale, data);
        }

        /// <summary>
        /// Get the extendedOptions
        /// </summary>
        /// <returns>List<OptimalPayments.HostedPayment.KeyValuePair></returns>
        public List<OptimalPayments.HostedPayment.KeyValuePair> extendedOptions()
        {
            return this.getProperty(HostedPaymentConstants.extendedOptions);
        }

        /// <summary>
        /// Set the extendedOptions
        /// </summary>
        /// <returns>void</returns>
        public void extendedOptions(List<OptimalPayments.HostedPayment.KeyValuePair> data)
        {
            this.setProperty(HostedPaymentConstants.extendedOptions, data);
        }

        /// <summary>
        /// Get the associatedTransactions
        /// </summary>
        /// <returns>List<OptimalPayments.HostedPayment.Transaction></returns>
        public List<OptimalPayments.HostedPayment.Transaction> associatedTransactions()
        {
            return this.getProperty(HostedPaymentConstants.associatedTransactions);
        }

        /// <summary>
        /// Set the associatedOptions
        /// </summary>
        /// <returns>void</returns>
        public void associatedTransactions(List<OptimalPayments.HostedPayment.Transaction> data)
        {
            this.setProperty(HostedPaymentConstants.associatedTransactions, data);
        }

        /// <summary>
        /// Get the transaction
        /// </summary>
        /// <returns>Transaction</returns>
        public Transaction transaction()
        {
            return this.getProperty(HostedPaymentConstants.transaction);
        }

        /// <summary>
        /// Set the transaction
        /// </summary>
        /// <returns>void</returns>
        public void transaction(Transaction data)
        {
            this.setProperty(HostedPaymentConstants.transaction, data);
        }

        /// <summary>
        /// Get the error
        /// </summary>
        /// <returns>OptError</returns>
        public OptError error()
        {
            return this.getProperty(HostedPaymentConstants.error);
        }

        /// <summary>
        /// Set the error
        /// </summary>
        /// <returns>void</returns>
        public void error(OptError data)
        {
            this.setProperty(HostedPaymentConstants.error, data);
        }

        public static OrderBuilder Builder()
        {
            return new OrderBuilder();
        }

        /// <summary>
        /// OrderBuilder will allow an Order to be initialized.
        /// set all properties and subpropeties, then trigger .Build() to 
        /// get the generated Order object
        /// </summary>
        public class OrderBuilder : BaseJSONBuilder<Order>
        {
            /// <summary>
            /// Set the id
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>OrderBuilder</returns>
            public OrderBuilder id(string data)
            {
                this.properties[HostedPaymentConstants.id] = data;
                return this;
            }

            /// <summary>
            /// Set the merchantRefNum parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>RefundBuilder</returns>
            public OrderBuilder merchantRefNum(string data)
            {
                this.properties[HostedPaymentConstants.merchantRefNum] = data;
                return this;
            }

            /// <summary>
            /// Set the currencyCode parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>RefundBuilder</returns>
            public OrderBuilder currencyCode(string data)
            {
                this.properties[HostedPaymentConstants.currencyCode] = data;
                return this;
            }

            /// <summary>
            /// Set the totalAmount parameter
            /// </summary>
            /// <param name=data>int</param>
            /// <returns>RefundBuilder</returns>
            public OrderBuilder totalAmount(int data)
            {
                this.properties[HostedPaymentConstants.totalAmount] = data;
                return this;
            }

            /// <summary>
            /// Set the customerIp parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>RefundBuilder</returns>
            public OrderBuilder customerIp(string data)
            {
                this.properties[HostedPaymentConstants.customerIp] = data;
                return this;
            }

            /// <summary>
            /// Set the customerNotificationEmail parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>RefundBuilder</returns>
            public OrderBuilder customerNotificationEmail(string data)
            {
                this.properties[HostedPaymentConstants.customerNotificationEmail] = data;
                return this;
            }

            /// <summary>
            /// Set the merchantNotificationEmail parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>RefundBuilder</returns>
            public OrderBuilder merchantNotificationEmail(string data)
            {
                this.properties[HostedPaymentConstants.merchantNotificationEmail] = data;
                return this;
            }

            /// <summary>
            /// Set the dueDate parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>RefundBuilder</returns>
            public OrderBuilder dueDate(string data)
            {
                this.properties[HostedPaymentConstants.dueDate] = data;
                return this;
            }

            /// <summary>
            /// Build a profile within this order.
            /// </summary>
            /// <returns>Profile.ProfileBuilder<OrderBuilder></returns>
            public Profile.ProfileBuilder<OrderBuilder> profile()
            {
                if (!this.properties.ContainsKey(HostedPaymentConstants.profile))
                {
                    this.properties[HostedPaymentConstants.profile] = new Profile.ProfileBuilder<OrderBuilder>(this);
                }
                return this.properties[HostedPaymentConstants.profile] as Profile.ProfileBuilder<OrderBuilder>;
            }

            /// Build a ShoppingCart within this order.
            /// </summary>
            /// <returns>ShoppingCart.ShoppingCartBuilder<OrderBuilder></returns>
            public ShoppingCartItem.ShoppingCartItemBuilder<OrderBuilder> addShoppingCartItem()
            {
                if (!this.properties.ContainsKey(HostedPaymentConstants.shoppingCart))
                {
                    this.properties[HostedPaymentConstants.shoppingCart] = new List<object>();
                }
                ShoppingCartItem.ShoppingCartItemBuilder<OrderBuilder> newBldr = new ShoppingCartItem.ShoppingCartItemBuilder<OrderBuilder>(this);
                ((List<object>)this.properties[HostedPaymentConstants.shoppingCart]).Add(newBldr);
                return newBldr;
            }

            /// Build a AncillaryFees within this order.
            /// </summary>
            /// <returns>AncillaryFees.AncillaryFeesBuilder<OrderBuilder></returns>
            public AncillaryFee.AncillaryFeeBuilder<OrderBuilder> addAncillaryFee()
            {
                if (!this.properties.ContainsKey("ancillaryFee"))
                {
                    this.properties["ancillaryFee"] = new List<object>();
                }
                AncillaryFee.AncillaryFeeBuilder<OrderBuilder> newBldr = new AncillaryFee.AncillaryFeeBuilder<OrderBuilder>(this);
                ((List<object>)this.properties["ancillaryFee"]).Add(newBldr);
                return newBldr;
            }

            /// Build a BillingDetails within this order.
            /// </summary>
            /// <returns>BillingDetails.BillingDetailsBuilder<OrderBuilder></returns>
            public BillingDetails.BillingDetailsBuilder<OrderBuilder> billingDetails()
            {
                if (!this.properties.ContainsKey(HostedPaymentConstants.billingDetails))
                {
                    this.properties[HostedPaymentConstants.billingDetails] = new BillingDetails.BillingDetailsBuilder<OrderBuilder>(this);
                }
                return this.properties[HostedPaymentConstants.billingDetails] as BillingDetails.BillingDetailsBuilder<OrderBuilder>;
            }

            /// Build a ShippingDetails within this order.
            /// </summary>
            /// <returns>ShippingDetails.ShippingDetailsBuilder<OrderBuilder></returns>
            public ShippingDetails.ShippingDetailsBuilder<OrderBuilder> shippingDetails()
            {
                if (!this.properties.ContainsKey(HostedPaymentConstants.shippingDetails))
                {
                    this.properties[HostedPaymentConstants.shippingDetails] = new ShippingDetails.ShippingDetailsBuilder<OrderBuilder>(this);
                }
                return this.properties[HostedPaymentConstants.shippingDetails] as ShippingDetails.ShippingDetailsBuilder<OrderBuilder>;
            }

            /// Build Callback a within this order.
            /// </summary>
            /// <returns>Callback.CallbackBuilder<OrderBuilder></returns>
            public Callback.CallbackBuilder<OrderBuilder> callback()
            {
                if (!this.properties.ContainsKey(HostedPaymentConstants.callback))
                {
                    this.properties[HostedPaymentConstants.callback] = new List<object>();
                }
                Callback.CallbackBuilder<OrderBuilder> newBldr = new Callback.CallbackBuilder<OrderBuilder>(this);
                ((List<object>)this.properties[HostedPaymentConstants.callback]).Add(newBldr);
                return newBldr;
            }

            /// Build a Redirect within this order.
            /// </summary>
            /// <returns>Redirect.RedirectBuilder<OrderBuilder></returns>
            public Redirect.RedirectBuilder<OrderBuilder> addRedirect()
            {
                if (!this.properties.ContainsKey(HostedPaymentConstants.redirect))
                {
                    this.properties[HostedPaymentConstants.redirect] = new List<object>();
                }
                Redirect.RedirectBuilder<OrderBuilder> newBldr = new Redirect.RedirectBuilder<OrderBuilder>(this);
                ((List<object>)this.properties[HostedPaymentConstants.redirect]).Add(newBldr);
                return newBldr;
            }

            /// Build a within this Link.
            /// </summary>
            /// <returns>Link.LinkBuilder<OrderBuilder></returns>
            public Link.LinkBuilder<OrderBuilder> addLink()
            {
                if (!this.properties.ContainsKey(HostedPaymentConstants.link))
                {
                    this.properties[HostedPaymentConstants.link] = new List<object>();
                }
                Link.LinkBuilder<OrderBuilder> newBldr = new Link.LinkBuilder<OrderBuilder>(this);
                ((List<object>)this.properties[HostedPaymentConstants.link]).Add(newBldr);
                return newBldr;
            }

            /// <summary>
            /// Set the paymentMethod parameter
            /// </summary>
            /// <param name=HostedPayment.paymentMethod>List<></param>
            /// <returns>RefundBuilder</returns>
            public OrderBuilder addPaymentMethod(String paymentMethod)
            {
                if (!this.properties.ContainsKey(HostedPaymentConstants.paymentMethod))
                {
                    this.properties[HostedPaymentConstants.paymentMethod] = new List<object>();
                }
                ((List<object>)this.properties[HostedPaymentConstants.paymentMethod]).Add(paymentMethod);
                return this;
            }

            /// Build a AddendumDate within this order.
            /// </summary>
            /// <returns>addendumData.addendumDataBuilder<addendumDataBuilder></returns>
            public KeyValuePair.KeyValuePairBuilder<OrderBuilder> addAddendumData()
            {
                if (!this.properties.ContainsKey(HostedPaymentConstants.addendumData))
                {
                    this.properties[HostedPaymentConstants.addendumData] = new List<object>();
                }
                KeyValuePair.KeyValuePairBuilder<OrderBuilder> newBldr = new KeyValuePair.KeyValuePairBuilder<OrderBuilder>(this);
                ((List<object>)this.properties[HostedPaymentConstants.addendumData]).Add(newBldr);
                return newBldr;
            }

            /// <summary>
            /// Set the locale parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>RefundBuilder</returns>
            public OrderBuilder locale(string data)
            {
                this.properties[HostedPaymentConstants.locale] = data;
                return this;
            }

            /// Build a ExtendedOptions within this order.
            /// </summary>
            /// <returns>ExtendedOptions.ExtendedOptionsBuilder<ExtendedOptionsBuilder></returns>
            public KeyValuePair.KeyValuePairBuilder<OrderBuilder> addExtendedOption()
            {
                if (!this.properties.ContainsKey(HostedPaymentConstants.extendedOptions))
                {
                    this.properties[HostedPaymentConstants.extendedOptions] = new List<object>();
                }
                KeyValuePair.KeyValuePairBuilder<OrderBuilder> newBldr = new KeyValuePair.KeyValuePairBuilder<OrderBuilder>(this);
                ((List<object>)this.properties[HostedPaymentConstants.extendedOptions]).Add(newBldr);
                return newBldr;
            }
        }
    }
}
