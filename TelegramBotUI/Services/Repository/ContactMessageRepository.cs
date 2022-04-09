using TelegramBotUI.Models;
using TelegramBotUI.Services.Base;

namespace TelegramBotUI.Services.Repository
{
    internal class ContactMessageRepository : RepositoryInMemory<ContactMessage>
    {
        protected override void Update(ContactMessage source, ContactMessage destination)
        {
            destination.Text = source.Text;
            destination.Date = source.Date;
        }
    }
}