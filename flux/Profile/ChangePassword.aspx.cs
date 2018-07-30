using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangePassword : System.Web.UI.Page
{
    Account acc = new Account();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void passValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (InputValidation.ValidatePassword(tb_password.Text, tb_passwordConfirm.Text) == true)
        {
            args.IsValid = true;
        }
        else
        {
            if (args.Value.Length < 6)
            {
                passValidator.Text = "Password should be 6-50 characters";
            }
            else
            {
                passValidator.Text = "Password do not match";
            }
            args.IsValid = false;
        }
    }

    protected void btn_change_Click(object sender, EventArgs e)
    {
        acc = (Account)Session["email"];
        if (acc == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "msgbox", "alert('Reset password timeout');window.location = 'Index.aspx';", true);
        }
        else
        {
            if (Page.IsValid)
            {
                acc.updatePassword(acc.gsEmail.ToString(), tb_password.Text);
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "msgbox", "alert('Reset password success!');window.location = 'Login.aspx';", true);
             }
        }

    }
}