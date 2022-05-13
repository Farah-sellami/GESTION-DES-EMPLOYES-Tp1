using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationEmploye.Models.Repositories
{
    public interface IRepository<T>
    {
        double SalaryAverage();
        double MaxSalary();
        int HrEmployeesCount();

        int ComEmployeesCount();

        int InfEmployeesCount();

        IList<T> GetAll();
        T FindByID(int id);
        void Add(T entity);
        void Update(int id, T entity);
        void Delete(int id);
        List<T> Search(string term);
    }
}
