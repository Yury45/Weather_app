using System;
using System.Collections.Generic;
using WPF_MVVM_Template.Models;
using WPF_MVVM_Template.Services.Interfaces;

namespace WPF_MVVM_Template.Services.Base
{
    abstract class RepositoryBase<T> : IRepository<T> where T : IEntity
    {
        private List<T>? _Items = new List<T>();

        private long _CurrentId = 1;

        public RepositoryBase() { }

        public RepositoryBase(IEnumerable<T> items)
        {
            _Items.AddRange(items);
            foreach (var item in items)
            {
                Add(item);
            }
        }

        public void Add(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            if (_Items.Contains(item)) return;

            item.Id = ++_CurrentId;
            _Items.Add(item);
        }

        public IEnumerable<T> GetAll() => _Items;

        public List<T> Set(List<T> NewItems) => _Items = NewItems;

        public bool Remove(T item) => _Items.Remove(item);

        public void Update(long id, T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            if (id < 1) throw new ArgumentOutOfRangeException(nameof(id), id, "Идентификатор не может быть меньше 1");

            if (_Items.Contains(item)) return;

            var db_item = ((IRepository<T>)this).Get(id);
            if (db_item == null) throw new InvalidOperationException("Элемент не отсутствует в базе");
            Update(item, db_item);
        }

        protected abstract void Update(T Source, T Destination);
    }
}
