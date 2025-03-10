using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    interface IBoard
    {
        /// konstruktor bezparametrowy 
        /// konstruktor z Player
        /// 
        public void AddPlayer(Player player);
        public void GenerateBoard();


        public bool CanMove(Player player,Move move);
        public bool Move(Player player,Move move);





    }
}
