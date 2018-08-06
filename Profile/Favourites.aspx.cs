using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Profile_Favourites : System.Web.UI.Page
{
    Account acc = new Account();
    Favourites fav = new Favourites();
    Product prod = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        acc = (Account)Session["Id"];
        if (acc != null)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }
    }

    protected void bind()
    {
        List<Favourites> favlist = new List<Favourites>();
        favlist = fav.getAllFavourites(acc.gsID);
        gv_favourites.DataSource = favlist;
        gv_favourites.DataBind();
    }

    protected void gv_favourites_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl = (Label)e.Row.FindControl("lbl_proddesc");
            Label lblprice = (Label)e.Row.FindControl("lbl_prodprice");
            Image imgprod = (Image)e.Row.FindControl("img_prod");
            Product p = new Product();
            prod = p.getProduct(lbl.Text);
            lbl.Text = string.Format("{0} <br/> <span style='color:#9e9e9e'>{1}</span>", prod.gsProdName, prod.gsShortDesc);
            lblprice.Text = string.Format("<span style='color:#EF6C00'>${0}</span>", prod.gsPrice);
            imgprod.ImageUrl = "~/img/" + prod.gsImage;
        }
    }

    protected void gv_favourites_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
            string pID = gv_favourites.DataKeys[row.RowIndex].Value.ToString();
            acc = (Account)Session["Id"];
            fav.deleteFavourite(pID, acc.gsID);
            bind();
        }
    }
}