
using Leap;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace NinjaGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public const int Width = 800;
        public const int Height = 600;

        Controller controller;
        List<SignalValues.Signal> signalList = new List<SignalValues.Signal>();
        String currentSign = "";
        SpriteFont font;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            controller = new Controller();
            Console.Write("something");
            SignDetector listener = new SignDetector();
            controller.Connect += listener.OnServiceConnect;
            controller.Device += listener.OnConnect;
            controller.FrameReady += listener.OnFrame;
            initSignals();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Diagnostics");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            checkForMatch();
            this.Draw(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.DrawString(font, currentSign, Vector2.One, Color.BlanchedAlmond);
            spriteBatch.End();
            // TODO: Add your drawing code here
            
            base.Draw(gameTime);
        }

        protected void initSignals()
        {
            Vector thumb = new Vector(-0.78f, .76f, -.44f);
            Vector index = new Vector(-.17f, .82f, -.36f);
            Vector middle = new Vector(.25f, .95f, .50f);
            Vector ring = new Vector(-.15f, -.90f, .30f);
            Vector pinky = new Vector(-.30f, -.85f, .30f);

            SignalValues.Signal bear = new SignalValues.Signal(HandSignals.Sign.bear, thumb, index, middle, ring, pinky);
            signalList.Add(bear);

        }

        protected void checkForMatch()
        {
            Vector thumb = MasterHand.Instance.Thumb;
            Vector index = MasterHand.Instance.Index;
            Vector middle = MasterHand.Instance.Middle;
            Vector ring = MasterHand.Instance.Ring;
            Vector pinky = MasterHand.Instance.Pinky;
            //foreach (SignalValues.Signal signal in signalList)
            //{
            //    int hits = 0;
            //    if (Math.Abs(thumb.x - signal.thumbX) < .1)
            //    {
            //        hits++;
            //    }
            //    if (Math.Abs(thumb.y - signal.thumbY) < .1){
            //        hits++;
            //    }
            //    if (Math.Abs(index.x - signal.indexX) < .1)
            //    {
            //        hits++;
            //    }
            //    if (Math.Abs(index.y - signal.indexY) < .1)
            //    {
            //        hits++;
            //    }
            //    if (Math.Abs(middle.y - signal.middleY) < .1)
            //    {
            //        hits++;
            //    }
            //    if (Math.Abs(middle.y - signal.middleY) < .1)
            //    {
            //        hits++;
            //    }

            //    if (hits > 5)
            //    {
            //        Console.WriteLine("COWAAAAAAAAAAAAABUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUNGAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            //        currentSign = "BEAR";
            //        break;
            //    }

            //}

            float num = 0;
            num += thumb.x + thumb.y;
            num += index.x + index.y;
            num += middle.x + middle.y;
            num += ring.x + ring.y;
            num += pinky.x + pinky.y;

            Console.WriteLine(num);
            Console.WriteLine(currentSign);

            if (num < -2.4f && num > -3.1f)
            {
                Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                currentSign = "SUCCESS";
            }

        }

    }
}
