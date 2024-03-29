using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using PuzzleBooble3DClone.GameComponents;

namespace PuzzleBooble3DClone
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class PuzzleBooble3dGame : Microsoft.Xna.Framework.Game, HangingBallsObserver
    {
        GraphicsDeviceManager graphics;

        public Camera Camera;
        public ContentRepository ContentRepository;

        private AimingArrow Arrow;
        private Score Score;
        private ComponentController ComponentController;

        public PuzzleBooble3dGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            Camera = new Camera(this);
            ContentRepository = new ContentRepository(this);
            Components.Add(Camera);
            Components.Add(ContentRepository);

            Floor floor = new Floor(this);
            FieldBounds bounds = new FieldBounds(this, floor);
            Score = new Score(this);
            BallGrid ballGrid = new BallGrid(this, floor, bounds, Score);
            ballGrid.Observer.Add(this);
            Arrow = new AimingArrow(this, floor);
            ComponentController = new ComponentController(this, floor, Arrow, ballGrid, bounds);            
            Components.Add(floor);
            Components.Add(ballGrid);
            Components.Add(Arrow);
            Components.Add(bounds);
            Components.Add(ComponentController);
            Components.Add(Score);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            base.LoadContent();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        public void OnPlayerWins()
        {
            Score.Message = "You Won !";
        }

        public void OnPlayerLoses()
        {
            Components.Remove(Arrow);
            Components.Remove(ComponentController.CurrentBall);
            Components.Remove(ComponentController);

            Score.Message = "You Lost.";
        }
    }
}
