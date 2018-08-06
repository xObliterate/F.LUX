using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Enquiry_ContactUs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            ContactUs cs = new ContactUs(tb_name.Text, tb_email.Text, tb_message.Text);
            cs.insertEnquiry();
            InputValidation.ClearInputs(this.Controls);
            lbl_msg.Visible = true;
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