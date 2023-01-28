using System;
using System.Collections.Generic;

namespace Labb3_Database.Models
{
    public partial class TblGrade
    {
        public int Id { get; set; }
        public int? Ranking { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime Date { get; set; }

        public virtual TblCourse Course { get; set; } = null!;
        public virtual TblStudent Student { get; set; } = null!;
    }
}
