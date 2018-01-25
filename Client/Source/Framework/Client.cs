using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Client.Framework
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Client : Microsoft.Xna.Framework.Game
    {
        private bool m_bInitialised;
        private List<Layer> m_layers;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        
        public Client()
        {
            m_bInitialised = false;
            m_layers = new List<Layer>();

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        public Common.Tools.ProcessResult StartUp(List<string> parameters)
        {
            if (m_bInitialised)
            {
                return new Common.Tools.ProcessResult(false, new List<Common.Tools.Message>() {
                    new Common.Tools.Message(Common.Tools.Message.Types.WARNING, "Already initialised") });
            }

            if (parameters == null)
            {
                parameters = new List<string>();
            }

            m_layers.Add(new IO.Layer(new LayerConfig("IO")));
            m_layers.Add(new System.Layer(new LayerConfig("System")));
            m_layers.Add(new Game.Layer(new LayerConfig("Game")));

            bool bInitialisationSucceeded = true;
            List<Common.Tools.Message> messages = new List<Common.Tools.Message>();
            foreach (Layer layer in m_layers)
            {
                Common.Tools.ProcessResult result = layer.StartUp(parameters);
                string sLayerName = layer.GetName();
                if (!result.WasSuccessful())
                {
                    bInitialisationSucceeded = false;
                    messages.Add(new Common.Tools.Message(Common.Tools.Message.Types.ERROR, "Failed to initialise layer '" + sLayerName + "'"));
                }

                foreach (Common.Tools.Message message in result.GetDetails())
                {
                    messages.Add(new Common.Tools.Message(message.GetMessageType(), sLayerName + ": " + message.GetMessage()));
                }
            }

            if (bInitialisationSucceeded)
            {
                m_bInitialised = true;
            }

            return new Common.Tools.ProcessResult(bInitialisationSucceeded, messages);
        }
        
        public Common.Tools.ProcessResult ShutDown()
        {
            if (!m_bInitialised)
            {
                return new Common.Tools.ProcessResult(false, new List<Common.Tools.Message> {
                    new Common.Tools.Message(Common.Tools.Message.Types.WARNING, "Not yet initialised") });
            }

            bool bSuccess = true;
            List<Common.Tools.Message> messages = new List<Common.Tools.Message>();
            foreach (Layer layer in m_layers)
            {
                Common.Tools.ProcessResult result = layer.ShutDown();
                string sLayerName = layer.GetName();
                if (!result.WasSuccessful())
                {
                    bSuccess = false;
                }

                foreach (Common.Tools.Message message in result.GetDetails())
                {
                    messages.Add(new Common.Tools.Message(message.GetMessageType(), sLayerName + ": " + message.GetMessage()));
                }
            }

            return new Common.Tools.ProcessResult(bSuccess, messages);
        }

        protected override void Initialize()
        {
            // Even though this does absolutely nothing for us we have to keep it otherwise it wont
            // be called internally and we'll get a null object reference every time the game starts
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
            {
                Exit();
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
