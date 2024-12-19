using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lol
{
    public class metod
    {
        public bool isInRange(int a, int b, int num)
        {
            if (a > b) (a, b) = (b, a);
            if (num >= a && num <= b) return true;
            else return false;
        }
    }
}
