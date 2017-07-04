using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DomainModels.Repository
{
    public class EntityRepository<T> : IEntityRepository<T> where T : class
    {
        private Func<SqlDataReader, T> parseFunc { get; set; }
        private string selectAllQuery { get; set; }
        private string selectByIdQuery { get; set; }


        public EntityRepository(Func<SqlDataReader, T> parse, string selectAllQuery, string selectByIdQuery)
        {
            this.parseFunc = parse;
            this.selectAllQuery = selectAllQuery;
            this.selectByIdQuery = selectByIdQuery;
        }

        private const string ConnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\ReactCalc\DomainModels\App_Data\reactcalc.mdf;Integrated Security=True";

        public T Create()
        {
            throw new NotImplementedException();
        }

        public void Delete(T user)
        {
            throw new NotImplementedException();
        }

        public T Get(long id)
        {
            using (var connection = new SqlConnection(ConnString))
            {
                SqlCommand command = new SqlCommand(string.Format(selectByIdQuery, id), connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return parseFunc(reader);
                    }
                }
                reader.Close();
            }
            return null;
        }

        public IEnumerable<T> GetAll()
        {
            using (var connection = new SqlConnection(ConnString))
            {
                SqlCommand command = new SqlCommand(selectAllQuery, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        yield return parseFunc(reader);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
            }
        }

        public void Update(T user)
        {
            throw new NotImplementedException();
        }
    }
}