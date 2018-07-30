using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adminLogin : System.Web.UI.Page
{
    Account acc = new Account();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void emailValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (InputValidation.ValidateEmail(args.Value) == true)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }

    protected void btn_login_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            acc.loginAdmin(tb_email.Text, tb_password.Text);
        }
    }
}