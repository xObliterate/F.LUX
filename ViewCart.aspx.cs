using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewCart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(IsPostBack))
        {
            LoadCart();
        }
    }

    protected void gv_cart_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
        string pID = gv_cart.DataKeys[row.RowIndex].Value.ToString();
        int quantity = int.Parse(((TextBox)row.Cells[2].FindControl("tb_Quantity")).Text);

        switch (e.CommandName)
        {
            case "Remove":
                ShoppingCart.Instance.RemoveItem(pID);
                LoadCart();
                break;

            case "Favourite":
                ShoppingCart.Instance.RemoveItem(pID);
                LoadCart();
                break;

            case "Minus":
                quantity--;
                ShoppingCart.Instance.SetItemQuantity(pID, quantity);
                LoadCart();
                break;

            case "Add":
                if (quantity == 10)
                {
                    LinkButton lb = row.FindControl("btn_plus") as LinkButton;
                    lb.Enabled = false;
                    lb.ForeColor = System.Drawing.Color.Silver;
                }
                else
                {
                    quantity++;
                    ShoppingCart.Instance.SetItemQuantity(pID, quantity);
                    LoadCart();
                }
                break;
        }
    }

    protected void LoadCart()
    {
        gv_cart.DataSource = ShoppingCart.Instance.Items;
        gv_cart.DataBind();

        decimal total = 0.0m, shippFee = 0.0m; ;
        int count = gv_cart.Rows.Count;

        foreach (ShoppingCartItem item in ShoppingCart.Instance.Items)
        {
            total += item.TotalPrice;
        }

        if (count > 0)
        {
            lbl_subtotal.Visible = true;
            lbl_deliveryfee.Visible = true;
            lbl_totalprice.Visible = true;
            btn_checkout.Visible = true;

            if (total >= 500)
            {
                shippFee = 0.00m;
                lbl_deliveryfee.Text = "Shipping Fee <strong>FREE</strong> ";
            }
            else
            {
                shippFee = 25.00m;
                lbl_deliveryfee.Text = string.Format("Shipping Fee <strong>${0}</strong> ", shippFee);
            }
            lbl_subtotal.Text = string.Format("Subtotal({0} items) <strong>${1}</strong> ", count, total.ToString());
            lbl_totalprice.Text = string.Format("Total Price <strong><span style='color:#EF6C00'>${0}</span></strong>", total + shippFee);
            Order order = new Order(lbl_subtotal.Text, shippFee.ToString(), lbl_totalprice.Text);
            Session["order"] = order;
        }
        else
        {
            lbl_msg.Visible = true;
            lbl_subtotal.Visible = false;
            lbl_deliveryfee.Visible = false;
            lbl_totalprice.Visible = false;
            btn_checkout.Visible = false;
        }
    }

    protected void btn_checkout_Click(object sender, EventArgs e)
    {
        List<Product> list = new List<Product>();
        foreach (GridViewRow row in gv_cart.Rows)
        {
            Label lbname = (Label)row.FindControl("lbl_prodname");
            Label lbdesc = (Label)row.FindControl("lbl_proddesc");
            TextBox tbquantity = (TextBox)row.FindControl("tb_quantity");

            string name = lbname.Text;
            string desc = lbdesc.Text;
            string quantity = tbquantity.Text;
            string price = row.Cells[2].Text;
            price = price.Replace("$", string.Empty);

            Product p = new Product(name, desc, int.Parse(quantity), decimal.Parse(price));
            list.Add(p);
        }
        Session["o"] = list;

        Response.Redirect("Checkout.aspx");
    }
}