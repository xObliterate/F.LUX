<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Invoice.aspx.cs" Inherits="Invoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container white z-depth-2">
        <ul class="tabs teal center">
            <li class="tab col s6"><a class="white-text">Invoice</a></li>
        </ul>
        <div class="col s12">
            <div class="form-container">
                <h3 class="teal-text">Payment success</h3>
                <div class="row">
                    <div class="input-field col s12">
                        <table>
                            <tr>
                                <td><b>Bill To</b></td>
                                <td><b>Ship To</b></td>
                                <td><b>Invoice #</b></td>
                                <td><b>Invoice Date</b></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_billing" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_shipping" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_invoiceNo" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_invoicedate" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <br />
                <div class="col s12">
                    <div class="form-container">
                        <asp:GridView ID="gv_order" CssClass="striped" runat="server" AutoGenerateColumns="False" DataKeyNames="gsorderId" OnRowDataBound="gv_order_RowDataBound">
                            <Columns>
                                <asp:BoundField HeaderText="Qty" DataField="gsquantity" />
                                <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate>
                                <asp:Label id="lbl_description" runat="server" Text='<%# Eval("gsprodId") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Unit Price" DataFormatString="{0:C}" DataField="gsorderPrice" />
                                <asp:BoundField HeaderText="Amount" DataFormatString="{0:C}" HtmlEncode="false" DataField="gsfinalPrice" />
                            </Columns>
                        </asp:GridView>
                        <div class="input-field col s12">
                            <asp:Label ID="lbl_subtotal" CssClass="right" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lbl_shippfee" CssClass="right" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lbl_finalprice" CssClass="right" runat="server"></asp:Label>
                            <br />
                            <br />
                            <asp:LinkButton ID="btn_close" CssClass="btn waves-effect waves-light right" runat="server" PostBackUrl="~/Index.aspx">Proceed</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

