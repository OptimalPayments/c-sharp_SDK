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
    public class Profile : OptimalPayments.Common.JSONObject
    {
        /// <summary>
        /// Initialize the Profile object with some set of properties
        /// </summary>
        /// <param name="properties">Dictionary<string, object></param>
        public Profile(Dictionary<string, object> properties = null)
            : base(fieldTypes, properties)
        {
        }

        private static new Dictionary<string, object> fieldTypes = new Dictionary<string, object>
        {
            {HostedPaymentConstants.id, STRING_TYPE},
            {HostedPaymentConstants.merchantCustomerId, STRING_TYPE},
            {HostedPaymentConstants.firstName, STRING_TYPE},
            {HostedPaymentConstants.lastName, STRING_TYPE},
            {HostedPaymentConstants.paymentToken, STRING_TYPE}
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
        /// Get the merchantCustomerId
        /// </summary>
        /// <returns>string</returns>
        public string merchantCustomerId()
        {
            return this.getProperty(HostedPaymentConstants.merchantCustomerId);
        }

        /// <summary>
        /// Set the merchantCustomerId
        /// </summary>
        /// <returns>void</returns>
        public void merchantCustomerId(string data)
        {
            this.setProperty(HostedPaymentConstants.merchantCustomerId, data);
        }

        /// <summary>
        /// Get the firstName
        /// </summary>
        /// <returns>string</returns>
        public string firstName()
        {
            return this.getProperty(HostedPaymentConstants.firstName);
        }

        /// <summary>
        /// Set the firstName
        /// </summary>
        /// <returns>void</returns>
        public void firstName(string data)
        {
            this.setProperty(HostedPaymentConstants.firstName, data);
        }

        /// <summary>
        /// Get the lastName
        /// </summary>
        /// <returns>string</returns>
        public string lastName()
        {
            return this.getProperty(HostedPaymentConstants.lastName);
        }

        /// <summary>
        /// Set the lastName
        /// </summary>
        /// <returns>void</returns>
        public void lastName(string data)
        {
            this.setProperty(HostedPaymentConstants.lastName, data);
        }

        /// <summary>
        /// Get the paymentToken
        /// </summary>
        /// <returns>string</returns>
        public string paymentToken()
        {
            return this.getProperty(HostedPaymentConstants.paymentToken);
        }

        /// <summary>
        /// Set the paymentToken
        /// </summary>
        /// <returns>void</returns>
        public void paymentToken(string data)
        {
            this.setProperty(HostedPaymentConstants.paymentToken, data);
        }

        /// <summary>
        /// ProfileBuilder<typeparam name="TBLDR"></typeparam> will allow a Profile to be initialized
        /// within another builder. Set properties and subpropeties, then trigger .Done() to 
        /// get back to the parent builder
        /// </summary>
        public class ProfileBuilder<TBLDR> : NestedJSONBuilder<Profile, TBLDR>
            where TBLDR : GenericJSONBuilder
        {
            /// <summary>
            /// Initialize the Profile builder within the context of a parent builder
            /// </summary>
            /// <param name="parent">TBLDR</param>
            public ProfileBuilder(TBLDR parent)
                : base(parent)
            {
                this.parent = parent;
            }

            /// <summary>
            /// Set the id
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ProfileBuilder<TBLDR></returns>
            public ProfileBuilder<TBLDR> id(string data)
            {
                this.properties[HostedPaymentConstants.id] = data;
                return this;
            }

            /// <summary>
            /// Set the merchantCustomerId
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ProfileBuilder<TBLDR></returns>
            public ProfileBuilder<TBLDR> merchantCustomerId(string data)
            {
                this.properties[HostedPaymentConstants.merchantCustomerId] = data;
                return this;
            }

            /// <summary>
            /// Set the firstname
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ProfileBuilder<TBLDR></returns>
            public ProfileBuilder<TBLDR> firstName(string data)
            {
                this.properties[HostedPaymentConstants.firstName] = data;
                return this;
            }

            /// <summary>
            /// Set the lastname
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ProfileBuilder<TBLDR></returns>
            public ProfileBuilder<TBLDR> lastName(string data)
            {
                this.properties[HostedPaymentConstants.lastName] = data;
                return this;
            }

            /// <summary>
            /// Set the paymentToken
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ProfileBuilder<TBLDR></returns>
            public ProfileBuilder<TBLDR> paymentToken(string data)
            {
                this.properties[HostedPaymentConstants.paymentToken] = data;
                return this;
            }
        }
    }
}
