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
    public class Cursor : Microsoft.Xna.Framework.DrawableGameComponent
    {
        protected Texture2D cursor;
        protected Vector2 cursopPosition;
        private SpriteBatch spriteBath = null;

        public Cursor(Game game,ref Texture2D cursor)
            : base(game)
        {
            this.cursor = cursor;
            spriteBath = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            // TODO: Construct any child components here
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            MouseState mouse = Mouse.GetState();
            cursopPosition = new Vector2(mouse.X, mouse.Y);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBath.Draw(cursor, cursopPosition, Color.White);
            base.Draw(gameTime);
        }
    }
}