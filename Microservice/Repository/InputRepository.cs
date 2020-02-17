
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using Npgsql;
using Microservice.Models;

namespace Microservice.Repository
{
    public class InputRepository : IRepository<Input>
    {
        private string connectionString;
        public InputRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");
        }

        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }

        public void Add(Input item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                // dbConnection.Execute("INSERT INTO customer (name,phone,email,address) VALUES(@Name,@Phone,@Email,@Address)", item);
                dbConnection.Execute("INSERT INTO public.\"Inputs\"(\"StudyName\",\"StudyStartDate\",\"EstimatedCompletionDate\",\"ProtocolID\",\"StudyGroup\",\"Phase\",\"PrimaryIndication\",\"SecondaryIndication\") VALUES(@StudyName,@StudyStartDate,@EstimatedCompletionDate,@ProtocolID,@StudyGroup,@Phase, @PrimaryIndication, @SecondaryIndication);", item);
            }

        }

        public IEnumerable<Input> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Input>("SELECT * FROM public.\"Inputs\"");
            }
        }

        public Input FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Input>("SELECT * FROM public.\"Inputs\" WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM customer WHERE Id=@Id", new { Id = id });
            }
        }

        public void Update(Input item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE customer SET name = @Name,  phone  = @Phone, email= @Email, address= @Address WHERE id = @Id", item);
            }
        }
    }
}
