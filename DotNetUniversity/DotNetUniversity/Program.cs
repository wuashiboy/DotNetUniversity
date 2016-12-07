using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DotNetUniversity
{
    class Program
    {
        static List<Course> ReadCourse(SqlConnection conn)
        {
            //test to see if I get everything back from Course
            var rv = new List<Course>();
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = @"SELECT Id, Title, InstructorID, CourseNo, DepartmentID FROM Course";

                //conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var id = reader[0];
                    var title = reader[1];
                    var instructorid = reader[2];
                    var courseno = reader[3];
                    var departmentid = reader[4];
                    var course = new Course
                    {
                        Id = (int)id,
                        Title = title as string,
                        InstructorID = (int)instructorid,
                        CourseNo = (int)courseno,
                        DepartmentID = (int)departmentid
                    };
                    rv.Add(course);
                }
                //conn.Close();
            }
            return rv;

        }

        static void Main(string[] args)
        {
            var connectionStrings = @"Server=Orion\SQLEXPRESS;Database=DotNetUniversity;Trusted_Connection=True;";
            using (var connection = new SqlConnection(connectionStrings))
            {
                connection.Open();
                var courses = ReadCourse(connection);
                foreach (var course in courses)
                {
                    Console.WriteLine(course);
                }

                connection.Close();
            }
            Console.ReadLine();
        }
    }
}

