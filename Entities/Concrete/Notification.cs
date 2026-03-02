using System;
using System.Text;
using System.Collections.Generic;

using Entities.Common;

namespace Entities.Concrete;

public class Notification:BaseEntity
{
    // main
    public string Info {get; set;}
    public bool IsRead {get; set;}

    // relation (one Profile ← many Notification)
    public Guid TargetProfileId {get; set;}
    public Profile TargetProfile {get; set;}
}
