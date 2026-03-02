using System;
using System.Text;
using System.Collections.Generic;

using Entities.Common;

namespace Entities.Concrete;

public class PostReaction:BaseEntity
{
    // main
    public string ReactionType {get; set;} // like dislike, from enum later

    // relation (one Profile ← many PostReaction)
    public Guid ProfileId {get; set;}
    public Profile Profile {get; set;}

    // relation (one Post ← many PostReaction)
    public Guid PostId {get; set;}
    public Post Post {get; set;}
}
