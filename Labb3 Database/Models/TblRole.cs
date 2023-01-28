using System;
using System.Collections.Generic;

namespace Labb3_Database.Models
{
    public partial class TblRole
    {
        public TblRole()
        {
            TblEmployees = new HashSet<TblEmployee>();
        }

        public int Id { get; set; }
        public string Role { get; set; } = null!;

        public virtual ICollection<TblEmployee> TblEmployees { get; set; }
    }
}
