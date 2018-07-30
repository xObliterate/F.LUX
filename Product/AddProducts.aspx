<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="AddProducts.aspx.cs" Inherits="AddProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container white z-depth-2">
        <ul class="tabs teal center">
            <li class="tab col s6"><a class="white-text">Add Product</a></li>
        </ul>
        <div class="col s12">
            <div class="form-container">
                <asp:Panel ID="addProductPanel" runat="server" DefaultButton="btn_add">
                    <div class="row">
                        <div class="input-field col s12">
                            <asp:TextBox ID="tb_prodName" CssClass="validate" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_prodName" EnableClientScript="false" ControlToValidate="tb_prodName" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>
                            <label for="tb_prodID">Product Name</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                            <asp:DropDownList ID="ddl_category" CssClass="dropdown-trigger2 btn-flat grey lighten-2 grey-text text-darken-1" runat="server">
                                <asp:ListItem Text="Select Category" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="1">Bedroom</asp:ListItem>
                                <asp:ListItem Value="2">Office</asp:ListItem>
                                <asp:ListItem Value="3">Dining</asp:ListItem>
                                <asp:ListItem Value="4">Kitchen</asp:ListItem>
                                <asp:ListItem Value="5">Bathroom</asp:ListItem>
                                <asp:ListItem Value="6">Children</asp:ListItem>
                                <asp:ListItem Value="7">Living room</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfv_ddl" InitialValue="0" EnableClientScript="false" ControlToValidate="ddl_category" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="Please select one category"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                            <asp:TextBox ID="tb_shortDesc" runat="server" MaxLength="255"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_shortDesc" EnableClientScript="false" ControlToValidate="tb_shortDesc" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="You can't leave this empty. "></asp:RequiredFieldValidator>
                            <label for="tb_shortDesc">Short Description</label>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field col s12">
                            <asp:TextBox ID="tb_prodDesc" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_prodDesc" EnableClientScript="false" ControlToValidate="tb_prodDesc" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="You can't leave this empty. "></asp:RequiredFieldValidator>
                            <label for="tb_prodDesc">Product Description</label>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field col s6">
                            <asp:TextBox ID="tb_quantity" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_quantity" EnableClientScript="false" ControlToValidate="tb_quantity" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="You cant't leave this empty. "></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="rev_quantity" ControlToValidate="tb_quantity" EnableClientScript="false" ValidationExpression="[0-9]+" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="Please enter in numbers only."></asp:RegularExpressionValidator>
                            <label for="tb_quantity">Quantity</label>
                        </div>
                        <div class="input-field col s6">
                            <asp:TextBox ID="tb_price" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_price" EnableClientScript="false" ControlToValidate="tb_price" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="You cant't leave this empty. "></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="rev_price" ControlToValidate="tb_price" EnableClientScript="false" ValidationExpression="[0-9]*(\.[0-9][0-9])?" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="Please enter in numbers and 0 or 2 decimals."></asp:RegularExpressionValidator>
                            <label for="tb_quantity">Price</label>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field col s6">
                            <asp:FileUpload ID="fileupload_photo" AllowMultiple="true" runat="server" Width="100%" />
                            <asp:RequiredFieldValidator ID="rfv_upload" runat="server" EnableClientScript="false" Display="Dynamic" ForeColor="Red" ControlToValidate="fileupload_photo" ErrorMessage="Please upload at least 1 image"></asp:RequiredFieldValidator>
                        </div>
                        <div class="input-field col s6">
                            <asp:Label ID="lbl_msg" runat="server" Visible="false" ForeColor="#ef6c00"></asp:Label>
                        </div>
                    </div>


                    <div class="center">
                        <asp:Button ID="btn_add" CssClass="btn" runat="server" Text="Add" OnClick="btn_add_Click"></asp:Button>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
