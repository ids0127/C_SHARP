using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shutta
{
    class BasicPlayer : Player
    {
        public const int KwangTTang38 = 50;
        public const int KwangTTang = 30;
        public const int Ttang = 10;

        public override int CalculateScore()
        {
            if ((Cards[0].IsKwang && (Cards[0].Number == 3 || Cards[0].Number == 8))
                && (Cards[1].IsKwang && (Cards[1].Number == 3 || Cards[1].Number == 8)))
                return KwangTTang38;

            else if (Cards[0].IsKwang && Cards[1].IsKwang)
                return Cards[0].Number + Cards[1].Number + KwangTTang;

            else if (Cards[0].Number == Cards[1].Number)
                return Cards[0].Number + Ttang;

            else return (Cards[0].Number + Cards[1].Number) % 10;
        }
    }
}
