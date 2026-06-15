using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMaster_Domain.Business
{
    public class GameResult
    {
        private string _playerName;
        private int _attempts;
        public string PlayerName { get { return _playerName; } set { _playerName = value; } }
        public int Attempts { get { return _attempts; } set { _attempts = value; } }

        //constructor
        public GameResult(string play, Int32 attem)
        {
            _playerName = play;
            _attempts = attem;
        }
        public override string ToString()
        {
            return _playerName + " - " + _attempts + " attempts";
        }
    }
}