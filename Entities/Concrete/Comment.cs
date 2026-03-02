using System;
using System.Text;
using System.Collections.Generic;

using Entities.Common;

namespace Entities.Concrete;

public class Comment:BaseEntity
{
    // main
    public string Text {get; set;}

    // relation (one Post ← many Comment)
    public Guid PostId {get; set;}
    public Post Post {get; set;}

    // relation (many Comment → one Profile)
    public Guid ProfileId {get; set;}
    public Profile Profile {get; set;}

    // relation (one Comment ← many Comment)
    public Guid? ParentCommentId {get; set;} = null!;
    public Comment? ParentComment {get; set;} = null!;

    // relation (one Comment ← many Comment)
    public List<Comment>? Replies {get; set;} = null!;

    // relation (one Comment ← many CommentReaction)
    public List<CommentReaction>? CommentReactions {get; set;} = null!;
}
