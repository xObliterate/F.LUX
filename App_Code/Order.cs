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
    private decimal subtotal, shippingfee, orderprice, finalprice;
    private int count, orderid, quantity, orderstatus, oprodid;
    private DateTime date, shipdate;
    private string prodID, image;

    public Order()
    {

    }

    public string gsimage
    {
        get { return image; }
        set { image = value; }
    }

    public DateTime gsshipdate
    {
        get { return shipdate; }
        set { shipdate = value; }
    }
    public int gsorderstatus
    {
        get { return orderstatus; }
        set { orderstatus = value; }
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

    public int gsorderId
    {
        get { return orderid; }
        set { orderid = value; }
    }

    public DateTime gsdate
    {
        get { return date; }
        set { date = value; }
    }

    public string gsprodId
    {
        get { return prodID; }
        set { prodID = value; }
    }

    public decimal gsorderPrice
    {
        get { return orderprice; }
        set { orderprice = value; }
    }

    public int gsquantity
    {
        get { return quantity; }
        set { quantity = value; }
    }

    public int gsoprodid
    {
        get { return oprodid; }
        set { oprodid = value; }
    }

    public decimal gsfinalPrice
    {
        get { return finalprice; }
        set { finalprice = value; }
    }

    public Order(string prodID, int quantity)
    {
        this.prodID = prodID;
        this.quantity = quantity;
    }

    public Order(decimal subtotal, decimal shippingfee, int count)
    {
        this.subtotal = subtotal;
        this.shippingfee = shippingfee;
        this.count = count;
    }

    public Order(int orderid, DateTime date, decimal shippingfee)
    {
        this.orderid = orderid;
        this.date = date;
        this.shippingfee = shippingfee;
    }

    public Order(string prodID, decimal orderprice, int quantity, decimal finalprice)
    {
        this.prodID = prodID;
        this.orderprice = orderprice;
        this.quantity = quantity;
        this.finalprice = finalprice;
    }

    public Order(int orderid, DateTime date, int orderstatus, DateTime shipdate, string prodID, int oprodid, string image)
    {
        this.orderid = orderid;
        this.date = date;
        this.orderstatus = orderstatus;
        this.shipdate = shipdate;
        this.prodID = prodID;
        this.oprodid = oprodid;
        this.image = image;
    }

    public Order(int orderid, string prodID, decimal orderprice, int quantity, DateTime date, int orderstatus)
    {
        this.orderid = orderid;
        this.prodID = prodID;
        this.orderprice = orderprice;
        this.quantity = quantity;
        this.date = date;
        this.orderstatus = orderstatus;

    }

    public List<Order> getAllOrderProducts(int orderid)
    {
        List<Order> orderList = new List<Order>();
        string pid;
        decimal orderprice, finalprice;
        int orderquantity;

        string queryStr = "SELECT pId, oProductPrice, oProductQuantity, finalPrice FROM OrderProducts WHERE orderId = @orderId";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@orderId", orderid);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        while (dr.Read())
        {
            pid = dr["pId"].ToString();
            orderprice = decimal.Parse(dr["oProductPrice"].ToString());
            orderquantity = int.Parse(dr["oProductQuantity"].ToString());
            finalprice = decimal.Parse(dr["finalPrice"].ToString());

            Order order = new Order(pid, orderprice, orderquantity, finalprice);
            orderList.Add(order);
        }
        con.Close();
        dr.Close();
        dr.Dispose();

        return orderList;
    }

    public List<Order> getAllOrder(int cid)
    {
        List<Order> orderList = new List<Order>();
        int orderid, orderstatus, oprodid;
        DateTime orderdate, shipdate;
        string prodID, image;


        string queryStr = "SELECT o.orderId, o.orderDate, o.orderStatus, o.shipDate, op.pId, op.oProductId, pi.pImage FROM [OrderProducts] op INNER JOIN [Order] o ON o.orderId = op.orderId INNER JOIN ProductImage pi ON pi.pID = op.pId WHERE o.cID = @cID";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@cID", cid);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        while (dr.Read())
        {
            orderid = int.Parse(dr["orderId"].ToString());
            orderdate = DateTime.Parse(dr["orderDate"].ToString());
            orderstatus = int.Parse(dr["orderStatus"].ToString());
            shipdate = DateTime.Parse(dr["shipDate"].ToString());
            prodID = dr["pId"].ToString();
            oprodid = int.Parse(dr["oProductId"].ToString());
            image = dr["pImage"].ToString();

            Order o = new Order(orderid, orderdate, orderstatus, shipdate, prodID, oprodid, image);
            orderList.Add(o);
        }
        con.Close();
        dr.Close();
        dr.Dispose();

        return orderList;
    }

    public List<Order> getSellerProductFromOrder(int sid)
    {
        List<Order> prodList = new List<Order>();
        int orderid, quantity, orderstatus;
        decimal price;
        DateTime orderdate;
        string prodID;

        string queryStr = "SELECT op.orderId, op.pId, op.oProductPrice, op.oProductQuantity, o.orderDate, o.orderStatus FROM [OrderProducts] op INNER JOIN [Order] o ON o.orderId = op.orderId INNER JOIN Product p on p.pID = op.pId WHERE p.sID = @sID";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@sID", sid);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        while (dr.Read())
        {
            orderid = int.Parse(dr["orderId"].ToString());
            prodID = dr["pId"].ToString();
            price = decimal.Parse(dr["oProductPrice"].ToString());
            quantity = int.Parse(dr["oProductQuantity"].ToString());
            orderdate = DateTime.Parse(dr["orderDate"].ToString());
            orderstatus = int.Parse(dr["orderStatus"].ToString());


            Order o = new Order(orderid, prodID, price, quantity, orderdate, orderstatus);
            prodList.Add(o);
        }
        con.Close();
        dr.Close();
        dr.Dispose();

        return prodList;
    }


    public Order getOrderProduct(int orderid)
    {
        Order order = null;
        string prodID;
        int prodquantity;

        string queryStr = "SELECT pID, oProductQuantity FROM [OrderProducts] WHERE orderId = @orderId";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@orderId", orderid);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            prodID = dr["pId"].ToString();
            prodquantity = int.Parse(dr["oProductQuantity"].ToString());
            order = new Order(prodID, prodquantity);
        }
        else
        {
            order = null;
        }
        con.Close();
        dr.Close();
        dr.Dispose();
        return order;
    }

    public Order getOrder(int cid)
    {
        Order order = null;
        int orderid;
        DateTime date;
        decimal shipfee;

        string queryStr = "SELECT orderId, orderDate, shipFee FROM [Order] WHERE cID = @cID AND orderDate = (SELECT MAX(orderDate) FROM [Order])";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@cID", cid);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            orderid = int.Parse(dr["orderId"].ToString());
            date = DateTime.Parse(dr["orderDate"].ToString());
            shipfee = decimal.Parse(dr["shipFee"].ToString());

            order = new Order(orderid, date, shipfee);
        }
        else
        {
            order = null;
        }
        con.Close();
        dr.Close();
        dr.Dispose();
        return order;
    }


    public int insertOrder(int id, int abookid, decimal shipfee)
    {
        //Order status
        // 0 = pending, 1 = received, 2 = shipping, 3 = delivered
        int result = 0;

        string queryStr = "INSERT INTO [Order] (cID, aBookId, payment, orderDate, shipFee, shipDate) VALUES(@cID, (SELECT aBookId FROM AddressBook WHERE cID = @cID and primaryAddress = 1), (SELECT paymentID FROM Payment WHERE cID = @cID), @orderDate, @shipFee, @shipDate)";

        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);

        cmd.Parameters.AddWithValue("@cID", id);
        cmd.Parameters.AddWithValue("@aBookId", abookid);
        cmd.Parameters.AddWithValue("@orderDate", DateTime.Now);
        cmd.Parameters.AddWithValue("@shipFee", shipfee);
        cmd.Parameters.AddWithValue("@shipDate", DateTime.Now.AddDays(7));

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

    public int updateStatus(int status, int orderId)
    {
        int result = 0;

        string queryStr = "UPDATE [Order] SET orderStatus = @orderStatus WHERE orderId = @orderId";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@orderStatus", status);
        cmd.Parameters.AddWithValue("@orderId", orderId);

        con.Open();
        result += cmd.ExecuteNonQuery();
        con.Close();
        return result;
    }
}