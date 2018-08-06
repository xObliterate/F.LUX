using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Order order = new Order();
        order = (Order)Session["Order"];
        decimal total = order.gssubtotal + order.gsshippingfee;

        int transId = (new Random()).Next(1000000000);
        (new StripePayment()).Charge(total, "Some Description", "tok_visa", "jane@gmail.com");
    }
    public string stripePublishableKey = WebConfigurationManager.AppSettings["StripePublishableKey"];

    protected void btn_stripe_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Invoice.aspx");
    }
}