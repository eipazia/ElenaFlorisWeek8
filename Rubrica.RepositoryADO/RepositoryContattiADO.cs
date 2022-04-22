using Rubrica.Core.Entities;
using Rubrica.Core.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.RepositoryADO
{
    internal class RepositoryContattiADO : IRepositoryContatti
    {
        string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = Rubrica; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public Contatto Add(Contatto item)
        {
            throw new NotImplementedException();

        }

        public bool Delete(Contatto item)
        {
            throw new NotImplementedException();
        }

        public List<Contatto> GetAll()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "select * from Contatto";

                    SqlDataReader reader = command.ExecuteReader();

                    List<Contatto> contatti = new List<Contatto>();

                    while (reader.Read())
                    {
                        var id = (int)reader["ContattoId"];
                        var nome = (string)reader["Nome"];
                        var cognome = (string)reader["Cognome"];
                       

                        var c = new Contatto();
                        c.ContattoId = id;
                        c.Nome = nome;
                        c.Cognome = cognome;
                        
                        contatti.Add(c);
                    }
                    connection.Close();

                    return contatti;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Contatto>();
            }
        }

        public Contatto GetByIdC(int id)
        {
            throw new NotImplementedException();
        }
    }
}
