﻿using System;
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
            Response.Redirect("/Login/Login.aspx");
            //Page.ClientScript.RegisterClientScriptBlock(GetType(), "msgbox", "alert('Please Login To Checkout');window.location = 'Index.aspx';", true);
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

            //IEnumerable<Product> a = Session["o"] as IEnumerable<Product>;

            //List<Product> prodlist = (List<Product>)Session["o"];
            //foreach (Product pd in prodlist)
            //{
            //     lbl_summary.Text += string.Format("{0} <br/> {1} <br/> {2}", pd.gsProdName, pd.gsQuantity, pd.gsPrice);
            //    lbl_prodname.Text += string.Format("{0},", pd.gsProdName);
            //    lbl_prodquantity.Text += string.Format(" {0},", pd.gsQuantity);
            //    lbl_prodprice.Text += string.Format("{0},", pd.gsPrice);
            //}

            lbl_summary.Text = string.Format("Subtotal({0} items) <strong>${1}</strong> <br/> Shipping Fee <strong>${2}</strong> <br/> Total Price <strong><span style='color:#EF6C00'>${3}</span></strong>", order.gscount, order.gssubtotal, order.gsshippingfee, order.gssubtotal + order.gsshippingfee);
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
        ShoppingCartItem sc = new ShoppingCartItem();
        int cID = acc.gsID;

        order.insertOrder(cID, add.gsAbID, order.gsshippingfee);

        List<Product> pList = new List<Product>();
        pList = (List<Product>)Session["o"];

        foreach (Product p in pList)
        {
            int pid = int.Parse(p.gsProdID);
            order.insertOrderProduct(pid, p.gsPrice, p.gsQuantity, p.gsPrice * p.gsQuantity);
        }
        sc.deleteAllCart(cID);
        Response.Redirect("Invoice.aspx");
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