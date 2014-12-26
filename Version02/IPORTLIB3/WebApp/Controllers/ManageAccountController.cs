using System.Web.Mvc;
using System.Web.Security;

namespace MvcAppAccount.Controllers
{
    public class ManageAccountController : Controller
    {

        public ActionResult Index()
        {
            return View(Membership.GetAllUsers());
        }
        public ActionResult Delete(string id)
        {
            Membership.DeleteUser(id);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(string id)
        {
            return View(Roles.GetAllRoles());
        }
        public ActionResult Update(string id)
        {
            string[] arr = id.Split('-');
            if (bool.Parse(arr[2]))
                Roles.AddUserToRole(arr[0], arr[1]);
            else
                Roles.RemoveUserFromRole(arr[0], arr[1]);
            return RedirectToAction("Edit/" + arr[0]);
        }
        public ActionResult ManageRole()
        {
            return View(Roles.GetAllRoles());
        }
        public ActionResult EditRole(string id)
        {
            return View((object)id);
        }
        [HttpPost]
        public ActionResult EditRole(string id, string RoleName)
        {
            Roles.DeleteRole(id);
            Roles.CreateRole(RoleName);
            return RedirectToAction("ManageRole");
        }
        public ActionResult DeleteRole(string id)
        {
            Roles.DeleteRole(id);
            return RedirectToAction("ManageRole");
        }
        public ActionResult AddRole(string RoleName)
        {
            if (!Roles.RoleExists(RoleName))
            {
                Roles.CreateRole(RoleName);
            }
            return Redirect("ManageRole");
        }

    }
}
