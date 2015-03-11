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
    public class Transaction : OptimalPayments.Common.JSONObject
    {
        /// <summary>
        /// Initialize the Transaction object with some set of properties
        /// </summary>
        /// <param name="properties">Dictionary<string, object></param>
        public Transaction(Dictionary<string, object> properties = null)
            : base(fieldTypes, properties)
        {
        }

        private static new Dictionary<string, object> fieldTypes = new Dictionary<string, object>
        {
            {HostedPaymentConstants.status, STRING_TYPE},
            {HostedPaymentConstants.lastUpdate, typeof(System.DateTime)},
            {HostedPaymentConstants.authType, HostedPaymentConstants.enumAuthType},
            {HostedPaymentConstants.authCode, STRING_TYPE},
            {HostedPaymentConstants.merchantRefNum, STRING_TYPE},
            {HostedPaymentConstants.associatedTransactions, typeof(List<Transaction>)},
            {HostedPaymentConstants.card, typeof(Card)},
            {HostedPaymentConstants.confirmationNumber, STRING_TYPE},
            {HostedPaymentConstants.currencyCode, STRING_TYPE},
            {HostedPaymentConstants.amount, INT_TYPE},
            {HostedPaymentConstants.paymentType, STRING_TYPE},
            {HostedPaymentConstants.settled, BOOL_TYPE},
            {HostedPaymentConstants.refunded, BOOL_TYPE},
            {HostedPaymentConstants.reversed, BOOL_TYPE},
            {HostedPaymentConstants.dateTime, typeof(System.DateTime)},
            {HostedPaymentConstants.reference, STRING_TYPE},
            {HostedPaymentConstants.cvdVerification, STRING_TYPE},
            {HostedPaymentConstants.houseNumberVerification, STRING_TYPE},
            {HostedPaymentConstants.zipVerification, STRING_TYPE},
            {HostedPaymentConstants.riskReasonCode, typeof(List<int>)},
            {HostedPaymentConstants.errorCode, INT_TYPE},
            {HostedPaymentConstants.errorMessage, STRING_TYPE}
        };

        /// <summary>
        /// Get the status
        /// </summary>
        /// <returns>string</returns>
        public string status()
        {
            return this.getProperty(HostedPaymentConstants.status);
        }

        /// <summary>
        /// Set the status
        /// </summary>
        /// <returns>void</returns>
        public void status(string data)
        {
            this.setProperty(HostedPaymentConstants.status, data);
        }

        /// <summary>
        /// Get the lastUpdate
        /// </summary>
        /// <returns>string</returns>
        public string lastUpdate()
        {
            return this.getProperty(HostedPaymentConstants.lastUpdate);
        }

        /// <summary>
        /// Set the lastUpdate
        /// </summary>
        /// <returns>void</returns>
        public void lastUpdate(string data)
        {
            this.setProperty(HostedPaymentConstants.lastUpdate, data);
        }

        /// <summary>
        /// Get the authType
        /// </summary>
        /// <returns>List</returns>
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
        /// Get the authCode
        /// </summary>
        /// <returns>string</returns>
        public string authCode()
        {
            return this.getProperty(HostedPaymentConstants.authCode);
        }

        /// <summary>
        /// Set the authCode
        /// </summary>
        /// <returns>void</returns>
        public void authCode(string data)
        {
            this.setProperty(HostedPaymentConstants.authCode, data);
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
        /// Get the associatedTransactions
        /// </summary>
        /// <returns>OptimalPayments.HostedPayment.Transaction</returns>
        public OptimalPayments.HostedPayment.Transaction associatedTransactions()
        {
            return this.getProperty(HostedPaymentConstants.associatedTransactions);
        }

        /// <summary>
        /// Set the associatedTransactions
        /// </summary>
        /// <returns>void</returns>
        public void associatedTransactions(OptimalPayments.HostedPayment.Transaction data)
        {
            this.setProperty(HostedPaymentConstants.associatedTransactions, data);
        }


        /// <summary>
        /// Get the card
        /// </summary>
        /// <returns>Card</returns>
        public Card card()
        {
            return this.getProperty(HostedPaymentConstants.card);
        }

        /// <summary>
        /// Set the card
        /// </summary>
        /// <returns>void</returns>
        public void card(Card data)
        {
            this.setProperty(HostedPaymentConstants.card, data);
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
        /// Get the paymentType
        /// </summary>
        /// <returns>string</returns>
        public string paymentType()
        {
            return this.getProperty(HostedPaymentConstants.paymentType);
        }

        /// <summary>
        /// Set the paymentType
        /// </summary>
        /// <returns>void</returns>
        public void paymentType(string data)
        {
            this.setProperty(HostedPaymentConstants.paymentType, data);
        }

        /// <summary>
        /// Get the settled
        /// </summary>
        /// <returns>bool</returns>
        public bool settled()
        {
            return this.getProperty(HostedPaymentConstants.settled);
        }

        /// <summary>
        /// Set the settled
        /// </summary>
        /// <returns>void</returns>
        public void settled(bool data)
        {
            this.setProperty(HostedPaymentConstants.settled, data);
        }

        /// <summary>
        /// Get the refunded
        /// </summary>
        /// <returns>bool</returns>
        public bool refunded()
        {
            return this.getProperty(HostedPaymentConstants.refunded);
        }

        /// <summary>
        /// Set the refunded
        /// </summary>
        /// <returns>void</returns>
        public void refunded(bool data)
        {
            this.setProperty(HostedPaymentConstants.refunded, data);
        }

        /// <summary>
        /// Get the reversed
        /// </summary>
        /// <returns>bool</returns>
        public bool reversed()
        {
            return this.getProperty(HostedPaymentConstants.reversed);
        }

        /// <summary>
        /// Set the reversed
        /// </summary>
        /// <returns>void</returns>
        public void reversed(bool data)
        {
            this.setProperty(HostedPaymentConstants.reversed, data);
        }

        /// <summary>
        /// Get the dateTime
        /// </summary>
        /// <returns>string</returns>
        public System.DateTime dateTime()
        {
            return this.getProperty(HostedPaymentConstants.dateTime);
        }

        /// <summary>
        /// Set the dateTime
        /// </summary>
        /// <returns>void</returns>
        public void dateTime(System.DateTime data)
        {
            this.setProperty(HostedPaymentConstants.dateTime, data);
        }

        /// <summary>
        /// Get the reference
        /// </summary>
        /// <returns>string</returns>
        public string reference()
        {
            return this.getProperty(HostedPaymentConstants.reference);
        }

        /// <summary>
        /// Set the reference
        /// </summary>
        /// <returns>void</returns>
        public void reference(string data)
        {
            this.setProperty(HostedPaymentConstants.reference, data);
        }

        /// <summary>
        /// Get the cvdVerification
        /// </summary>
        /// <returns>string</returns>
        public string cvdVerification()
        {
            return this.getProperty(HostedPaymentConstants.cvdVerification);
        }

        /// <summary>
        /// Set the cvdVerification
        /// </summary>
        /// <returns>void</returns>
        public void cvdVerification(string data)
        {
            this.setProperty(HostedPaymentConstants.cvdVerification, data);
        }

        /// <summary>
        /// Get the houseNumberVerification
        /// </summary>
        /// <returns>string</returns>
        public string houseNumberVerification()
        {
            return this.getProperty(HostedPaymentConstants.houseNumberVerification);
        }

        /// <summary>
        /// Set the houseNumberVerification
        /// </summary>
        /// <returns>void</returns>
        public void houseNumberVerification(string data)
        {
            this.setProperty(HostedPaymentConstants.houseNumberVerification, data);
        }

        /// <summary>
        /// Get the zipVerification
        /// </summary>
        /// <returns>string</returns>
        public string zipVerification()
        {
            return this.getProperty(HostedPaymentConstants.zipVerification);
        }

        /// <summary>
        /// Set the zipVerification
        /// </summary>
        /// <returns>void</returns>
        public void zipVerification(string data)
        {
            this.setProperty(HostedPaymentConstants.zipVerification, data);
        }

        /// <summary>
        /// Get the riskReasonCode
        /// </summary>
        /// <returns>List<int></returns>
        public List<int> riskReasonCode()
        {
            return this.getProperty(HostedPaymentConstants.riskReasonCode);
        }

        /// <summary>
        /// Set the riskReasonCode
        /// </summary>
        /// <returns>void</returns>
        public void riskReasonCode(List<int> data)
        {
            this.setProperty(HostedPaymentConstants.riskReasonCode, data);
        }

        /// <summary>
        /// Get the errorCode
        /// </summary>
        /// <returns>int</returns>
        public int errorCode()
        {
            return this.getProperty(HostedPaymentConstants.errorCode);
        }

        /// <summary>
        /// Set the errorCode
        /// </summary>
        /// <returns>void</returns>
        public void errorCode(int data)
        {
            this.setProperty(HostedPaymentConstants.errorCode, data);
        }

        /// <summary>
        /// Get the errorMessage
        /// </summary>
        /// <returns>string</returns>
        public string errorMessage()
        {
            return this.getProperty(HostedPaymentConstants.errorMessage);
        }

        /// <summary>
        /// Set the errorMessage
        /// </summary>
        /// <returns>void</returns>
        public void errorMessage(string data)
        {
            this.setProperty(HostedPaymentConstants.errorMessage, data);
        }

    }
}
