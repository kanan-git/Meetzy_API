using System;
using System.Text;
using System.Collections.Generic;

using Entities.Common;
using Entities.Auth;

namespace Entities.Concrete;

public class Profile:BaseEntity
{
    // main
    // public string CoverPictureUrl {get; set;}
    // public string ProfilePictureUrl {get; set;}
    // public IFormFile ProfileImage {get; set;}
    // public byte[] ProfileImageBytes {get; set;}
    public string? Addressline {get; set;} = null!; // property, street
    public string? Bio {get; set;} = null!;
    public string CurrentStatus {get; set;} // online offline
    public string FeedPageUrl {get; set;}
    public string? IpV4Address {get; set;} = null!; // 255.255.255.255
    public string? IpV6Address {get; set;} = null!; // ffff:ffff:ffff:ffff:ffff:ffff:ffff:ffff
    public bool IsPrivate {get; set;} // public 0 false, private 1 true

    // relation (one Profile ↔ one MediaFile)
    public Guid? ProfileImageId {get; set;} = null!;
    public MediaFile? ProfileImage {get; set;} = null!;

    // relation (one Profile ↔ one AppUser)
    public string? OwnerId {get; set;} = null!;
    public AppUser? Owner {get; set;} = null!;

    // relation (many Profile → one City)
    public Guid? CityId {get; set;} = null!;
    public City? City {get; set;} = null!;

    // relation (one Profile ← many Post)
    public List<Post>? Posts {get; set;} = null!;

    // relation (one Profile ← many Comment)
    public List<Comment>? Comments {get; set;} = null!;

    // relation (one Profile ← many Message)
    public List<Message>? MessagesSent {get; set;} = null!;
    public List<Message>? MessagesReceived {get; set;} = null!;

    // relation (one Profile ← many Notification)
    public List<Notification>? Notifications {get; set;} = null!;

    // relation (one Profile ← many FriendsList)
    public List<FriendsList>? FriendsListsInitiated {get; set;} = null!;
    public List<FriendsList>? FriendsListsReceived {get; set;} = null!;

    // relation (one Profile ← many FriendRequest)
    public List<FriendRequest>? FriendRequestsSent {get; set;} = null!;
    public List<FriendRequest>? FriendRequestsReceived {get; set;} = null!;

    // relation (one Profile ← many ActivityLog)
    public List<ActivityLog>? Activities {get; set;} = null!;

    // relation (one Profile ← many PostReaction)
    public List<PostReaction>? PostReactions {get; set;} = null!;

    // relation (one Profile ← many CommentReaction)
    public List<CommentReaction>? CommentReactions {get; set;} = null!;
}
