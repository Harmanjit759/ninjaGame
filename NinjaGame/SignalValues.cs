using Leap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaGame
{
    public class SignalValues
    {
        public struct Signal
        {
            public HandSignals.Sign type;

            public int thumbX;
            public int thumbY;
            public int indexX;
            public int indexY;
            public int middleX;
            public int middleY;
            public int ringX;
            public int ringY;
            public int pinkyX;
            public int pinkyY;

            public Signal(HandSignals.Sign sign, Vector thumb, Vector index, Vector middle, Vector ring, Vector pinky)
            {
                type = sign;
                thumbX = (int) thumb.x;
                thumbY = (int) thumb.y;
                indexX = (int) index.x;
                indexY = (int) index.y;
                middleX = (int) middle.x;
                middleY = (int) middle.y;
                ringX = (int) ring.x;
                ringY = (int) ring.y;
                pinkyX = (int) pinky.x;
                pinkyY = (int) pinky.y;

            }
        }

    }
}
