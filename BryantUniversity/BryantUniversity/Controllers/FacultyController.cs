using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Models.Repo;
using BryantUniversity.ViewModels;
using System.Web.Mvc;

namespace BryantUniversity.Controllers
{
    public class FacultyController : Controller
    {
        private Context context;

        public FacultyController()
        {
            context = new Context();
        }

        // GET: Faculty
        [HttpGet]
        public ActionResult Index()
        {
            using(context)
            {
                var viewModel = new UserListViewModel();
                var userRepository = new UserRepo(context);

                viewModel.Users = userRepository.GetAllUsers();

                return View(viewModel);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            var userViewModel = new UserViewModel();
            return View(userViewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(userViewModel.Password);
                User user = new User(userViewModel.Email, hashedPassword, userViewModel.Name);
                UserRepo repository;

                using (context)
                {
                    repository = new UserRepo(context);
                    repository.Insert(user);

                    var roleRepo = new UserRoleRepo(context);
                    UserRole userRole;

                    int userId = repository.GetById(user.Id).Id;

                    switch (userViewModel.RoleType)
                    {
                        case RoleType.Admin:
                            userRole = new UserRole(userId, 1);
                            break;
                        case RoleType.Faculty:
                            userRole = new UserRole(userId, 2);
                            break;
                        case RoleType.Researcher:
                            userRole = new UserRole(userId, 3);
                            break;
                        case RoleType.Student:
                            userRole = new UserRole(userId, 4);
                            break;
                        default:
                            userRole = new UserRole();
                            break;
                    }

                    roleRepo.Insert(userRole);
                }
                return RedirectToAction("Create", "Faculty");
            }

            return View(userViewModel);
        }
    }
}