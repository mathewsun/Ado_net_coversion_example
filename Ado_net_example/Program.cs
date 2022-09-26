using Microsoft.Data.SqlClient;


namespace Ado_net_example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var wallets = new List<Wallets>();
            //to get the connection string 
            var connectionstring = "server=192.168.1.69;user=exchange;password=exchange1;database=Exchange;Encrypt=False;TrustServerCertificate=False";
            //build the sqlconnection and execute the sql command
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                string commandtext = "SELECT Id, Convert(Decimal(38,20),Value) as Value from Wallets";

                SqlCommand cmd = new SqlCommand(commandtext, conn);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var wallet = new Wallets()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Value = Convert.ToDecimal(reader["Value"])
                    };

                    wallets.Add(wallet);
                }

                int i = 10;
            }

            


        }

        class Wallets
        {
            public int Id { get; set; }
            public decimal Value { get; set; }
        }
    }
}