using System.Threading.Tasks;

namespace WPF_MVVM_Template.Infrastructure.Commands.Base
{
    internal delegate Task ActionAsync();

    internal delegate Task ActionAsync<in T>(T parameter);
}
