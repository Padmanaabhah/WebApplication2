using System.Data.SqlClient;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class ProductService
    {
        private static string db_source = "paddaz204.database.windows.net";

        private static string db_user = "paddy";

        private static string db_password = "Asdf12345678";

        private static string db_Database = "paddyaz-204";

        private SqlConnection GetConnection()
        {
            var _builder = new  SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_Database;
            return new SqlConnection(_builder.ConnectionString);
        }

        public List<Product> GetProducts()
        {
            SqlConnection conn = GetConnection();

            List<Product> products = new List<Product>();

            string statement = "SELECT ProductID,ProductName, Quantity from Products";

            conn.Open();

            SqlCommand cmd = new SqlCommand(statement, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Product product = new Product
                {
                    ProductId = reader.GetInt32(0),
                    ProductName = reader.GetString(1),
                    Quantity = reader.GetInt32(2)
                };

                products.Add(product);
            }

            conn.Close();

            return products;
        }
    }
}
