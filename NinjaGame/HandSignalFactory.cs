using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaGame
{
    public class HandSignalFactory
    {
        private static HandSignalFactory instance = new HandSignalFactory();

        public static HandSignalFactory Instance
        {
            get
            {
                return instance;
            }
        }

        //public static HandSignals.Sign getSignal(MasterHand hand)
        //{

        //}
    }
}
