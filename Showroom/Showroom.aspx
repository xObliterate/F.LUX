<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Showroom.aspx.cs" Inherits="Showroom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container white z-depth-2">
        <ul class="tabs teal center">
            <li class="tab col s6"><a class="white-text">Showroom</a></li>
        </ul>
        <div class="col s12">
            <div class="form-container">
                <h3 class="teal-text">Booking Details</h3>
                <asp:Panel ID="bookingPanel" runat="server" DefaultButton="btn_submit">

                    <div class="row">
                        <asp:Calendar ID="Calendar1" CssClass="datepicker-calendar-container" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged">
                            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                            <NextPrevStyle VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#808080" />
                            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                            <SelectorStyle BackColor="#CCCCCC" />
                            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <WeekendDayStyle BackColor="#FFFFCC" />
                        </asp:Calendar>
                    </div>

                    <div class="row">
                        <div class="input-field col s2">
                            <asp:Label ID="lbl_slot" CssClass="teal-text" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lbl_date" CssClass="teal-text" runat="server"></asp:Label>
                        </div>
                        <div class="input-field col s2.5">
                            <asp:Button ID="btn_9" CssClass="btn" runat="server" Text="9AM" OnClick="btn_9_Click"></asp:Button>
                        </div>
                        <div class="input-field col s2.5">
                            <asp:Button ID="btn_12" CssClass="btn" runat="server" Text="12PM" OnClick="btn_12_Click"></asp:Button>

                        </div>
                        <div class="input-field col s2.5">
                            <asp:Button ID="btn_3" CssClass="btn" runat="server" Text="3PM" OnClick="btn_3_Click"></asp:Button>
                        </div>
                        <div class="input-field col s2.5">
                            <asp:Button ID="btn_6" CssClass="btn" runat="server" Text="6PM" OnClick="btn_6_Click"></asp:Button>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s2">
                            <asp:TextBox ID="tb_pax" runat="server"></asp:TextBox>
                            <label for="tb_pax">Pax</label>
                        </div>
                    </div>

                    <div class="center">
                        <asp:Button ID="btn_submit" CssClass="btn" runat="server" Text="Submit" OnClick="btn_submit_Click"></asp:Button>
                    </div>
                    <asp:Label ID="lbl_msg" CssClass="right" ForeColor="#ef6c30" runat="server" Visible="false"></asp:Label>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>

