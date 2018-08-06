<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="FAQ.aspx.cs" Inherits="FAQ" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container white z-depth-2">
        <ul class="tabs teal center">
            <li class="tab col s6"><a class="white-text">FAQ</a></li>
        </ul>
        <ul class="collapsible">
            <li>
                <div class="collapsible-header"><i class="material-icons">add_circle_outline</i><b>Can i choose my delivery date?</b></div>
                <div class="collapsible-body"><span>Yes, but only for furniture orders. After you make your purchase, you will be asked to choose a date and a time slot. Currently, we only offer two slots : 9.30am to 2.30pm, or 1:30pm to 6:30pm.</span></div>
            </li>
            <li>
                <div class="collapsible-header"><i class="material-icons">add_circle_outline</i><b>Can you hold my order until my house is ready?</b></div>
                <div class="collapsible-body"><span>Congrats on the new home! Yes, we can hold your order for up to 30 days from the date your items arrive in our warehouse.For furniture orders, you'll be able to choose any delivery data within 30 days from the date your order will be ready for delivery.</span></div>
            </li>
            <li>
                <div class="collapsible-header"><i class="material-icons">add_circle_outline</i><b>I'd like to get my order earlier</b></div>
                <div class="collapsible-body"><span>We are constantly improving our technology to give you an accurate estimation of when your order will be ready. In the case when your items arrive at our warehouse earlier than the estimated date, we will contact you via email to arrange for an earlier delivery!</span></div>
            </li>
            <li>
                <div class="collapsible-header"><i class="material-icons">add_circle_outline</i><b>I'd like to get some of my items first.</b></div>
                <div class="collapsible-body"><span>To help you save on your delivery charges, we consolidate your items and only deliver it to you when all the items are ready in our warehouse.If you want to receive some items first, please send us an email at cs@flux.com</span></div>
            </li>
            <li>
                <div class="collapsible-header"><i class="material-icons">add_circle_outline</i><b>Will you dispose of my existing furniture</b></div>
                <div class="collapsible-body"><span>Yes we do! We offer same-day disposal services for small and large furniture items. Click here. Simply add them to your cart and checkout.</span></div>
            </li>
            <li>
                <div class="collapsible-header"><i class="material-icons">add_circle_outline</i><b>I need help with styling!</b></div>
                <div class="collapsible-body"><span>Well,you're in luck! We offer a complimentary interior styling advice to all our customers. Simply write in to cs@flux.com and our styling agent will be replying to you with free styling tips and recommendation, or feel free to check out our blog or instagram for some styling inspirations!</span></div>
            </li>
            <li>
                <div class="collapsible-header"><i class="material-icons">add_circle_outline</i><b>Can you hold my order until my house is ready?</b></div>
                <div class="collapsible-body"><span>Congrats on the new home! Yes, we can hold your order for up to 30days from the date your items arrive in our warehouse. For furniture orders, you'll be able to choose any delivery date within 30 days from the date your order will be ready for delivery.</span></div>
            </li>
            <li>
                <div class="collapsible-header"><i class="material-icons">add_circle_outline</i><b>Do you ship internationally?</b></div>
                <div class="collapsible-body"><span>F.LUX does ship internationally</span></div>
            </li>
            <li>
                <div class="collapsible-header"><i class="material-icons">add_circle_outline</i><b>I received my order and it's defective</b></div>
                <div class="collapsible-body"><span>We're so sorry the item did not reach you in good condtion! We are happy to arrange for a prompt replacement or repair. Simply request for a replacement or repair by writing in to cs@flux.com for our customer happiness agent to follow up with you directly.</span></div>
            </li>
            <li>
                <div class="collapsible-header"><i class="material-icons">add_circle_outline</i><b>Can i self-collect my order?</b></div>
                <div class="collapsible-body">
                    <span>Sure thing! All you need to do is to leave us a note during checkout and send us an email at cs@flux.com, with your order number and the date you would like to collect your order. Please wait for a confirmation from our customer happiness team before dropping by, as we cannot gurantee that your order is ready for collection. 
                                            Self-Collection will be at our office/warehouse, located at 19 Kallang Avenue #02-153 Singapore 339410. Our opening hours are monday to friday, between 10am to 7pm (excluding eve and public holiday)
                    </span>
                </div>
            </li>
            <li>
                <div class="collapsible-header"><i class="material-icons">add_circle_outline</i><b>Do you deliver to all parts of Singapore?</b></div>
                <div class="collapsible-body"><span>We deliver to any street address in Singapore, excluding restricted areas like Pulau Ubin. If you're unsure of whether we deliver to your area, do send an email to cs@flux.com to check with our customer happiness team</span></div>
            </li>
        </ul>
        <asp:LinkButton ID="linkbtn_contact" CssClass="right" runat="server" PostBackUrl="~/Enquiry/ContactUs.aspx" Text="More Enquiries? Contact Us" />
    </div>
</asp:Content>

