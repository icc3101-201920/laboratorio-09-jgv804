using System;
using System.Collections.Generic;
using System.Text;
using Laboratorio_8_OOP_201920.Cards;

namespace Laboratorio_8_OOP_201920
{
    public class PlayerEventArgs : EventArgs
    {
        public Card card { get; set; }
        public Player player { get; set; }
    }
}


