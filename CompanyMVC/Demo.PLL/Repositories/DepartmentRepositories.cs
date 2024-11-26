using Demo.DAL.Context;
using Demo.DAL.Entities;
using Demo.PLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Demo.PLL.Repositories
{
    public class DepartmentRepositories : GenericRepository<Department>, IDepartmentRepositories
    {
        public DepartmentRepositories(CompanyDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
