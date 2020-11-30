using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models;
using System.Data.SqlClient;

namespace WindowsFormsApp1.Services
{
    public class GroupsProvider
    {
        private SqlConnection _connection;

        public GroupsProvider(SqlConnection connection)
        {
            _connection = connection;
        }
        public List<Group> GetAllWithSpecialties()
        {
            var result = new List<Group>();

            try
            {
                _connection.Open();
                var command = new SqlCommand(
                    cmdText: @"SELECT [Groups].[id],
                                [Groups].[name],
                                [Groups].[year],
                                [Groups].[specialty_id],

                                [Specialties].[name],
                                [Specialties].[code]
                        FROM [Groups]
                        LEFT JOIN [Specialties] 
                     ON [Specialties].[id] = [Groups].[specialty_id]",

                    connection: _connection
                    );

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var specialty = new Specialty
                        {
                            Code = reader.GetString(3),
                            Name = reader.GetString(4),
                            Id = reader.GetInt32(5),

                        };

                        var group = new Group
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Year = reader.GetInt32(2),
                            Specialty_id = reader.GetInt32(3),
                            Specialty = specialty
                        };
                        result.Add(group);
                    }
                }
            }
            finally
            {
                _connection.Close();
            }
            return result;
        }
        public bool Add(Group group)
        {
            bool result = false;
            try
            {
                _connection.Open();

                var command = new SqlCommand(
                    cmdText: @"
                    INSERT INTO [Groups]
                        ([name],[year],[specialtyId]])
                    VALUES
                        (@Name,@Year,@Specialty_id)
                    ",
                     _connection
                );
                command.Parameters.AddWithValue("@Name", group.Name);
                command.Parameters.AddWithValue("@Year", group.Year);
                command.Parameters.AddWithValue("@SpecialtyId", group.Specialty_id);

                int affected = command.ExecuteNonQuery();
                result = affected > 0;
            }
            finally
            {
                _connection.Close();
            }
            return result;
        }
        public bool Update(int id, Group group)
        {
            bool result = false;
            try
            {
                _connection.Open();
                var command = new SqlCommand(
                    @"
                        UPDATE [Specialties]
                        SET
                            [name] = @Name,
                            [Year] = @Year,
                            [SpecialtyId] = @SpecialtyId
                        WHERE
                            [id] = @Id
                    ",
                    _connection
                    );
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Name", group.Name);
                command.Parameters.AddWithValue("@Year", group.Year);
                command.Parameters.AddWithValue("@SpecialtyId", group.Specialty_id);


                int affected = command.ExecuteNonQuery();
                result = affected > 0;
            }
            finally
            {
                _connection.Close();
            }
            return result;
        }
        public bool Delete(int id, Group group)
        {
            bool result = false;

            try
            {
                _connection.Open();
                var command = new SqlCommand(
                    @"
                        DELETE FROM [Groups]
                        WHERE [id] = @Id
                    ",
                    _connection
                    );
                command.Parameters.AddWithValue("@Id", group.Id);
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

