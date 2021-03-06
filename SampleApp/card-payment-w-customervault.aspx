﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="card-payment-w-customervault.aspx.cs" Inherits="SampleApp.card_payment_w_customervault" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Optimal SDK - CardPayment With Customer Vault</title>
</head>
<body>
    <% if (payment_id != null)
       { %>
    <h1>Payment Successful! ID: <% Response.Write(payment_id); %></h1>
    <% }
       else
       { %>
    <form runat="server">
        <fieldset>
            <legend>Billing Details</legend>
            <div>
                <label>
                    Merchant Customer Id: 
						<input type="text" name="merchant_customer_id" value="<%
                            if (Request.Form["merchant_customer_id"] == null)
                            {
                                Response.Write(System.Guid.NewGuid().ToString());
                            }
                            else
                            {
                                Response.Write(Request.Form["merchant_customer_id"]);
                            }
						%>" />
                </label>
            </div>
            <div>
                <label>
                    First Name: 
						<input type="text" name="first_name" value="<% Response.Write(Request.Form["first_name"]); %>" />
                </label>
            </div>
            <div>
                <label>
                    Last Name: 
						<input type="text" name="last_name" value="<% Response.Write(Request.Form["last_name"]); %>" />
                </label>
            </div>
            <div>
                <label>
                    Email: 
						<input type="text" name="email" value="<%
                            if (Request.Form["email"] == null)
                            {
                                Response.Write("test@test.com");
                            }
                            else
                            {
                                Response.Write(Request.Form["email"]);
                            }
						%>" />
                </label>
            </div>
            <div>
                <label>
                    Street: 
						<input type="text" name="street" value="<% Response.Write(Request.Form["street"]); %>" />
                </label>
            </div>
            <div>
                <label>
                    City: 
						<input type="text" name="city" value="<% Response.Write(Request.Form["city"]); %>" />
                </label>
            </div>
            <div>
                <label>
                    State/Province: 
						<input type="text" name="state" value="<%
                            if (Request.Form["state"] == null)
                            {
                                Response.Write("ON");
                            }
                            else
                            {
                                Response.Write(Request.Form["state"]);
                            }
						%>" />
                </label>
            </div>
            <div>
                <label>
                    Country: 
						<select name="country">
                            <option value="CA" <%
                                if (Request.Form["country"] == null
                                    || Request.Form["country"].Equals("CA"))
                                {
                                    Response.Write(" selected");
                                }
							%>>Canada</option>
                            <option value="US" <%
                                if (Request.Form["country"] != null
                                    && Request.Form["country"].Equals("US"))
                                {
                                    Response.Write(" selected");
                                }
							%>>USA</option>
                        </select>
                </label>
            </div>
            <div>
                <label>
                    Zip/Postal Code: 
						<input type="text" name="zip" value="<%
                            if (Request.Form["zip"] == null)
                            {
                                Response.Write("M5H 2N2");
                            }
                            else
                            {
                                Response.Write(Request.Form["zip"]);
                            }
						%>" />
                </label>
            </div>
        </fieldset>
        <fieldset>
            <legend>Order Details</legend>
            <div>
                <label>
                    Merchant Ref Num: 
						<input type="text" name="merchant_ref_num" value="<%
                            if (Request.Form["merchant_ref_num"] == null)
                            {
                                Response.Write(System.Guid.NewGuid().ToString());
                            }
                            else
                            {
                                Response.Write(Request.Form["merchant_ref_num"]);
                            }
						%>" />
                </label>
            </div>
            <div>
                <label>
                    Amount: 
						<input type="text" name="amount" value="<%
                            if (Request.Form["amount"] == null)
                            {
                                Response.Write("100.00");
                            }
                            else
                            {
                                Response.Write(Request.Form["amount"]);
                            }
						%>" />
                </label>
            </div>
            <div>
                <label>
                    Card Number: 
						<input type="text" autocomplete="off" name="card_number" value="<%
                            if (Request.Form["card_number"] == null)
                            {
                                Response.Write("4444333322221111");
                            }
                            else
                            {
                                Response.Write(Request.Form["card_number"]);
                            }
						%>" />
                </label>
            </div>
            <div>
                <label>
                    Card Expiry: 
                    <asp:DropDownList ID="card_expiry_month" runat="server" />
                </label>
            </div>
            <div>
                <label>
                    Card Expiry: 
                    <asp:DropDownList ID="card_expiry_year" runat="server" />
                </label>
            </div>
        </fieldset>
        <asp:Button ID="btnSubmit" Text="Submit" runat="server" />
    </form>
    <% } %>
</body>
</html>
