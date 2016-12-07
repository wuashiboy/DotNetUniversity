using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetUniversity
{
     public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int InstructorID { get; set; }
        public int CourseNo { get; set; }
        public int DepartmentID { get; set; }

        public override string ToString()
        
        {
            return $"{Id}, {Title}, {InstructorID}, {CourseNo}, {DepartmentID}";
        }
    }
}
