using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;

/// <summary>
/// Summary description for Account
/// </summary>
public class Account
{
    private string connStr = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;

    private string email = "", phone = "", fName = "", lName = "", storeName = "", fax = "";
    private int id = 0;

    public Account()
    {

    }
    public Account(string email)
    {
        this.email = email;
    }

    public Account(string email, string phone)
    {
        this.email = email;
        this.phone = phone;
    }

    public Account(string email, string phone, int id, string fName, string lName)
    {
        this.email = email;
        this.phone = phone;
        this.id = id;
        this.fName = fName;
        this.lName = lName;
    }


    public Account(string email, string phone, string storeName, int id, string fax)
    {
        this.email = email;
        this.phone = phone;
        this.storeName = storeName;
        this.id = id;
        this.fax = fax;
    }

    public int gsID
    {
        get { return id; }
        set { id = value; }
    }

    public string gsEmail
    {
        get { return email; }
        set { email = value; }
    }

    public string gsPhone
    {
        get { return phone; }
        set { phone = value; }
    }

    public string gsFname
    {
        get { return fName; }
        set { fName = value; }
    }

    public string gsLname
    {
        get { return lName; }
        set { lName = value; }
    }

    public string gsStoreName
    {
        get { return storeName; }
        set { storeName = value; }
    }

    public string gsFax
    {
        get { return fax; }
        set { fax = value; }
    }

    public void updateProfile(string email, string phone, int id, string fname, string lname)
    {
        var page = HttpContext.Current.CurrentHandler as Page;
        string queryStr = "";
        queryStr = "UPDATE Account SET phone = @phone WHERE email = @email";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@email", email);
        cmd.Parameters.AddWithValue("@phone", phone);
        con.Open();
        cmd.ExecuteNonQuery();

        queryStr = "UPDATE Customer SET fName = @fName, lName = @lName WHERE cID = @cID";
        cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@cID", id);
        cmd.Parameters.AddWithValue("@fName", fname);
        cmd.Parameters.AddWithValue("@lName", lname);
        cmd.ExecuteNonQuery();
        con.Close();

        ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "msgbox", "alert('Update successful');window.location = '/Profile/UserProfile.aspx';", true);
    }

    public int updatePassword(string email, string pass)
    {
        string queryStr = "UPDATE Account SET password = @password WHERE email = @email";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@email", email);

        string saltHashReturned = PasswordHash.CreateHash(pass);
        int commaIndex = saltHashReturned.IndexOf(":");
        string extractedString = saltHashReturned.Substring(0, commaIndex);
        commaIndex = saltHashReturned.IndexOf(":");
        extractedString = saltHashReturned.Substring(commaIndex + 1);
        commaIndex = extractedString.IndexOf(":");
        string salt = extractedString.Substring(0, commaIndex);

        commaIndex = extractedString.IndexOf(":");
        extractedString = extractedString.Substring(commaIndex + 1);
        string hash = extractedString;

        cmd.Parameters.AddWithValue("@password", saltHashReturned);
        con.Open();
        int nOfRow = 0;
        nOfRow = cmd.ExecuteNonQuery();
        con.Close();
        return nOfRow;
    }

    public void resetPassword(string email)
    {
        string fname;

        SqlConnection con = new SqlConnection(connStr);
        string queryStr = "SELECT acc.email, acc.password, cus.fName FROM Account acc INNER JOIN Customer cus ON cus.cID = acc.Id WHERE email = @email";
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@email", email);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            fname = dr["fName"].ToString();
            SendMail.sendPasswordResetEmail(email, fname);
        }
        con.Close();
        dr.Close();
        dr.Dispose();
    }

    public Account loginAdmin(string login, string pass)
    {
        Account acc = null;
        string email, password;

        string queryStr = "SELECT email, password FROM Account where email = @email";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@email", login);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            email = dr["email"].ToString();
            password = dr["password"].ToString();
            if (pass == password)
            {
                acc = new Account(email);
                HttpContext.Current.Session.RemoveAll();
                HttpContext.Current.Session["admin"] = acc;
                HttpContext.Current.Response.BufferOutput = true;
                HttpContext.Current.Response.Redirect("/Profile/adminProfile.aspx");
            }
            else
            {
                HttpContext.Current.Response.Write("<script>alert('Wrong password');</script>");
            }
        }
        else
        {
            acc = null;
        }
        con.Close();
        dr.Close();
        dr.Dispose();
        return acc;
    }

    public Account loginSeller(string login, string password)
    {
        Account acc = null;
        string email, hashpassword, phone, storeName, fax;
        int sID;

        SqlConnection con = new SqlConnection(connStr);
        string queryStr = "SELECT acc.email, acc.password, acc.phone, sel.* FROM Account acc INNER JOIN Seller sel ON sel.sID = acc.Id WHERE acc.email = @email";
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@email", login);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        if (!dr.HasRows)
        {
            HttpContext.Current.Response.Write("<script>alert('Email does not exist');</script");
        }
        else
        {
            if (dr.Read())
            {
                email = dr["email"].ToString();
                hashpassword = dr["password"].ToString();
                phone = dr["phone"].ToString();
                sID = int.Parse(dr["sID"].ToString());
                storeName = dr["name"].ToString();
                fax = dr["fax"].ToString();
                bool validUser = PasswordHash.ValidatePassword(password, hashpassword);
                if (validUser == true)
                {
                    acc = new Account(email, phone, storeName, sID, fax);
                    HttpContext.Current.Session.RemoveAll();
                    HttpContext.Current.Session["sellerId"] = acc;
                    HttpContext.Current.Response.BufferOutput = true;
                    HttpContext.Current.Response.Redirect("/Profile/SellerProfile.aspx");
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>alert('Wrong password');</script>");
                }
            }
            else
            {
                acc = null;
            }
            con.Close();
            dr.Close();
            dr.Dispose();
        }
        return acc;
    }

    public Account loginUser(string login, string password)
    {
        Account acc = null;
        string email, hashpassword, phone, fname, lname;
        int cID;

        SqlConnection con = new SqlConnection(connStr);
        string queryStr = "SELECT acc.email, acc.password, acc.phone, cus.* FROM Account acc INNER JOIN Customer cus ON cus.cID = acc.Id WHERE acc.email = @email";
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@email", login);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        if (!dr.HasRows)
        {
            HttpContext.Current.Response.Write("<script>alert('Email does not exist');</script");
        }
        else
        {
            if (dr.Read())
            {
                email = dr["email"].ToString();
                hashpassword = dr["password"].ToString();
                phone = dr["phone"].ToString();
                cID = int.Parse(dr["cID"].ToString());
                fname = dr["fName"].ToString();
                lname = dr["lName"].ToString();
                bool validUser = PasswordHash.ValidatePassword(password, hashpassword);
                if (validUser == true)
                {
                    acc = new Account(email, phone, cID, fname, lname);
                    HttpContext.Current.Session.RemoveAll();
                    HttpContext.Current.Session["Id"] = acc;
                    HttpContext.Current.Response.BufferOutput = true;
                    HttpContext.Current.Response.Redirect("/Profile/UserProfile.aspx");
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>alert('Wrong password');</script>");
                }
            }
            else
            {
                acc = null;
            }
            con.Close();
            dr.Close();
            dr.Dispose();
        }
        return acc;
    }

    public void regSeller(string email, string pass, string phone, string storeName, string fax)
    {
        var page = HttpContext.Current.CurrentHandler as Page;
        string queryStr = "";

        SqlConnection con = new SqlConnection(connStr);
        con.Open();
        queryStr = "SELECT email from Account WHERE email = @email";
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@email", email);

        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            HttpContext.Current.Response.Write("<script>alert('Email exist');</script>");
        }
        else
        {
            dr.Close();
            dr.Dispose();

            queryStr = "INSERT INTO Account (email, password, accType, phone)"
                + "VALUES(@email, @password, 2, @phone)" + "INSERT INTO Seller (sID, name, fax) VALUES((SELECT COUNT(*) FROM Account), @storeName, @fax)";

            cmd = new SqlCommand(queryStr, con);
            cmd.Parameters.AddWithValue("@email", email);

            // First ":" to second is the salt
            // Second ":" to the end is the hash
            string saltHashReturned = PasswordHash.CreateHash(pass);
            int commaIndex = saltHashReturned.IndexOf(":");
            string extractedString = saltHashReturned.Substring(0, commaIndex);
            commaIndex = saltHashReturned.IndexOf(":");
            extractedString = saltHashReturned.Substring(commaIndex + 1);
            commaIndex = extractedString.IndexOf(":");
            string salt = extractedString.Substring(0, commaIndex);

            commaIndex = extractedString.IndexOf(":");
            extractedString = extractedString.Substring(commaIndex + 1);
            string hash = extractedString;

            cmd.Parameters.AddWithValue("@password", saltHashReturned);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@storeName", storeName);
            cmd.Parameters.AddWithValue("@fax", fax);
            cmd.ExecuteNonQuery();
            con.Close();

            ScriptManager.RegisterClientScriptBlock(page, GetType(), "msgbox", "alert('Register successful');window.location = '/Login/sellerLogin.aspx';", true);
            SendMail.sendRegistrationEmail(email, storeName, pass);
        }
    }

    public void regUser(string email, string pass, string phone, string fname, string lname)
    {
        var page = HttpContext.Current.CurrentHandler as Page;
        string queryStr = "";

        SqlConnection con = new SqlConnection(connStr);
        con.Open();
        queryStr = "SELECT email from Account WHERE email = @email";
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@email", email);

        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            HttpContext.Current.Response.Write("<script>alert('Email exist');</script>");
        }
        else
        {
            dr.Close();
            dr.Dispose();

            queryStr = "INSERT INTO Account (email, password, accType, phone)"
                + "VALUES(@email, @password, 1, @phone)" + "INSERT INTO Customer (cID, fName, lName) VALUES((SELECT COUNT(*) FROM Account), @fName, @lName)";

            cmd = new SqlCommand(queryStr, con);
            cmd.Parameters.AddWithValue("@email", email);

            // First ":" to second is the salt
            // Second ":" to the end is the hash
            string saltHashReturned = PasswordHash.CreateHash(pass);
            int commaIndex = saltHashReturned.IndexOf(":");
            string extractedString = saltHashReturned.Substring(0, commaIndex);
            commaIndex = saltHashReturned.IndexOf(":");
            extractedString = saltHashReturned.Substring(commaIndex + 1);
            commaIndex = extractedString.IndexOf(":");
            string salt = extractedString.Substring(0, commaIndex);

            commaIndex = extractedString.IndexOf(":");
            extractedString = extractedString.Substring(commaIndex + 1);
            string hash = extractedString;

            cmd.Parameters.AddWithValue("@password", saltHashReturned);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@fName", fname);
            cmd.Parameters.AddWithValue("@lName", lname);
            cmd.ExecuteNonQuery();
            con.Close();

            ScriptManager.RegisterClientScriptBlock(page, GetType(), "msgbox", "alert('Register successful');window.location = '/Login/Login.aspx';", true);
            SendMail.sendRegistrationEmail(email, fname, pass);
        }
    }
}
