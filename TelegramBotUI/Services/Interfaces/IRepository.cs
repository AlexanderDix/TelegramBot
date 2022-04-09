using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TelegramBotUI.Models.Interfaces;

namespace TelegramBotUI.Services.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        void Add(T item);
        bool Remove (T item);
        void Update(int id, T item);
        IEnumerable<T> GetAll();
        T Get(int id) => GetAll().FirstOrDefault(item => item.Id == id);
    }
}