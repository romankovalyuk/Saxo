using System;

namespace Saxo.Flow
{
    public interface IDataService
    {
        string Query { get; }
        dynamic QueryResult { get; }
        object RawData { get; }
        Exception ServiceException { get; }

        void Search();
        bool IsQuerySuccessfull(); 
    }
}