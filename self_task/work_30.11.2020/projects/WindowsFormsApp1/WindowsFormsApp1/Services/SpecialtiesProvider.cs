using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models;
using System.Data.SqlClient;

namespace WindowsFormsApp1.Services
{
    public class SpecialtiesProvider
    {
        private SqlConnection _connection;

        public SpecialtiesProvider(SqlConnection connection)
        {
            _connection = connection;
        }
        public List<Specialty> GetAll()
        {
            List<Specialty> result = new List<Specialty>();

            try
            {
                _connection.Open();
                var command = new SqlCommand(
                    cmdText: "SELECT [id], [code], [name] FROM [Specialties]",
                    connection: _connection
                    );

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var speciatly = new Specialty
                        {
                            Id = reader.GetInt32(0),
                            Code = reader.GetString(1),
                            Name = reader.GetString(2),
                        };
                        result.Add(speciatly);
                    }
                }
            }
            finally
            {
                _connection.Close();
            }
            return result;
        }
        public bool Add(Specialty specialty)
        {
            bool result = false;
            try
            {
                _connection.Open();

                var command = new SqlCommand(
                    cmdText: @"
                    INSERT INTO [Specialties]
                        ([code],[name]])
                    VALUES
                        (@Code,@Name)
                    ",
                     _connection
                );
                command.Parameters.AddWithValue("@Code", specialty.Code);
                command.Parameters.AddWithValue("@Name", specialty.Name);

                int affected = command.ExecuteNonQuery();
                result = affected > 0;
            }
            finally
            {
                _connection.Close();
            }
            return result;
        }
        public bool Update(int id, Specialty specialty)
        {
            bool result = false;
            try
            {
                _connection.Open();
                var command = new SqlCommand(
                    @"
                        UPDATE [Specialties]
                        SET
                            [code] = @Code,
                            [name] = @Name
                        WHERE
                            [id] = @Id
                    ",
                    _connection
                    );
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Code", specialty.Code);
                command.Parameters.AddWithValue("@Name", specialty.Name);

                int affected = command.ExecuteNonQuery();
                result = affected > 0;
            }
            finally
            {
                _connection.Close();
            }
            return result;
        }
        public bool Delete(int id)
        {
            bool result = false;

            try
            {
                _connection.Open();
                var command = new SqlCommand(
                    @"
                        DELETE FROM [Specialties]
                        WHERE [id] = @Id
                    ",
                    _connection
                    );
                command.Parameters.AddWithValue("@Id", id);
                var affected = command.ExecuteNonQuery();
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

