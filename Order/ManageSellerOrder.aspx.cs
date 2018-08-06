using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class Order_ManageSellerOrder : System.Web.UI.Page
{
    Account acc = new Account();
    Order order = new Order();
    protected void Page_Load(object sender, EventArgs e)
    {
        acc = (Account)Session["sellerId"];
        if (!IsPostBack && acc != null)
        {
            bind();
        }
    }

    protected void bind()
    {
        List<Order> orderlist = new List<Order>();
        orderlist = order.getSellerProductFromOrder(acc.gsID);
        gv_sellerorder.DataSource = orderlist;
        gv_sellerorder.DataBind();
    }

    protected void gv_sellerorder_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblpending = (Label)e.Row.FindControl("lbl_pending");
            DateTime dateorder = DateTime.Parse(lblpending.Text);

            DateTime dateNow = DateTime.Now;
            long diff = (dateNow - dateorder).Ticks;
            TimeSpan ts = TimeSpan.FromTicks(diff);
            lblpending.Text = ts.TotalHours.ToString("0.0") + " Hours";

            Label lblstatus = (Label)e.Row.FindControl("lbl_orderstatus");
            switch (lblstatus.Text)
            {
                //Order status
                // 0 = pending, 1 = received, 2 = shipping, 3 = delivered
                case "0":
                    lblstatus.Text = "Pending";
                    lblstatus.ForeColor = Color.Red;
                    break;

                case "1":
                    lblstatus.Text = "Received";
                    lblstatus.ForeColor = Color.Goldenrod;
                    break;

                case "2":
                    lblstatus.Text = "Shipping";
                    lblstatus.ForeColor = Color.Green;
                    break;

                case "3":
                    lblstatus.Text = "Delivered";
                    LinkButton lbReceived = (LinkButton)e.Row.FindControl("linkbtn_received");
                    LinkButton lbShipped = (LinkButton)e.Row.FindControl("linkbtn_ship");
                    lbReceived.Visible = false;
                    lbShipped.Visible = false;
                    lblstatus.ForeColor = Color.Green;
                    break;
            }
        }
    }

    protected void gv_sellerorder_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
        Label lbstatus = (Label)row.FindControl("lbl_orderstatus");

        int status = 0;
        int orderid = int.Parse(row.Cells[0].Text);

        switch (e.CommandName)
        {
            case "Received":
                status = 1;
                order.updateStatus(status, orderid);
                break;
            case "Shipped":
                status = 2;
                order.updateStatus(status, orderid);
                break;
        }
        bind();
    }
}