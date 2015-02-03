using System;
using System.Collections.Generic;
using System.Linq;

namespace Saxo.Flow
{
    public class SaxoFlow : FlowBase<SaxoFlowResult>
    {
        protected override void InitializeDataService(RequestInfo requestInfo)
        {
            DataService = new SaxoService(requestInfo);
        }

        protected override void InitializeResult(SaxoFlowResult result)
        {
            dynamic data = DataService.QueryResult.products;
            var item = data as List<object>;
            if (item == null)
            {
                result.IsValidResult = false;
                return;
            }

            var objDic = item.FirstOrDefault() as IDictionary<string, Object>;
            if (objDic == null)
            {
                result.IsValidResult = false;
                return;
            }

            result.Isbn = (string)objDic["isbn13"];
            result.ImageUrl = (string)objDic["imageurl"];

            result.Label = (string)objDic["label"];

            result.Title = (string)objDic["title"]; 
            result.RatingCount = (int)objDic["ratingcount"];

            result.Url = (string)objDic["url"];

            result.IsValidResult = true;
        }
    }
}