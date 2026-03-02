using System;
using System.Text;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using DAL.EFCore;
using DAL.Repositories.Abstract;
using DAL.Repositories.Concrete.EFCore;
using Microsoft.Extensions.Configuration;

namespace DAL;

public static class ConfigurationServices
{
    public static IServiceCollection AddDALConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        // SCOPES
        services.AddScoped<IActivityLogRepository, EFCActivityLogRepository>();
        services.AddScoped<IChatRepository,EFCChatRepository>();
        services.AddScoped<ICityRepository,EFCCityRepository>();
        services.AddScoped<ICommentRepository,EFCCommentRepository>();
        services.AddScoped<ICommentReactionRepository,EFCCommentReactionRepository>();
        services.AddScoped<ICountryRepository,EFCCountryRepository>();
        services.AddScoped<IFriendRequestRepository,EFCFriendRequestRepository>();
        services.AddScoped<IFriendsListRepository,EFCFriendsListRepository>();
        services.AddScoped<IHashtagRepository,EFCHashtagRepository>();
        services.AddScoped<IMediaFileRepository,EFCMediaFileRepository>();
        services.AddScoped<IMessageRepository,EFCMessageRepository>();
        services.AddScoped<INotificationRepository,EFCNotificationRepository>();
        services.AddScoped<IPostRepository,EFCPostRepository>();
        services.AddScoped<IPostReactionRepository,EFCPostReactionRepository>();
        services.AddScoped<IProfileRepository,EFCProfileRepository>();

        // DB CONTEXT
        services.AddDbContext<MeetzyDbContext>(opt => 
        {
            opt.UseSqlServer(configuration.GetConnectionString("Default"));
        });

        // OUTPUT
        return services;
    }
}
