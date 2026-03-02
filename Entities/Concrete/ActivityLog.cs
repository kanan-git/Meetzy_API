using System;
using System.Text;
using System.Collections.Generic;

using Entities.Common;

namespace Entities.Concrete;

public class ActivityLog:BaseEntity
{
    // main
    public string Action {get; set;} // from enum later
    public string? Details {get; set;} = null!;
    public string? IpV4Address {get; set;} = null!;
    public string? IpV6Address {get; set;} = null!;

    // relation (one Profile ← many ActivityLog)
    public Guid ProfileId {get; set;}
    public Profile Profile {get; set;}
}
