using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for Order
/// </summary>
public class Order
{
    private string connStr = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;
    private decimal subtotal, shippingfee;
    private int count;

    public Order()
    {

    }

    public decimal gssubtotal
    {
        get { return subtotal; }
        set { subtotal = value; }
    }

    public decimal gsshippingfee
    {
        get { return shippingfee; }
        set { shippingfee = value; }
    }

    public int gscount
    {
        get { return count; }
        set { count = value; }
    }

    public Order(decimal subtotal, decimal shippingfee, int count)
    {
        this.subtotal = subtotal;
        this.shippingfee = shippingfee;
        this.count = count;
    }

    public int insertOrder(int id, int abookid, decimal shipfee)
    {
        //Order status
        // 0 = pending, 1 = received, 2 = shipping, 3 = delivered
        int result = 0;

        string queryStr = "INSERT INTO [Order] (cID, aBookId, payment, orderDate, shipFee) VALUES(@cID, (SELECT aBookId FROM AddressBook WHERE cID = @cID and primaryAddress = 1), (SELECT paymentID FROM Payment WHERE cID = @cID), @orderDate, @shipFee)";

        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);

        cmd.Parameters.AddWithValue("@cID", id);
        cmd.Parameters.AddWithValue("@aBookId", abookid);
        cmd.Parameters.AddWithValue("@orderDate", DateTime.Now);
        cmd.Parameters.AddWithValue("@shipFee", shipfee);

        con.Open();
        result += cmd.ExecuteNonQuery();
        con.Close();
        return result;
    }

    public int insertOrderProduct(int pid, decimal price, int quantity, decimal finalPrice)
    {
        int result = 0;

        string queryStr = "INSERT INTO OrderProducts (orderId, pId, oProductPrice, oProductQuantity, finalPrice) VALUES((SELECT MAX(orderId) FROM [Order] ), @pID, @oProductPrice, @oProductQuantity, @finalPrice)";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@pID", pid);
        cmd.Parameters.AddWithValue("@oProductPrice", price);
        cmd.Parameters.AddWithValue("@oProductQuantity", quantity);
        cmd.Parameters.AddWithValue("@finalPrice", finalPrice);

        con.Open();
        result += cmd.ExecuteNonQuery();
        con.Close();
        return result;
    }
}