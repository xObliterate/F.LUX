using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    Account acc = new Account();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            acc.regUser(tb_email.Text, tb_password.Text, tb_phone.Text, tb_fname.Text, tb_lname.Text);
        }
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
}