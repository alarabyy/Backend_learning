using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Port.Filters
{
    public class HandleErrorAttribute : Attribute , IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //catch 
            ContentResult contentResult = new ContentResult();
            contentResult.Content = " Some Exception  throw";
            context.Result = contentResult;
        }
    }
}
