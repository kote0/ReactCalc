using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Models;
using System.Data.SqlClient;

namespace DomainModels.Repository
{
    public class OperationResultRepository : IOperationResultRepository
    {
        private IUserRepository UserRepository { get; set; }
        private IOperationRepository OperationRepository { get; set; }
        public OperationResultRepository()
        {
            UserRepository = new UserRepository();
            OperationRepository = new OperationRepository();
        }
        public OperationResult Get(long Id)
        {
            using (var connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\ReactCalc\DomainModels\App_Data\reactCalc.mdf;Integrated Security=True"))
            {
                SqlCommand command = new SqlCommand("SELECT Id, Author, Operation, InputData, Result, ExecutionTime, ExecutionDate  FROM OperationResult Where Id=" + Id + ";", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt64(0);
                        var author = UserRepository.Get(reader.GetInt64(1));
                        var operation = OperationRepository.Get(reader.GetInt64(2));
                        var inputData = reader.GetString(3);
                        var result = reader.GetDouble(4);
                        var executionTime = reader.GetInt32(5);
                        return new OperationResult()
                        {
                            Id = id,
                            Author = author,
                            Operation = operation,
                            InputData = inputData,
                            ExecutionTime = executionTime,
                        };
                    }
                }
                reader.Close();
                return null;
            }
        }

        public IEnumerable<OperationResult> GetAll()
        {
            using (var connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\ReactCalc\DomainModels\App_Data\reactCalc.mdf;Integrated Security=True"))
            {
                SqlCommand command = new SqlCommand("SELECT Id, Author, Operation, InputData, Result, ExecutionTime, ExecutionDate  FROM OperationResult;", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt64(0);
                        var author = UserRepository.Get(reader.GetInt64(1));
                        var operation = OperationRepository.Get(reader.GetInt64(2));
                        var inputData = reader.GetString(3);
                        var result = reader.GetDouble(4);
                        var executionTime = reader.GetInt32(5);
                        //var executionDate = reader.GetDateTime(6);
                        yield return new OperationResult()
                        {
                            Id = id,
                            Author = author,
                            Operation = operation,
                            InputData = inputData,
                            ExecutionTime = executionTime,
                            //ExecutionDate = executionDate
                        };
                    }
                }
                reader.Close();
            }
        }
    }
}
