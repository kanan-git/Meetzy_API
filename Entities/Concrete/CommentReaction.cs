using System;
using System.Text;
using System.Collections.Generic;

using Entities.Common;

namespace Entities.Concrete;

public class CommentReaction:BaseEntity
{
    // main
    public string ReactionType {get; set;} // like dislike, from enum later

    // relation (one Profile ← many CommentReaction)
    public Guid ProfileId {get; set;}
    public Profile Profile {get; set;}

    // relation (one Comment ← many CommentReaction)
    public Guid CommentId {get; set;}
    public Comment Comment {get; set;}
}
