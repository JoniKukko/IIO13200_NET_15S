using System;
using System.Data;
using System.Data.SqlClient;


// Sovellus hakee SQL Serveriltä DemoxOy-tietokannasta lanaolt-taulusta kaikki tietueet
namespace ADODataReader
{
    class Program
    {


        static void Main(string[] args)
        {
            GetData_DataTable();
        }





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



        static DataTable GetDataSimple ()
        {
            DataTable datatable = new DataTable();

            datatable.Columns.Add("FirstName", typeof(string));
            datatable.Columns.Add("LastName", typeof(string));

            datatable.Rows.Add("Kalle", "Isokallio");
            datatable.Rows.Add("Matti", "Mainio");

            return datatable;
        }




        static DataTable GetDataReal ()
        {
            string query = "SELECT asioid, lastname, firstname, date FROM lasnaolot";
            string connectionString = @"Data source=eight.labranet.jamk.fi; initial catalog=DemoxOy; user=koodari; password=koodari13;";

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
                string connectionString =  @"Data source=eight.labranet.jamk.fi; initial catalog=DemoxOy; user=koodari; password=koodari13;";

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
