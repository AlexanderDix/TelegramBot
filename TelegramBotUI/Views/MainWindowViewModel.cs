using TelegramBotUI.ViewModels.Base;

namespace TelegramBotUI.Views
{
    internal class MainWindowViewModel : ViewModel
    {
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

        #endregion

        #region Commands

        #endregion

        #region Methods

        #endregion

        #region Constructors

        #endregion
    }
}