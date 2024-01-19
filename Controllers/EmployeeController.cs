using Microsoft.AspNetCore.Mvc;
using MVCCoreApp5.Models;
using System.Xml.Linq;

namespace MVCCoreApp5.Controllers
{

    public class EmployeeController : Controller
    {
        static List<Employee>? list = null;
        public EmployeeController()
        {
            if (list == null)
            {
                list = new List<Employee>()
            {
      new Employee() { Id = 1, Name = "Deepak", DateofJoining = new DateTime(2020, 02, 10), Salary = 40000, Dept = "IT" },

       new Employee() { Id = 1, Name = "Srishti", DateofJoining = new DateTime(2020, 02, 10), Salary = 40000, Dept = "IT" },

            };
            }
        }
        public IActionResult Index()
        {

            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            list.Add(employee);
            //return View();
            return RedirectToAction("Index");

        }

        public IActionResult Display(int? id)
        {
            if (!id.HasValue)
            {
                ViewBag.msg = "Please provide a ID"; return View();
            }
            else
            {
                var employee = list.FirstOrDefault(x => x.Id == id);
                if (employee == null)
                {
                    ViewBag.msg = "There is no record woth this ID";
                    return View();
                }
                else
                    return View(employee);
            }


        }

        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                ViewBag.msg = "Please provide a ID"; return View();
            }
            else
            {
                var employee = list.Where(x => x.Id == id).FirstOrDefault();
                if (employee == null)
                {
                    ViewBag.msg = "There is no record woth this ID";
                    return View();
                }
                else
                    return View(employee);
            }


        }
        [HttpPost]
        public IActionResult Delete(Employee employee, int id)
        {
            var temp = list.Where(x => x.Id == id).FirstOrDefault();
            if (temp != null)
                list.Remove(temp);
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                ViewBag.msg = "Please provide a ID"; return View();
            }
            else
            {
                var employee = list.Where(x => x.Id == id).FirstOrDefault();
                if (employee == null)
                {
                    ViewBag.msg = "There is no record with this ID";
                    return View();
                }
                else
                    return View(employee);
            }

        }

        [HttpPost]
        public IActionResult Edit(Employee employee, int id)
        {
            var temp = list.Where(x => x.Id == id).FirstOrDefault();
            if (temp != null)
            {
                foreach (Employee emp in list)
                {
                    if (emp.Id == temp.Id)
                    {
                        emp.Id = employee.Id;
                        emp.Name = employee.Name;
                         emp.DateofJoining = employee.DateofJoining;
                        emp.Salary = employee.Salary;
                        emp.Dept = employee.Dept;
                        break;
                    }


                }
            }
            return RedirectToAction("Index");

        }


    }
}







