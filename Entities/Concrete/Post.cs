using System;
using System.Text;
using System.Collections.Generic;

using Entities.Common;
using Entities.Auth;

namespace Entities.Concrete;

public class Post:BaseEntity
{
    // main
    public string TextContent {get; set;}
    public string? Location {get; set;} = null!;

    // relation (many Post → one Profile)
    public Guid ProfileId {get; set;}
    public Profile Profile {get; set;}

    // relation (one Post ← many Comment)
    public List<Comment>? Comments {get; set;} = null!;

    // relation (one Post ← many PostReaction)
    public List<PostReaction>? PostReactions {get; set;} = null!;

    // relation (one Post ← many MediaFile)
    public List<MediaFile>? MediaFiles {get; set;} = null!;

    // relation (many Post ↔ many Hashtag)
    public List<Hashtag>? Hashtag {get; set;} = null!;
}
