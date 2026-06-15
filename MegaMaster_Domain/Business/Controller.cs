using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegaMaster_Domain.Persistence;

namespace MegaMaster_Domain.Business
{
    public class Controller
    {
        private Persistcode _persistenceLayer;




        private List<string> _availableColors;
            
        private List<string> _secretCode;
        private int _attempts; 
        public int Attempts { get { return _attempts; }  }
        public List<string> AvailableColors { get { return _availableColors; } }


        public Controller()
        {
            _persistenceLayer = new Persistcode();
            _availableColors = new List<string>();
           
            _availableColors.Add("Rood");
            _availableColors.Add("Blauw");
            _availableColors.Add("Groen");
            _availableColors.Add("Geel");
            _availableColors.Add("Paars");
            _availableColors.Add("Oranje");            

            _secretCode = new List<string>();
            
            _attempts = 0;

            SetColors();            
        }
        
        public Controller(string connstring) : this()
        {
            _persistenceLayer = new Persistcode(connstring);
        }


        public void SetColors() 
        {
            Random rnd = new();
            for (int i = 0; i < 4; i++)
            {
                int index = rnd.Next(0, _availableColors.Count);
                _secretCode.Add(_availableColors[index]);
            }
        }

        public GuessResult CheckGuess(List<string> guess)
        {
            _attempts++;

            int correctPosition = 0;
            int correctColor = 0;
            //make a secret copy of the list, to be able to check the colors
            List<string> secretCopy = new List<string>();
            foreach (string color in _secretCode) secretCopy.Add(color);
            

            //make a secret copy of the guess of the user, to be able to check the colors
            List<string> guessCopy = new List<string>();
            foreach (string color in guess) guessCopy.Add(color);
            
            //first check: correct positions
            for (int i = 3; i >= 0; i--)
            {
                if (guessCopy[i] == secretCopy[i])
                {
                    correctPosition++;
                    guessCopy.RemoveAt(i);
                    secretCopy.RemoveAt(i);
                }
            }

            //second check: correct color but wrong positions
            foreach (string color in guessCopy.ToList())
            {
                if (secretCopy.Contains(color))
                {
                    correctColor++;
                    secretCopy.Remove(color);
                }
            }
            GuessResult result = new GuessResult();
            result.CorrectPosition = correctPosition;
            result.CorrectColor = correctColor;
            return result;
        }

        public bool IsWinner(GuessResult result)
        {
            return result.CorrectPosition == 4;
        }
        public void SlaScoreOp(string spelerNaam)
        {
            // Dit stuurt de gegevens door naar de database-laag
            _persistenceLayer.InsertIntoDB(spelerNaam, _attempts);
        }

    }
}
