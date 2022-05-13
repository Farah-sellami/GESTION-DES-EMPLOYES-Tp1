using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationEmploye.Models.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        List<Employee> lemployees; //liste de employe
        public EmployeeRepository()
        {
            lemployees = new List<Employee>()
            {
                new Employee {Id=1,Name="Sofien ben ali", Departement= "comptabilité",Salary=1000},
                new Employee {Id=2,Name="Mourad triki", Departement= "RH",Salary=1500},
                new Employee {Id=3,Name="ali ben mohamed", Departement= "informatique",Salary=1700},
                new Employee {Id=4,Name="tarak aribi", Departement= "informatique",Salary=1800},
                new Employee {Id=5,Name="taha hssin", Departement= "RH",Salary=1200},
                new Employee {Id=6,Name="salah ben salah", Departement= "comptabilité",Salary=1300},
                new Employee {Id=7,Name="emna ali", Departement= "RH",Salary=1500}
            };
        }
        public void Add(Employee e)
        {
            //ajouter un employé dans la liste
            lemployees.Add(e);
        }
        public void Delete(int id)
        {
            var emp = FindByID(id);
            lemployees.Remove(emp);
        }

        public Employee FindByID(int id)
        {
            //retourne l’employé ayant cet id
            //retoune un seul objet : id de employe recherché
            return lemployees.FirstOrDefault(x => x.Id == id);
            /*where filtrage  expl tt les employe de departements info
            lemployees.Where(x => x.Id == id);*/


        }
       
        public List<Employee> Search(string term)
        {
            //Recherche des employés dont leur noms contiennent la chaîne term
            if (!String.IsNullOrEmpty(term))

                return lemployees.Where(a => a.Name.Contains(term)).ToList();
           else
                return lemployees;

        }
        public void Update(int id, Employee newemployee)
        {
            //Modifier un employé
            var emp = FindByID(id);

            emp.Name = newemployee.Name;
            emp.Salary = newemployee.Salary;
            emp.Departement = newemployee.Departement;

        }

        public double SalaryAverage()
        {
            return lemployees.Average(x => x.Salary);
        }
        public double MaxSalary()
        {
            return lemployees.Max(x => x.Salary);
        }
        public int HrEmployeesCount()
        {
            return lemployees.Where(x => x.Departement == "RH").Count();
        }

        public int ComEmployeesCount()
        {
            return lemployees.Where(x => x.Departement == "comptabilité").Count();
        }

        public int InfEmployeesCount()
        {
            return lemployees.Where(x => x.Departement == "informatique").Count();
        }


        IList<Employee> IRepository<Employee>.GetAll()
        {
            return lemployees;
        }
    }
}
