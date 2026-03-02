using System;
using System.Text;
using System.Collections.Generic;

using Entities.Common;

namespace Entities.Concrete;

public class Chat:BaseEntity
{
    // relation (one Profile ← many Chat)
    public Guid ProfileNo1Id {get; set;}
    public Profile ProfileNo1 {get; set;}

    // relation (one Profile ← many Chat)
    public Guid ProfileNo2Id {get; set;}
    public Profile ProfileNo2 {get; set;}

    // relation (many Message → one Chat)
    public List<Message>? Messages {get; set;} = null!;
}
