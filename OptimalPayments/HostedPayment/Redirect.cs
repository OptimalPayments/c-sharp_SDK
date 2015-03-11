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
    public class Redirect : OptimalPayments.Common.JSONObject
    {
        /// <summary>
        /// Initialize the Redirect object with some set of properties
        /// </summary>
        /// <param name="properties">Dictionary<string, object></param>
        public Redirect(Dictionary<string, object> properties = null)
            : base(fieldTypes, properties)
        {
        }

        private static new Dictionary<string, object> fieldTypes = new Dictionary<string, object>
        {
            {HostedPaymentConstants.rel, HostedPaymentConstants.enumRelRedirect},
            {HostedPaymentConstants.returnKeys, typeof(List<string>)},
            {HostedPaymentConstants.uri, URL_TYPE},
            {HostedPaymentConstants.delimiter, STRING_TYPE}
        };


        /// <summary>
        /// Get the rel
        /// </summary>
        /// <returns>string</returns>
        public string rel()
        {
            return this.getProperty(HostedPaymentConstants.rel);
        }

        /// <summary>
        /// Set the rel
        /// </summary>
        /// <returns>void</returns>
        public void rel(string data)
        {
            this.setProperty(HostedPaymentConstants.rel, data);
        }

        /// <summary>
        /// Get the returnKeys
        /// </summary>
        /// <returns>List<string></returns>
        public List<string> returnKeys()
        {
            return this.getProperty(HostedPaymentConstants.returnKeys);
        }

        /// <summary>
        /// Set the returnKeys
        /// </summary>
        /// <returns>void</returns>
        public void returnKeys(List<string> data)
        {
            this.setProperty(HostedPaymentConstants.returnKeys, data);
        }

        /// <summary>
        /// Get the amount
        /// </summary>
        /// <returns>url</returns>
        public string amount()
        {
            return this.getProperty(HostedPaymentConstants.amount);
        }

        /// <summary>
        /// Set the amount
        /// </summary>
        /// <returns>void</returns>
        public void amount(string data)
        {
            this.setProperty(HostedPaymentConstants.amount, data);
        }

        /// <summary>
        /// Get the delimiter
        /// </summary>
        /// <returns>string</returns>
        public string delimiter()
        {
            return this.getProperty(HostedPaymentConstants.delimiter);
        }

        /// <summary>
        /// Set the delimiter
        /// </summary>
        /// <returns>void</returns>
        public void delimiter(string data)
        {
            this.setProperty(HostedPaymentConstants.delimiter, data);
        }

        /// <summary>
        /// RedirectBuilder<typeparam name="TBLDR"></typeparam> will allow a Redirect to be initialized
        /// within another builder. Set properties and subpropeties, then trigger .Done() to 
        /// get back to the parent builder
        /// </summary>
        public class RedirectBuilder<TBLDR> : NestedJSONBuilder<Redirect, TBLDR>
            where TBLDR : GenericJSONBuilder
        {
            /// <summary>
            /// Initialize the Redirect builder within the context of a parent builder
            /// </summary>
            /// <param name="parent">TBLDR</param>
            public RedirectBuilder(TBLDR parent)
                : base(parent)
            {
                this.parent = parent;
            }

            /// <summary>
            /// Set the rel
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>RedirectBuilder<TBLDR></returns>
            public RedirectBuilder<TBLDR> rel(string data)
            {
                this.properties[HostedPaymentConstants.rel] = data;
                return this;
            }

            /// <summary>
            /// Set the returnKeys
            /// </summary>
            /// <param name=HostedPayment.returnKeys>List<string></param>
            /// <returns>RedirectBuilder<TBLDR></returns>
            public RedirectBuilder<TBLDR> addReturnKey(string returnKey)
            {
                if (!this.properties.ContainsKey(HostedPaymentConstants.returnKeys))
                {
                    this.properties[HostedPaymentConstants.returnKeys] = new List<object>();
                }
                ((List<object>)this.properties[HostedPaymentConstants.returnKeys]).Add(returnKey);
                return this;
            }

            /// <summary>
            /// Set the uri
            /// </summary>
            /// <param name=HostedPayment.uri>string</param>
            /// <returns>RedirectBuilder<TBLDR></returns>
            public RedirectBuilder<TBLDR> uri(string data)
            {
                this.properties[HostedPaymentConstants.uri] = data;
                return this;
            }

            /// <summary>
            /// Set the delimiter
            /// </summary>
            /// <param name=HostedPayment.delimiter>string</param>
            /// <returns>RedirectBuilder<TBLDR></returns>
            public RedirectBuilder<TBLDR> delimiter(string data)
            {
                this.properties[HostedPaymentConstants.delimiter] = data;
                return this;
            }
        }
    }
}
