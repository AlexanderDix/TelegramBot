using Microsoft.Extensions.DependencyInjection;
using TelegramBotUI.ViewModels.WindowViewModels;

namespace TelegramBotUI.ViewModels
{
    internal class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel => App.Services.GetRequiredService<MainWindowViewModel>();
    }
}