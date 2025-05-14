using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Diagnostics;
namespace DataAccess
{
    internal class Names
    {
        public List<string> All { get; }  = new List<string>();
        //1 kere olusturulak her bir instance icin ve surekli olarak kullanilacak..ondan dolayi readonly yapilir
        //Good practise: make fields readonly if possible..if we don't intend to modify after they are first set in the constructor or at declaration		
        private readonly NamesValidator _namesValidator2 = new NamesValidator();


        public void AddNames(List<string> names)
        {
            foreach (var name in names)
            {
                AddName(name);
            }
        }
       
        public void AddName(string name)
        {
            

            if (_namesValidator2.IsValid(name))
            {
                All.Add(name);
            }
        }


      
    }
}
