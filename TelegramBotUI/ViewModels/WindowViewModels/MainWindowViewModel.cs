using TelegramBotUI.Models;
using TelegramBotUI.Services;
using TelegramBotUI.ViewModels.Base;

namespace TelegramBotUI.ViewModels.WindowViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private readonly BotManager _botManager;

        #region Fields

        #endregion

        #region Properties

        #region Title : string - Заголовок окна

        ///<summary>Заголовок окна</summary>
        private string _title = "Телеграмм бот UI";

        ///<summary>Заголовок окна</summary>
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        #endregion

        #region SelectedContact : Contact - Выбранный контакт

        ///<summary>Выбранный контакт</summary>
        private Contact _selectedContact;

        ///<summary>Выбранный контакт</summary>
        public Contact SelectedContact
        {
            get => _selectedContact;
            set => Set(ref _selectedContact, value);
        }

        #endregion

        #endregion

        #region Commands

        #endregion

        #region Methods

        #endregion

        #region Constructors

        public MainWindowViewModel(BotManager botManager)
        {
            _botManager = botManager;
        }

        #endregion
    }
}