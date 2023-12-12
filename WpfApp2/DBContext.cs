using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class DBContext
    {
        private static Entities _entities;

        public static Entities GetContext()
        {
            if (_entities == null)
            {
                _entities = new Entities();
            }
            return _entities;
        }
    }
}
