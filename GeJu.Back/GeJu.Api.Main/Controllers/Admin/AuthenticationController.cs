using GeJu.Sql;
using Microsoft.AspNetCore.Mvc;

namespace GeJu.Api.Main.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public AuthenticationController(DataContext context)
        {
            _dataContext = context;
        }
    }
}
