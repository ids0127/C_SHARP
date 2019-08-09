using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shutta
{
    public class Dealer
    {
        #region money
        private int _money;

        internal void PutMoney(int bettingMoney)
        {
            _money += bettingMoney;
        }

        internal int GetMoney()
        {
            int moneyToReturn = _money;
            _money = 0;
            return moneyToReturn;
        }
        #endregion

        private List<Card> _cards = new List<Card>();

        private int _cardIndex;


        public List<Card> Cards { get; }

        public Card DrawCard()
        {

            return _cards[_cardIndex++];
        }

        public Card DealerCard()
        {

            return _cards[_cardIndex - 1];
        }

        public string GetCardTextDealer()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var card in Cards)
                builder.Append("딜러 공통 카드 : " + card.ToString() + "\t");

            return builder.ToString();
        }

        public Dealer()
        {
            Cards = new List<Card>();
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    bool isKwang = (j == 0) && (i == 1 || i == 3 || i == 8);
                    bool headCard = (j == 0);
                    Card card = new Card(i, isKwang, headCard);
                    _cards.Add(card);
                }
            }

            // shuffle
            _cards = _cards.OrderBy(x => Guid.NewGuid()).ToList();
        }
    }
}
