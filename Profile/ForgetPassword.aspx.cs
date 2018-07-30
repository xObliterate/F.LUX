using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ForgetPassword : System.Web.UI.Page
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

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            acc.resetPassword(tb_email.Text);
            Response.Write("<script>alert('Please check your email for more information.');</script>");
            acc = new Account(tb_email.Text);
            Session["email"] = acc;
        }
    }
}