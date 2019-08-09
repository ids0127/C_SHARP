using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shutta
{
    public abstract class Player
    {
        public Player()
        {
            Cards = new List<Card>();         
        }

        public List<Card> Cards { get; }

        public int Money { get; set; }

        public int CalculateScore()
        {
            List<int> scores = new List<int>();
            
            int tmp;
            for (int i = 0; i < 3; i++)
            {
                int j = (i + 1) % 3;

                if ((Cards[i].IsKwang && (Cards[i].Number == 3 || Cards[i].Number == 8)) &&
                    (Cards[j].IsKwang && (Cards[j].Number == 3 || Cards[j].Number == 8)))
                    tmp = 50;

                else if (Cards[i].IsKwang && Cards[j].IsKwang)
                    tmp = 40;

               /* else if ((Cards[i].HeadCard && (Cards[i].Number == 4 || Cards[i].Number == 7)) &&
                        (Cards[j].HeadCard && (Cards[j].Number == 7 || Cards[j].Number == 4)))
                    tmp = 3800;

                else if ((Cards[i].Number == 3 && Cards[j].Number == 7) ||
                        (Cards[i].Number == 7 && Cards[j].Number == 3))
                    tmp = 3600;

    */
                else if ((Cards[i].HeadCard &&(Cards[i].Number == 4 || Cards[i].Number == 9)) &&
                        (Cards[j].HeadCard && (Cards[j].Number == 4 || Cards[j].Number == 9)))
                    tmp = 35;

                else if ((Cards[i].Number == 4 && Cards[j].Number == 9) ||
                        (Cards[i].Number == 9 && Cards[j].Number == 4))
                    tmp = 19;

                else if (Cards[i].Number == Cards[j].Number)
                    tmp = Cards[i].Number + 20;

                else if ((Cards[i].Number == 1 && Cards[j].Number == 2) || (Cards[i].Number == 2 && Cards[j].Number == 1))
                    tmp = 18;

                else if ((Cards[i].Number == 1 && Cards[j].Number == 4) || (Cards[i].Number == 4 && Cards[j].Number == 1))
                    tmp = 17;

                else if ((Cards[i].Number == 1 && Cards[j].Number == 9) || (Cards[i].Number == 9 && Cards[j].Number == 1))
                    tmp = 16;

                else if ((Cards[i].Number == 1 && Cards[j].Number == 10) || (Cards[i].Number == 10 && Cards[j].Number == 1))
                    tmp = 15;

                else if ((Cards[i].Number == 4 && Cards[j].Number == 10) || (Cards[i].Number == 10 && Cards[j].Number == 4))
                    tmp = 14;

                else if ((Cards[i].Number == 4 && Cards[j].Number == 6) || (Cards[i].Number == 6 && Cards[j].Number == 4))
                    tmp = 13;

                else tmp = ((Cards[i].Number + Cards[j].Number) % 10);

                scores.Add(tmp);
            }

            return scores.Max();
        }

        public abstract string GetCardText();
        public abstract string GetCardTextPublic();
    }
}
