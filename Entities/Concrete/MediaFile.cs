using System;
using System.Text;
using System.Collections.Generic;

using Entities.Common;

namespace Entities.Concrete;

public class MediaFile:BaseEntity
{
    // main
    public string FileName {get; set;}
    public string FilePath {get; set;}
    public string FileType {get; set;}
    public long? FileSize {get; set;} = null!;
    public byte[] FileData {get; set;}

    // relation (one MediaFile ↔ one Profile)
    public Profile? ProfileImageOwner {get; set;} = null!;

    // relation (many MediaFile → one Profile)
    public Guid ProfileId {get; set;}
    public Profile Profile {get; set;}

    // relation (one Post ← many MediaFile)
    public Guid? PostId {get; set;} = null!;
    public Post Post {get; set;}

    // relation (one Message ← many MediaFile)
    public Guid? MessageId {get; set;} = null!;
    public Message Message {get; set;}
}
