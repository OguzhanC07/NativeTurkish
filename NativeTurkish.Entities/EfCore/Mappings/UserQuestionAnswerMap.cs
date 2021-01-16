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
    public class UserQuestionAnswerMap : IEntityTypeConfiguration<UserQuestionAnswer>
    {
        public void Configure(EntityTypeBuilder<UserQuestionAnswer> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            
        }
    }
}
