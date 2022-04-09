using System.Collections;
using System.Collections.Generic;
using TelegramBotUI.Models;
using TelegramBotUI.Services.Repository;
using TelegramBotUI.ViewModels.Base;

namespace TelegramBotUI.ViewModels.WindowViewModels
{
    internal class MainWindowViewModel : ViewModel
    {

        #region Fields

        private readonly ContactMessageManager _messageManager;
        public IEnumerable<Contact> Contacts => _messageManager.Contacts;
        public IEnumerable<ContactMessage> Messages => _messageManager.Messages;

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

        public MainWindowViewModel(ContactMessageManager messageManager)
        {
            _messageManager = messageManager;
        }

        #endregion
    }
}