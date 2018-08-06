using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Product_ViewAllProducts : System.Web.UI.Page
{
    Product prod = null;
    Account acc = null;
    ShoppingCartItem sci = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        acc = (Account)Session["sellerId"];
        if (!IsPostBack)
        {
            if (acc != null)
            {
                Response.Redirect("SellerIndex.aspx");
            }
            else
            {
                bind();
            }
        }
    }
    protected void bind()
    {
        List<Product> prodList = new List<Product>();
        prod = new Product();
        prodList = prod.getAllProd();
        rpt_popProd.DataSource = prodList;
        rpt_popProd.DataBind();
    }

    protected void btn_cart_Click(object sender, EventArgs e)
    {
        acc = (Account)Session["Id"];
        Product p = new Product();
        Button btn = (Button)sender;
        RepeaterItem item = (RepeaterItem)btn.NamingContainer;
        HiddenField idField = (HiddenField)item.FindControl("lbl_popID");
        string prodID = idField.Value;
        prod = p.getProduct(prodID);

        if (acc != null)
        {
            List<ShoppingCartItem> scList = new List<ShoppingCartItem>();
            ShoppingCartItem sc = new ShoppingCartItem();

            scList = sc.getAllCartItem(acc.gsID);
            if (scList.Count == 0)
            {
                sc.insertCart(acc.gsID, prodID, prod.gsPrice);
            }
            else
            {
                for (int i = 0; i < scList.Count; i++)
                {
                    if (!(scList[i].ItemID.Equals(prodID)))
                    {
                        sci = sc.getCartItem(acc.gsID, prodID);
                        if (sci != null)
                        {
                            int quantity = sci.Product_Quantity;
                            decimal finalprice = prod.gsPrice;
                            sc.updateCart(acc.gsID, int.Parse(sci.ItemID), quantity, finalprice += sci.Product_FinalPrice);
                            break;
                        }
                        else
                        {
                            sc.insertCart(acc.gsID, prodID, prod.gsPrice);
                        }
                    }
                    else
                    {
                        int quantity = scList[i].Product_Quantity;
                        decimal finalprice = prod.gsPrice;
                        sc.updateCart(acc.gsID, int.Parse(scList[i].ItemID), quantity, finalprice += scList[i].Product_FinalPrice);
                        break;
                    }
                }
            }
        }
        else
        {
            ShoppingCart.Instance.AddItem(prodID, prod);
        }
    }
    protected void linkbtn_info_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        RepeaterItem item = (RepeaterItem)btn.NamingContainer;
        HiddenField idField = (HiddenField)item.FindControl("lbl_popID");

        string pID = idField.Value;
        Response.Redirect("/Product/ProductDetails.aspx?pID=" + pID);
    }
}