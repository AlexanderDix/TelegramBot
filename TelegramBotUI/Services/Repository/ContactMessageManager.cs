using System.Collections;
using System.Collections.Generic;
using TelegramBotUI.Models;

namespace TelegramBotUI.Services.Repository
{
    internal class ContactMessageManager
    {
        private readonly ContactRepository _contacts;
        private readonly ContactMessageRepository _messages;

        public IEnumerable<Contact> Contacts => _contacts.GetAll();
        public IEnumerable<ContactMessage> Messages => _messages.GetAll();

        public ContactMessageManager(ContactRepository contacts, ContactMessageRepository messages)
        {
            _contacts = contacts;
            _messages = messages;
        }
    }
}