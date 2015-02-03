using System;
using System.Collections.Generic;

namespace Saxo.Flow
{
    public abstract class FlowResultBase
    {
        public List<ServiceErrorDetails> ErrorsDetails { get; set; }

        public bool IsValidResult { get; set; }
    }

    public class ServiceErrorDetails
    {
        public string ServiceName { get; set; }
        public string Query { get; set; }
        public Exception Exception { get; set; }
    }
}