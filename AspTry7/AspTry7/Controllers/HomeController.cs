using AspTry7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspTry7.Controllers
{
    public class HomeController : Controller
    {
        EmployeesDbContext db = new EmployeesDbContext();
        public ActionResult Index()
        {
            var employees = db.Employeesing;
            ViewBag.Employees = employees;
            var post = db.Posting;
            ViewBag.Postring = post;
            var regsing = db.Regs;
            ViewBag.Regs = regsing;
            SelectList idPosts = new SelectList(db.Posting, "idPost", "name");
            ViewBag.Id = idPosts;
            return View();
        }

        
        public ActionResult AddReg()  
        {
            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            return View();
        }

        [HttpPost]
        public ActionResult About(Employees emploee)
        {
            db.Employeesing.Add(emploee);
            db.SaveChanges();
            return RedirectPermanent("/Home/Index");
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(Post posting)
        {
            db.Posting.Add(posting);
            db.SaveChanges();
            return RedirectPermanent("/Home/Contact");
        }

        [HttpPost]
        public ActionResult AddReg(Reg regs)
        {
            db.Regs.Add(regs);
            db.SaveChanges();
            return RedirectPermanent("/Home/AddReg");
        }

        [HttpGet]
        public ActionResult GetEmployees(int idPost) 
        {
            var query = from x in db.Regs
                        join y in db.Employeesing on x.idEmp equals y.idEmp
                        join z in db.Posting on x.idPost equals z.idPost
                        where z.idPost == idPost && x.idEmp == y.idEmp
                        select new QuryFirstModel
                        {
                            Name = y.surname,
                            Post = z.name
                        };

            query = query.Distinct();
            ViewBag.Emploee = query.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult GetEmploeesDate(DateTime dateBegin, DateTime dateEnd)
        {
            var query = from x in db.Regs
                        join y in db.Employeesing on x.idEmp equals y.idEmp
                        join z in db.Posting on x.idPost equals z.idPost
                        where x.dateTake >= dateBegin && x.dateLeave <= dateEnd
                        select new QueryTheardModel
                        {
                            Surname = y.surname,
                            Name = y.name,
                            Patranomyc = y.lastname
                        };

            query = query.Distinct();
            ViewBag.EmplDate = query.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult GetPosts(string surname)
        {
            var query = from x in db.Regs
                        join y in db.Employeesing on x.idEmp equals y.idEmp
                        join z in db.Posting on x.idPost equals z.idPost
                        where y.surname == surname && x.Status == "Р"
                        select new QuerySecondModel
                        {
                            Name = y.surname,
                            Post = z.name,
                            Salary = z.price * x.WageRate,
                            Date = x.dateTake
                        };

            query = query.Distinct();
            ViewBag.Post = query.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult GetMark(string surname, string name, string lastname)
        {
            var query = from x in db.Regs
                        join y in db.Employeesing on x.idEmp equals y.idEmp
                        join z in db.Posting on x.idPost equals z.idPost
                        where y.surname == surname && y.name == name && y.lastname == lastname
                        select new Mark
                        {
                            NamePost = z.name,
                            dateTake = x.dateTake,
                            dateLeave = x.dateLeave,
                            Desc = x.Desc
                        };

            query = query.Distinct();
            ViewBag.Mark = query.ToList();
            ViewBag.Name = name;
            ViewBag.Surname = surname;
            ViewBag.Lastname = lastname;
            return View();
        }

        public ActionResult getMaxMinPost() 
        {
            var result = from ot in db.Regs
                         join v in db.Employeesing on ot.idEmp equals v.idEmp
                         join c in db.Posting on ot.idPost equals c.idPost
                         //join a in minRate on ot.PositionId equals a.PositionId
                         //join b in maxRate on ot.PositionId equals b.PositionId
                         where c.price * ot.WageRate == c.price
                         //where ot.Rate == a.Rate || ot.Rate == b.Rate
                         select new ThirdModel
                         {
                             surname = v.surname,
                             name = v.name,
                             lastname = v.lastname,
                             Profession = c.name,
                             Salary = c.price
                         };
            ViewBag.Alisa = result.ToList();
            return View();
        }


        [HttpPost]
        public ActionResult GetEmploeesSalary(string month, int year)
        {
            Dictionary<int, string> months = new Dictionary<int, string>(5);
            months.Add(1, "январь");
            months.Add(2, "февраль");
            months.Add(3, "март");
            months.Add(4, "апрель");
            months.Add(5, "май");
            months.Add(6, "июнь");
            months.Add(7, "июль");
            months.Add(8, "август");
            months.Add(9, "сентябрь");
            months.Add(10, "октябрь");
            months.Add(11, "ноябрь");
            months.Add(12, "декабрь");

            int mon = 1;//дефолт
            foreach (var i in months) 
            { 
                if (i.Value.Equals(month.Trim().ToLower()))
                {
                    mon = i.Key;
                    break;
                }
            }

            List<FirstFunction> list = new List<FirstFunction>();

            var salary = db.Regs.Where(x => x.YearOfSalary == year && x.MonthOfSalary == month).Select(x => x.idPost).ToList();

            var results1 = from p in db.Regs
                           group new { p.idEmp, p.idPost, p.WageRate } by p.idEmp into g
                           select new { PersonId = g.Key, Items = g.ToList() };


            foreach (var el in results1)
            {
                double sumOklad = 0;
                double premia = 0;
                double ndfl = 0;

                foreach (var l in salary)
                {
                    if (el.Items.Select(x => x.idPost).First() == l)
                    {

                        foreach (var t in el.Items)
                        {
                            int PodtId = Convert.ToInt32(t.idPost);
                            var f = db.Posting.Where(x => x.idPost == PodtId).Select(x => x.price).FirstOrDefault();
                            sumOklad += f * t.WageRate;
                        }
                        var result = db.Employeesing.Where(x => x.idEmp == el.PersonId).Select(x => new { x.surname, x.dateOfBirth }).FirstOrDefault();
                        if(result != null) 
                        {
                            string name = result.surname;
                            int date = result.dateOfBirth.Month;
                            if (date == mon)
                                premia = sumOklad * 0.15;
                            ndfl = sumOklad * 0.13 + premia * 0.13;
                            if(sumOklad != 0 && ndfl != 0)
                                list.Add(new FirstFunction { Surname = name, Salary = sumOklad, Premia = premia, NDFL = ndfl, toHand = sumOklad + premia - ndfl });
                        }
                    }
                }
            }

            ViewBag.Salary = list;
            return View();
        }

    }
}