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

        GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
        string pID = gv_cart.DataKeys[row.RowIndex].Value.ToString();
        string quantity1 = ((TextBox)row.Cells[3].FindControl("tb_Quantity")).Text;
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
                        LinkButton lb = row.FindControl("btn_plus") as LinkButton;
                        lb.Enabled = false;
                        lb.ForeColor = System.Drawing.Color.Silver;
                    }
                    else
                    {
                        lbPlus.CommandArgument = "<%# Eval('Product_Quantity') %>";
                        cartQuantity++;
                        cartQuantity -= 1;
                        decimal finalprice = prod.gsPrice * cartQuantity;
                        sc.updateCart(acc.gsID, int.Parse(pID), cartQuantity, finalprice += prod.gsPrice);
                    }
                    break;
                }
                else
                {
                    quantity = int.Parse(quantity1);
                    if (quantity == 10)
                    {
                        LinkButton lb = row.FindControl("btn_plus") as LinkButton;
                        lb.Enabled = false;
                        lb.ForeColor = System.Drawing.Color.Silver;
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

        decimal total = 0.0m, shippFee = 0.0m;
        string price = "";
        int count = gv_cart.Rows.Count;

        foreach (ShoppingCartItem item in ShoppingCart.Instance.Items)
        {
            total += item.TotalPrice;
        }

        //foreach (GridViewRow row in gv_cart.Rows)
        //{
        //    for (int i = 0; i < count; i++)
        //    {
        //        price = row.Cells[2].Text;
        //        total += decimal.Parse(price);
        //    }
        //}

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

            if (acc != null)
            {
                lbl_subtotal.Text = string.Format("Subtotal({0} items) <strong>${1}</strong> ", count, price.ToString());
            }
            else
            {
                lbl_subtotal.Text = string.Format("Subtotal({0} items) <strong>${1}</strong> ", count, total.ToString());
                lbl_totalprice.Text = string.Format("Total Price <strong><span style='color:#EF6C00'>${0}</span></strong>", total + shippFee);
                order = new Order(lbl_subtotal.Text, shippFee.ToString(), lbl_totalprice.Text);
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