using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CortexWebService
{
    public interface IAuditable
    {
        Guid CreatedById { get; set; }
        DateTime CreatedDateTime { get; set; }
        Guid EditedById { get; set; }
        DateTime EditedDateTime { get; set; }
    }

    public interface IDeletable
    {
        bool IsDeleted { get; set; }
    }

    public interface IVersionable
    {
        int Version { get; set; }
    }

    public interface IId
    {
        Guid Id { get; set; }
    }
}
