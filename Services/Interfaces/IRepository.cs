using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVM_Template.Models;

namespace WPF_MVVM_Template.Services.Interfaces
{
    public interface IRepository<T> where T: IEntity
    {
        void Add(T item);

        IEnumerable<T> GetAll();

        T Get(long Id) => GetAll().FirstOrDefault(item => item.Id == Id);

        bool Remove(T item);

        void Update(long Id, T item);

    }
}
