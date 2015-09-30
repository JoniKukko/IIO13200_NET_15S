using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


// Sovellus hakee SQL Serveriltä DemoxOy-tietokannasta lanaolt-taulusta kaikki tietueet
namespace ADODataReader
{
    public class Program
    {


        static string connectionString = ConfigurationManager.ConnectionStrings["Lasnaolot"].ConnectionString;

        
        static void GetData_DataTable ()
        {
            try
            {
                DataTable datatable = GetDataReal();
                string rivi = "";

                foreach (DataRow datarow in datatable.Rows)
                {
                    rivi = "";
                    foreach (DataColumn datacolumn in datatable.Columns)
                    {
                        rivi += datarow[datacolumn].ToString();
                    }
                    Console.WriteLine(rivi);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        public static DataTable GetDataSimple ()
        {
            DataTable datatable = new DataTable();

            datatable.Columns.Add("FirstName", typeof(string));
            datatable.Columns.Add("LastName", typeof(string));

            datatable.Rows.Add("Kalle", "Isokallio");
            datatable.Rows.Add("Matti", "Mainio");

            return datatable;
        }




        public static DataTable GetDataReal (string asioid = "")
        {
            string query = "SELECT asioid, lastname, firstname, date FROM lasnaolot";

            if (asioid != "")
            {
                query += " WHERE asioid = '" + asioid + "'";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataSet dataset = new DataSet();
                    dataAdapter.Fill(dataset, "lasnaolot");
                    return dataset.Tables["lasnaolot"];
                }
            }

        }






        static void GetData_DataReader ()
        {
            try
            {
                string query = "SELECT asioid, lastname, firstname FROM lasnaolot";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                throw new Exception("Tietueita ei ole olemassa");
                            }
                            
                            while (reader.Read())
                            {
                                Console.WriteLine("{0}\t{1}", reader.GetString(0), reader.GetString(1));
                            }
                            
                        }
                    }
                    
                    Console.WriteLine("Tietokanta suljettu");
                }

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}
