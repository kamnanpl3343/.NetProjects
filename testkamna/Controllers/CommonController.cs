using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace Efox.LeadManager.Controllers
{
    public class CommonController : Controller
    {
        private IConfiguration _configuration;
        private string _databaseConnectionString;
        public CommonController(IConfiguration configuration)
        {
            _configuration = configuration;
            _databaseConnectionString = _configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(_databaseConnectionString))
            {
                //take action about it.
            }
        }


    }
}

