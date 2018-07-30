using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for Address
/// </summary>
public class Address
{
    private string connStr = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;

    private string addName = "", addInfo = "", addPostal = "", addPhone = "";
    private int abID = 0, cusID = 0;

    public Address()
    {

    }

    public Address(string addName, string addInfo, string addPostal, string addPhone)
    {
        this.addName = addName;
        this.addInfo = addInfo;
        this.addPostal = addPostal;
        this.addPhone = addPhone;
    }

    public Address(int abID, int cusID, string addName, string addInfo, string addPostal, string addPhone)
    {
        this.abID = abID;
        this.cusID = cusID;
        this.addName = addName;
        this.addInfo = addInfo;
        this.addPostal = addPostal;
        this.addPhone = addPhone;
    }

    public string gsAddName
    {
        get { return addName; }
        set { addName = value; }
    }

    public string gsAddInfo
    {
        get { return addInfo; }
        set { addInfo = value; }
    }

    public string gsAddPostal
    {
        get { return addPostal; }
        set { addPostal = value; }
    }

    public string gsAddPhone
    {
        get { return addPhone; }
        set { addPhone = value; }
    }

    public int gsAbID
    {
        get { return abID; }
        set { abID = value; }
    }

    public int gsCusID
    {
        get { return cusID; }
        set { cusID = value; }
    }

    public void removePrimaryAddress(int id)
    {
        string queryStr = "UPDATE AddressBook SET primaryAddress = NULL WHERE cID = @cID";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@cID", id);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }

    public void setPrimaryAddress(int id, string postal)
    {
        string queryStr = "UPDATE AddressBook SET primaryAddress = 1 WHERE cID = @cID AND aPostal = @aPostal";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@cID", id);
        cmd.Parameters.AddWithValue("@aPostal", postal);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }

    public Address getAddress(int id)
    {
        Address address = null;

        string name, add, postal, phone;

        string queryStr = "SELECT aName, aInfo, aPostal, aPhone FROM AddressBook WHERE cID = @cID AND primaryAddress = 1";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@cID", id);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            name = dr["aName"].ToString();
            add = dr["aInfo"].ToString();
            postal = dr["aPostal"].ToString();
            phone = dr["aPhone"].ToString();
            address = new Address(name, add, postal, phone);
        }
        else
        {
            address = null;
        }
        con.Close();
        dr.Close();
        dr.Dispose();
        return address;
    }

    public List<Address> getAddressAll(int id)
    {
        List<Address> addDetail = new List<Address>();
        string addName, addInfo, addPostal, addPhone;
        int abID, cID;

        string queryStr = "SELECT * FROM AddressBook WHERE cID = @cID";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@cID", id);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        while (dr.Read())
        {
            abID = int.Parse(dr["aBookId"].ToString());
            cID = int.Parse(dr["cID"].ToString());
            addName = dr["aName"].ToString();
            addInfo = dr["aInfo"].ToString();
            addPostal = dr["aPostal"].ToString();
            addPhone = dr["aPhone"].ToString();

            Address add = new Address(abID, cID, addName, addInfo, addPostal, addPhone);
            addDetail.Add(add);
        }
        con.Close();
        dr.Close();
        dr.Dispose();

        return addDetail;
    }

    public int insertAddress(int id)
    {
        int result = 0;

        string queryStr = "INSERT INTO AddressBook(cID, aName, aInfo, aPostal, aPhone)" + "VALUES(@cID, @aName, @aInfo, @aPostal, @aPhone)";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);

        cmd.Parameters.AddWithValue("@cID", id);
        cmd.Parameters.AddWithValue("@aName", this.addName);
        cmd.Parameters.AddWithValue("@aInfo", this.addInfo);
        cmd.Parameters.AddWithValue("@aPostal", this.addPostal);
        cmd.Parameters.AddWithValue("@aPhone", this.addPhone);

        con.Open();
        result += cmd.ExecuteNonQuery();
        con.Close();

        return result;
    }

    public int removeAddress(string id)
    {
        string queryStr = "DELETE FROM AddressBook WHERE aBookId = @id";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@id", id);
        con.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        con.Close();
        return nofRow;
    }

    public int updateAddress(string id, string name, string address, string postal, string phone)
    {
        string queryStr = "UPDATE AddressBook SET aName = @aName, aInfo = @aInfo, aPostal = @aPostal, aPhone = @aPhone WHERE aBookId = @id";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@aName", name);
        cmd.Parameters.AddWithValue("@aInfo", address);
        cmd.Parameters.AddWithValue("@aPostal", postal);
        cmd.Parameters.AddWithValue("@aPhone", phone);

        con.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        con.Close();
        return nofRow;
    }
}
