using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for Favourites
/// </summary>
public class Favourites
{
    private string connStr = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;
    private int cid, favid;
    private string prodID;

    public int gsID
    {
        get { return cid; }
        set { cid = value; }
    }

    public int gsfavID
    {
        get { return favid; }
        set { favid = value; }
    }

    public string gsprodID
    {
        get { return prodID; }
        set { prodID = value; }
    }

    public Favourites()
    {
    }

    public Favourites(int favid)
    {
        this.favid = favid;
    }

    public Favourites(string prodID, int favid)
    {
        this.favid = favid;
        this.prodID = prodID;
    }

    public Favourites(int cid, string prodID)
    {
        this.cid = cid;
        this.prodID = prodID;
    }

    public int insertFavourite()
    {
        int result = 0;

        string queryStr = "INSERT INTO Favourites(cID, pID) VALUES(@cID, @pID)";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@cID", this.cid);
        cmd.Parameters.AddWithValue("@pID", this.prodID);
        con.Open();
        result = cmd.ExecuteNonQuery();
        con.Close();
        return result;
    }

    public int deleteFavourite(string pid, int cid)
    {
        string queryStr = "DELETE FROM Favourites WHERE pID = @pID AND cID = @cID";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@pID", pid);
        cmd.Parameters.AddWithValue("@cID", cid);
        con.Open();
        int nOfRow = 0;
        nOfRow = cmd.ExecuteNonQuery();
        return nOfRow;
    }

    public Favourites getFavourite(string pid, int cid)
    {
        Favourites fav = null;
        int favID;

        string queryStr = "SELECT favId FROM Favourites WHERE pID = @pID AND cID = @cID";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@pID", pid);
        cmd.Parameters.AddWithValue("@cID", cid);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.HasRows && dr.Read())
        {
            favID = int.Parse(dr["favId"].ToString());
            fav = new Favourites(favid);
        }
        else
        {
            fav = null;
        }
        con.Close();
        dr.Close();
        dr.Dispose();
        return fav;
    }

    public List<Favourites> getAllFavourites(int id)
    {
        List<Favourites> favList = new List<Favourites>() ;
        string prodID;
        int favid;

        string queryStr = "SELECT favId, pID FROM Favourites WHERE cID = @cID";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@cID", id);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        while (dr.Read())
        {
            prodID = dr["pID"].ToString();
            favid = int.Parse(dr["favId"].ToString());

            Favourites fav = new Favourites(prodID, favid);
            favList.Add(fav);
        }
        con.Close();
        dr.Close();
        dr.Dispose();
        return favList;
    }
}