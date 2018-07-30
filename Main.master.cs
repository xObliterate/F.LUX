using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Main : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Account acc = (Account)Session["Id"];
        Account sellAcc = (Account)Session["sellerId"];

        if (Session["Id"] != null)
        {
            linkbtn_profile.Text = acc.gsFname.ToString().ToUpper() ;
            linkbtn_profile1.Text = acc.gsFname.ToString().ToUpper();
        }
        else if (Session["sellerId"] != null)
        {
            linkbtn_sellerProfile.Text = sellAcc.gsStoreName.ToString().ToUpper() + "<i class='material-icons left'>people</i>";
            linkbtn_sellerProfile1.Text = sellAcc.gsStoreName.ToString().ToUpper();
        }
        else if (Session["admin"] != null)
        {
            linkbtn_adminProfile.Text = "ADMIN<i class='material-icons left'>supervisor_account</i>";
        }
    }

    protected void btn_logout_Click(object sender, EventArgs e)
    {
        logout();
    }

    protected void logout()
    {
        Session.Abandon();
        Session.RemoveAll();
        FormsAuthentication.SignOut();

        Response.Cache.SetExpires(DateTime.Now.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();

        Response.Redirect("/Index.aspx");
    }
}
