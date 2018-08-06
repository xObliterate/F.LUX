using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Showroom_AdminShowroom : System.Web.UI.Page
{
    Showrooms s = new Showrooms();
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
        List<Showrooms> slist = new List<Showrooms>();
        slist = s.getAllShowroom();
        gv_showroom.DataSource = slist;
        gv_showroom.DataBind();

        int count = gv_showroom.Rows.Count;
        if (count == 0)
        {
            lbl_empty.Visible = true;
        }
        else
        {
            lbl_empty.Visible = false;
        }

    }

    protected void gv_showroom_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbslot = (Label)e.Row.FindControl("lbl_slot");
            switch (lbslot.Text)
            {
                case "1":
                    lbslot.Text = "9AM";
                    break;

                case "2":
                    lbslot.Text = "12pm";
                    break;

                case "3":
                    lbslot.Text = "3pm";
                    break;

                case "4":
                    lbslot.Text = "6pm";
                    break;
            }
        }
    }
}