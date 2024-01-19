using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ProductRepository
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ShopPrimerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        public List<Product> GetAllProducts()
        {
            var productList = new List<Product>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection;
                cmd.CommandText = "SELECT * FROM Products";

                

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product p = new Product();
                    p.Id = reader.GetInt32(0);
                    p.Name = reader.GetString(1);
                    p.Description = reader.GetString(2);
                    p.ExpiryDate = reader.GetDateTime(3);

                    productList.Add(p);
                }

            }
            return productList;
        }
        public int InsertProduct(Product product)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection;
                cmd.CommandText = string.Format("INSERT INTO Products VALUES('{0}','{1}','{2}')",
                    product.Name,product.Description,product.ExpiryDate);

                return cmd.ExecuteNonQuery();
            }

        }
    }
}
