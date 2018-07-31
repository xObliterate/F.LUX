using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;



//IEquatable - type-specific to determine the equality of Instances
public class ShoppingCartItem : IEquatable<ShoppingCartItem>
{
    string connStr = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;
    public int Quantity { get; set; }

    private string _ItemID;
    public string ItemID
    {
        get { return _ItemID; }
        set { _ItemID = value; }
    }

    private string _ItemName;
    public string Product_Name
    {
        get { return _ItemName; }
        set { _ItemName = value; }
    }

    private string _ItemDesc;
    public string Product_Desc
    {
        get { return _ItemDesc; }
        set { _ItemDesc = value; }

    }

    private string _Product_Image;
    public string Product_Image
    {
        get { return _Product_Image; }
        set { _Product_Image = value; }
    }

    private decimal _ItemPrice;
    public decimal Product_Price
    {
        get { return _ItemPrice; }
        set { _ItemPrice = value; }
    }

    private int _ItemQuantity;
    public int Product_Quantity
    {
        get { return _ItemQuantity; }
        set { _ItemQuantity = value; }
    }

    private decimal _ItemFinalPrice;
    public decimal Product_FinalPrice
    {
        get { return _ItemFinalPrice; }
        set { _ItemFinalPrice = value; }
    }

    public decimal TotalPrice
    {
        get { return Product_Price * Quantity; }
    }

    public ShoppingCartItem(string productID)
    {
        this.ItemID = productID;
    }

    public ShoppingCartItem(string productID, Product prod)
    {
        this.ItemID = productID;
        this.Product_Name = prod.gsProdName;
        this.Product_Desc = prod.gsShortDesc;
        this.Product_Price = prod.gsPrice;
        this.Product_Image = "~/img/" + prod.gsImage;
    }

    public ShoppingCartItem(string productID, string productName, string productDesc, decimal productPrice)
    {
        this.ItemID = productID;
        this.Product_Name = productName;
        this.Product_Desc = productDesc;
        this.Product_Price = productPrice;
    }

    public ShoppingCartItem(string productID, int quantity, decimal finalPrice)
    {
        this.ItemID = productID;
        this.Product_Quantity = quantity;
        this.Product_FinalPrice = finalPrice;
    }

    private int cID;
    public ShoppingCartItem(int cID, string productID, int quantity, decimal finalPrice)
    {
        this.cID = cID;
        this.ItemID = productID;
        this.Product_Quantity = quantity;
        this.Product_FinalPrice = finalPrice;
    }

    public bool Equals(ShoppingCartItem anItem)
    {
        return anItem.ItemID == this.ItemID;
    }

    public ShoppingCartItem()
    {

    }

    public int insertCart(int id, string prodID, decimal total)
    {
        int result = 0;
        string queryStr = "INSERT INTO CustomerCart(cID, pID, quantity, finalPrice) VALUES(@cID, @pID, @quantity, @finalPrice)";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@cID", id);
        cmd.Parameters.AddWithValue("@pID", prodID);
        cmd.Parameters.AddWithValue("@quantity", 1);
        cmd.Parameters.AddWithValue("@finalPrice", total);
        con.Open();
        result += cmd.ExecuteNonQuery();
        con.Close();
        return result;
    }

    public ShoppingCartItem getCartItem(int id, string prodID)
    {
        ShoppingCartItem sc = null;
        int cid, quantity;
        string pid;
        decimal price;

        string queryStr = "SELECT cID, pID, quantity, finalPrice FROM CustomerCart WHERE cID = @cID AND pID = @pID";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@cID", id);
        cmd.Parameters.AddWithValue("@pID", prodID);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows && dr.Read())
        {
            cid = int.Parse(dr["cID"].ToString());
            pid = dr["pID"].ToString();
            quantity = int.Parse(dr["quantity"].ToString());
            price = decimal.Parse(dr["finalPrice"].ToString());

            sc = new ShoppingCartItem(cid, pid, quantity, price);
        }
        else
        {
            sc = null;
        }
        con.Close();
        dr.Close();
        dr.Dispose();
        return sc;
    }

    public List<ShoppingCartItem> getAllCartItem(int id)
    {
        List<ShoppingCartItem> scList = new List<ShoppingCartItem>();
        string pID;
        int quantity;
        decimal price;

        string queryStr = "SELECT pID, quantity, finalPrice FROM CustomerCart WHERE cID = @cID";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@cID", id);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        while (dr.Read())
        {
            pID = dr["pID"].ToString();
            quantity = int.Parse(dr["quantity"].ToString());
            price = decimal.Parse(dr["finalPrice"].ToString());

            ShoppingCartItem sc = new ShoppingCartItem(pID, quantity, price);
            scList.Add(sc);
        }
        con.Close();
        dr.Close();
        dr.Dispose();

        return scList;
    }

    public int updateCart(int id, int pid, int quantity, decimal finalprice)
    {
        string queryStr = "UPDATE CustomerCart SET quantity = @quantity, finalPrice = @finalPrice WHERE cID = @cID AND pID = @pID";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@cID", id);
        cmd.Parameters.AddWithValue("@pID", pid);
        cmd.Parameters.AddWithValue("@quantity", quantity + 1);
        cmd.Parameters.AddWithValue("@finalPrice", finalprice);

        con.Open();
        int nOfRow = 0;
        nOfRow = cmd.ExecuteNonQuery();
        con.Close();

        return nOfRow;
    }
}