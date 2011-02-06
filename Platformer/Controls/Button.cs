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
    public class Button : Microsoft.Xna.Framework.DrawableGameComponent
    {
        protected Vector2 size, position;
        protected String text;
        protected bool isFocus;
        protected Texture2D texture;
        protected SpriteFont font;
        protected MouseState oldMs;
        private SpriteBatch spriteBatch;

        public delegate void Hendler(EventArgs e);
        public event Hendler MouseClick;
        public event Hendler MouseMove;

        #region Свойства

        public Vector2 Size
        {
            get { return size; }
            set { size = value; }

        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }

        }

        public String Text
        {
            get { return text; }
            set { text = value; }

        }




        #endregion

        public Button(Game game, ref Texture2D texture, SpriteFont font)
            : base(game)
        {
            text = "Button";
            this.font = font;
            this.texture = texture;
            size = font.MeasureString(text);
            position = new Vector2(0, 0);
            spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
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
            HandleFocus();

            base.Update(gameTime);
        }
        /// <summary>
        /// Проверка наведения курсора
        /// </summary>
        private void HandleFocus()
        {
            MouseState ms = Mouse.GetState();

            if (ms.X > position.X && ms.X < (position.X + size.X) &&
                ms.Y > position.Y && ms.Y < (position.Y + size.Y))
            {
                isFocus = true;

                //MouseMove(EventArgs.Empty);

                if (ms.LeftButton == ButtonState.Pressed&&oldMs.LeftButton==ButtonState.Released)
                {
                    MouseClick(EventArgs.Empty);

                }

            }
            else
            {
                isFocus = false;
            }
            oldMs = ms;
        }


        

        public override void Draw(GameTime gameTime)
        {
            if (isFocus)
            {
                spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y),
                    Color.Green);
            }
            else
            {
                spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y),
                    Color.Red);

            }

            spriteBatch.DrawString(font, text, position, Color.White);



            base.Draw(gameTime);
        }

    }
}