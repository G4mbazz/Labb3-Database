using System;
using System.Collections.Generic;

namespace Labb3_Database.Models
{
    public partial class TblEmployee
    {
        public TblEmployee()
        {
            TblCourses = new HashSet<TblCourse>();
        }

        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; } = null!;
        public string Ssn { get; set; } = null!;
        public DateTime? DateOfEmployment { get; set; }

        public virtual TblRole Role { get; set; } = null!;
        public virtual ICollection<TblCourse> TblCourses { get; set; }
    }
}
