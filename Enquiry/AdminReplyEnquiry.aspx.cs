using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Enquiry_AdminReplyEnquiry : System.Web.UI.Page
{
    ContactUs cs = new ContactUs();
    protected void Page_Load(object sender, EventArgs e)
    {
        cs = (ContactUs)Session["adminreply"];
        tb_name.Text = cs.gsname;
        tb_email.Text = cs.gsemail;
        tb_message.Text = cs.gsmessage;
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            cs = (ContactUs)Session["adminreply"];
            cs.updateEnquiry(tb_replymessage.Text, cs.gsid);
            SendMail.sendEnquiryEmail(tb_email.Text, tb_name.Text, tb_message.Text, tb_replymessage.Text);
            Response.Redirect("/Enquiry/AdminViewEnquiry.aspx");
        }
    }
}