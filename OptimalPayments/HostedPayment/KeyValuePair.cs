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
    public class KeyValuePair : OptimalPayments.Common.JSONObject
    {
        /// <summary>
        /// Initialize the KeyValuePair object with some set of properties
        /// </summary>
        /// <param name="properties">Dictionary<string, object></param>
        public KeyValuePair(Dictionary<string, object> properties = null)
            : base(fieldTypes, properties)
        {
        }

        private static new Dictionary<string, object> fieldTypes = new Dictionary<string, object>
        {
            {HostedPaymentConstants.key, STRING_TYPE},
            {HostedPaymentConstants.value, STRING_TYPE}
        };


        /// <summary>
        /// Get the key
        /// </summary>
        /// <returns>string</returns>
        public string key()
        {
            return this.getProperty(HostedPaymentConstants.key);
        }

        /// <summary>
        /// Set the key
        /// </summary>
        /// <returns>void</returns>
        public void key(string data)
        {
            this.setProperty(HostedPaymentConstants.key, data);
        }

        /// <summary>
        /// Get the value
        /// </summary>
        /// <returns>string</returns>
        public string value()
        {
            return this.getProperty(HostedPaymentConstants.value);
        }

        /// <summary>
        /// Set the value
        /// </summary>
        /// <returns>void</returns>
        public void value(string data)
        {
            this.setProperty(HostedPaymentConstants.value, data);
        }

        /// <summary>
        /// KeyValuePairBuilder<typeparam name="TBLDR"></typeparam> will allow a KeyValuePair to be initialized
        /// within another builder. Set properties and subpropeties, then trigger .Done() to 
        /// get back to the parent builder
        /// </summary>
        public class KeyValuePairBuilder<TBLDR> : NestedJSONBuilder<KeyValuePair, TBLDR>
            where TBLDR : GenericJSONBuilder
        {
            /// <summary>
            /// Initialize the KeyValuePair builder within the context of a parent builder
            /// </summary>
            /// <param name="parent">TBLDR</param>
            public KeyValuePairBuilder(TBLDR parent)
                : base(parent)
            {
                this.parent = parent;
            }

            /// <summary>
            /// Set the key
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>KeyValuePairBuilder<TBLDR></returns>
            public KeyValuePairBuilder<TBLDR> key(string data)
            {
                this.properties[HostedPaymentConstants.key] = data;
                return this;
            }

            /// <summary>
            /// Set the value
            /// </summary>data.value>string</param>
            /// <returns>KeyValuePairBuilder<TBLDR></returns>
            public KeyValuePairBuilder<TBLDR> value(string data)
            {
                this.properties[HostedPaymentConstants.value] = data;
                return this;
            }

            /// <summary>
            /// Set the value
            /// </summary>
            /// <param name=data>int</param>
            /// <returns>KeyValuePairBuilder<TBLDR></returns>
            public KeyValuePairBuilder<TBLDR> value(int data)
            {
                this.properties[HostedPaymentConstants.value] = data.ToString(System.Threading.Thread.CurrentThread.CurrentCulture);
                return this;
            }

            /// <summary>
            /// Set the value
            /// </summary>
            /// <param name=data>bool</param>
            /// <returns>KeyValuePairBuilder<TBLDR></returns>
            public KeyValuePairBuilder<TBLDR> value(bool data)
            {
                this.properties[HostedPaymentConstants.value] = data.ToString().ToLower();
                return this;
            }
        }
    }
}
