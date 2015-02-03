using System.Threading.Tasks;

namespace Saxo.Flow
{
    public interface IFlow
    {
        Task<FlowResultBase> Execute(RequestInfo requestInfo);
    }
}