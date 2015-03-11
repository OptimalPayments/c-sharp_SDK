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
    public class Callback : OptimalPayments.Common.JSONObject
    {
        /// <summary>
        /// Initialize the Callback object with some set of properties
        /// </summary>
        /// <param name="properties">Dictionary<string, object></param>
        public Callback(Dictionary<string, object> properties = null)
            : base(fieldTypes, properties)
        {
        }

        private static new Dictionary<string, object> fieldTypes = new Dictionary<string, object>
        {
            {HostedPaymentConstants.format, HostedPaymentConstants.enumFormat},
            {HostedPaymentConstants.rel, HostedPaymentConstants.enumRelCallback},
            {HostedPaymentConstants.retries, INT_TYPE},
            {HostedPaymentConstants.returnKeys, typeof(List<string>)},
            {HostedPaymentConstants.synchronous, BOOL_TYPE},
            {HostedPaymentConstants.uri, STRING_TYPE},
            {HostedPaymentConstants.delimiter, STRING_TYPE}
        };

        /// <summary>
        /// Get the format
        /// </summary>
        /// <returns>string</returns>
        public string format()
        {
            return this.getProperty(HostedPaymentConstants.format);
        }

        /// <summary>
        /// Set the format
        /// </summary>
        /// <returns>void</returns>
        public void format(string data)
        {
            this.setProperty(HostedPaymentConstants.format, data);
        }

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
        /// Get the retries
        /// </summary>
        /// <returns>int</returns>
        public int retries()
        {
            return this.getProperty(HostedPaymentConstants.retries);
        }

        /// <summary>
        /// Set the retries
        /// </summary>
        /// <returns>void</returns>
        public void retries(int data)
        {
            this.setProperty(HostedPaymentConstants.retries, data);
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
        /// Get the synchronous
        /// </summary>
        /// <returns>bool</returns>
        public bool synchronous()
        {
            return this.getProperty(HostedPaymentConstants.synchronous);
        }

        /// <summary>
        /// Set the synchronous
        /// </summary>
        /// <returns>void</returns>
        public void synchronous(bool data)
        {
            this.setProperty(HostedPaymentConstants.synchronous, data);
        }

        /// <summary>
        /// Get the uri
        /// </summary>
        /// <returns>String</returns>
        public String uri()
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
        /// CallbackBuilder<typeparam name="TBLDR"></typeparam> will allow a Callback to be initialized
        /// within another builder. Set properties and subpropeties, then trigger .Done() to 
        /// get back to the parent builder
        /// </summary>
        public class CallbackBuilder<TBLDR> : NestedJSONBuilder<Callback, TBLDR>
            where TBLDR : GenericJSONBuilder
        {
            /// <summary>
            /// Initialize the Callback builder within the context of a parent builder
            /// </summary>
            /// <param name="parent">TBLDR</param>
            public CallbackBuilder(TBLDR parent)
                : base(parent)
            {
                this.parent = parent;
            }

            /// <summary>
            /// Set the format
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>CallbackBuilder<TBLDR></returns>
            public CallbackBuilder<TBLDR> format(string data)
            {
                this.properties[HostedPaymentConstants.format] = data;
                return this;
            }

            /// <summary>
            /// Set the rel
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>CallbackBuilder<TBLDR></returns>
            public CallbackBuilder<TBLDR> rel(string data)
            {
                this.properties[HostedPaymentConstants.rel] = data;
                return this;
            }

            /// <summary>
            /// Set the retries
            /// </summary>
            /// <param name=data>int</param>
            /// <returns>CallbackBuilder<TBLDR></returns>
            public CallbackBuilder<TBLDR> retries(int data)
            {
                this.properties[HostedPaymentConstants.retries] = data;
                return this;
            }

            /// <summary>
            /// Set the returnKeys
            /// </summary>
            /// <param name=data>List<string></param>
            /// <returns>CallbackBuilder<TBLDR></returns>
            public CallbackBuilder<TBLDR> returnKeys(List<string> data)
            {
                this.properties[HostedPaymentConstants.returnKeys] = data;
                return this;
            }

            /// <summary>
            /// Set the synchronous
            /// </summary>
            /// <param name=data>bool</param>
            /// <returns>CallbackBuilder<TBLDR></returns>
            public CallbackBuilder<TBLDR> synchronous(bool data)
            {
                this.properties[HostedPaymentConstants.synchronous] = data;
                return this;
            }

            /// <summary>
            /// Set the uri
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>CallbackBuilder<TBLDR></returns>
            public CallbackBuilder<TBLDR> uri(string data)
            {
                this.properties[HostedPaymentConstants.uri] = data;
                return this;
            }

            /// <summary>
            /// Set the delimiter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>CallbackBuilder<TBLDR></returns>
            public CallbackBuilder<TBLDR> delimiter(string data)
            {
                this.properties[HostedPaymentConstants.delimiter] = data;
                return this;
            }
        }
    }
}
