<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hosted-payment-simple.aspx.cs" Inherits="SampleApp.hosted_payment_simple" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
                    First Name: 
						<input type="text" name="first_name" value="<%
                            if (Request.Form["first_name"] == null)
                            {
                                Response.Write("First");
                            }
                            else
                            {
                                Response.Write(Request.Form["first_name"]);
                            }
						%>" />
                </label>
            </div>
            <div>
                <label>
                    Last Name: 
						<input type="text" name="last_name" value="<%
                            if (Request.Form["last_name"] == null)
                            {
                                Response.Write("Last");
                            }
                            else
                            {
                                Response.Write(Request.Form["last_name"]);
                            }
						%>" />
                </label>
            </div>
            <div>
                <label>
                    Street: 
						<input type="text" name="street" value="<%
                            if (Request.Form["street"] == null)
                            {
                                Response.Write("123 Fake St.");
                            }
                            else
                            {
                                Response.Write(Request.Form["street"]);
                            }
						%>" />
                </label>
            </div>
            <div>
                <label>
                    City: 
						<input type="text" name="city" value="<%
                            if (Request.Form["city"] == null)
                            {
                                Response.Write("Toronto");
                            }
                            else
                            {
                                Response.Write(Request.Form["city"]);
                            }
						%>" />
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
        </fieldset>
        <asp:Button ID="btnSubmit" Text="Submit" runat="server" />
    </form>
    <% } %>
</body>
</html>
