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
    public class Label : Microsoft.Xna.Framework.DrawableGameComponent
    {
        protected Vector2 position;
        protected SpriteBatch spriteBatch = null;
        protected Color color;
        protected SpriteFont font;
        protected String text;
        protected bool shadows;


        

        public Label(Game game,SpriteFont font)
            : base(game)
        {
            position = Vector2.Zero;
            color = Color.Black;
            this.font = font;
            text = "Label";
            spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
        }

        #region Varibles


        /// <summary>
        /// Тени текста
        /// </summary>
        public bool Shadows
        {
            get {return shadows; }
            set { shadows = value; }
        
        
        }
        /// <summary>
        /// Text
        /// </summary>
        public String Text
        {
            get { return text; }
            set { text = value; }
        }

        /// <summary>
        /// Position
        /// </summary>
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        
        }


        /// <summary>
        /// Color
        /// </summary>
        public Color Color
        {
            get { return color; }
            set { color = value; }
        
        }



        #endregion


        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            
            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
            if (shadows)
            {
                spriteBatch.DrawString(font, text,new Vector2( position.X+2,position.Y+2), Color.Gray);
            }
            spriteBatch.DrawString(font, text, position, color);
            

            base.Draw(gameTime);
        }
    }
}