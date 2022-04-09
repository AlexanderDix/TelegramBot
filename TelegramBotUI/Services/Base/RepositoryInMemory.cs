using System;
using System.Collections.Generic;
using TelegramBotUI.Models.Interfaces;
using TelegramBotUI.Services.Interfaces;
using TelegramBotUI.Services.Repository;

namespace TelegramBotUI.Services.Base
{
    internal abstract class RepositoryInMemory<T> : IRepository<T> where T : IEntity
    {
        private readonly List<T> _items = new();
        private int _lastId = 1;

        protected RepositoryInMemory()
        {
        }

        protected RepositoryInMemory(IEnumerable<T> items)
        {
            foreach (T item in items) Add(item);
        }

        public void Add(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            if (_items.Contains(item)) return;

            item.Id = ++_lastId;
            _items.Add(item);
        }

        public bool Remove(T item) => _items.Remove(item);

        public void Update(int id, T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id), "Индекс не может быть меньше 1");

            if (_items.Contains(item)) return;

            T dbItem = ((IRepository<T>) this).Get(id);

            if (dbItem is null) throw new InvalidOperationException("Редактируемый элемент не найден в репозитории");

            Update(item, dbItem);
        }

        protected abstract void Update(T source, T destination);

        public IEnumerable<T> GetAll() => _items;
    }
}