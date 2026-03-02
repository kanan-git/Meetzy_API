using System;
using System.Text;
using System.Collections.Generic;

using Core.Entities.Abstract;

namespace Entities.Common;

public class BaseEntity:IEntity
{
    public Guid Id {get; set;}
    public DateTime CreatedAt {get; set;}
    public DateTime UpdatedAt {get; set;}
}
