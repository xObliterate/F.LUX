using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Checkout : System.Web.UI.Page
{
    Account acc = new Account();
    Address add = null;
    Order order = new Order();
    Payment pay = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        acc = (Account)Session["Id"];
        if (acc == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "msgbox", "alert('Session timeout');window.location = 'Index.aspx';", true);
        }
        else
        {
            Address address = new Address();
            Payment p = new Payment();
            int cID = acc.gsID;

            add = address.getAddress(cID);
            if (add != null)
            {
                lbl_address.Text = string.Format("Ship to<br/> <b>{0}</b> <br/>{1} <br/>Singapore - {2} <br/>{3}", add.gsAddName, add.gsAddInfo.ToUpper(), add.gsAddPostal, add.gsAddPhone);
            }

            pay = p.getPaymentInfo(cID);
            if (pay != null)
            {
                paymentPanel.Visible = false;
                string cc = pay.gscc;
                cc = cc.Replace(cc.Substring(3, 10), "**********");
                string cvv = pay.gscvv.ToString();
                cvv = cvv.Replace(cvv.Substring(1, 2), "**");

                lbl_payment.Text = string.Format("CC No: <strong>{0}</strong> <br/> Expiry: <strong>{1}</strong> <br/> Name: <strong>{2}</strong> <br/> CVV: <strong>{3}</strong> <br/>", cc, pay.gsexpiry, pay.gsname.ToUpper(), cvv);
            }
            else
            {
                btn_pay.Visible = false;
            }

            order = (Order)Session["order"];

            //List<Product> prodlist = (List<Product>)Session["o"];
            //var list = (List<Product>)Session["o"];
            //IEnumerable<Product> a = Session["o"] as IEnumerable<Product>;
            //foreach (Product p in prodlist)
            //{
            //    lbl_summary.Text = string.Format("{0} <br/> {1} <br/> {2}", p.gsProdName, p.gsQuantity, p.gsPrice);
            //}

            lbl_summary.Text = string.Format("{0} <br/> Shipping Fee ${1} <br/> {2}", order.gssubtotal, order.gsshippingfee, order.gstotal);
        }


    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Payment p = new Payment(tb_CardNumber.Text, tb_CardName.Text, tb_ExpMonth.Text, int.Parse(tb_Cvv.Text));
            int cID = acc.gsID;
            p.insertPayment(cID);
            InputValidation.ClearInputs(this.Controls);
            Response.Redirect(Request.RawUrl);
        }
    }

    protected void btn_pay_Click(object sender, EventArgs e)
    {
        int cID = acc.gsID;
        order.insertOrder(cID, add.gsAbID, decimal.Parse(order.gsshippingfee));

        //iterate product properties
       // order.insertOrderProduct();
    }

    protected void ccVlidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (InputValidation.ValidateCC(args.Value) == true)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }

    protected void expiryValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (InputValidation.IsValidExpiration(args.Value) == true)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }

    protected void cvvValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (InputValidation.IsValidCvv(args.Value) == true)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }
}