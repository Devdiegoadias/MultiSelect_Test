using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
   public  interface IOperador
    {
        IEnumerable<Operador> GetAllOperadors();
        void AddOperador(Operador Operador);
        void UpdateOperador(Operador Operador);
        Operador GetOperador(int? id);
        void DeleteOperador(int? id);
    }
}
