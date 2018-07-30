using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddProducts : System.Web.UI.Page
{
    Account acc = new Account();
    protected void Page_Load(object sender, EventArgs e)
    {
        acc = (Account)Session["sellerId"];

        if (acc == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "msgbox", "alert('Session timeout!');window.location = '/Index.aspx';", true);
        }
    }

    protected void btn_add_Click(object sender, EventArgs e)
    {
        //Product Status
        //0 = pending, 1 = Accepted, 2 = Rejected

        //Product Category
        //1 = bedroom, 2 = office, 3 = dining, 4 = kitchen, 5 = bathroom, 6 = children, 7 = livingroom
        acc = (Account)Session["sellerID"];
        int sID = acc.gsID, category = 0, result = 0;

        if (ddl_category.SelectedIndex > 0)
        {
            category = int.Parse(ddl_category.SelectedItem.Value);
        }
        if (Page.IsValid)
        {
            Product prod = new Product(category, sID, tb_prodName.Text, tb_shortDesc.Text, tb_prodDesc.Text, int.Parse(tb_quantity.Text), decimal.Parse(tb_price.Text), "0");
            result = prod.productInsert(sID);

            lbl_msg.Visible = true;
            if (result > 0)
            {
                foreach (HttpPostedFile postedFile in fileupload_photo.PostedFiles)
                {
                    string fileName = Path.GetFileName(postedFile.FileName);
                    postedFile.SaveAs(Server.MapPath("~/img/") + fileName);
                    prod = new Product(fileName);
                    prod.productImageInsert();
                }

                lbl_msg.Text = "Product Insert Successful";
                InputValidation.ClearInputs(this.Controls);
                ddl_category.SelectedIndex = 0;
            }
            else
            {
                lbl_msg.Text = "Product Insert NOT Successful";

            }
        }
    }
}