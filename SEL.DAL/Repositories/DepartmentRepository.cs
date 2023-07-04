using System.Data.SqlClient;
using SEL.DAL.Entities;
using SEL.DAL.Repositories.Interfaces;

namespace SEL.DAL.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly string _connectionString;

        public DepartmentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Department> GetAll()
        {
            var departments = new List<Department>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var query = "SELECT Id, Name, ParentDepartmentId FROM Departments";
                var command = new SqlCommand(query, connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var departmentId = (int)reader["Id"];
                        var departmentName = (string)reader["Name"];
                        var parentDepartmentId = reader["ParentDepartmentId"] != DBNull.Value ? (int?)reader["ParentDepartmentId"] : null;

                        var department = new Department
                        {
                            Id = departmentId,
                            Name = departmentName,
                            ParentDepartmentId = parentDepartmentId
                        };

                        departments.Add(department);
                    }
                }
            }

            return departments;
        }

        public Department GetById(int id)
        {
            Department department = null;
            
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT Id, ParentDepartmentId, Name " +
                            "FROM Departments " +
                            "WHERE Id = @Id";
                
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var sqlResponseId = reader.GetInt32(reader.GetOrdinal("Id"));
                        var sqlResponseName = reader.GetString(reader.GetOrdinal("Name"));
                        var parentDepartmentId = reader["ParentDepartmentId"] != DBNull.Value ? (int?)reader["ParentDepartmentId"] : null;
                        
                        department = new Department
                        {
                            Id = sqlResponseId,
                            Name = sqlResponseName,
                            ParentDepartmentId = parentDepartmentId,
                        };
                    }
                }
            }

            return department;
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                
                var query = "DELETE FROM Departments WHERE Id = @Id";

                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        }
    }
}