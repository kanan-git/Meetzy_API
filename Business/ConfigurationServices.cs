using System;
using System.Text;
using System.Reflection;
using System.Collections.Generic;

using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

using Business.Services.Abstract;
using Business.Services.Concrete;

namespace Business;

public static class ConfigurationServices
{
    public static IServiceCollection AddBusinessConfigurations(this IServiceCollection services)
    {
        // FLUENTVALIDATION
        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        // AUTOMAPPER
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(typeof(Business.Profiles.AuthProfiles));

        // SCOPES
        services.AddScoped<IActivityLogService,ActivityLogService>();
        services.AddScoped<IChatService,ChatService>();
        services.AddScoped<ICityService,CityService>();
        services.AddScoped<ICommentService,CommentService>();
        services.AddScoped<ICommentReactionService,CommentReactionService>();
        services.AddScoped<ICountryService,CountryService>();
        services.AddScoped<IFriendRequestService,FriendRequestService>();
        services.AddScoped<IFriendsListService,FriendsListService>();
        services.AddScoped<IHashtagService,HashtagService>();
        services.AddScoped<IMediaFileService,MediaFileService>();
        services.AddScoped<IMessageService,MessageService>();
        services.AddScoped<INotificationService,NotificationService>();
        services.AddScoped<IPostService,PostService>();
        services.AddScoped<IPostReactionService,PostReactionService>();
        services.AddScoped<IProfileService,ProfileService>();

        // OUTPUT
        return services;
    }
}
