using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for Showroom
/// </summary>
public class Showrooms
{
    private string connStr = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;
    private int cid, slot, pax, showid;
    DateTime date;
    string fname, lname;

    public Showrooms()
    {

    }

    public string gsfname
    {
        get { return fname; }
        set { fname = value; }
    }

    public string gslname
    {
        get { return lname; }
        set { lname = value; }
    }

    public int gsshowid
    {
        get { return showid; }
        set { showid = value; }
    }

    public int gsid
    {
        get { return cid; }
        set { cid = value; }
    }

    public int gsslot
    {
        get { return slot; }
        set { slot = value; }
    }

    public int gspax
    {
        get { return pax; }
        set { pax = value; }
    }

    public DateTime gsdate
    {
        get { return date; }
        set { date = value; }
    }

    public Showrooms(int slot, DateTime date)
    {
        this.slot = slot;
        this.date = date;
    }

    public Showrooms(int cid, int slot, int pax, DateTime date)
    {
        this.cid = cid;
        this.slot = slot;
        this.pax = pax;
        this.date = date;
    }

    public Showrooms(int showid, int slot, int pax, DateTime date, string fname, string lname)
    {
        this.showid = showid;
        this.slot = slot;
        this.pax = pax;
        this.date = date;
        this.fname = fname;
        this.lname = lname;
    }

    public List<Showrooms> getAllShowroom()
    {
        List<Showrooms> slist = new List<Showrooms>();
        string fname, lname;
        int showid, slot, pax;
        DateTime date;

        string queryStr = "SELECT s.*, c.fName, c.lName FROM Showroom s INNER JOIN Customer c ON s.cID = c.cID";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        while (dr.Read())
        {
            showid = int.Parse(dr["showId"].ToString());
            slot = int.Parse(dr["slot"].ToString());
            pax = int.Parse(dr["pax"].ToString());
            date = DateTime.Parse(dr["date"].ToString());
            fname = dr["fName"].ToString();
            lname = dr["lName"].ToString();

            Showrooms s = new Showrooms(showid, slot, pax, date, fname, lname);
            slist.Add(s);
        }
        con.Close();
        dr.Close();
        dr.Dispose();
        return slist;
    }

    public Showrooms getBooking(int s, DateTime d)
    {
        Showrooms sr = null;
        int slot;
        DateTime date;

        string queryStr = "SELECT * FROM Showroom WHERE slot = @slot AND date = @date";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@slot", s);
        cmd.Parameters.AddWithValue("@date", d);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.HasRows && dr.Read())
        {
            slot = int.Parse(dr["slot"].ToString());
            date = DateTime.Parse(dr["date"].ToString());

            sr = new Showrooms(slot, date);
        }
        else
        {
            sr = null;
        }
        con.Close();
        dr.Close();
        dr.Dispose();
        return sr;
    }

    public int insertShowroom()
    {
        int result = 0;

        string queryStr = "INSERT INTO Showroom(cID, slot, pax, date) VALUES(@cID, @slot, @pax, @date)";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@cID", this.cid);
        cmd.Parameters.AddWithValue("@slot", this.slot);
        cmd.Parameters.AddWithValue("@pax", this.pax);
        cmd.Parameters.AddWithValue("@date", this.date);
        con.Open();
        result += cmd.ExecuteNonQuery();
        con.Close();
        return result;
    }
}