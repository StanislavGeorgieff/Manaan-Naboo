using GameProject.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameProject
{
    interface IEnemy : ILivingBeing
    {
        Direction Dir { get; set; }
    }
}
