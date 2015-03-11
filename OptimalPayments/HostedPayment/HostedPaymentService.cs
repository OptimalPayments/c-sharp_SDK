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
using OptimalApiClient = OptimalPayments.OptimalApiClient;

namespace OptimalPayments.HostedPayment
{
    public class HostedPaymentService
    {

        /// <summary>
        /// The api client, performs all http requests
        /// </summary>
        private OptimalApiClient client;

        /// <summary>
        /// The card payments api base uri 
        /// </summary>
        private string uri = "hosted/v1";

        /// <summary>
        /// Initialize the card payments service with an client object
        /// </summary>
        /// <param name="client">OptimalApiClient</param>
        public HostedPaymentService(OptimalApiClient client)
        {
            this.client = client;
        }

        /// <summary>
        /// process order
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>Order</returns>
        public Order processOrder(Order order)
        {
            order.setRequiredFields(new List<string> {
                HostedPaymentConstants.merchantRefNum,
                HostedPaymentConstants.currencyCode,
                HostedPaymentConstants.totalAmount
            });

            order.setOptionalFields(new List<string> {
                HostedPaymentConstants.customerIp,
                HostedPaymentConstants.customerNotificationEmail,
                HostedPaymentConstants.merchantNotificationEmail,
                HostedPaymentConstants.dueDate, 
                HostedPaymentConstants.profile, 
                HostedPaymentConstants.shoppingCart, 
                HostedPaymentConstants.ancillaryFees, 
                HostedPaymentConstants.billingDetails,
                HostedPaymentConstants.shippingDetails,
                HostedPaymentConstants.callback,
                HostedPaymentConstants.redirect,
                HostedPaymentConstants.link,
                HostedPaymentConstants.paymentMethod,
                HostedPaymentConstants.addendumData,
                HostedPaymentConstants.locale,
                HostedPaymentConstants.extendedOptions
            });

            Request request = new Request(
                method: RequestType.POST,
                uri: this.prepareURI("/orders"),
                body: order
            );

            dynamic response = this.client.processRequest(request);

            return new Order(response);
        }

        /// <summary>
        /// Get the Order
        /// </summary>
        /// <param name="auth">Order</param>
        /// <returns>Order</returns>
        public Order getOrder(Order order)
        {
            order.setRequiredFields(new List<string> { HostedPaymentConstants.id });
            order.checkRequiredFields();

            Request request = new Request(
                uri: this.prepareURI("/orders/" + order.id())
            );

            dynamic response = this.client.processRequest(request);

            return new Order(response);
        }

        /// <summary>
        /// Cancel an order
        /// </summary>
        /// <param name="order"></param>
        /// <returns>Order</returns>
        public Order cancelOrder(Order order)
        {
            order.setRequiredFields(new List<string> { HostedPaymentConstants.id });
            order.checkRequiredFields();

            Request request = new Request(
                method: RequestType.DELETE,
                uri: this.prepareURI("/orders/" + order.id())
            );

            dynamic response = this.client.processRequest(request);

            return new Order(response);
        }

        /// <summary>
        /// Cancel the Order
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>Order</returns>
        public Order cancelHeldOrder(Order order)
        {
            order.setRequiredFields(new List<string> {HostedPaymentConstants.id});
            order.checkRequiredFields();

            Order tempOrder = new Order();
            tempOrder.transaction().status("CANCELLED");

            Request request = new Request(
                method: RequestType.PUT,
                uri: this.prepareURI("/orders/" + order.id()),
                body: tempOrder
            );

            dynamic response = this.client.processRequest(request);

            return new Order(response);
        }

        /// <summary>
        /// Approve held order
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>Order</returns>
        public Order approveHeldOrder(Order order)
        {
            order.setRequiredFields(new List<string> { HostedPaymentConstants.id });
            order.checkRequiredFields();

            Order tmpOrder = new Order();
            tmpOrder.transaction().status("SUCCESS");

            Request request = new Request(
                method: RequestType.PUT,
                uri: this.prepareURI("/orders/" + order.id()),
                body: tmpOrder
            );

            dynamic response = this.client.processRequest(request);

            return new Order(response);
        }

        /// <summary>
        /// Resend order callback
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>True if successful</returns>
        public Boolean resendCallback(Order order)
        {
            order.setRequiredFields(new List<string> { HostedPaymentConstants.id });
            order.checkRequiredFields();

            Request request = new Request(
                method: RequestType.GET,
                uri: this.prepareURI("/orders/" + order.id() + "/resend_callback")

            );


            this.client.processRequest(request);

            return true;
        }

        /// <summary>
        /// Refund order
        /// </summary>
        /// <param name="refund">Refund</param>
        /// <returns>Refund</returns>
        public Refund refund(Refund newRefund)
        {
            newRefund.setRequiredFields(new List<string> { HostedPaymentConstants.orderId });
            newRefund.checkRequiredFields();
            newRefund.setRequiredFields(new List<string> { });
            newRefund.setOptionalFields(new List<string> {
                HostedPaymentConstants.amount,
                HostedPaymentConstants.merchantRefNum
            });

            Request request = new Request(
                method: RequestType.POST,
                uri: this.prepareURI("/orders/" + newRefund.orderId() + "/refund"),
                body: newRefund
            );

            dynamic response = this.client.processRequest(request);

            return new Refund(response);
        }

        /// <summary>
        /// Get the Settlement
        /// </summary>
        /// <param name="settlement">Settlement</param>
        /// <returns>Settlement</returns>
        public Settlement settlement(Settlement newSettlement)
        {
            newSettlement.setRequiredFields(new List<string> { HostedPaymentConstants.orderId });
            newSettlement.checkRequiredFields();
            newSettlement.setRequiredFields(new List<string> { });
            newSettlement.setOptionalFields(new List<string> {
                HostedPaymentConstants.amount,
                HostedPaymentConstants.merchantRefNum
            });

            Request request = new Request(
                method: RequestType.POST,
                uri: this.prepareURI("/orders/" + newSettlement.orderId() + "/settlement"),
                body: newSettlement
            );

            dynamic response = this.client.processRequest(request);

            return new Settlement(response);
        }

        /// <summary>
        /// Rebill order
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>Order</returns>
        public Order rebillOrder(Order order)
        {
            if (String.IsNullOrWhiteSpace(order.id())) {
                if (order.profile() == null)
                {
                    throw new OptimalException("You must specify a profile or id");
                }
                else if (String.IsNullOrWhiteSpace(order.profile().id()) || String.IsNullOrWhiteSpace(order.profile().paymentToken()))
                {
                    throw new OptimalException("You must specify a profile id and profile payment token");
                }
            }

            order.setRequiredFields(new List<string> { 
                HostedPaymentConstants.merchantRefNum,
                HostedPaymentConstants.currencyCode,
                HostedPaymentConstants.totalAmount 
            });

            order.setOptionalFields(new List<string> {
                HostedPaymentConstants.customerIp,
                HostedPaymentConstants.customerNotificationEmail,
                HostedPaymentConstants.merchantNotificationEmail,
                HostedPaymentConstants.dueDate,
                HostedPaymentConstants.profile,
                HostedPaymentConstants.shoppingCart,
                HostedPaymentConstants.ancillaryFees,
                HostedPaymentConstants.billingDetails,
                HostedPaymentConstants.shippingDetails,
                HostedPaymentConstants.callback,
                HostedPaymentConstants.paymentMethod,
                HostedPaymentConstants.addendumData,
                HostedPaymentConstants.locale,
                HostedPaymentConstants.extendedOptions
            });

            string urlAppend = "";
            if (!String.IsNullOrWhiteSpace(order.id())){
                urlAppend = "/" + order.id();
            }

            Request request = new Request(
                method: RequestType.POST,
                uri: this.prepareURI("/orders" + urlAppend),
                body: order
            );

            dynamic response = this.client.processRequest(request);

            return new Order(response);
        }

        /// <summary>
        /// Update rebill
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>Order</returns>
        public Order updateRebill(Order order)
        {
            order.setRequiredFields(new List<string> { HostedPaymentConstants.id });
            order.checkRequiredFields();
            order.setRequiredFields(new List<string> { });
            order.setOptionalFields(new List<string> {
                HostedPaymentConstants.merchantRefNum,
                HostedPaymentConstants.currencyCode,
                HostedPaymentConstants.totalAmount,
                HostedPaymentConstants.customerIp,
                HostedPaymentConstants.customerNotificationEmail,
                HostedPaymentConstants.merchantNotificationEmail,
                HostedPaymentConstants.dueDate,
                HostedPaymentConstants.profile,
                HostedPaymentConstants.shoppingCart,
                HostedPaymentConstants.ancillaryFees,
                HostedPaymentConstants.billingDetails,
                HostedPaymentConstants.shippingDetails,
                HostedPaymentConstants.callback,
                HostedPaymentConstants.paymentMethod,
                HostedPaymentConstants.addendumData,
                HostedPaymentConstants.locale,
                HostedPaymentConstants.extendedOptions
            });

            Request request = new Request(
                method: RequestType.PUT,
                uri: this.prepareURI("/orders/" + order.id()),
                body: order
            );

            dynamic response = this.client.processRequest(request);

            return new Order(response);
        }

        /// <summary>
        /// Get a report of recent orders
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public Pagerator<Order> getOrders(int count = 0)
        {
            if (count < 0)
            {
                throw new OptimalException("Invalid count " + count + ". Positive int expected.");
            }

            Dictionary<string, string> queryStr = new Dictionary<string, string>();
            if (count > 0)
            {
                queryStr.Add("num", count.ToString());
            }

            Request request = new Request(
                method: RequestType.GET,
                uri: this.prepareURI("/orders"),
                queryString: queryStr
            );

            dynamic response = this.client.processRequest(request);

            return new Pagerator<Order>(this.client, typeof(Order), response);
        }

        private string prepareURI(string path)
        {
            return this.uri + path;
        }
    }
}