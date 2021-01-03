using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    interface IRole
    {
        IEnumerable<Role> GetAllRoles();
        void AddRole(Role Role);
        void UpdateRole(Role Role);
        Role GetRole(int? id);
        void DeleteRole(int? id);
    }
}
