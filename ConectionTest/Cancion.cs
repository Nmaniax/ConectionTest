using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectionTest
{
    class Cancion
    {
        private int id;
        private String name;
        public Cancion()
        {
            id = 0;
            name = "";
        }

        public void SetData(int i, String n)
        {
            Id = i;
            Name = n;
        }

        public void PrintData()
        {
            Console.WriteLine("{0} || {1} ", Id, Name);
        }

        public int Id {
            get => id;
            set => id = value;
        }
        public String Name { get => name;
            set => name = value;
        }
    }
}
