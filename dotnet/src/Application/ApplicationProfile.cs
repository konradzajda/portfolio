// <copyright file="ApplicationProfile.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

using Application.Daos;
using Application.Resources;

namespace AutoMapper
{
    /// <summary>
    /// Represents a <see cref="Profile"/> of the application layer.
    /// </summary>
    public class ApplicationProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationProfile"/> class.
        /// </summary>
        public ApplicationProfile()
        {
            this.CreateMap<PersonalDetailsDao, PersonalDetailsResource>();
        }
    }
}