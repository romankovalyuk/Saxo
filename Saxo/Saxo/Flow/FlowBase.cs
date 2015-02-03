using System.Threading.Tasks;

namespace Saxo.Flow
{
    public abstract class FlowBase : IFlow
    {
        public virtual Task<FlowResultBase> Execute(RequestInfo requestInfo)
        {
            return Task.FromResult<FlowResultBase>(null);
        }
    }

    public abstract class FlowBase<T> : FlowBase where T : FlowResultBase, new()
    {
        protected IDataService DataService { get; set; }

        protected abstract void InitializeDataService(RequestInfo requestInfo);
        protected abstract void InitializeResult(T result);

        public override sealed async Task<FlowResultBase> Execute(RequestInfo requestInfo)
        {
            await base.Execute(requestInfo).ConfigureAwait(false);

            InitializeDataService(requestInfo);
            var result = new T();

            if (!await ExecuteService(result, DataService).ConfigureAwait(false))
            {
                return result;
            }

            InitializeResult(result);
            
            return result;
        }

        protected Task<bool> ExecuteService(FlowResultBase result, IDataService service)
        {
            service.Search();

            var isQuerySuccessful = service.IsQuerySuccessfull();
            
            if (isQuerySuccessful)
            {
                return Task.FromResult(true);
            }

            result.ErrorsDetails.Add(new ServiceErrorDetails
            {
                ServiceName = service.GetType().Name,
                Exception = service.ServiceException,
                Query = service.Query,
            });

            return Task.FromResult(false);
        }
    }
}