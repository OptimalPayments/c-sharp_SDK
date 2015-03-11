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
    public class ShoppingCartItem : OptimalPayments.Common.JSONObject
    {
        /// <summary>
        /// Initialize the CartItem object with some set of properties
        /// </summary>
        /// <param name="properties">Dictionary<string, object></param>
        public ShoppingCartItem(Dictionary<string, object> properties = null)
            : base(fieldTypes, properties)
        {
        }

        private static new Dictionary<string, object> fieldTypes = new Dictionary<string, object>
        {
            {HostedPaymentConstants.amount, INT_TYPE},
            {HostedPaymentConstants.description, STRING_TYPE},
            {HostedPaymentConstants.sku, STRING_TYPE},
            {HostedPaymentConstants.quantity, INT_TYPE}
        };

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
        /// Get the description
        /// </summary>
        /// <returns>string</returns>
        public string description()
        {
            return this.getProperty(HostedPaymentConstants.description);
        }

        /// <summary>
        /// Set the description
        /// </summary>
        /// <returns>void</returns>
        public void description(string data)
        {
            this.setProperty(HostedPaymentConstants.description, data);
        }

        /// <summary>
        /// Get the sku
        /// </summary>
        /// <returns>string</returns>
        public string sku()
        {
            return this.getProperty(HostedPaymentConstants.sku);
        }

        /// <summary>
        /// Set the sku
        /// </summary>
        /// <returns>void</returns>
        public void sku(string data)
        {
            this.setProperty(HostedPaymentConstants.sku, data);
        }

        /// <summary>
        /// Get the quantity
        /// </summary>
        /// <returns>int</returns>
        public int quantity()
        {
            return this.getProperty(HostedPaymentConstants.quantity);
        }

        /// <summary>
        /// Set the quantity
        /// </summary>
        /// <returns>void</returns>
        public void quantity(int data)
        {
            this.setProperty(HostedPaymentConstants.quantity, data);
        }

         /// <summary>
        /// CartItemBuilder<typeparam name="TBLDR"></typeparam> will allow a CartItem to be initialized
        /// within another builder. Set properties and subpropeties, then trigger .Done() to 
        /// get back to the parent builder
        /// </summary>
        public class ShoppingCartItemBuilder<TBLDR> : NestedJSONBuilder<ShoppingCartItem, TBLDR>
            where TBLDR : GenericJSONBuilder
        {
            /// <summary>
            /// Initialize the CartItem builder within the context of a parent builder
            /// </summary>
            /// <param name="parent">TBLDR</param>
            public ShoppingCartItemBuilder(TBLDR parent)
                : base(parent)
            {
                this.parent = parent;
            }

            /// <summary>
            /// Set the amount
            /// </summary>
            /// <param name=data>int</param>
            /// <returns>CartItemBuilder<TBLDR></returns>
            public ShoppingCartItemBuilder<TBLDR> amount(int data)
            {
                this.properties[HostedPaymentConstants.amount] = data;
                return this;
            }

            /// <summary>
            /// Set the description
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>CartItemBuilder<TBLDR></returns>
            public ShoppingCartItemBuilder<TBLDR> description(string data)
            {
                this.properties[HostedPaymentConstants.description] = data;
                return this;
            }

            /// <summary>
            /// Set the sku
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>CartItemBuilder<TBLDR></returns>
            public ShoppingCartItemBuilder<TBLDR> sku(string data)
            {
                this.properties[HostedPaymentConstants.sku] = data;
                return this;
            }

            /// <summary>
            /// Set the quantity
            /// </summary>
            /// <param name=data>int</param>
            /// <returns>CartItemBuilder<TBLDR></returns>
            public ShoppingCartItemBuilder<TBLDR> quantity(int data)
            {
                this.properties[HostedPaymentConstants.quantity] = data;
                return this;
            }
        }
    }
}
