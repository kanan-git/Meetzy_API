using System;
using System.Text;
using System.Collections.Generic;

using Entities.Common;

namespace Entities.Concrete;

public class Hashtag:BaseEntity
{
    // main
    public string TagValue {get; set;} // from enum later

    // relation (many Hashtag ↔ many Post)
    public List<Post>? Posts {get; set;} = null!;
}
