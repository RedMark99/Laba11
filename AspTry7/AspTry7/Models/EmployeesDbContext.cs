using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AspTry7.Models
{
    public class EmployeesDbContext : DbContext
    {

        public DbSet<Employees> Employeesing { get; set; }

        public DbSet<Post> Posting { get; set; }

        public DbSet<Reg> Regs { get; set; }

    }

    public class EmployeesDbInitializer : DropCreateDatabaseAlways<EmployeesDbContext>
    {

        protected override void Seed(EmployeesDbContext db)
        {
            db.Employeesing.Add(new Employees { surname = "Чубенко", name = "Марк", lastname = "Григорьевич", gender = "М", dateOfBirth = DateTime.Parse("15.11.1999") });
            db.Employeesing.Add(new Employees { surname = "Накано", name = "Лера", lastname = "Марковна", gender = "Ж", dateOfBirth = DateTime.Parse("11.11.1999") });
            db.Employeesing.Add(new Employees { surname = "Накано", name = "Дарина", lastname = "Маркоана", gender = "Ж", dateOfBirth = DateTime.Parse("03.11.1999") });

            db.Posting.Add(new Post { name = "Админ", price = 19000 });
            db.Posting.Add(new Post { name = "Модер", price = 15000 });
            db.Posting.Add(new Post { name = "Саппорт", price = 11000 });

            base.Seed(db);
        }
    }
}