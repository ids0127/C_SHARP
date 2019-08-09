using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shutta
{
    public class Dictionary
    {
        private Dictionary() { }

        private static Dictionary _instance;

        public static Dictionary Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Dictionary();

                return _instance;
            }
        }

        public Dictionary<int, string> Table = new Dictionary<int, string>()
        {
        {50,"38광땡"},
         {40,"광땡"},
         {35,"멍텅구리 사구"},
         {30,"장땡"},
         {29,"9땡"},
         {28,"8땡"},
         {27,"7땡"},
         {26,"6땡"},
         {25,"5땡"},
         {24,"4땡"},
         {23,"3땡"},
         {22,"2땡"},
         {21,"삥땡"},
         {19,"사구"},
         {18,"알리"},
         {17,"독사"},
         {16,"구삥"},
         {15,"장삥"},
         {14,"장사"},
         {13,"세륙"},
         {9,"갑오"},
         {8,"8끗"},
         {7,"7끗"},
         {6,"6끗"},
         {5,"5끗"},
         {4,"4끗"},
         {3,"3끗"},
         {2,"2끗"},
         {1,"1끗"},
         {0,"망통"},
         {100,"포기"}

        };


    } 

}


   
