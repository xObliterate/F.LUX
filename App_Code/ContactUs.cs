using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for ContactUs
/// </summary>
public class ContactUs
{
    private string connStr = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;
    private string name, email, message, adminreply;
    private int status, id;

    public ContactUs()
    {

    }
    public int gsid
    {
        get { return id; }
        set { id = value; }
    }

    public string gsname
    {
        get { return name; }
        set { name = value; }
    }

    public string gsemail
    {
        get { return email; }
        set { email = value; }
    }

    public string gsmessage
    {
        get { return message; }
        set { message = value; }
    }

    public string gsadminreply
    {
        get { return adminreply; }
        set { adminreply = value; }
    }

    public int gsstatus
    {
        get { return status; }
        set { status = value; }
    }

    public ContactUs(string name, string email, string message)
    {
        this.name = name;
        this.email = email;
        this.message = message;
    }

    public ContactUs(int id, string name, string email, string message)
    {
        this.id = id;
        this.name = name;
        this.email = email;
        this.message = message;
    }

    public int insertEnquiry()
    {
        int result = 0;

        string queryStr = "INSERT INTO ContactUs(name, email, message) VALUES(@name, @email, @message)";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@name", this.name);
        cmd.Parameters.AddWithValue("@email", this.email);
        cmd.Parameters.AddWithValue("@message", this.message);

        con.Open();
        result += cmd.ExecuteNonQuery();
        con.Close();
        return result;
    }

    public List<ContactUs> getAllEnquiry()
    {
        List<ContactUs> csList = new List<ContactUs>();
        string name, email, message;
        int id;

        string queryStr = "SELECT csId, name, email, message FROM ContactUs WHERE status = 0";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        while (dr.Read())
        {
            id = int.Parse(dr["csId"].ToString());
            name = dr["name"].ToString();
            email = dr["email"].ToString();
            message = dr["message"].ToString();
            ContactUs cs = new ContactUs(id, name, email, message);
            csList.Add(cs);
        }
        con.Close();
        dr.Close();
        dr.Dispose();
        return csList;
    }

    public int updateEnquiry(string adminreply, int id )
    {
        int result = 0;

        string queryStr = "UPDATE ContactUs SET status = 1, adminReply = @adminReply WHERE csId = @csId";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@adminReply", adminreply);
        cmd.Parameters.AddWithValue("@csId", id);
        con.Open();
        result = cmd.ExecuteNonQuery();
        con.Close();
        return result;
    }
}