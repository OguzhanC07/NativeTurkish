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
    public class QuestionMap : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.QuestionName).HasMaxLength(500).IsRequired();

            builder.HasMany(I => I.QuestionChoices).WithOne(I => I.Question).HasForeignKey(I => I.QuestionId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(I => I.UserQuestionAnswers).WithOne(I => I.Question).HasForeignKey(I => I.QuestionId).OnDelete(DeleteBehavior.NoAction);



        }

    }
}
