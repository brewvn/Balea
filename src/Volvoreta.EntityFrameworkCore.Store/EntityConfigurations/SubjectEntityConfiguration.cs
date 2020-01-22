﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Volvoreta.EntityFrameworkCore.Store.Entities;
using Volvoreta.EntityFrameworkCore.Store.Options;

namespace Volvoreta.EntityFrameworkCore.Store.EntityConfigurations
{
    internal class SubjectEntityConfiguration : IEntityTypeConfiguration<SubjectEntity>
    {
        private readonly StoreOptions options;

        public SubjectEntityConfiguration(StoreOptions options)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public void Configure(EntityTypeBuilder<SubjectEntity> builder)
        {
            builder.ToTable(options.Subjects.Name);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Sub)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();
            builder
                .HasIndex(x => x.Sub)
                .IsUnique();
        }
    }
}