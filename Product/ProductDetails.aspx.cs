using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductDetails : System.Web.UI.Page
{
    Product prod = null;
    Account acc = null;
    ShoppingCartItem sci = null;
    Favourites fav = null;

    protected void Page_Load(object sender, EventArgs e)
    {

        Product p = new Product();
        Favourites f = new Favourites();

        string pID = Request.QueryString["pID"].ToString();
        prod = p.getProduct(pID);
        acc = (Account)Session["Id"];


        img_product.ImageUrl = "~/img/" + prod.gsImage;
        lbl_prodname.Text = string.Format("<b>PRODUCT DETAILS</b> <br/> <span style='color:#2196f3'>{0}</span>", prod.gsProdName);
        lbl_prodid.Text = string.Format("<b>PRODUCT CODE</b> <br/> <span style='color:#2196f3'>{0}</span>", prod.gsProdID);
        lbl_prodprice.Text = string.Format("<strong>${0}</strong>", prod.gsPrice);
        lbl_description.Text = string.Format("<center><b>PRODUCT DESCRIPTION</b> <br/> <span style='color:#212121'>{0}</span> </center>", prod.gsLongDesc);

        if (acc != null)
        {
            if (f.getFavourite(pID, acc.gsID) != null)
            {
                linkbtn_favourite.Text = "<i class='material-icons pink-text'>favorite</i>";
            }
            else
            {
                linkbtn_favourite.Text = "<i class='material-icons pink-text'>favorite_border</i>";
            }
        }
    }

    protected void btn_addtocart_Click(object sender, EventArgs e)
    {
        acc = (Account)Session["Id"];
        Product p = new Product();
        string pID = Request.QueryString["pID"].ToString();
        prod = p.getProduct(pID);

        if (acc != null)
        {
            List<ShoppingCartItem> scList = new List<ShoppingCartItem>();
            ShoppingCartItem sc = new ShoppingCartItem();

            scList = sc.getAllCartItem(acc.gsID);
            if (scList.Count == 0)
            {
                sc.insertCart(acc.gsID, pID, prod.gsPrice);
            }
            else
            {
                for (int i = 0; i < scList.Count; i++)
                {
                    if (!(scList[i].ItemID.Equals(pID)))
                    {
                        sci = sc.getCartItem(acc.gsID, pID);
                        if (sci != null)
                        {
                            int quantity = sci.Product_Quantity;
                            decimal finalprice = prod.gsPrice;
                            sc.updateCart(acc.gsID, int.Parse(sci.ItemID), quantity, finalprice += sci.Product_FinalPrice);
                            break;
                        }
                        else
                        {
                            sc.insertCart(acc.gsID, pID, prod.gsPrice);
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
            ShoppingCart.Instance.AddItem(pID, prod);
        }
    }

    protected void linkbtn_favourite_Click(object sender, EventArgs e)
    {
        Favourites f = new Favourites();
        acc = (Account)Session["Id"];
        string pID = Request.QueryString["pID"].ToString();

        if (acc != null)
        {
            if (f.getFavourite(pID, acc.gsID) == null)
            {
                fav = new Favourites(acc.gsID, pID);
                fav.insertFavourite();
                linkbtn_favourite.Text = "<i class='material-icons pink-text'>favorite</i>";
            }
            else
            {
                f.deleteFavourite(pID, acc.gsID);
                linkbtn_favourite.Text = "<i class='material-icons pink-text'>favorite_border</i>";
            }
        }

    }
}