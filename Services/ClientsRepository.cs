using WPF_MVVM_Template.Models;
using WPF_MVVM_Template.Services.Base;

namespace WPF_MVVM_Template.Services
{
    class ClientsRepository : RepositoryBase<Client>
    {
        protected override void Update(Client Source, Client Destination)
        {
            Destination.State = Source.State;
            Destination.Messages = Source.Messages;
            Destination.Id = Source.Id;
        }

    }
}
