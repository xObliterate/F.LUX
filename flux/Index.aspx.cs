using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    Product prod = null;
    Account acc = null;


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
        prodList = prod.getAllPopProd();
        rpt_popProd.DataSource = prodList;
        rpt_popProd.DataBind();
    }

    protected void btn_cart_Click(object sender, EventArgs e)
    {
        acc = (Account)Session["Id"];
        Product p = new Product();
        if (acc != null)
        {
            Button btn = (Button)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;
            HiddenField idField = (HiddenField)item.FindControl("lbl_popID");

            string prodID = idField.Value;
            prod = p.getProduct(prodID);
            ShoppingCart.Instance.AddItem(prodID, prod); 
        }
        else
        {

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