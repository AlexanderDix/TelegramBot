using System;
using System.Linq;
using TelegramBotUI.Models;

namespace TelegramBotUI.Services.Repository
{
    internal static class TestData
    {
        public static Contact[] Contacts { get; } = Enumerable
            .Range(1, 10)
            .Select(c => new Contact
            {
                FirstName = $"Имя {c}",
                LastName = $"Фамилия {c}",
                UserName = $"username {c}"
            })
            .ToArray();

        public static ContactMessage[] Messages { get; } = CreateMessages(Contacts);

        private static ContactMessage[] CreateMessages(Contact[] contacts)
        {
            var random = new Random(DateTime.Now.Millisecond);
            var index = 1;

            foreach (Contact contact in contacts)
                for (var i = 0; i < 10; i++)
                    contact.Messages.Add(new ContactMessage
                    {
                        Text = $"Сообщение {index++}",
                        Date = DateTime.Now.Subtract(TimeSpan.FromSeconds(300 * random.Next()))
                    });

            return contacts.SelectMany(c => c.Messages).ToArray();
        }
    }
}