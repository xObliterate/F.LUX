using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Globalization;

public partial class Showroom : System.Web.UI.Page
{
    Account acc = new Account();
    Showrooms showr = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        btn_3.BackColor = Color.Gray;
        btn_6.BackColor = Color.Gray;
        btn_9.BackColor = Color.Gray;
        btn_12.BackColor = Color.Gray;
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            acc = (Account)Session["Id"];
            int slot = 0;
            switch (lbl_slot.Text)
            {
                case "9AM":
                    slot = 1;
                    break;
                case "12PM":
                    slot = 2;
                    break;
                case "3PM":
                    slot = 3;
                    break;
                case "6PM":
                    slot = 4;
                    break;
            }
            DateTime d = DateTime.Parse(lbl_date.Text);
            Showrooms sr = new Showrooms();
            showr = sr.getBooking(slot, d);
            lbl_msg.Visible = true;
            if (showr != null)
            {
                lbl_msg.Text = "Slot is already taken";
            }
            else
            {
                sr = new Showrooms(acc.gsID, slot, int.Parse(tb_pax.Text), d);
                sr.insertShowroom();
                InputValidation.ClearInputs(this.Controls);
                lbl_date.Text = "";
                lbl_slot.Text = "";
                lbl_msg.Text = "Booking Success!";
            }
        }
    }

    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.Date.CompareTo(DateTime.Today) < 1)
        {
            e.Day.IsSelectable = false;
            e.Cell.ForeColor = System.Drawing.Color.Red;
            e.Cell.Font.Strikeout = true;
        }
    }

    protected void btn_9_Click(object sender, EventArgs e)
    {
        btn_9.BackColor = Color.Goldenrod;
        lbl_slot.Text = string.Format("9AM");
    }

    protected void btn_12_Click(object sender, EventArgs e)
    {
        btn_12.BackColor = Color.Goldenrod;
        lbl_slot.Text = string.Format("12PM");
    }

    protected void btn_3_Click(object sender, EventArgs e)
    {
        btn_3.BackColor = Color.Goldenrod;
        lbl_slot.Text = string.Format("3PM");
    }

    protected void btn_6_Click(object sender, EventArgs e)
    {
        btn_6.BackColor = Color.Goldenrod;
        lbl_slot.Text = string.Format("6PM");
    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        lbl_date.Text = string.Format("{0}", Calendar1.SelectedDate.ToShortDateString());
    }
}