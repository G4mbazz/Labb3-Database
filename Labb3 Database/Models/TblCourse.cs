using System;
using System.Collections.Generic;

namespace Labb3_Database.Models
{
    public partial class TblCourse
    {
        public TblCourse()
        {
            TblGrades = new HashSet<TblGrade>();
        }

        public int Id { get; set; }
        public string CourseName { get; set; } = null!;
        public string CourseDescription { get; set; } = null!;
        public int TeacherId { get; set; }

        public virtual TblEmployee Teacher { get; set; } = null!;
        public virtual ICollection<TblGrade> TblGrades { get; set; }
    }
}
