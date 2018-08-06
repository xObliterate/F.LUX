using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Enquiry_AdminViewEnquiry : System.Web.UI.Page
{
    ContactUs cs = new ContactUs();
    Account acc = new Account();

    protected void Page_Load(object sender, EventArgs e)
    {
        acc = (Account)Session["admin"];

        if (!IsPostBack && acc != null)
        {
            bind();
        }
    }
    protected void bind()
    {
        List<ContactUs> csList = new List<ContactUs>();
        csList = cs.getAllEnquiry();
        gv_enquiry.DataSource = csList;
        gv_enquiry.DataBind();

        int count = gv_enquiry.Rows.Count;
        if (count == 0)
        {
            lbl_empty.Visible = true;
        }
        else
        {
            lbl_empty.Visible = false;
        }
    }


    protected void gv_enquiry_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gv_enquiry.SelectedRow;
        int id = int.Parse(gv_enquiry.DataKeys[row.RowIndex].Value.ToString());
        string name = row.Cells[0].Text, email = row.Cells[1].Text, message = row.Cells[2].Text;
        cs = new ContactUs(id, name, email, message);
        Session["adminreply"] = cs;
        Response.Redirect("/Enquiry/AdminReplyEnquiry.aspx");
    }
}