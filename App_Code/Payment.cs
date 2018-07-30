using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for Payment
/// </summary>
public class Payment
{
    private string connStr = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;
    private string cc, name, expiry;
    private int cvv;

    public string gscc
    {
        get { return cc; }
        set { cc = value; }
    }

    public string gsname
    {
        get { return name; }
        set { name = value; }
    }

    public string gsexpiry
    {
        get { return expiry; }
        set { expiry = value; }
    }

    public int gscvv
    {
        get { return cvv; }
        set { cvv = value; }
    }
    public Payment()
    {
    }

    public Payment(string cc, string name, string expiry, int cvv)
    {
        this.cc = cc;
        this.name = name;
        this.expiry = expiry;
        this.cvv = cvv;
    }

    public int insertPayment(int id)
    {
        int result = 0;

        string queryStr = "INSERT INTO Payment(cc, expiry, name, cvv, cID) VALUES(@cc, @expiry, @name, @cvv, @cID)";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@cc", this.cc);
        cmd.Parameters.AddWithValue("@expiry", this.expiry);
        cmd.Parameters.AddWithValue("@name", this.name);
        cmd.Parameters.AddWithValue("@cvv", this.cvv);
        cmd.Parameters.AddWithValue("@cID", id);
        con.Open();
        result += cmd.ExecuteNonQuery();
        con.Close();

        return result;
    }

    public Payment getPaymentInfo(int id)
    {
        Payment pay = null;
        string cc, expiry, name;
        int cvv;

        string queryStr = "SELECT * FROM Payment WHERE cID = @cID";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@cID", id);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.HasRows && dr.Read())
        {
            cc = dr["cc"].ToString();
            expiry = dr["expiry"].ToString();
            name = dr["name"].ToString();
            cvv = int.Parse(dr["cvv"].ToString());

            pay = new Payment(cc, name, expiry, cvv);
        }
        else
        {
            pay = null;
        }
        con.Close();
        dr.Close();
        dr.Dispose();
        return pay;
    }
}