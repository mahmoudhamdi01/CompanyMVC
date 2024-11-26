using Demo.DAL.Entities;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.PLL.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
       IQueryable<Employee> GetEmployeeByAddress(string address);

    }
}
