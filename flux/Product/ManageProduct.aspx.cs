using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class ManageProduct : System.Web.UI.Page
{
    Product prod = new Product();
    Account acc = new Account();
    protected void Page_Load(object sender, EventArgs e)
    {
        acc = (Account)Session["sellerID"];
        if (!IsPostBack)
        {
            if (acc != null)
            {
                bind();
                bindSearch();
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "msgbox", "alert('Session timeout!');window.location = 'Index.aspx';", true);
            }
        }
    }

    protected void btn_addProducts_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddProducts.aspx");
    }

    protected void bind()
    {
        List<Product> prodList = new List<Product>();

        acc = (Account)Session["sellerID"];
        int id = acc.gsID;

        prodList = prod.getAllProduct(id);
        gv_product.DataSource = prodList;
        gv_product.DataBind();
    }

    protected void bindSearch()
    {
        List<Product> prodList = new List<Product>();
        prodList = prod.productSearch(tb_search.Text.Trim());
        gv_product.DataSource = prodList;
        gv_product.DataBind();
    }

    protected void gv_product_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gv_product.EditIndex = e.NewEditIndex;
        bind();
    }

    protected void gv_product_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gv_product.EditIndex = -1;
        bind();
    }

    protected void gv_product_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int result = 0;
        try
        {
            GridViewRow row = (GridViewRow)gv_product.Rows[e.RowIndex];
            string id = gv_product.DataKeys[e.RowIndex].Value.ToString();
            string pName = ((TextBox)row.Cells[0].Controls[0]).Text;
            decimal price = decimal.Parse(((TextBox)row.Cells[2].Controls[0]).Text);
            int quantity = int.Parse(((TextBox)row.Cells[3].Controls[0]).Text);

            result = prod.productUpdate(id, pName, quantity, price);
            lbl_msg.Visible = true;
            if (result > 0)
            {
                lbl_msg.Text = "Product updated successfully.";
            }
            else
            {
                lbl_msg.Text = "Product NOT updated successfully";
            }
            gv_product.EditIndex = -1;
            bind();

        }
        catch (FormatException e1)
        {
            lbl_msg.Text = e1.Message.ToString();
        }
    }

    protected void gv_product_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl = (Label)e.Row.FindControl("lbl_status");
            switch (lbl.Text)
            {
                case "0":
                    lbl.Text = "<i class='fas fa-exclamation'></i>";
                    lbl.ForeColor = System.Drawing.Color.Goldenrod;
                    break;
                case "1":
                    lbl.Text = "<i class='material-icons'>check</i>";
                    lbl.ForeColor = System.Drawing.Color.LimeGreen;
                    break;
            }
            e.Row.Cells[0].Text = Regex.Replace(e.Row.Cells[0].Text, tb_search.Text.Trim(), delegate (Match match)
            {
                return string.Format("<span style = 'background-color:#D9EDF7'>{0}</span>", match.Value);
            }, RegexOptions.IgnoreCase);
        }
    }

    protected void gv_product_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int result = 0;
        string prodID = gv_product.DataKeys[e.RowIndex].Value.ToString();
        result = prod.productDelete(prodID);

        if (result > 0)
        {
            lbl_msg.Text = "Product Removed successfully";
        }
        else
        {
            lbl_msg.Text = "Product is NOT remove";
        }
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        bindSearch();
    }
}