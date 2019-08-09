using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shutta
{
    public class Card
    {
        
        public int Number {get; } // 생성자에서만 변경 가능

        public bool IsKwang { get; private set; } // Card 클래스 내에서만 변경 가능

        public bool HeadCard { get; private set; }

        public Card(int number, bool isKwang, bool headCard)
        {
            Number = number;
            IsKwang = isKwang;
            HeadCard = headCard;
        }

        public override string ToString()
        {
            if (IsKwang)
                return Number + "K";

            else if (HeadCard)
                return Number + "특";
            else
                return Number.ToString();
        }
    }
}
