using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Product_ApproveProducts : System.Web.UI.Page
{
    Product prod = new Product();
    Account acc = new Account();

    protected void Page_Load(object sender, EventArgs e)
    {
        acc = (Account)Session["admin"];
        if (!IsPostBack && acc != null)
        {
            bind();
        }
    }
    protected void bind()
    {
        List<Product> prodList = new List<Product>();
        prodList = prod.approveProducts();
        gv_approveproducts.DataSource = prodList;
        gv_approveproducts.DataBind();

        int count = gv_approveproducts.Rows.Count;
        if (count == 0)
        {
            lbl_empty.Visible = true;
        }
        else
        {
            lbl_empty.Visible = false;
        }
    }

    protected void gv_approveproducts_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
        LinkButton lbcheck = (LinkButton)row.FindControl("linkbtn_approved");
        LinkButton lbcross = (LinkButton)row.FindControl("linkbtn_reject");
        string pID = gv_approveproducts.DataKeys[row.RowIndex].Value.ToString();

        int status = 0;

        switch (e.CommandName)
        {
            case "Check":
                status = 1;
                prod.productStatusUpdate(pID, status);
                break;
            case "Cross":
                status = 2;
                prod.productStatusUpdate(pID, status);
                break;
        }
        bind();
    }
}