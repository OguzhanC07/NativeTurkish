using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NativeTurkish.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTurkish.Entities.EfCore.Mappings
{
    public class LevelMap : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            
            
            builder.Property(I => I.Name).HasMaxLength(500).IsRequired();

            builder.HasMany(I => I.Questions).WithOne(I => I.Level).HasForeignKey(I => I.LevelId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
