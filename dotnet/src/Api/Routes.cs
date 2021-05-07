// <copyright file="Routes.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

using Api.Personal.Controllers;

namespace Api
{
    /// <summary>
    /// Dictionary containing values of the controller's routes.
    /// </summary>
    internal static class Routes
    {
        /// <summary>
        /// Route for the <see cref="PersonalDetailsController"/>.
        /// </summary>
        public const string PersonalPrefix = PublicApiPrefix + "personal/";

        private const string PublicApiPrefix = ApiPrefix + "public/";

        private const string ApiPrefix = "api/";
    }
}