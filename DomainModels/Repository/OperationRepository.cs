using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Models;
using System.Data.SqlClient;

namespace DomainModels.Repository
{
    public class OperationRepository : IOperationRepository
    {
        public Operation Get(long Id)
        {
            using (var connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\ReactCalc\DomainModels\App_Data\reactCalc.mdf;Integrated Security=True"))
            {
                SqlCommand command = new SqlCommand("SELECT Id, Name, FullName FROM Operation Where Id=" + Id + ";", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt64(0);
                        var name = reader.GetString(1);
                        var fullName = reader.GetString(2);
                        return new Operation()
                        {
                            Id = id,
                            Name = name,
                            FullName = fullName
                        };
                    }
                }
                reader.Close();
                return null;
            }
        }
        public IEnumerable<Operation> GetAll()
        {
            using (var connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\ReactCalc\DomainModels\App_Data\reactCalc.mdf;Integrated Security=True"))
            {
                SqlCommand command = new SqlCommand("SELECT Id, Name, FullName FROM Operation;", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt64(0);
                        var name = reader.GetString(1);
                        var fullName = reader.GetString(2);
                        yield return new Operation()
                        {
                            Id = id,
                            Name = name,
                            FullName = fullName
                        };
                    }
                }
                reader.Close();
            }
        }
    }
}
