using System.Data.SqlClient;
using SEL.DAL.Entities;
using SEL.DAL.Repositories.Interfaces;

namespace SEL.DAL.Repositories
{
    public class WorkerRepository : IWorkerRepository
    {
        private string _connectionString;

        public WorkerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Worker> GetAll()
        {
            var workers = new List<Worker>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Workers";
                connection.Open();
                
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var worker = new Worker
                            {
                                Id = (int)reader["Id"],
                                DepartmentId = (int)reader["DepartmentId"],
                                FirstName = (string)reader["FirstName"],
                                MidName = (string)reader["MidName"],
                                LastName = (string)reader["LastName"],
                                PersonnelNumber = (int)reader["PersonnelNumber"]
                            };

                            workers.Add(worker);
                        }
                    }
                }
            }

            return workers;
        }

        public Worker GetById(int id)
        {
            Worker worker = null;
            
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT Id, DepartmentId, FirstName, MidName, LastName, PersonnelNumber " +
                            "FROM Workers " +
                            "WHERE Id = @Id";
                
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        worker = new Worker
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            DepartmentId = reader.GetInt32(reader.GetOrdinal("DepartmentId")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            MidName = reader.GetString(reader.GetOrdinal("MidName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            PersonnelNumber = reader.GetInt32(reader.GetOrdinal("PersonnelNumber"))
                        };
                    }
                }
            }

            return worker;
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                
                var query = "DELETE FROM Workers WHERE Id = @Id";

                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Worker entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                
                var query = "UPDATE Workers " +
                            "SET " +
                            "DepartmentId = @DepartmentId, " +
                            "FirstName = @FirstName, " +
                            "MidName = @MidName, " +
                            "LastName = @LastName, " +
                            "PersonnelNumber = @PersonnelNumber " +
                            "WHERE Id = @Id";
                
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", entity.Id);
                command.Parameters.AddWithValue("@DepartmentId", entity.DepartmentId);
                command.Parameters.AddWithValue("@FirstName", entity.FirstName);
                command.Parameters.AddWithValue("@MidName", entity.MidName);
                command.Parameters.AddWithValue("@LastName", entity.LastName);
                command.Parameters.AddWithValue("@PersonnelNumber", entity.PersonnelNumber);

                command.ExecuteNonQuery();
            }
        }
    }
}