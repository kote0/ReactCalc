using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Models;
using System.Data.SqlClient;

namespace DomainModels.Repository
{
    public class UserFavoriteRepository : IUserFavoriteRepository
    {
        private IUserRepository UserRepository { get; set; }
        private IOperationResultRepository OperationResultRepository { get; set; }
        public UserFavoriteRepository()
        {
            UserRepository = new UserRepository();
            OperationResultRepository = new OperationResultRepository();
        }
        public IEnumerable<UserFavoriteResult> GetAll()
        {
            using (var connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\ReactCalc\DomainModels\App_Data\reactCalc.mdf;Integrated Security=True"))
            {
                SqlCommand command = new SqlCommand("SELECT Id, Result, Users FROM UserFavoriteResult;", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt64(0);
                        
                        var user = UserRepository.Get(reader.GetInt64(2));
                        var result = reader.GetInt64(1);
                        yield return new UserFavoriteResult()
                        {
                            Id = id,
                            User = user,
                            Result = OperationResultRepository.Get(result)
                        };
                    }
                }
                reader.Close();
            }
        }
    }
}
