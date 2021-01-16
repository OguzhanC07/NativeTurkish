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
    public class QuestionChoicesMap : IEntityTypeConfiguration<QuestionChoices>
    {
        public void Configure(EntityTypeBuilder<QuestionChoices> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.HasMany(I => I.UserQuestionAnswers).WithOne(I => I.QuestionChoices).HasForeignKey(I => I.ChoiceId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
