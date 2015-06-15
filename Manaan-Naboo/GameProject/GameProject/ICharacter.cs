using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameProject
{
    public interface ICharacter
    {
        int Health { get; set; }
        int Strength { get; set; }
        int Experience { get; set; }
        int Gold { get; set; }
        List<GameObject> Inventar { get; set; }

    }
}
