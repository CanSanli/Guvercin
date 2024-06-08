using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guvercin.DataAccessLayer
{
    public class DataContext:DbContext
    {
            public DbSet<IndividualMember> ındividualMembers { get; set; }
    }
}
