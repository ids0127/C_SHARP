using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shutta
{
    public class ComputerPlayer : Player
    {
        public override string GetCardText()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var card in Cards)
                builder.Append("??" + "\t");

            return builder.ToString();
        }

        public override string GetCardTextPublic()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var card in Cards)
                builder.Append(card.ToString() + "\t");

            return builder.ToString();
        }

    }


}
