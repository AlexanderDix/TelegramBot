using Microsoft.Extensions.DependencyInjection;
using TelegramBotUI.Services.Interfaces;

namespace TelegramBotUI.Services
{
    internal static class ServicesRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddTransient<IUserDialog, UserDialogService>();
    }
}