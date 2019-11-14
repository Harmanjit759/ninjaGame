using Leap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaGame
{
    public class MasterHand
    {
        private static MasterHand instance = new MasterHand();

        public static MasterHand Instance {
            get
            {
                return instance;
            }
        }

        public Vector Thumb { get => thumb; set => thumb = value; }
        public Vector Index { get => index; set => index = value; }
        public Vector Middle { get => middle; set => middle = value; }
        public Vector Ring { get => ring; set => ring = value; }
        public Vector Pinky { get => pinky; set => pinky = value; }

        private Vector thumb;
        private Vector index;
        private Vector middle;
        private Vector ring;
        private Vector pinky;
    }
}
