using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMaster_Domain.Business
{
    public class GuessResult
    {
        private int _correctPosition;
        private int _correctColor;
        public int CorrectPosition { get { return _correctPosition; } set { _correctPosition = value; } }
        public int CorrectColor { get { return _correctColor; } set { _correctColor = value; } }

        public GuessResult()
        {
            _correctPosition = 0;
            _correctColor = 0;
        }
        public GuessResult(int correctP,int correctC)
        {
            _correctPosition = correctP;
            _correctColor = correctC;
        }
        public override string ToString()
        {
            return $"Zwarte \U0001F4CD: {_correctPosition} - Witte \U0001F4CD: {_correctColor}";
        }
    }
}