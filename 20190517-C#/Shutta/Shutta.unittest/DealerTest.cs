using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Shutta.UnitTest
{
    [TestClass]
    public class DealerTest
    {
        [TestMethod]
        public void 스물장의_카드에는_광이_3장_들어있어야_함()
        {
            Dealer dealer = new Dealer();
            
            List<Card> cards = new List<Card>();
            for (int i = 0; i < 20; i++)
            {
                Card card = dealer.DrawCard();
                cards.Add(card);
            }

            int kwangCount = 0;
            //for (int i = 0; i < cards.Count; i++)
            //    if (cards[i].IsKwang)
            //        kwangCount++;
            foreach(Card card in cards)
                if (card.IsKwang)
                    kwangCount++;

            Assert.AreEqual(3, kwangCount);
        }

        [TestMethod]
        public void 스물장의_카드에는_1이_2장_들어있어야_함()
        {
            Dealer dealer = new Dealer();
            
            List<Card> cards = new List<Card>();
            for (int i = 0; i < 20; i++)
            {
                Card card = dealer.DrawCard();
                cards.Add(card);
            }

            int countOf1 = 0;
            foreach(Card card in cards)
                if (card.Number == 1)
                    countOf1++;

            Assert.AreEqual(2, countOf1);
        }
    }
}
