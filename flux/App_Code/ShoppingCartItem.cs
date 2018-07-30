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

    public bool Equals(ShoppingCartItem anItem)
    {
        return anItem.ItemID == this.ItemID;
    }

    public ShoppingCartItem()
    {

    }
    //public int insertCart(int id, string prodID, int quantity, decimal total)
    //{
    //    int result = 0;

    //    string queryStr = "INSERT INTO CustomerCart(cID, pID, quantity, finalPrice) VALUES(@cID, @pID, @quantity, @finalPrice)";
    //    SqlConnection con = new SqlConnection(connStr);
    //    SqlCommand cmd = new SqlCommand(queryStr, con);

    //    cmd.Parameters.AddWithValue("@cID", id);
    //    cmd.Parameters.AddWithValue("@pID", prodID);
    //    cmd.Parameters.AddWithValue("@quantity", quantity);
    //    cmd.Parameters.AddWithValue("@finalPrice", total);

    //    con.Open();
    //    result += cmd.ExecuteNonQuery();
    //    con.Close();
    //    return result;
    //}
}