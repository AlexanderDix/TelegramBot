using Microsoft.Extensions.DependencyInjection;
using TelegramBotUI.Services.Interfaces;
using TelegramBotUI.Services.Repository;

namespace TelegramBotUI.Services
{
    internal static class ServicesRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddTransient<IUserDialog, UserDialogService>()
            .AddSingleton<ContactRepository>()
            .AddSingleton<ContactMessageRepository>()
            .AddSingleton<ContactMessageManager>();
    }
}