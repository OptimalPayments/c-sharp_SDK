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
    public class Settlement : OptimalPayments.Common.JSONObject
    {
        /// <summary>
        /// Initialize the Settlement object with some set of properties
        /// </summary>
        /// <param name="properties">Dictionary<string, object></param>
        public Settlement(Dictionary<string, object> properties = null)
            : base(fieldTypes, properties)
        {
        }

        private static new Dictionary<string, object> fieldTypes = new Dictionary<string, object>
        {
            {HostedPaymentConstants.id, STRING_TYPE},
            {HostedPaymentConstants.amount, INT_TYPE},
            {HostedPaymentConstants.merchantRefNum, STRING_TYPE},
            {HostedPaymentConstants.authType, STRING_TYPE},
            {HostedPaymentConstants.confirmationNumber, STRING_TYPE},
            {HostedPaymentConstants.currencyCode, STRING_TYPE},
            {HostedPaymentConstants.mode, STRING_TYPE},
            {HostedPaymentConstants.originalMerchantRefNum, STRING_TYPE},
            {HostedPaymentConstants.orderId, STRING_TYPE}
        };


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
        /// Get the amount
        /// </summary>
        /// <returns>int</returns>
        public int amount()
        {
            return this.getProperty(HostedPaymentConstants.amount);
        }

        /// <summary>
        /// Set the amount
        /// </summary>
        /// <returns>void</returns>
        public void amount(int data)
        {
            this.setProperty(HostedPaymentConstants.amount, data);
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
        /// Get the authType
        /// </summary>
        /// <returns>string</returns>
        public string authType()
        {
            return this.getProperty(HostedPaymentConstants.authType);
        }

        /// <summary>
        /// Set the authType
        /// </summary>
        /// <returns>void</returns>
        public void authType(string data)
        {
            this.setProperty(HostedPaymentConstants.authType, data);
        }

        /// <summary>
        /// Get the confirmationNumber
        /// </summary>
        /// <returns>string</returns>
        public string confirmationNumber()
        {
            return this.getProperty(HostedPaymentConstants.confirmationNumber);
        }

        /// <summary>
        /// Set the confirmationNumber
        /// </summary>
        /// <returns>void</returns>
        public void confirmationNumber(string data)
        {
            this.setProperty(HostedPaymentConstants.confirmationNumber, data);
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
        /// Get the mode
        /// </summary>
        /// <returns>string</returns>
        public string mode()
        {
            return this.getProperty(HostedPaymentConstants.mode);
        }

        /// <summary>
        /// Set the mode
        /// </summary>
        /// <returns>void</returns>
        public void mode(string data)
        {
            this.setProperty(HostedPaymentConstants.mode, data);
        }

        /// <summary>
        /// Get the originalMerchantRefNum
        /// </summary>
        /// <returns>string</returns>
        public string originalMerchantRefNum()
        {
            return this.getProperty(HostedPaymentConstants.originalMerchantRefNum);
        }

        /// <summary>
        /// Set the originalMerchantRefNum
        /// </summary>
        /// <returns>void</returns>
        public void originalMerchantRefNum(string data)
        {
            this.setProperty(HostedPaymentConstants.originalMerchantRefNum, data);
        }

        /// <summary>
        /// Get the orderId
        /// </summary>
        /// <returns>string</returns>
        public string orderId()
        {
            return this.getProperty(HostedPaymentConstants.orderId);
        }

        /// <summary>
        /// Set the orderId
        /// </summary>
        /// <returns>void</returns>
        public void orderId(string data)
        {
            this.setProperty(HostedPaymentConstants.orderId, data);
        }

        public static SettlementBuilder Builder() {
            return new SettlementBuilder();
        }

        /// <summary>
        /// SettlementBuilder will allow an Settlement to be initialized.
        /// set all properties and subpropeties, then trigger .Build() to 
        /// get the generated Settlement object
        /// </summary>
        public class SettlementBuilder : BaseJSONBuilder<Settlement>
        {
            /// <summary>
            /// Set the order id
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>SettlementBuilder</returns>
            public SettlementBuilder id(string data)
            {
                this.properties[HostedPaymentConstants.id] = data;
                return this;
            }

            /// <summary>
            /// Set the merchantRefNum parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>SettlementBuilder</returns>
            public SettlementBuilder merchantRefNum(string data)
            {
                this.properties[HostedPaymentConstants.merchantRefNum] = data;
                return this;
            }

            /// <summary>
            /// Set the totalAmount parameter
            /// </summary>
            /// <param name=HostedPayment.totalAmount>int</param>
            /// <returns>SettlementBuilder</returns>
            public SettlementBuilder amount(int data)
            {
                this.properties[HostedPaymentConstants.amount] = data;
                return this;
            }

            /// <summary>
            /// Set the id
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>SettlementBuilder</returns>
            public SettlementBuilder orderId(string data)
            {
                this.properties[HostedPaymentConstants.orderId] = data;
                return this;
            }

        }
    }
}
