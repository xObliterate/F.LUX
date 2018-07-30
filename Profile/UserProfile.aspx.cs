using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserProfile : System.Web.UI.Page
{
    Account acc = new Account();
    Address add = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        acc = (Account)Session["Id"];

        if (acc == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "msgbox", "alert('Session timeout');window.location = 'Index.aspx';", true);
        }
        else
        {
            lbl_email.Text = acc.gsEmail.ToString();
            lbl_name.Text = acc.gsFname.ToString();
            lbl_phone.Text = "(+65) " + acc.gsPhone.ToString();
            lbl_name.Text = acc.gsFname.ToString() + " " + acc.gsLname.ToString();

            Address address = new Address();
            int cID = acc.gsID;
            add = address.getAddress(cID);

            if (add != null)
            {
                lbl_addName.Text = add.gsAddName;
                lbl_address.Text = add.gsAddInfo.ToUpper();
                lbl_postal.Text = "Singapore " + add.gsAddPostal;
                lbl_addPhone.Text = "(+65) " + add.gsAddPhone;

                lbl_billName.Text = add.gsAddName;
                lbl_billAddress.Text = add.gsAddInfo.ToUpper();
                lbl_billPostal.Text = "Singapore " + add.gsAddPostal;
                lbl_billPhone.Text = "(+65) " + add.gsAddPhone;
            }

        }
    }

    protected void btn_editProfile_Click(object sender, EventArgs e)
    {
        if (acc != null)
        {
            Response.Redirect("EditProfile.aspx");
        }

    }

    protected void btn_editAddress_Click(object sender, EventArgs e)
    {
        if (acc != null)
        {
            Response.Redirect("AddressView.aspx");
        }
    }
}