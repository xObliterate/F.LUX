using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    Account acc = new Account();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["tbEmail"] != null && Request.Cookies["tbPw"] != null)
            {
                cb_remember.Checked = true;
                tb_email.Text = Request.Cookies["tbEmail"].Value;
                tb_password.Text = Request.Cookies["tbPw"].Value;
            }
        }
    }

    protected void btn_login_Click(object sender, EventArgs e)
    {
       // Page.Validate();
        if (Page.IsValid)
        {
            if (cb_remember.Checked == true)
            {
                Response.Cookies["tbEmail"].Value = tb_email.Text;
                Response.Cookies["tbPw"].Value = tb_password.Text;
                Response.Cookies["tbEmail"].Expires = DateTime.Now.AddDays(3);
                Response.Cookies["tbPw"].Expires = DateTime.Now.AddDays(3);
            }
            else
            {
                Response.Cookies["tbEmail"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["tbPw"].Expires = DateTime.Now.AddDays(-1);
            }
            acc.loginUser(tb_email.Text, tb_password.Text);         
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
}