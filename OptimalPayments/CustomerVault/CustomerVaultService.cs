﻿/*
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

using OptimalPayments.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OptimalPayments.CustomerVault
{
    public class CustomerVaultService
    {

        /// <summary>
        /// The api client, performs all http requests
        /// </summary>
        private OptimalApiClient client;

        /// <summary>
        /// The card payments api base uri 
        /// </summary>
        private string uri = "customervault/v1";

        /// <summary>
        /// Initialize the card payments service with an client object
        /// </summary>
        /// <param name="client">OptimalApiClient</param>
        public CustomerVaultService(OptimalApiClient client)
        {
            this.client = client;
        }

        /// <summary>
        /// Check if the service is available
        /// </summary>
        /// <returns>true if successful</returns>
        public Boolean monitor()
        {
            Request request = new Request(uri: "customervault/monitor");
            dynamic response = this.client.processRequest(request);

            return ("READY".Equals((string)(response[CustomerVaultConstants.status])));
        }

        /// <summary>
        /// Create profile
        /// </summary>
        /// <param name="profile">Profile</param>
        /// <returns>Profile</returns>
        public Profile create(Profile profile)
        {
            profile.setRequiredFields(new List<string> {
                CustomerVaultConstants.merchantCustomerId,
                CustomerVaultConstants.locale
            });
            profile.setOptionalFields(new List<string> {
                CustomerVaultConstants.firstName,
                CustomerVaultConstants.middleName,
                CustomerVaultConstants.lastName,
                CustomerVaultConstants.dateOfBirth,
                CustomerVaultConstants.ip,
                CustomerVaultConstants.gender,
                CustomerVaultConstants.nationality,
                CustomerVaultConstants.email,
                CustomerVaultConstants.phone,
                CustomerVaultConstants.cellPhone,
                CustomerVaultConstants.card
            });

            Request request = new Request(
                method: RequestType.POST,
                uri: this.prepareURI("/profiles"),
                body: profile
            );
            dynamic response = this.client.processRequest(request);

            return new Profile(response);
        }

        /// <summary>
        /// create address 
        /// </summary>
        /// <param name="address">Address</param>
        /// <returns>Address</returns>
        public Address create(Address address)
        {
            address.setRequiredFields(new List<string> { CustomerVaultConstants.profileId });
            address.checkRequiredFields();
            address.setRequiredFields(new List<string> { CustomerVaultConstants.country });
            address.setOptionalFields(new List<string> {
                CustomerVaultConstants.nickName,
                CustomerVaultConstants.street,
                CustomerVaultConstants.street2,
                CustomerVaultConstants.city,
                CustomerVaultConstants.state,
                CustomerVaultConstants.zip,
                CustomerVaultConstants.recipientName,
                CustomerVaultConstants.phone
            });

            Request request = new Request(
                method: RequestType.POST,
                uri: this.prepareURI("/profiles/" + address.profileId() + "/addresses"),
                body: address
            );

            dynamic response = this.client.processRequest(request);

            Address returnVal = new Address(response);
            returnVal.profileId(address.profileId());
            return returnVal;
        }

        /// <summary>
        /// Create card 
        /// </summary>
        /// <param name="card">Card</param>
        /// <returns>Card</returns>
        public Card create(Card card)
        {
            card.setRequiredFields(new List<string> { CustomerVaultConstants.profileId });
            card.checkRequiredFields();
            card.setRequiredFields(new List<string> {
                CustomerVaultConstants.cardNum,
                CustomerVaultConstants.cardExpiry
            });
            card.setOptionalFields(new List<string> {
                CustomerVaultConstants.nickName,
                CustomerVaultConstants.merchantRefNum,
                CustomerVaultConstants.holderName,
                CustomerVaultConstants.billingAddressId
            });

            Request request = new Request(
                method: RequestType.POST,
                uri: this.prepareURI("/profiles/" + card.profileId() + "/cards"),
                body: card
            );

            dynamic response = this.client.processRequest(request);

            Card returnVal = new Card(response);
            returnVal.profileId(card.profileId());
            return returnVal;
        }

        /// <summary>
        /// update Profile  
        /// </summary>
        /// <param name="profile">Profile</param>
        /// <returns>Profile</returns>
        public Profile update(Profile profile)
        {
            profile.setRequiredFields(new List<string> { CustomerVaultConstants.id });
            profile.checkRequiredFields();
            profile.setRequiredFields(new List<string> {
                CustomerVaultConstants.merchantCustomerId,
                CustomerVaultConstants.locale
            });
            profile.setOptionalFields(new List<string> {
                CustomerVaultConstants.firstName,
                CustomerVaultConstants.middleName,
                CustomerVaultConstants.lastName,
                CustomerVaultConstants.dateOfBirth,
                CustomerVaultConstants.ip,
                CustomerVaultConstants.gender,
                CustomerVaultConstants.nationality,
                CustomerVaultConstants.email,
                CustomerVaultConstants.phone,
                CustomerVaultConstants.cellPhone
            });

            Request request = new Request(
                method: RequestType.PUT,
                uri: this.prepareURI("/profiles/" + profile.id()),
                body: profile
            );

            dynamic response = this.client.processRequest(request);

            return new Profile(response);
        }

        /// <summary>
        /// Update address 
        /// </summary>
        /// <param name="address">Address</param>
        /// <returns>Address</returns>
        public Address update(Address address)
        {
            address.setRequiredFields(new List<string> {
                CustomerVaultConstants.profileId,
                CustomerVaultConstants.id
            });
            address.checkRequiredFields();
            address.setRequiredFields(new List<string> { CustomerVaultConstants.country });
            address.setOptionalFields(new List<string> {
                CustomerVaultConstants.nickName,
                CustomerVaultConstants.street,
                CustomerVaultConstants.street2,
                CustomerVaultConstants.city,
                CustomerVaultConstants.state,
                CustomerVaultConstants.zip,
                CustomerVaultConstants.recipientName,
                CustomerVaultConstants.phone
            });

            Request request = new Request(
                method: RequestType.PUT,
                uri: this.prepareURI("/profiles/" + address.profileId() + "/addresses/" + address.id()),
                body: address
            );

            dynamic response = this.client.processRequest(request);

            Address returnVal = new Address(response);
            returnVal.profileId(address.profileId());
            return returnVal;
        }

        /// <summary>
        /// Update card 
        /// </summary>
        /// <param name="card">Card</param>
        /// <returns>Card</returns>
        public Card update(Card card)
        {
            card.setRequiredFields(new List<string> {
                CustomerVaultConstants.profileId,
                CustomerVaultConstants.id
            });
            card.checkRequiredFields();
            card.setRequiredFields(new List<string> { });
            card.setOptionalFields(new List<string> {
                CustomerVaultConstants.cardExpiry,
                CustomerVaultConstants.nickName,
                CustomerVaultConstants.merchantRefNum,
                CustomerVaultConstants.holderName,
                CustomerVaultConstants.billingAddressId
            });

            Request request = new Request(
                method: RequestType.PUT,
                uri: this.prepareURI("/profiles/" + card.profileId() + "/cards/" + card.id()),
                body: card
            );

            dynamic response = this.client.processRequest(request);

            Card returnVal = new Card(response);
            returnVal.profileId(card.profileId());
            return returnVal;
        }

        /// <summary>
        /// delete profile
        /// </summary>
        /// <param name="profile">Profile</param>
        /// <returns>bool</returns>
        public bool delete(Profile profile)
        {
            profile.setRequiredFields(new List<string> { CustomerVaultConstants.id });
            profile.checkRequiredFields();

            Request request = new Request(
                method: RequestType.DELETE,
                uri: this.prepareURI("/profiles/" + profile.id())
            );

            this.client.processRequest(request);

            return true;
        }

        /// <summary>
        ///Delete address 
        /// </summary>
        /// <param name="address">Address</param>
        /// <returns>bool</returns>
        public bool delete(Address address)
        {
            address.setRequiredFields(new List<string> {
                CustomerVaultConstants.profileId,
                CustomerVaultConstants.id
            });
            address.checkRequiredFields();

            Request request = new Request(
                method: RequestType.DELETE,
                uri: this.prepareURI("/profiles/" + address.profileId() + "/addresses/" + address.id())
            );

            this.client.processRequest(request);
            return true;
        }

        /// <summary>
        /// Delete card 
        /// </summary>
        /// <param name="card">Card</param>
        /// <returns>bool</returns>
        public bool delete(Card card)
        {
            card.setRequiredFields(new List<string> {
                CustomerVaultConstants.profileId,
                CustomerVaultConstants.id
            });
            card.checkRequiredFields();

            Request request = new Request(
                method: RequestType.DELETE,
                uri: this.prepareURI("/profiles/" + card.profileId() + "/cards/" + card.id()),
                body: card
            );

            this.client.processRequest(request);

            return true;
        }

        /// <summary>
        /// get profile
        /// </summary>
        /// <param name="profile">Profile</param>
        /// <returns>Profile</returns>
        public Profile get(Profile profile, bool includeAddresses = false, bool includeCards = false)
        {
            profile.setRequiredFields(new List<string> { CustomerVaultConstants.id });
            profile.checkRequiredFields();

            Dictionary<String, String> queryStr = new Dictionary<String, String>();
            var toInclude = new StringBuilder();

            if (includeAddresses)
            {
                //queryStr.Add(CustomerVaultConstants.addresses);
                toInclude.Append(CustomerVaultConstants.addresses);
            }
            if (includeAddresses && includeCards)
            {
                //queryStr.Add(",");
                toInclude.Append(",");
            }
            if (includeCards)
            {
                //queryStr.Add(CustomerVaultConstants.cards);
                toInclude.Append(CustomerVaultConstants.cards);
            }

            if (toInclude.Length > 0)
                queryStr.Add(CustomerVaultConstants.fields, toInclude.ToString());

            Request request = new Request(
                method: RequestType.GET,
                uri: this.prepareURI("/profiles/" + profile.id()),
                queryString: queryStr
            //    queryStr: queryStr
            );

            dynamic response = this.client.processRequest(request);

            return new Profile(response);
        }

        /// <summary>
        /// Get address 
        /// </summary>
        /// <param name="address">Address</param>
        /// <returns>Address</returns>
        public Address get(Address address)
        {
            address.setRequiredFields(new List<string> {
                CustomerVaultConstants.profileId,
                CustomerVaultConstants.id
            });
            address.checkRequiredFields();

            Request request = new Request(
                method: RequestType.GET,
                uri: this.prepareURI("/profiles/" + address.profileId() + "/addresses/" + address.id()),
                body: address
            );

            dynamic response = this.client.processRequest(request);

            Address returnVal = new Address(response);
            returnVal.profileId(address.profileId());
            return returnVal;
        }

        /// <summary>
        /// Get card 
        /// </summary>
        /// <param name="card">Card</param>
        /// <returns>Card</returns>
        public Card get(Card card)
        {
            card.setRequiredFields(new List<string> {
                CustomerVaultConstants.profileId,
                CustomerVaultConstants.id
            });
            card.checkRequiredFields();

            Request request = new Request(
                method: RequestType.GET,
                uri: this.prepareURI("/profiles/" + card.profileId() + "/cards/" + card.id())
            );

            dynamic response = this.client.processRequest(request);

            Card returnVal = new Card(response);
            returnVal.profileId(card.profileId());
            return returnVal;
        }


        private string prepareURI(string path)
        {
            return this.uri + path;
        }
    }
}
