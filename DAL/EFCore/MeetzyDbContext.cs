// SYSTEM PACKAGES
using System;
using System.Text;
using System.Collections.Generic;

// NUGET PACKAGES
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

// IMPORTED NAMESPACES
using Entities.Auth;
using Entities.Concrete;
using System.Reflection;

// ACTIVE NAMESPACE
namespace DAL.EFCore;

public class MeetzyDbContext:IdentityDbContext<AppUser>
{
    // CONSTRUCTION
    public MeetzyDbContext(DbContextOptions<MeetzyDbContext> options):base(options)
    {}

    // ADD TABLES
    public DbSet<ActivityLog> ActivityLogs {get; set;}
    public DbSet<Chat> Chats {get; set;}
    public DbSet<City> Cities {get; set;}
    public DbSet<Comment> Comments {get; set;}
    public DbSet<CommentReaction> CommentReactions {get; set;}
    public DbSet<Country> Countries {get; set;}
    public DbSet<FriendRequest> FriendRequests {get; set;}
    public DbSet<FriendsList> FriendsLists {get; set;}
    public DbSet<Hashtag> Hashtags {get; set;}
    public DbSet<MediaFile> MediaFiles {get; set;}
    public DbSet<Message> Messages {get; set;}
    public DbSet<Notification> Notifications {get; set;}
    public DbSet<Post> Posts {get; set;}
    public DbSet<PostReaction> PostReactions {get; set;}
    public DbSet<Profile> Profiles {get; set;}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
