using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace RpgMonoGameProject
{
    public static class Engine
    {
        private static List<Keys> pressedKeys = new List<Keys>(); 


        static List<Keys> GetPressedKeys()
        {
            return CheckForPressedKeys(out pressedKeys) ? pressedKeys : null;
        }

        private static bool CheckForPressedKeys(out List<Keys> keys )
        {
            throw new NotImplementedException();
        }
    }
}
