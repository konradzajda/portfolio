// <copyright file="IPersonalDetailsContext.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

using System.Threading;
using System.Threading.Tasks;

using Application.Daos;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public interface IPersonalDetailsContext
    {
        DbSet<PersonalDetailsDao> Personals { get; }

        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}