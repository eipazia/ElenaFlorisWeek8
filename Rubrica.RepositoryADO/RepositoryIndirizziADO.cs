using Rubrica.Core.Entities;
using Rubrica.Core.InterfaceRepository;
using System.Data;
using System.Data.SqlClient;

namespace Rubrica.RepositoryADO
{
    public class RepositoryIndirizziADO : IRepositoryIndirizzi
    {
        string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = Rubrica; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public Indirizzo Add(Indirizzo item)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "insert into Indirizzo values(@id, @tipo, @via, @cap,@citta, @provincia,@nazione)";
                    command.Parameters.AddWithValue("@id", item.IndirizzoId);
                    command.Parameters.AddWithValue("@tipo", item.Tipo);
                    command.Parameters.AddWithValue("@via", item.Via);
                    command.Parameters.AddWithValue("@cap", item.CAP);
                    command.Parameters.AddWithValue("@citta", item.Citta);
                    command.Parameters.AddWithValue("@provincia", item.Provincia);
                    command.Parameters.AddWithValue("@nazione", item.Nazione);
                    int numRighe = command.ExecuteNonQuery();
                    if (numRighe == 1)
                    {
                        connection.Close();
                        return item;
                    }
                    connection.Close();
                    return item;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool Delete(Indirizzo item)
        {
            throw new NotImplementedException();
        }

        public List<Indirizzo> GetAll()
        {
            throw new NotImplementedException();
        }

        public Indirizzo GetByIdI(int id)
        {
            throw new NotImplementedException();
        }
    }
}