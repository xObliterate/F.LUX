using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class Invoice : System.Web.UI.Page
{
    Account acc = new Account();
    Order order = null;
    Address add = null;
    Product prod = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        acc = (Account)Session["Id"];

        if (!IsPostBack)
        {
            if (acc != null)
            {
                Order o = new Order();
                Address a = new Address();
                add = a.getAddress(acc.gsID);
                order = o.getOrder(acc.gsID);

                string price = "";
                decimal finalprice = 0.0m;

                lbl_billing.Text = string.Format("{0} <br/> {1} <br/> {2} <br/> ", add.gsAddName, add.gsAddInfo, add.gsAddPostal);
                lbl_shipping.Text = string.Format("{0} <br/> {1} <br/> {2} <br/> ", add.gsAddName, add.gsAddInfo, add.gsAddPostal);
                lbl_invoiceNo.Text = string.Format("{0}", order.gsorderId);
                lbl_invoicedate.Text = string.Format("{0}", order.gsdate);

                bind();

                foreach (GridViewRow row in gv_order.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        price = row.Cells[3].Text;
                        finalprice += decimal.Parse(price, NumberStyles.Currency);
                    }
                }
                lbl_subtotal.Text = string.Format("Subtotal <strong>${0}</strong>", finalprice.ToString());
                lbl_shippfee.Text = string.Format("Shipping Fee <strong>${0}</strong>", order.gsshippingfee);
                lbl_finalprice.Text = string.Format("Total Price <strong><span style='color:#EF6C00'>${0}</span></strong>", finalprice + order.gsshippingfee);
            }
            else
            {
                Response.Redirect("Index.aspx");
            }
        }
    }

    protected void bind()
    {
        List<Order> orderlist = new List<Order>();
        Order o = new Order();
        order = o.getOrder(acc.gsID);
        orderlist = order.getAllOrderProducts(order.gsorderId);
        gv_order.DataSource = orderlist;
        gv_order.DataBind();
    }

    protected void gv_order_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl = (Label)e.Row.FindControl("lbl_description");
            Product p = new Product();
            prod = p.getProduct(lbl.Text);
            lbl.Text = string.Format("{0} <br/> <span style='color:#9e9e9e'>{1}</span>", prod.gsProdName, prod.gsShortDesc);
        }
    }
}