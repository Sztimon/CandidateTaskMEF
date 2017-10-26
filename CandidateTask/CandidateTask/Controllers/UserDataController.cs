using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataModel;
using DataModel.Models;

namespace CandidateTask.Controllers
{
    public class UserDataController : Controller
    {
        // GET: UserData
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUserData(UserData newUser)
        {
            List<UserData> listOfUsers = (List<UserData>)Session["UsersData"];
            if (listOfUsers == null)
            {
                listOfUsers = new List<UserData>();
            }
            listOfUsers.Add(newUser);
            Session["UsersData"] = listOfUsers;
            return RedirectToAction("Index", "UserData");
        }

        [HttpPost]
        public ActionResult SaveUserData()
        {
            List<UserData> listOfUsers = (List<UserData>)Session["UsersData"];
            if (listOfUsers != null)
            {
                SaveUserData saveUserData = new SaveUserData();
                saveUserData.SaveData(listOfUsers);
                Session["UsersData"] = null;
                listOfUsers = null;
            }
            return RedirectToAction("Index", "UserData");
        }
    }
}