using Microsoft.Extensions.DependencyInjection;
using TelegramBotUI.ViewModels.WindowViewModels;

namespace TelegramBotUI.ViewModels
{
    internal static class ViewModelsRegistrator
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services) => services
            .AddSingleton<MainWindowViewModel>();
    }
}