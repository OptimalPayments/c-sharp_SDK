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

namespace OptimalPayments.HostedPayment
{
    public class Card : OptimalPayments.Common.JSONObject
    {
        /// <summary>
        /// Initialize the Card object with some set of properties
        /// </summary>
        /// <param name="properties">Dictionary<string, object></param>
        public Card(Dictionary<string, object> properties = null)
            : base(fieldTypes, properties)
        {
        }

        private static new Dictionary<string, object> fieldTypes = new Dictionary<string, object>
        {
            {HostedPaymentConstants.brand, STRING_TYPE},
            {HostedPaymentConstants.country, STRING_TYPE},
            {HostedPaymentConstants.expiry, STRING_TYPE},
            {HostedPaymentConstants.lastDigits, STRING_TYPE},
            {HostedPaymentConstants.threeDEnrolment, STRING_TYPE},
            {HostedPaymentConstants.type, STRING_TYPE}
        };

        /// <summary>
        /// Get the brand
        /// </summary>
        /// <returns>string</returns>
        public string brand()
        {
            return this.getProperty(HostedPaymentConstants.brand);
        }

        /// <summary>
        /// Set the brand
        /// </summary>
        /// <returns>void</returns>
        public void brand(string data)
        {
            this.setProperty(HostedPaymentConstants.brand, data);
        }

        /// <summary>
        /// Get the country
        /// </summary>
        /// <returns>string</returns>
        public string country()
        {
            return this.getProperty(HostedPaymentConstants.country);
        }

        /// <summary>
        /// Set the country
        /// </summary>
        /// <returns>void</returns>
        public void country(string data)
        {
            this.setProperty(HostedPaymentConstants.country, data);
        }

        /// <summary>
        /// Get the expiry
        /// </summary>
        /// <returns>string</returns>
        public string expiry()
        {
            return this.getProperty(HostedPaymentConstants.expiry);
        }

        /// <summary>
        /// Set the expiry
        /// </summary>
        /// <returns>void</returns>
        public void expiry(string data)
        {
            this.setProperty(HostedPaymentConstants.expiry, data);
        }

        /// <summary>
        /// Get the lastDigits
        /// </summary>
        /// <returns>string</returns>
        public string lastDigits()
        {
            return this.getProperty(HostedPaymentConstants.lastDigits);
        }

        /// <summary>
        /// Set the lastDigits
        /// </summary>
        /// <returns>void</returns>
        public void lastDigits(string data)
        {
            this.setProperty(HostedPaymentConstants.lastDigits, data);
        }

        /// <summary>
        /// Get the threeDEnrolment
        /// </summary>
        /// <returns>string</returns>
        public string threeDEnrolment()
        {
            return this.getProperty(HostedPaymentConstants.threeDEnrolment);
        }

        /// <summary>
        /// Set the threeDEnrolment
        /// </summary>
        /// <returns>void</returns>
        public void threeDEnrolment(string data)
        {
            this.setProperty(HostedPaymentConstants.threeDEnrolment, data);
        }

        /// <summary>
        /// Get the type
        /// </summary>
        /// <returns>string</returns>
        public string type()
        {
            return this.getProperty(HostedPaymentConstants.type);
        }

        /// <summary>
        /// Set the type
        /// </summary>
        /// <returns>void</returns>
        public void type(string data)
        {
            this.setProperty(HostedPaymentConstants.type, data);
        }
    }
}
