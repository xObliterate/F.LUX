using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for Product
/// </summary>
public class Product
{
    private string connStr = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;
    private string prodID, prodName, shortDesc, longDesc, image, status;
    private int categoryID, sellerID, quantity;
    private decimal price;
    private DateTime datetime;

    public Product()
    {

    }

    public Product(string image)
    {
        this.image = image;
    }


    public Product(string prodID, string prodName, string image, string shortDesc, decimal price)
    {
        this.prodID = prodID;
        this.prodName = prodName;
        this.image = image;
        this.shortDesc = shortDesc;
        this.price = price;
    }

    public Product(string prodID, string prodName, string image, string shortDesc, string longDesc, decimal price)
    {
        this.prodID = prodID;
        this.prodName = prodName;
        this.image = image;
        this.shortDesc = shortDesc;
        this.longDesc = longDesc;
        this.price = price;
    }
    public Product(string prodName, string shortDesc, decimal price, string image)
    {
        this.prodName = prodName;
        this.shortDesc = shortDesc;
        this.price = price;
        this.image = image;
    }

    public Product(string prodID, string shortDesc, int quantity, decimal price)
    {
        this.prodID = prodID;
        this.shortDesc = shortDesc;
        this.quantity = quantity;
        this.price = price;
    }

    public Product(string prodID, string prodName, int quantity, decimal price, DateTime datetime, string status)
    {
        this.prodID = prodID;
        this.prodName = prodName;
        this.quantity = quantity;
        this.price = price;
        this.datetime = datetime;
        this.status = status;
    }

    public Product(int categoryID, int sellerID, string prodName, string shortDesc, string longDesc, int quantity, decimal price, string status)
    {
        this.categoryID = categoryID;
        this.sellerID = sellerID;
        this.prodName = prodName;
        this.shortDesc = shortDesc;
        this.longDesc = longDesc;
        this.quantity = quantity;
        this.price = price;
        this.status = status;
    }

    public DateTime gsDatetime
    {
        get { return datetime; }
        set { datetime = value; }
    }

    public string gsImage
    {
        get { return image; }
        set { image = value; }
    }

    public string gsProdID
    {
        get { return prodID; }
        set { prodID = value; }
    }

    public int gsCategoryID
    {
        get { return categoryID; }
        set { categoryID = value; }
    }
    public int gsSellerID
    {
        get { return sellerID; }
        set { sellerID = value; }
    }
    public string gsProdName
    {
        get { return prodName; }
        set { prodName = value; }
    }

    public string gsShortDesc
    {
        get { return shortDesc; }
        set { shortDesc = value; }
    }

    public string gsLongDesc
    {
        get { return longDesc; }
        set { longDesc = value; }
    }

    public int gsQuantity
    {
        get { return quantity; }
        set { quantity = value; }
    }

    public string gsStatus
    {
        get { return status; }
        set { status = value; }
    }

    public decimal gsPrice
    {
        get { return price; }
        set { price = value; }
    }

    public List<Product> productSearch(string name)
    {
        List<Product> prodList = new List<Product>();
        string pName, status, pID;
        DateTime pDateAdded;
        int quantity;
        decimal price;

        string queryStr = "SELECT * FROM Product WHERE pName LIKE '%' + @pName + '%'";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@pName", name);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            pID = dr["pID"].ToString();
            pName = dr["pName"].ToString();
            quantity = int.Parse(dr["pQuantity"].ToString());
            price = decimal.Parse(dr["pPrice"].ToString());
            pDateAdded = DateTime.Parse(dr["pDateAdded"].ToString());
            status = dr["pStatus"].ToString();

            Product prod = new Product(pID, pName, quantity, price, pDateAdded, status);
            prodList.Add(prod);
        }
        con.Close();
        dr.Close();
        dr.Dispose();

        return prodList;
    }


    public int productDelete(string id)
    {
        string queryStr = "";
        queryStr = "DELETE FROM ProductImage WHERE pID = @pID";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@pID", id);
        con.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();

        queryStr = "DELETE FROM Product WHERE pID = @pID";
        cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@pID", id);
        nofRow += cmd.ExecuteNonQuery();
        con.Close();
        return nofRow;
    }
    public int productStatusUpdate(string prodid, int status)
    {
        string queryStr = "UPDATE Product SET pStatus = @pStatus WHERE pID = @pID";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@pID", prodid);
        cmd.Parameters.AddWithValue("@pStatus", status);
        con.Open();
        int nOfRow = 0;
        nOfRow = cmd.ExecuteNonQuery();
        con.Close();
        return nOfRow;
    }

    public int productUpdate(string id, string prodName, int quantity, decimal price)
    {
        string queryStr = "UPDATE Product SET pName = @pName, pQuantity = @pQuantity, pPrice = @pPrice WHERE pID = @pID";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@pID", id);
        cmd.Parameters.AddWithValue("@pName", prodName);
        cmd.Parameters.AddWithValue("@pQuantity", quantity);
        cmd.Parameters.AddWithValue("@pPrice", price);

        con.Open();
        int nOfRow = 0;
        nOfRow = cmd.ExecuteNonQuery();
        con.Close();
        return nOfRow;
    }

    public int productInsert(int id)
    {
        int result = 0;

        string queryStr = "INSERT INTO Product(cID, sID, pName, pShortDesc, pLongDesc, pQuantity, pPrice, pDateAdded, pStatus) VALUES(@cID, @sID, @pName, @pShortDesc, @pLongDesc, @pQuantity, @pPrice, @pDateAdded, @pStatus)";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);

        cmd.Parameters.AddWithValue("@cID", this.categoryID);
        cmd.Parameters.AddWithValue("@sID", id);
        cmd.Parameters.AddWithValue("@pName", this.prodName);
        cmd.Parameters.AddWithValue("@pShortDesc", this.shortDesc);
        cmd.Parameters.AddWithValue("@pLongDesc", this.longDesc);
        cmd.Parameters.AddWithValue("@pQuantity", this.quantity);
        cmd.Parameters.AddWithValue("@pPrice", this.price);
        cmd.Parameters.AddWithValue("@pDateAdded", DateTime.Now);
        cmd.Parameters.AddWithValue("@pStatus", this.status);

        con.Open();
        result += cmd.ExecuteNonQuery();
        con.Close();
        return result;
    }

    public int productImageInsert()
    {
        int result = 0;
        string queryStr = "INSERT INTO ProductImage(pID, pImage) VALUES((SELECT MAX(pID) FROM Product), @pImage)";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue(@"pImage", this.image);
        con.Open();
        result = cmd.ExecuteNonQuery();
        con.Close();
        return result;
    }

    public Product getProduct(string pid)
    {
        Product prod = null;
        string prodName, prodDesc, prodID, prodImage, prodlongdesc;
        decimal price;

        string queryStr = "SELECT p.pID, p.pName, p.pShortDesc, p.pLongDesc, pi.pImage, p.pPrice FROM Product p INNER JOIN ProductImage pi ON p.pID = pi.pID WHERE p.pID = @pID";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@pID", pid);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            prodID = dr["pID"].ToString();
            prodName = dr["pName"].ToString();
            prodImage = dr["pImage"].ToString();
            prodDesc = dr["pShortDesc"].ToString();
            prodlongdesc = dr["pLongDesc"].ToString();
            price = decimal.Parse(dr["pPrice"].ToString());

            prod = new Product(prodID, prodName, prodImage, prodDesc, prodlongdesc, price);
        }
        else
        {
            prod = null;
        }
        con.Close();
        dr.Close();
        dr.Dispose();
        return prod;
    }

    public List<Product> getAllProduct(int id)
    {
        List<Product> prodList = new List<Product>();
        string pName, pID, status;
        DateTime pDateAdded;
        int quantity;
        decimal price;

        string queryStr = "SELECT pID, pName, pQuantity, pPrice, pDateAdded, pStatus FROM Product WHERE sID = @sID";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@sID", id);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        while (dr.Read())
        {
            pID = dr["pID"].ToString();
            pName = dr["pName"].ToString();
            quantity = int.Parse(dr["pQuantity"].ToString());
            price = decimal.Parse(dr["pPrice"].ToString());
            pDateAdded = DateTime.Parse(dr["pDateAdded"].ToString());
            status = dr["pStatus"].ToString();

            Product prod = new Product(pID, pName, quantity, price, pDateAdded, status);
            prodList.Add(prod);
        }
        con.Close();
        dr.Close();
        dr.Dispose();

        return prodList;
    }

    public List<Product> getAllPopProd()
    {
        //p.pStatus 0 = pending, 1 = approved, 2 = rejected

        List<Product> prodList = new List<Product>();
        string prodID, pname, pimage, pshortDesc;
        decimal price;

        string queryStr = "SELECT TOP 4 p.pID, p.pName, p.pShortDesc, pi.pImage, p.pPrice FROM Product p INNER JOIN ProductImage pi ON p.pID = pi.pID WHERE p.pStatus = 1";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        while (dr.Read())
        {
            prodID = dr["pID"].ToString();
            pname = dr["pName"].ToString();
            pimage = "~/img/" + dr["pImage"].ToString();
            pshortDesc = dr["pShortDesc"].ToString();
            price = decimal.Parse(dr["pPrice"].ToString());
            Product prod = new Product(prodID, pname, pimage, pshortDesc, price);
            prodList.Add(prod);
        }
        con.Close();
        dr.Close();
        dr.Dispose();

        return prodList;
    }

    public List<Product> getAllProd()
    {
        //p.pStatus 0 = pending, 1 = approved, 2 = rejected

        List<Product> prodList = new List<Product>();
        string prodID, pname, pimage, pshortDesc;
        decimal price;

        string queryStr = "SELECT p.pID, p.pName, p.pShortDesc, pi.pImage, p.pPrice FROM Product p INNER JOIN ProductImage pi ON p.pID = pi.pID WHERE p.pStatus = 1";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        while (dr.Read())
        {
            prodID = dr["pID"].ToString();
            pname = dr["pName"].ToString();
            pimage = "~/img/" + dr["pImage"].ToString();
            pshortDesc = dr["pShortDesc"].ToString();
            price = decimal.Parse(dr["pPrice"].ToString());
            Product prod = new Product(prodID, pname, pimage, pshortDesc, price);
            prodList.Add(prod);
        }
        con.Close();
        dr.Close();
        dr.Dispose();

        return prodList;
    }

    public List<Product> approveProducts()
    {
        //p.pStatus 0 = pending, 1 = approved, 2 = rejected

        List<Product> prodList = new List<Product>();
        string prodID, pname, pimage, pshortDesc;
        decimal price;

        string queryStr = "SELECT p.pID, p.pName, p.pShortDesc, pi.pImage, p.pPrice FROM Product p INNER JOIN ProductImage pi ON p.pID = pi.pID WHERE p.pStatus = 0";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        while (dr.Read())
        {
            prodID = dr["pID"].ToString();
            pname = dr["pName"].ToString();
            pimage = "~/img/" + dr["pImage"].ToString();
            pshortDesc = dr["pShortDesc"].ToString();
            price = decimal.Parse(dr["pPrice"].ToString());
            Product prod = new Product(prodID, pname, pimage, pshortDesc, price);
            prodList.Add(prod);
        }
        con.Close();
        dr.Close();
        dr.Dispose();

        return prodList;
    }
}