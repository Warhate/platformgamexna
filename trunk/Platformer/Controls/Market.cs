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
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using Platformer.Elements;


namespace Platformer.Controls
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Market : Microsoft.Xna.Framework.DrawableGameComponent
    {
        protected Texture2D blackTexture;
        protected Rectangle rect = new Rectangle();
        protected List<Fruit> fruits;
        protected SpriteBatch spriteBatch = null;
        private ContentManager content = null;
        protected SpriteFont font;

        public Market(Game game)
            : base(game)
        {
            Enabled = false;
            Visible = false;
            spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            content = (ContentManager)Game.Services.GetService(typeof(ContentManager));
            Initialize();

            // TODO: Construct any child components here
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            blackTexture = content.Load<Texture2D>("blackFon");
            font = content.Load<SpriteFont>("Font");
            base.Initialize();
        }

        public void Show()
        {
            Enabled = true;
            Visible = true;        
        }

        public void Hide()
        {
            Enabled = false;
            Visible = false;  
        
        }


        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(blackTexture, new Rectangle(100, 100, 400, 300), Color.White);
            spriteBatch.DrawString(font, "Market", new Vector2(110, 110), Color.White);
            base.Draw(gameTime);
        }
    }
}