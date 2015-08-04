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
    public class Link : OptimalPayments.Common.JSONObject
    {
        /// <summary>
        /// Initialize the Link object with some set of properties
        /// </summary>
        /// <param name="properties">Dictionary<string, object></param>
        public Link(Dictionary<string, object> properties = null)
            : base(fieldTypes, properties)
        {
        }

        private static new Dictionary<string, object> fieldTypes = new Dictionary<string, object>
        {
            {HostedPaymentConstants.rel,  HostedPaymentConstants.enumRelLink},
            {HostedPaymentConstants.returnKeys, typeof(List<string>)},
            {HostedPaymentConstants.uri, URL_TYPE}
        };

        /// <summary>
        /// Get the rel
        /// </summary>
        /// <returns>List</returns>
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
        /// Get the uri
        /// </summary>
        /// <returns>uri</returns>
        public string uri()
        {
            return this.getProperty(HostedPaymentConstants.uri);
        }

        /// <summary>
        /// Set the uri
        /// </summary>
        /// <returns>void</returns>
        public void uri(String data)
        {
            this.setProperty(HostedPaymentConstants.uri, data);
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
        /// LinkBuilder<typeparam name="TBLDR"></typeparam> will allow a Link to be initialized
        /// within another builder. Set properties and subpropeties, then trigger .Done() to 
        /// get back to the parent builder
        /// </summary>
        public class LinkBuilder<TBLDR> : NestedJSONBuilder<Link, TBLDR>
            where TBLDR : GenericJSONBuilder
        {
            /// <summary>
            /// Initialize the Link builder within the context of a parent builder
            /// </summary>
            /// <param name="parent">TBLDR</param>
            public LinkBuilder(TBLDR parent)
                : base(parent)
            {
                this.parent = parent;
            }

            /// <summary>
            /// Set the rel
            /// </summary>
            /// <param name=HostedPayment.rel>string</param>
            /// <returns>LinkBuilder<TBLDR></returns>
            public LinkBuilder<TBLDR> rel(string data)
            {
                this.properties[HostedPaymentConstants.rel] = data;
                return this;
            }

            /// <summary>
            /// Set the returnKeys
            /// </summary>
            /// <param name=HostedPayment.returnKeys>List<string></param>
            /// <returns>LinkBuilder<TBLDR></returns>
            public LinkBuilder<TBLDR> addReturnKey(string returnKey)
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
            /// <param name="uri">string</param>
            /// <returns>LinkBuilder<TBLDR></returns>
            public LinkBuilder<TBLDR> uri(string data)
            {
                this.properties["uri"] = data;
                return this;
            }
        }
    }
}
