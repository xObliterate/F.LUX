using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SellerProfile : System.Web.UI.Page
{
    Account acc = new Account();
    protected void Page_Load(object sender, EventArgs e)
    {
        acc = (Account)Session["sellerId"];

        if(acc == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "msgbox", "alert('Session timeout');window.location = 'Index.aspx';", true);
        }
        else
        {

        }
    }
}