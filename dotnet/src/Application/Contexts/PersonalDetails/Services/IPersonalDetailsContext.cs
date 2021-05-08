// <copyright file="IPersonalDetailsContext.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

using System.Threading;
using System.Threading.Tasks;

using Application.Daos;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    /// <summary>
    /// Defines properties and methods for managing data access objects from personal details context.
    /// </summary>
    public interface IPersonalDetailsContext
    {
        /// <summary>
        /// Gets a <see cref="DbSet{TEntity}"/> for the personal details.
        /// </summary>
        DbSet<PersonalDetailsDao> Personals { get; }

        /// <summary>
        /// Saves changes applied to all data access objects.
        /// </summary>
        /// <param name="token">A <see cref="CancellationToken"/> used for cancelling asynchronous operations.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}