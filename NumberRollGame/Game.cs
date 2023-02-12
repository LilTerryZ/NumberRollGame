using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberRollGame
{
    class Game
    {
        public int AmountDoubles { get; set; }
        public int AmountTriples { get; set; }
        public int AmountQuadruple { get; set; }
        public int AmountQuintuple { get; set; }
        public int Score { get; set; }
        public Game(int amountDoubles, int amountTriples, int amountQuadruple, int amountQuintuple, int score)
        {
            AmountDoubles = amountDoubles;
            AmountTriples = amountTriples;
            AmountQuadruple = amountQuadruple;
            AmountQuintuple = amountQuintuple;
            Score = score;
        }
       
    } 
}
