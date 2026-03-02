using System;
using System.Text;
using System.Collections.Generic;

using Entities.Common;

namespace Entities.Concrete;

public class FriendsList:BaseEntity
{
    // relation (one Profile ← many FriendsList)
    public Guid ProfileId {get; set;}
    public Profile Profile {get; set;}

    // relation (one Profile ← many FriendsList)
    public Guid FriendId {get; set;}
    public Profile Friend {get; set;}
}
