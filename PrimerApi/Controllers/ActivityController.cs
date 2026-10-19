using Dao_library;
using Entity_library;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/activities")]
    public class ActivityController : Controller
    {
        private readonly ActivityDao _activityDao;

        public ActivityController(ActivityDao activityDao) 
        { 
         this._activityDao = activityDao;
        }

        [HttpGet]
        public async Task<IEnumerable<ActivityDao>> Get()
        {
            return await _activityDao.GetActivity.ToListAsync();
        }
        
       


    }
}
