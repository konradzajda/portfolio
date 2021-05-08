// <copyright file="PersonalDetailsContextTests.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;

using Application.Daos;
using Application.Services;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Infrastructure.Services
{
    public class PersonalDetailsContextTests
    {
        private readonly IPersonalDetailsContext sut;

        public PersonalDetailsContextTests()
        {
            // TODO: Remove in-memory database from tests.
            var options = new DbContextOptionsBuilder<PersonalDetailsContext>()
                .UseInMemoryDatabase($"{Guid.NewGuid()}")
                .Options;

            this.sut = new PersonalDetailsContext(options);
        }

        [Fact]
        public async Task SaveChanges_ShouldSetCreationDate_WhenNewDaoAdded()
        {
            // Given
            var dao = new PersonalDetailsDao();
            var entry = this.sut.Personals.Add(dao);

            // When
            await this.sut.SaveChangesAsync();

            // Then
            entry.Entity.CreationDateUtc.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(3));
        }

        [Fact]
        public async Task SaveChanges_ShouldSetLastUpdateDate_WhenNewDaoAdded()
        {
            // Given
            var dao = new PersonalDetailsDao();
            var entry = this.sut.Personals.Add(dao);

            // When
            await this.sut.SaveChangesAsync();

            // Then
            entry.Entity.UpdateDateUtc.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(3));
        }

        [Fact]
        public async Task SaveChanges_ShouldSetLastUpdateDate_WhenDaoModified()
        {
            // Given
            var dao = new PersonalDetailsDao();
            this.sut.Personals.Add(dao);
            await this.sut.SaveChangesAsync();

            var entity = await this.sut.Personals.SingleAsync();

            var updateDate = entity.UpdateDateUtc;

            entity.FirstName = nameof(entity.FirstName);

            // When
            await this.sut.SaveChangesAsync();

            // Then
            entity.UpdateDateUtc.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(3))
                .And.Should().NotBe(updateDate);
        }

        [Fact]
        public async Task SaveChanges_ShouldNotChangeCreationDate_WhenDaoModified()
        {
            // Given
            var dao = new PersonalDetailsDao();

            this.sut.Personals.Add(dao);
            await this.sut.SaveChangesAsync();
            var entity = await this.sut.Personals.SingleAsync();

            var creationDate = entity.CreationDateUtc;

            entity.FirstName = nameof(entity.FirstName);

            // When
            await this.sut.SaveChangesAsync();

            // Then
            entity.CreationDateUtc.Should().Be(creationDate);
        }
    }
}