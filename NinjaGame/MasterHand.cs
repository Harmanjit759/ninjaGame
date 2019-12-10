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

        public List<Hand> Hands { get => hands; set => hands = value; }
        public Vector Thumb { get => thumb; set => thumb = value; }
        public Vector Index { get => index; set => index = value; }
        public Vector Middle { get => middle; set => middle = value; }
        public Vector Ring { get => ring; set => ring = value; }
        public Vector Pinky { get => pinky; set => pinky = value; }
        public Hand Hand { get => hand; set => hand = value; }
        public bool IsThumbExtended { get => isThumbExtended; set => isThumbExtended = value; }
        public bool IsIndexExtended { get => isIndexExtended; set => isIndexExtended = value; }
        public bool IsMiddleExtended { get => isMiddleExtended; set => isMiddleExtended = value; }
        public bool IsRingExtended { get => isRingExtended; set => isRingExtended = value; }
        public bool IsPinkyExtended { get => isPinkyExtended; set => isPinkyExtended = value; }

        private List<Hand> hands;
        private Hand hand;
        private Vector thumb;
        private Vector index;
        private Vector middle;
        private Vector ring;
        private Vector pinky;
        private bool isThumbExtended;
        private bool isIndexExtended;
        private bool isMiddleExtended;
        private bool isRingExtended;
        private bool isPinkyExtended;
    }
}
