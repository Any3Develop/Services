using System.Threading.Tasks;

namespace Services.CommandService
{
    public interface ICommand<in TProtocol> where TProtocol : IProtocol
    {
        Task Execute(TProtocol protocol);
    }
}