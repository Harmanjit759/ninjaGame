using Leap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaGame
{
    class SignDetector
    {
        public void OnServiceConnect(object sender, ConnectionEventArgs args)
        {
            Console.WriteLine("Service Connected");
        }

        public void OnConnect(object sender, DeviceEventArgs args)
        {
            Console.WriteLine("Connected");
        }

        public void OnFrame(object sender, FrameEventArgs args)
        {
            Console.WriteLine("Frame Available.");
            // Get the most recent frame and report some basic information
            Frame frame = args.frame;

            Console.WriteLine(
              "Frame id: {0}, timestamp: {1}, hands: {2}",
              frame.Id, frame.Timestamp, frame.Hands.Count
            );

            MasterHand.Instance.Hands = frame.Hands;
           
            foreach (Hand hand in frame.Hands)
            {
                //Console.WriteLine("  Hand id: {0}, palm position: {1}, fingers: {2}",
                //  hand.Id, hand.PalmPosition, hand.Fingers.Count);
                //// Get the hand's normal vector and direction
                //Vector normal = hand.PalmNormal;
                //Vector direction = hand.Direction;

                //// Calculate the hand's pitch, roll, and yaw angles
                //Console.WriteLine(
                //  "  Hand pitch: {0} degrees, roll: {1} degrees, yaw: {2} degrees",
                //  direction.Pitch * 180.0f / (float)Math.PI,
                //  normal.Roll * 180.0f / (float)Math.PI,
                //  direction.Yaw * 180.0f / (float)Math.PI
                //);

                MasterHand.Instance.Hand = hand;
                Finger[] fingers = MasterHand.Instance.Hand.Fingers.ToArray();
                Finger thumb = fingers[0];
                Finger index = fingers[1];
                Finger middle = fingers[2];
                Finger ring = fingers[3];
                Finger pinky = fingers[4];
                MasterHand.Instance.IsThumbExtended = thumb.IsExtended;
                MasterHand.Instance.IsIndexExtended = index.IsExtended;
                MasterHand.Instance.IsMiddleExtended = middle.IsExtended;
                MasterHand.Instance.IsRingExtended = ring.IsExtended;
                MasterHand.Instance.IsPinkyExtended = pinky.IsExtended;

                float num = 0;
                foreach(Finger finger in hand.Fingers)
                {
                    //Console.WriteLine(finger.Type);
                    //Console.WriteLine(finger.Direction);
                    num += finger.Direction.x + finger.Direction.y;

                    Vector direction = finger.Direction;
                    Finger.FingerType type = finger.Type;

                    switch (type)
                    {
                        case Finger.FingerType.TYPE_THUMB:
                            {
                                MasterHand.Instance.Thumb = direction;
                                break;
                            }

                        case Finger.FingerType.TYPE_INDEX:
                            {
                                MasterHand.Instance.Index = direction;
                                break;
                            }

                        case Finger.FingerType.TYPE_MIDDLE:
                            {
                                MasterHand.Instance.Middle = direction;
                                break;
                            }
                        case Finger.FingerType.TYPE_RING:
                            {
                                MasterHand.Instance.Ring = direction;
                                break;
                            }
                        case Finger.FingerType.TYPE_PINKY:
                            {
                                MasterHand.Instance.Pinky = direction;
                                break;
                            }
                    }
                }
                Console.WriteLine(num);
            }

           
        }
    }
}
