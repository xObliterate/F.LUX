using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditProfile : System.Web.UI.Page
{
    Account acc = new Account();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            acc = (Account)Session["Id"];
            tb_fname.Text = acc.gsFname.ToString();
            tb_lname.Text = acc.gsLname.ToString();
            tb_email.Text = acc.gsEmail.ToString();
            tb_phone.Text = acc.gsPhone.ToString();
            tb_email.Enabled = false;
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

    protected void btn_update_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            acc = (Account)Session["Id"];
            int id = acc.gsID;
            acc.updateProfile(tb_email.Text, tb_phone.Text, id, tb_fname.Text, tb_lname.Text);
            acc = new Account(tb_email.Text, tb_phone.Text, id, tb_fname.Text, tb_lname.Text);
            Session["Id"] = acc;
        }
    }
}