// <copyright file="ApiProfile.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

using Api.Personal.Views;
using Application.Resources;

namespace AutoMapper
{
    /// <summary>
    /// Represents <see cref="Profile"/> for the presentation layer.
    /// </summary>
    internal class ApiProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiProfile"/> class.
        /// </summary>
        public ApiProfile()
        {
            this.CreateMap<PersonalDetailsResource, PersonalDetailsViewModel>();
        }
    }
}