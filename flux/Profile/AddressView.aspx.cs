using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddressView : System.Web.UI.Page
{
    Address add = new Address();
    Account acc = new Account();
    protected void Page_Load(object sender, EventArgs e)
    {
        acc = (Account)Session["Id"];
        if (!IsPostBack)
        {
            if (acc != null)
            {
                bind();
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "msgbox", "alert('Session timeout!');window.location = 'Index.aspx';", true);

            }
        }
    }
    protected void bind()
    {
        List<Address> addList = new List<Address>();

        acc = (Account)Session["Id"];
        int cId = acc.gsID;

        addList = add.getAddressAll(cId);
        gv_address.DataSource = addList;
        gv_address.DataBind();
    }

    protected void btn_add_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditAddress.aspx");
    }

    protected void gv_address_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gv_address.SelectedRow;

        acc = (Account)Session["Id"];
        int cId = acc.gsID;

        string postal = row.Cells[2].Text;

        add.removePrimaryAddress(cId);
        add.setPrimaryAddress(cId, postal);
        Page.ClientScript.RegisterClientScriptBlock(GetType(), "msgbox", "alert('Primary address selected!');window.location = 'UserProfile.aspx';", true);
    }

    protected void gv_address_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int result = 0;
        string addID = gv_address.DataKeys[e.RowIndex].Value.ToString();
        result = add.removeAddress(addID);

        if (result > 0)
        {
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "msgbox", "alert('Removed success!');window.location = 'AddressView.aspx';", true);
        }
        else
        {
            Response.Write("<script>alert('Address Removal NOT successfully');</script>");
        }
    }

    protected void gv_address_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gv_address.EditIndex = e.NewEditIndex;
        bind();
    }

    protected void gv_address_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gv_address.EditIndex = -1;
        bind();
    }

    protected void gv_address_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int result = 0;
        GridViewRow row = (GridViewRow)gv_address.Rows[e.RowIndex];
        string id = gv_address.DataKeys[e.RowIndex].Value.ToString();
        string name = ((TextBox)row.Cells[0].Controls[0]).Text;
        string address = ((TextBox)row.Cells[1].Controls[0]).Text;
        string postal = ((TextBox)row.Cells[2].Controls[0]).Text;
        string phone = ((TextBox)row.Cells[3].Controls[0]).Text;

        result = add.updateAddress(id, name, address, postal, phone);
        if (result > 0)
        {
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "msgbox", "alert('Update success!');window.location = 'AddressView.aspx';", true);
        }
        else
        {
            Response.Write("<script>alert('Product NOT updated');</script>");
        }
    }
}