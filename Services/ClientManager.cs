using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVM_Template.Annotations;
using WPF_MVVM_Template.Models;

namespace WPF_MVVM_Template.Services
{
    class ClientManager
    {
        private ClientsRepository _Clients = new ClientsRepository();

        public List<Client>? Clients
        {
            get { return _Clients.GetAll().ToList(); }
            set => _Clients.Set(value);
        }


        public ClientManager(ClientsRepository Clients)
        {
            _Clients = Clients;
        }
    }
}
