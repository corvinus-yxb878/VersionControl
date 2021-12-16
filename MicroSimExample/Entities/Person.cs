using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MicroExmaple.Entities
{
    public class Person
    {
        public int BirthYear { get; set; }
        public Gender Gender { get; set; }
        public int NbrOfChildren { get; set; }
        public bool IsAlive { get; set; }

        public Person()
        {
            IsAlive = true;
        }
    }
   
}
