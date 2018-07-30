using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditAddress : System.Web.UI.Page
{
    Account acc = new Account();
    protected void Page_Load(object sender, EventArgs e)
    {
        acc = (Account)Session["Id"];
        if(acc == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "msgbox", "alert('Session timeout!');window.location = 'Index.aspx';", true);
        }
    }

    protected void btn_save_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            int result = 0;
            acc = (Account)Session["Id"];
            int cId = acc.gsID;

            Address add = new Address(tb_name.Text, tb_add.Text, tb_postal.Text, tb_phone.Text);
            result = add.insertAddress(cId);

            if (result > 0)
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "msgbox", "alert('Insert success!');window.location = 'AddressView.aspx';", true);
            }
            else
            {
                Response.Write("<script>alert('Insert NOT successful');</script>");
            }
        }
    }

    protected void phoneValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (InputValidation.ValidatePhone(args.Value) == true)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }
}