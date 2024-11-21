using Microsoft.AspNetCore.Mvc;
using Port.Filters;

namespace Port.Controllers.Test
{
    public class Test
    {
        [HandleError]
        public IActionResult Index()
        {
            throw new Exception("Exception for error");
        }
    }
}
