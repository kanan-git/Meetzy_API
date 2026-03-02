using System;
using System.Text;
using System.Collections.Generic;

using Entities.Common;

namespace Entities.Concrete;

public class FriendRequest:BaseEntity
{
    // main
    public string Status {get; set;} // accepted pending rejected, from enum later

    // relation (many FriendRequest → One Profile)
    public Guid SenderProfileId {get; set;}
    public Profile SenderProfile {get; set;}

    // relation (many FriendRequest → One Profile)
    public Guid ReceiverProfileId {get; set;}
    public Profile ReceiverProfile {get; set;}
}
