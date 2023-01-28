using System;
using System.Collections.Generic;

namespace Labb3_Database.Models
{
    public partial class TblStudent
    {
        public TblStudent()
        {
            TblGrades = new HashSet<TblGrade>();
        }

        public int Id { get; set; }
        public string FName { get; set; } = null!;
        public string LName { get; set; } = null!;
        public string Ssn { get; set; } = null!;

        public virtual ICollection<TblGrade> TblGrades { get; set; }
    }
}
