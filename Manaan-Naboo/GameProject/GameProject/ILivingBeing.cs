using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameProject
{
    // Used for directly for enemies
    interface ILivingBeing
    {
        int Health { get; set; }
        int Strength { get; set; }
    }
}
