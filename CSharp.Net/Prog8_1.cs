using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISS.RV.LIB;


namespace Prog8_2
{

    class Rectangle1
    {
        public class Coin
        {
            const int HEAD = 0;
            const int TAIL = 1;

            int face = HEAD;
            public void Flip()
            {
               // face = ISS.RNDInt(2);
            }
            public int GetFace()
            {
                return face;
            }
        }
    }
}