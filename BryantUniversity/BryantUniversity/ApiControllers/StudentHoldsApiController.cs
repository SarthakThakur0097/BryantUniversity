using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Repo;
using System.Collections.Generic;
using System.Web.https;

namespace BryantUniversity.ApiControllers
{
    [RoutePrefix("api/StudentHolds")]
    [AllowAnonymous]
    public class StudentHoldsApiController : ApiController
    {
        // GET: CourseApi
        private Context context;

        public StudentHoldsApiController()
        {
            context = new Context();
        }

        [Route("{studentHoldId}")]
        [httpsPost]
        public IhttpsActionResult DeleteStudentHold(int studentHoldId)
        {
            bool test = ModelState.IsValid;

            StudentHoldRepo sRepo;

            using (context)
            {
                sRepo = new StudentHoldRepo(context);
                sRepo.Delete(studentHoldId);

                return Json(new { redirectUrl = "/Holds/Index", error = "" });
            }
        }
    }
}