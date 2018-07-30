using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Checkout : System.Web.UI.Page
{
    Account acc = new Account();
    Address add = null;
    Order order = new Order();
    protected void Page_Load(object sender, EventArgs e)
    {
        acc = (Account)Session["Id"];
        if (acc == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "msgbox", "alert('Session timeout');window.location = 'Index.aspx';", true);
        }
        else
        {
            Address address = new Address();
            int cID = acc.gsID;
            add = address.getAddress(cID);
            lbl_address.Text = string.Format("Ship to<br/> <b>{0}</b> <br/>{1} <br/>Singapore - {2} <br/>{3}", add.gsAddName, add.gsAddInfo.ToUpper(), add.gsAddPostal, add.gsAddPhone);

            Order order = new Order();
            order = (Order)Session["order"];
            lbl_summary.Text = string.Format("{0} <br/> Shipping Fee ${1} <br/> {2}", order.gssubtotal, order.gsshippingfee, order.gstotal);
        }

    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
           // order.insertOrder(acc.gsID,add.gsAbID, );
        }
    }

    protected void ccVlidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (InputValidation.ValidateCC(args.Value) == true)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }

    protected void expiryValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (InputValidation.IsValidExpiration(args.Value) == true)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }

    protected void cvvValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (InputValidation.IsValidCvv(args.Value) == true)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }
}