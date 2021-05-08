// <copyright file="PersonalDetailsContext.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Application.Abstractions;
using Application.Daos;
using Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Services
{
    /// <summary>
    /// Provides data access object managing based on the Entity Framework's <see cref="DbContext"/>.
    /// </summary>
    public class PersonalDetailsContext : DbContext, IPersonalDetailsContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonalDetailsContext"/> class.
        /// </summary>
        /// <param name="options">Options of the context, see <see cref="DbContextOptions{TContext}"/>.</param>
        public PersonalDetailsContext(DbContextOptions<PersonalDetailsContext> options)
            : base(options)
        {
        }

        /// <inheritdoc />
        public DbSet<PersonalDetailsDao> Personals { get; init; }

        /// <inheritdoc />
        public new Task<int> SaveChangesAsync(CancellationToken token = default)
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