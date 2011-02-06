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


namespace Platformer.Controls
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class CoinsBar : Microsoft.Xna.Framework.DrawableGameComponent
    {
        protected int coinCount;
        protected Rectangle bound; //для дальнейшей доработки фона бара
        protected SpriteFont font;
        protected Texture2D coinTexture;
        protected Vector2 position;
        private SpriteBatch spriteBatch = null;
        private ContentManager content=null;
        private int wWidth, wHight;

        public CoinsBar(Game game)
            : base(game)
        {
            coinCount = 134546842;
            wWidth = Game.Window.ClientBounds.Width;
            wHight = Game.Window.ClientBounds.Height;
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            content = (ContentManager)Game.Services.GetService(typeof(ContentManager));

            coinTexture = content.Load<Texture2D>("Coin");
            font = content.Load<SpriteFont>("CoinsFont");

            base.Initialize();
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
            //spriteBatch.Draw(coinTexture, new Rectangle(0,0,24,24), Color.White);
            //
            spriteBatch.Draw(coinTexture, new Rectangle((wWidth - 32) - (int)font.MeasureString(coinCount.ToString()).X,
                0, 16, 16), Color.White);
            spriteBatch.DrawString(font, coinCount.ToString(), new Vector2(wWidth - (int)font.MeasureString(coinCount.ToString()).X,
                0), Color.White);

            base.Draw(gameTime);
        }
    }
}