
using System.Data.Entity;


namespace Guvercin.DataAccessLayer
{
    public class DataContext : DbContext
    {
        public DbSet<IndividualMember> individualMembers { get; set; }
        public DbSet<HouseholdMember> householdMembers { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<IndividualMember>()
        //        .HasMany(im => im.HouseholdMembers)
        //        .WithRequired(hm => hm.IndividualMember)
        //        .HasForeignKey(hm => hm.IndividualMemberId);

        //    base.OnModelCreating(modelBuilder);
        //}

    }


}
