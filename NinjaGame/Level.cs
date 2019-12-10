using Leap;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaGame
{
    public class Level
    {
        private enum JutsuType
        {
            fire,
            freezing,
            lightning,
            dark,
            poison,
        }

        private class SignStack
        {
            public Stack<string> signs;
            public JutsuType type;
            private string[] originalSigns;

            public SignStack(string sign1, string sign2, string sign3, string sign4,JutsuType type)
            {
                signs = new Stack<string>();
                signs.Push(sign4);
                signs.Push(sign3);
                signs.Push(sign2);
                signs.Push(sign1);
                this.type = type;
                originalSigns = new string[] { sign1, sign2, sign3, sign4};
            }

            public void Reset()
            {
                signs = new Stack<string>();
                signs.Push(originalSigns[3]);
                signs.Push(originalSigns[2]);
                signs.Push(originalSigns[1]);
                signs.Push(originalSigns[0]);
            }

            private void ConsumeSign(string sign)
            {
                if (sign.Equals(signs.Peek()))
                {
                    signs.Pop();
                }
               
            }

            public void Update(GameTime gameTime, string sign,Level level)
            {
                ConsumeSign(sign);
                if (signs.Count < 1)
                {
                    Reset();
                    level.ActivateJutsu(this.type);
                }
            }
        }

        private SpriteFont font;

        private Dictionary<String, String> signTranslator;

        private List<SignStack> signStacks;

        private Controller controller;

        private List<Jutsu> activeJutsu;

        private string currentSign;

        private string currentSignTranslated;

        public Vector origin;

        public Vector indexOrigin;

        public Game1 game;

        private int timeLimit;
     
        private List<Jutsu> toBeRemoved;
        private List<Jutsu> toBeAdded;

        public Level (Game1 game, Controller controller, SpriteFont font)
        {
            this.controller = controller;
            this.toBeRemoved = new List<Jutsu>();
            this.toBeAdded = new List<Jutsu>();
            this.timeLimit = 0;
            currentSign = "NNNNNNNNNNNNNNN";
            currentSignTranslated = "";
            activeJutsu = new List<Jutsu>();
            origin = new Vector(200f, 200f,100f);
            signStacks = new List<SignStack>();
            signTranslator = new Dictionary<string, string>();
            this.font = font;
            this.game = game;

            string star = "YYYYY";
            string fist = "NNNNN";
            string stag = "NYNNY";
            string uno = "NYNNN";
            string crescent = "YNNNY";
            string trident = "NYYYN";

            signTranslator.Add("YYYYY", "Star");
            signTranslator.Add("NNNNN", "Fist");
            signTranslator.Add("NYNNY", "Stag");
            signTranslator.Add("NYNNN", "Uno");
            signTranslator.Add("YNNNY", "Crescent");
            signTranslator.Add("NYYYN", "Trident");

            SignStack fire = new SignStack(star, fist, trident, fist,JutsuType.fire);
            SignStack freezing = new SignStack(uno, stag, fist, trident, JutsuType.freezing);
            SignStack lightning = new SignStack(stag, crescent, fist, star,JutsuType.lightning);
            SignStack dark = new SignStack(trident, fist, stag, uno, JutsuType.dark);
            SignStack poison = new SignStack(uno, trident, crescent, star, JutsuType.poison);
            signStacks.Add(fire);
            signStacks.Add(freezing);
            signStacks.Add(lightning);
            signStacks.Add(dark);
            signStacks.Add(poison);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.DrawString(font, currentSignTranslated, new Vector2(710f, 20f), Color.White);
            foreach(Jutsu jutsu in activeJutsu)
            {
                jutsu.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {
            TimerManager.Instance.Update(gameTime);
            foreach(Jutsu expiredJutsu in toBeRemoved)
            {
                activeJutsu.Remove(expiredJutsu);
            }
            toBeRemoved.Clear();
            activeJutsu.AddRange(toBeAdded);
            toBeAdded.Clear();
            UpdateCurrentSign();
            foreach(SignStack stack in signStacks)
            {
                stack.Update(gameTime, currentSign, this);
            }
            foreach(Jutsu jutsu in activeJutsu)
            {
                jutsu.Update(gameTime);
            }
            timeLimit += gameTime.ElapsedGameTime.Milliseconds;
            if (timeLimit > 5000)
            {
                ResetSignStacks();
                timeLimit = 0;
            }
        }

        private void UpdateCurrentSign()
        {
            if (controller.IsConnected)
            {
                string sign = "";

                
                Frame frame = controller.Frame ();
                List<Hand> hands = frame.Hands;
                if (hands.Count > 0)
                {
                    Hand hand = frame.Hands.ElementAt(0);
                    origin = hand.StabilizedPalmPosition;
                    Finger thumb = hand.Fingers[0];
                    Finger index = hand.Fingers[1];
                    Finger middle = hand.Fingers[2];
                    Finger ring = hand.Fingers[3];
                    Finger pinky = hand.Fingers[4];

                    indexOrigin = index.StabilizedTipPosition;

                    string thumbS = thumb.IsExtended ? "Y" : "N";
                    string indexS = index.IsExtended ? "Y" : "N";
                    string middleS = middle.IsExtended ? "Y" : "N";
                    string ringS = ring.IsExtended ? "Y" : "N";
                    string pinkyS = pinky.IsExtended ? "Y" : "N";

                    sign += thumbS + indexS + middleS + ringS + pinkyS;
                    currentSign = sign;
                    string value;
                    if (signTranslator.TryGetValue(sign, out value))
                    {
                        currentSignTranslated = value;
                    }
                    else
                    {
                        currentSignTranslated = "";
                    }
                    Console.WriteLine("Sign: "+sign);
                    Console.WriteLine("Value: "+value);
                    Console.WriteLine(origin);
                }

            }
        }

        private void ResetSignStacks()
        {
            foreach(SignStack stack in signStacks)
            {
                stack.Reset();
            }
        }

        public void Remove(Jutsu jutsuToRemove)
        {
            this.toBeRemoved.Add(jutsuToRemove);
        }

        private void ConsumeSign(String sign)
        {

        }

        private void ActivateJutsu(JutsuType type)
        {
            switch (type)
            {
                case JutsuType.fire:
                    {
                        toBeAdded.Add(new FireJutsu(this));
                        break;
                    }
                case JutsuType.freezing:
                    {
                        toBeAdded.Add(new FreezingJutsu(this));
                        break;
                    }
                case JutsuType.lightning:
                    {
                        toBeAdded.Add(new LightningJutsu(this));
                        break;
                    }
                case JutsuType.dark:
                    {
                        toBeAdded.Add(new DarkJutsu(this));
                        break;
                    }
                case JutsuType.poison:
                    {
                        toBeAdded.Add(new PoisonJutsu(this));
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

        }

    }
}
