using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductDetails : System.Web.UI.Page
{
    Product prod = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        Product p = new Product();

        string pID = Request.QueryString["pID"].ToString();
        prod = p.getProduct(pID);

        img_product.ImageUrl = "~/img/" + prod.gsImage;
        lbl_prodname.Text = prod.gsProdName;
    }
}