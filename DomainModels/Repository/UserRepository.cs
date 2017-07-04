using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Models;
using System.Data.SqlClient;

namespace DomainModels.Repository
{
    public class UserRepository : IUserRepository
    {
        public User Create(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        public User Get(long Id)
        {
            using (var connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\ReactCalc\DomainModels\App_Data\reactCalc.mdf;Integrated Security=True"))
            {
                SqlCommand command = new SqlCommand("SELECT Id, FIO, Login FROM Users Where Id=" + Id + ";", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt64(0);
                        var fio = reader.GetString(1);
                        var login = reader.GetString(2);
                        return new User()
                        {
                            FIO = fio,
                            Login = login,
                            Id = id,
                        };
                    }
                }
                reader.Close();
                return null;
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (var connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\ReactCalc\DomainModels\App_Data\reactCalc.mdf;Integrated Security=True"))
            {
                SqlCommand command = new SqlCommand("SELECT Id, FIO, Login FROM Users;", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt64(0);
                        var fio = reader.GetString(1);
                        var login = reader.GetString(2);
                        yield return new User()
                        {
                            FIO = fio,
                            Login = login,
                            Id = id,
                        };
                    }
                }
                else
                {
                    //Console.WriteLine("No rows found.");
                }
                reader.Close();
            }
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<string[]> Find(long id)
        {
            using (var connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\ReactCalc\DomainModels\App_Data\reactCalc.mdf;Integrated Security=True"))
            {
                SqlCommand command = new SqlCommand("select Operation.Name, Operation.FullName, " +
                    " OperationResult.InputData, OperationResult.Result, Users.FIO" +
                    " From Users, OperationResult, Operation" +
                    " Where Users.Id = OperationResult.Author" +
                    " and Operation.Id = OperationResult.Operation; ", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        yield return new[] {
                            reader.GetString(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetFloat(3).ToString(),
                            reader.GetString(4)
                        };
                    }
                }
                reader.Close();
            }
        }
    }
}
