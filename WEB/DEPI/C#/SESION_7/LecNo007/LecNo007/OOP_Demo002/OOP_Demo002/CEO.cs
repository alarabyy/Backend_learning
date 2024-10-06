using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Demo002
{
    public sealed class CEO:Manager
    {
        protected sealed override double BonusValue()
        {
            return base.BonusValue();
        }
       
    }
    // public class Owner : CEO { } Can not Inherit from Sealed Class
}
