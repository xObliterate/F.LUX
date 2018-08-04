using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewCart : System.Web.UI.Page
{
    ShoppingCartItem sc = new ShoppingCartItem();
    Account acc = new Account();
    Product prod = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(IsPostBack))
        {
            LoadCart();
        }
    }

    protected void gv_cart_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Product p = new Product();

        GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
        string pID = gv_cart.DataKeys[row.RowIndex].Value.ToString();
        string quantity1 = ((TextBox)row.Cells[3].FindControl("tb_quantity")).Text;
        string cartQuantity1 = ((TextBox)row.Cells[3].FindControl("tb_cartQuantity")).Text;
        LinkButton lbMinus = (LinkButton)row.FindControl("btn_minus");
        LinkButton lbPlus = (LinkButton)row.FindControl("btn_plus");

        int cartQuantity = 0;
        int quantity = 0;

        acc = (Account)Session["Id"];

        prod = p.getProduct(pID);

        switch (e.CommandName)
        {
            case "Remove":
                if (acc != null)
                {
                    sc.deleteCart(pID, acc.gsID);
                }
                else
                {
                    ShoppingCart.Instance.RemoveItem(pID);
                }
                break;

            case "Favourite":
                if (acc != null)
                {

                }
                else
                {
                    ShoppingCart.Instance.RemoveItem(pID);
                }
                break;

            case "Minus":
                if (acc != null)
                {
                    cartQuantity = int.Parse(cartQuantity1);

                    lbMinus.CommandArgument = "<%# Eval('Product_Quantity') %>";
                    cartQuantity--;
                    cartQuantity -= 1;
                    decimal finalprice = prod.gsPrice * cartQuantity;

                    sc.updateCart(acc.gsID, int.Parse(pID), cartQuantity, finalprice -= prod.gsPrice);
                }
                else
                {
                    quantity = int.Parse(quantity1);

                    lbMinus.CommandArgument = "<%# Eval('Quantity') %>";
                    quantity--;
                    ShoppingCart.Instance.SetItemQuantity(pID, quantity);
                }
                break;

            case "Add":
                if (acc != null)
                {
                    cartQuantity = int.Parse(cartQuantity1);
                    if (cartQuantity == 10)
                    {
                        lbPlus.Enabled = false;
                    }
                    else
                    {
                        lbPlus.CommandArgument = "<%# Eval('Product_Quantity') %>";
                        cartQuantity++;
                        cartQuantity -= 1;
                        decimal finalprice = prod.gsPrice * cartQuantity;
                        sc.updateCart(acc.gsID, int.Parse(pID), cartQuantity, finalprice += prod.gsPrice);
                    }
                }
                else
                {
                    quantity = int.Parse(quantity1);
                    if (quantity == 10)
                    {
                        lbPlus.Enabled = false;
                    }
                    else
                    {
                        lbPlus.CommandArgument = "<%# Eval('Quantity') %>";
                        quantity++;
                        ShoppingCart.Instance.SetItemQuantity(pID, quantity);
                    }
                }
                break;
        }
        LoadCart();
    }

    protected void LoadCart()
    {
        acc = (Account)Session["Id"];
        Order order = null;
        if (acc != null)
        {
            int id = acc.gsID;
            List<ShoppingCartItem> scList = new List<ShoppingCartItem>();
            scList = sc.getAllCartItem(id);
            gv_cart.DataSource = scList;
            gv_cart.DataBind();
        }
        else
        {
            gv_cart.DataSource = ShoppingCart.Instance.Items;
            gv_cart.DataBind();
        }

        decimal total = 0.0m, shippFee = 0.0m, subtotal = 0.0m;
        string price = "";
        int count = gv_cart.Rows.Count, quantity;

        foreach (ShoppingCartItem item in ShoppingCart.Instance.Items)
        {
            total += item.TotalPrice;
        }

        foreach (GridViewRow row in gv_cart.Rows)
        {
            TextBox tbquantity = (TextBox)row.FindControl("tb_cartQuantity");
            quantity = int.Parse(tbquantity.Text);

            price = row.Cells[2].Text;
            price = price.Replace("$", string.Empty);
            subtotal += decimal.Parse(price) * quantity;
        }

        if (count > 0)
        {
            lbl_subtotal.Visible = true;
            lbl_deliveryfee.Visible = true;
            lbl_totalprice.Visible = true;
            btn_checkout.Visible = true;

            if (total >= 500 || subtotal >= 500)
            {
                shippFee = 0.00m;
                lbl_deliveryfee.Text = "Shipping Fee <strong>FREE</strong> ";
            }
            else
            {
                shippFee = 25.00m;
                lbl_deliveryfee.Text = string.Format("Shipping Fee <strong>${0}</strong> ", shippFee);
            }

            if (acc != null)
            {
                lbl_subtotal.Text = string.Format("Subtotal({0} items) <strong>${1}</strong> ", count, subtotal);
                lbl_totalprice.Text = string.Format("Total Price <strong><span style='color:#EF6C00'>${0}</span></strong>", subtotal + shippFee);
                order = new Order(subtotal, shippFee, count);
            }
            else
            {
                lbl_subtotal.Text = string.Format("Subtotal({0} items) <strong>${1}</strong> ", count, total.ToString());
                lbl_totalprice.Text = string.Format("Total Price <strong><span style='color:#EF6C00'>${0}</span></strong>", total + shippFee);
            }
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
            TextBox tbquantity;

            if (Session["Id"] != null)
            {
                tbquantity = (TextBox)row.FindControl("tb_cartQuantity");
            }
            else
            {
                tbquantity = (TextBox)row.FindControl("tb_quantity");
            }
            string pID = gv_cart.DataKeys[row.RowIndex].Value.ToString();
            string desc = lbdesc.Text;
            string quantity = tbquantity.Text;
            string price = row.Cells[2].Text;
            price = price.Replace("$", string.Empty);

            Product p = new Product(pID, desc, int.Parse(quantity), decimal.Parse(price));
            list.Add(p);
        }
        Session["o"] = list;

        Response.Redirect("Checkout.aspx");
    }

    protected void tb_cartQuantity_TextChanged(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
        TextBox tbquantity = (TextBox)row.FindControl("tb_cartQuantity");

        Product p = new Product();
        acc = (Account)Session["Id"];
        string pID = gv_cart.DataKeys[row.RowIndex].Value.ToString();
        int quantity = int.Parse(tbquantity.Text.Trim());

        if (quantity > 10)
        {
            lbl_quantitymsg.Visible = true;
            tbquantity.Text = "10";
        }
        else
        {
            lbl_quantitymsg.Visible = false;
            prod = p.getProduct(pID);
            decimal finalprice = quantity * prod.gsPrice;
            sc.updateCart(acc.gsID, int.Parse(pID), quantity - 1, finalprice);

        }

        LoadCart();
    }
}