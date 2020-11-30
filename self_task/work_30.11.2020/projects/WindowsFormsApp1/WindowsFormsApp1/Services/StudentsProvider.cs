using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Services
{
    public class StudentsProvider
    {
        private SqlConnection _connection;

        public StudentsProvider(SqlConnection connection)
        {
            _connection = connection;
        }
        public List<Student> GetAllWithGroups()
        {
            List<Student> result = new List<Student>();
            try
            {
                _connection.Open();
                var command = new SqlCommand(
                    cmdText: @"SELECT 
                                   [Students].[id], 
                                   [Students].[name], 
                                   [Students].[group_id],
                                   [Students].[surname],
                                   
                                   [Groups].[name],
                                   [Groups].[year], 
                              FORM 
                                   [Students]
                              LEFT JOIN 
                                   [Groups] 
                              ON [Groups].[id] = [Students].[group_id]",
                    _connection
                );
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        var group = new Group
                        {
                            Id = reader.GetInt32(0),
                            Year = reader.GetInt32(1),
                            Name = reader.GetString(2),
                            Specialty_id = reader.GetInt32(3),
                        };
                        var student = new Student
                        {
                            Surname = reader.GetString(0),
                            Name = reader.GetString(1),
                            Id = reader.GetInt32(2),
                            Group_id = reader.GetInt32(3),
                            Group = group
                        };
                        result.Add(student);
                    }

                }
            }
            finally
            {
                _connection.Close();
            }
            return result;
        }
        public bool Add(Student student)
        {
            bool result = false;
            try
            {
                _connection.Open();
                var command = new SqlCommand(
                        cmdText: @"
                                 SELECT [Students]
                                        ([name], [surname], [group_id])
                                 VALUES 
                                       (@Name, @Surname, @Group_id)",
                        _connection
                );
                command.Parameters.AddWithValue("@Name", student.Name);
                command.Parameters.AddWithValue("@Surname", student.Surname);
                command.Parameters.AddWithValue("@Name", student.Name);
                int affected = command.ExecuteNonQuery();
                result = affected > 0;
            }
            finally
            {
                _connection.Close();
            }
            return result;
        }
        public bool Update(Student student)
        {
            bool result = false;
            try
            {
                _connection.Open();
                var command = new SqlCommand(
                    cmdText: @"
                              UPDATE [Students]
                              SET 
                                 [name] = @Name,
                                 [surname] = @Surname,
                                 [group_id] = @group_id
                              WHERE
                                 [id] = @Id",
                    _connection
                );
                command.Parameters.AddWithValue("@Name", student.Name);
                command.Parameters.AddWithValue("@Surname", student.Surname);
                command.Parameters.AddWithValue("@Id", student.Id);
                command.Parameters.AddWithValue("@Group_id", student.Group_id);
                int affected = command.ExecuteNonQuery();
                result = affected > 0;
            }
            finally
            {
                _connection.Close();
            }
            return result;
        }
        public bool Delete(Student student)
        {
            bool result = false;
            try
            {
                _connection.Open();
                var command = new SqlCommand(
                    cmdText: @"
                              DELETE FROM [Students]
                              WHERE [id] = @Id",
                    _connection
                );
                command.Parameters.AddWithValue("@id", student.Id);

                int affected = command.ExecuteNonQuery();
                result = affected > 0;
            }
            finally
            {
                _connection.Close();
            }
            return result;
        }
    }
}
