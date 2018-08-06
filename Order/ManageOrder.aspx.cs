using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Profile_ManageOrder : System.Web.UI.Page
{
    Order order = new Order();
    Account acc = new Account();
    Product prod = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        acc = (Account)Session["Id"];
        if (!IsPostBack && acc != null)
        {
            bind();
        }
    }
    protected void bind()
    {
        List<Order> orderlist = new List<Order>();
        orderlist = order.getAllOrder(acc.gsID);
        gv_order.DataSource = orderlist;
        gv_order.DataBind();
    }

    protected void gv_order_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblquantity = (Label)e.Row.FindControl("lbl_quantity");
            Order o = null;
            o = order.getOrderProduct(int.Parse(lblquantity.Text));
            lblquantity.Text = o.gsquantity.ToString();

            Label lblstatus = (Label)e.Row.FindControl("lbl_status");
            switch (lblstatus.Text)
            {
                //Order status
                // 0 = pending, 1 = received, 2 = shipping, 3 = delivered
                case "0":
                    lblstatus.Text = "Pending";
                    lblstatus.ForeColor = System.Drawing.Color.Red;
                    break;

                case "1":
                    lblstatus.Text = "Received";
                    lblstatus.ForeColor = System.Drawing.Color.Goldenrod;
                    break;

                case "2":
                    lblstatus.Text = "Shipping";
                    lblstatus.ForeColor = System.Drawing.Color.Green;
                    break;

                case "3":
                    lblstatus.Text = "Delivered";
                    lblstatus.ForeColor = System.Drawing.Color.Green;
                    break;
            }

            Label lblshipdate = (Label)e.Row.FindControl("lbl_shipdate");
            var datetime = DateTime.Parse(lblshipdate.Text);
            var date = datetime.Date;
            lblshipdate.Text = date.ToString("dd/MM/yyyy");
        }
    }

    protected void gv_order_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
        int status = 3;
        int orderid = int.Parse(row.Cells[1].Text);

        if(e.CommandName== "Delivered")
        {
            order.updateStatus(status, orderid);
        }
        bind();
    }
}