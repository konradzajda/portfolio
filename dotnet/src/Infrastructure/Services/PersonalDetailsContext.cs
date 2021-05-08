// <copyright file="/Users/konrad/Documents/GitHub/portfolio/dotnet/src/Infrastructure/Services/PersonalDetailsContext.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Application.Daos;
using Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Services
{
    public class PersonalDetailsContext : DbContext, IPersonalDetailsContext
    {
        public DbSet<PersonalDetailsDao> Personals { get; init; }

        public PersonalDetailsContext(DbContextOptions<PersonalDetailsContext> options)
            : base(options)
        {
        }

        public Task<int> SaveChangesAsync(CancellationToken token = default)
        {
            var trackables = this.ChangeTracker.Entries<ITrackable>()
                .ToArray();

            var modifiedTrackables = trackables.Where(y => y.State == EntityState.Modified);
            var createdTrackables = trackables.Where(y => y.State == EntityState.Added);

            foreach (var trackable in modifiedTrackables)
            {
                HandleUpdatedEntity(trackable);
            }

            foreach (var trackable in createdTrackables)
            {
                HandleCreatedEntity(trackable);
            }

            return base.SaveChangesAsync(token);
        }

        private static void HandleCreatedEntity(EntityEntry<ITrackable> entity)
        {
            if (entity.State != EntityState.Added)
            {
                throw new ArgumentException(
                    "Cannot set new creation date on the entity that is not in Added state",
                    nameof(entity));
            }

            SetPropertyToUtcNow(entity, nameof(ITrackable.CreationDateUtc));
            SetPropertyToUtcNow(entity, nameof(ITrackable.UpdateDateUtc));
        }

        private static void HandleUpdatedEntity(EntityEntry<ITrackable> entity)
        {
            if (entity.State != EntityState.Modified)
            {
                throw new ArgumentException(
                    "Cannot set new update date on the entity that is not in Modified state",
                    nameof(entity));
            }

            SetPropertyToUtcNow(entity, nameof(ITrackable.UpdateDateUtc));
        }

        private static void SetPropertyToUtcNow(EntityEntry<ITrackable> entity, string propertyName)
        {
            entity.Property<DateTime>(propertyName).CurrentValue = DateTime.UtcNow;
        }
    }
}