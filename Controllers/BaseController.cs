using OBLIslamiPOApi.Infrastructure.Utility;
using OBLIslamiPOApi.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OBLIslamiPOApi.LoginSecurity;
using OBLIslamiPOApi.DataOperations;

namespace OBLIslamiPOApi.Controllers
{
    public class BaseController : Controller
    {
        protected IUnitOfWork Uow { get; set; }

        protected ILogger Logger { get; set; }
        protected IOptions<ConfigurationOptions> Options { get; set; }

        protected ILoginDP LDp { get; set; }
        protected ITransActionDP TDp { get; set; }

     
    }
}