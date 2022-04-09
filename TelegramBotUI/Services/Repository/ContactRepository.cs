using TelegramBotUI.Models;
using TelegramBotUI.Services.Base;

namespace TelegramBotUI.Services.Repository
{
    internal class ContactRepository : RepositoryInMemory<Contact>
    {
        protected override void Update(Contact source, Contact destination)
        {
            destination.FirstName = source.FirstName;
            destination.LastName = source.LastName;
            destination.UserName = source.UserName;
        }
    }
}