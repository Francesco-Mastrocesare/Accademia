using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModisAPI.Models.WorkerServices
{
    public class WorkerServicesStudenti : IWorkerServicesStudenti
    {
        public List<Studente> RestituisciListaStudenti()
        {
            //var studente1 = new Studente { Id = 1, Cognome = "Fragnelli", Nome = "Sefora" };
            //var studente2 = new Studente { Id = 2, Cognome = "Mastrocesare", Nome = "Francesco"};

            //return new List<Studente> { studente1, studente2 };


            return ListaDB(); ;
        }

        public int Registrazione(int id, string nome, string cognome)
        {
            return InsertStudente(id, nome, cognome);
        }

        public SqlConnectionStringBuilder Login()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "serverdbazure.database.windows.net";
            builder.UserID = "Francesco";
            builder.Password = "Server1987";
            builder.InitialCatalog = "ProvaDB";
            return builder;
        }

        public List<Studente> ListaDB()
        {
            List<Studente> obj = new List<Studente>();
            try
            {
                var builder = Login();
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                   

                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT ID, Nome, Cognome ");
                    sb.Append("FROM studente");
                    //sb.Append("FROM [SalesLT].[ProductCategory] pc ");
                    //sb.Append("JOIN [SalesLT].[Product] p ");
                    //sb.Append("ON pc.productcategoryid = p.productcategoryid;");
                    String sql = sb.ToString();


                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                obj.Add(new Studente {Id = reader.GetInt32(0) ,Nome = reader.GetString(1), Cognome = reader.GetString(2) });
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return obj;

        }

        public Studente RestituisciStudente(int id)
        {
            return RestituisciListaStudenti().Where(x => x.Id == id).FirstOrDefault();
        }

        public int InsertStudente(int id, string nome, string cognome)
        {
            try
            {
                var builder = Login();
                
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("INSERT INTO studente (ID, Nome, Cognome) ");
                    sb.Append("VALUES(" +id+ ", '" +nome+ "', '" +cognome+ "');");
                    //sb.Append("FROM [SalesLT].[ProductCategory] pc ");
                    //sb.Append("JOIN [SalesLT].[Product] p ");
                    //sb.Append("ON pc.productcategoryid = p.productcategoryid;");
                    String sql = sb.ToString();
                    
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
            catch
            {
                return 0;
            }

        }
    }
}
