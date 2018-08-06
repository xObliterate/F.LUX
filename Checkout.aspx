<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Checkout.aspx.cs" Inherits="Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col s6">
                <asp:Panel ID="paymentPanel" runat="server" DefaultButton="btn_submit">

                    <div class="container1 white z-depth-2">
                        <ul class="tabs teal center">
                            <li class="tab col s6"><a class="white-text">Checkout</a></li>
                        </ul>
                        <div class="col s12">
                            <div class="form-container">
                                <h4>Debit / Credit</h4>
                                <div class="row">
                                    <div class="input-field col s12">
                                        <asp:TextBox ID="tb_CardNumber" runat="server" MaxLength="16"></asp:TextBox>
                                        <label for="tb_CardNumber">Card Number</label>
                                        <asp:RequiredFieldValidator ID="CardNumber_empty" EnableClientScript="false" Display="Dynamic" runat="server" ErrorMessage="You can't leave this empty." ForeColor="Red" ControlToValidate="tb_CardNumber"></asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="ccVlidator" runat="server" ControlToValidate="tb_CardNumber" ErrorMessage="Card Number is not valid" Display="Dynamic" ForeColor="Red" OnServerValidate="ccVlidator_ServerValidate"></asp:CustomValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="input-field col s12">
                                        <asp:TextBox ID="tb_ExpMonth" runat="server" MaxLength="7"></asp:TextBox>
                                        <label for="tb_ExpMonth">Expiry Date</label>
                                        <asp:RequiredFieldValidator ID="ExpMonth_empty" EnableClientScript="false" Display="Dynamic" runat="server" ErrorMessage="You can't leave this empty." ForeColor="Red" ControlToValidate="tb_ExpMonth"></asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="expiryValidator" runat="server" ControlToValidate="tb_ExpMonth" ErrorMessage="Expiry Date is not valid" Display="Dynamic" ForeColor="Red" OnServerValidate="expiryValidator_ServerValidate"></asp:CustomValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="input-field col s12">
                                        <asp:TextBox ID="tb_CardName" runat="server"></asp:TextBox>
                                        <label for="tb_CardName">Name On Card</label>
                                        <asp:RequiredFieldValidator ID="CardName_empty" EnableClientScript="false" Display="Dynamic" runat="server" ErrorMessage="You can't leave this empty." ForeColor="Red" ControlToValidate="tb_CardName"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="input-field col s12">
                                        <asp:TextBox ID="tb_Cvv" runat="server" MaxLength="3"></asp:TextBox>
                                        <label for="tb_Cvv">CVV</label>
                                        <asp:RequiredFieldValidator ID="Cvv_empty" EnableClientScript="false" Display="Dynamic" runat="server" ErrorMessage="You can't leave this empty." ForeColor="Red" ControlToValidate="tb_Cvv"></asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="cvvValidator" runat="server" ControlToValidate="tb_Cvv" ErrorMessage="CVV is not valid" Display="Dynamic" ForeColor="Red" OnServerValidate="cvvValidator_ServerValidate"></asp:CustomValidator>
                                    </div>
                                </div>
                                <div class="center">
                                    <asp:Button ID="btn_submit" CssClass="btn" runat="server" Text="Add" OnClick="btn_submit_Click"></asp:Button>
                                </div>

                                <asp:LinkButton ID="linkbtn_stripe" runat="server" PostBackUrl="~/Payment/Default.aspx" CausesValidation="False"><i class="fab fa-cc-stripe fa-3x"></i></asp:LinkButton>

                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>

            <div class="col s6">
                <div class="container1 white z-depth-2">
                    <ul class="tabs teal center">
                        <li class="tab col s6"><a class="white-text">Order Summary</a></li>
                    </ul>
                    <div class="form-container">
                        <h4>Shipping & Billing</h4>
                        <div class="row">
                            <div class="input-field col s12">
                                <asp:Label ID="lbl_address" runat="server"></asp:Label>
                            </div>
                        </div>
                        <hr />
                        <h4>Order Summary</h4>
                        <div class="row">
                            <div class="input-field col s12">
                                <asp:Label ID="lbl_summary" runat="server"></asp:Label>
            <%--                    <asp:Label ID="lbl_prodname" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="lbl_prodquantity" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="lbl_prodprice" runat="server"></asp:Label>
                                <br />--%>
                            </div>
                        </div>
                        <hr />
                        <h4>Payment Info</h4>
                        <div class="row">
                            <div class="input-field col s12">
                                <asp:Label ID="lbl_payment" runat="server"></asp:Label>
                                <asp:Button ID="btn_pay" CssClass="btn right" Text="Pay" runat="server" OnClick="btn_pay_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

