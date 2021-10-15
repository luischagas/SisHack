using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisHack.Domain.Entities;

namespace SisHack.Infrastructure.Mappings
{
    public class PeopleMapping : IEntityTypeConfiguration<People>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<People> builder)
        {
            builder
                .ToTable("People");

            builder
                .Property(p => p.CreatedOn)
                .HasColumnType("datetime")
                .IsRequired();

            builder
                .Property(p => p.IsDeleted)
                .IsRequired();

            builder
                .Property(p => p.PhoneNumber)
                .IsRequired();

            builder
                .Property(p => p.Name)
                .IsRequired();

            builder
                .Property(p => p.Type)
                .IsRequired();

            builder
                .Ignore(p => p.CascadeMode);

            builder
                .Ignore(p => p.ValidationResult);

            builder.HasQueryFilter(p => p.IsDeleted == false);
        }

        #endregion Methods
    }
}
