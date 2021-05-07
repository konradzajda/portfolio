// <copyright file="GetFirstNameQuery.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

using Application.Abstractions;
using MediatR;

namespace Application.Queries.PersonalDetails
{
    /// <summary>
    /// Defines query for getting first name.
    /// </summary>
    public sealed class GetFirstNameQuery : IRequest<IResult<string>>
    {
    }
}