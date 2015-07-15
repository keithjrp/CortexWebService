// ***********************************************************************
// Assembly         : CortexWebService
// Author           : ktam
// Created          : 01-28-2015
//
// Last Modified By : ktam
// Last Modified On : 01-28-2015
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// The CortexWebService namespace.
/// </summary>
namespace CortexWebService
{
    /// <summary>
    /// Interface IAuditable
    /// </summary>
    public interface IAuditable
    {
        /// <summary>
        /// Gets or sets the created by identifier.
        /// </summary>
        /// <value>The created by identifier.</value>
        Guid CreatedById { get; set; }
        /// <summary>
        /// Gets or sets the created date time.
        /// </summary>
        /// <value>The created date time.</value>
        DateTime CreatedDateTime { get; set; }
        /// <summary>
        /// Gets or sets the edited by identifier.
        /// </summary>
        /// <value>The edited by identifier.</value>
        Guid EditedById { get; set; }
        /// <summary>
        /// Gets or sets the edited date time.
        /// </summary>
        /// <value>The edited date time.</value>
        DateTime EditedDateTime { get; set; }
    }

    /// <summary>
    /// Interface IDeletable
    /// </summary>
    public interface IDeletable
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value><c>true</c> if this instance is deleted; otherwise, <c>false</c>.</value>
        bool IsDeleted { get; set; }
    }

    /// <summary>
    /// Interface IVersionable
    /// </summary>
    public interface IVersionable
    {
        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>The version.</value>
        int Version { get; set; }
    }

    /// <summary>
    /// Interface IId
    /// </summary>
    public interface IId
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        Guid Id { get; set; }
    }
}
