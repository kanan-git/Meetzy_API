using System;
using System.Text;
using System.Collections.Generic;

using Entities.Common;

namespace Entities.Concrete;

public class Message:BaseEntity
{
    // main
    public string TextContent {get; set;}
    public bool IsRead {get; set;}

    // relation (one Chat ← many Message)
    public Guid ChatId {get; set;}
    public Chat Chat {get; set;}

    // relation (many Message → one Profile)
    public Guid SenderProfileId {get; set;}
    public Profile SenderProfile {get; set;}

    // relation (many Message → one Profile)
    public Guid ReceiverProfileId {get; set;}
    public Profile ReceiverProfile {get; set;}

    // relation (one Message ← many MediaFile)
    public List<MediaFile> MediaFiles {get; set;}
}
