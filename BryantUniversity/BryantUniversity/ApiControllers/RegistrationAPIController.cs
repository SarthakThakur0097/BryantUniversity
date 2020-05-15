using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Repo;
using System.Collections.Generic;
using System.Web.Http;

namespace BryantUniversity.ApiControllers
{
    [RoutePrefix("api/Registration")]
    [AllowAnonymous]
    public class RegistrationApiController : ApiController
    {
        // GET: CourseApi
        private Context context;

        public RegistrationApiController()
        {
            context = new Context();
        }

        [Route("{registrationId}")]
        [HttpPost]
        public IHttpActionResult DropStudentCourse(int registrationId)
        {
            bool test = ModelState.IsValid;
            RegistrationRepo rRepo;

            using (context)
            {
                rRepo = new RegistrationRepo(context);
                rRepo.Delete(registrationId);

                return Json(new { redirectUrl = "/Student/drop", error = "" });
            }
        }

    }
}