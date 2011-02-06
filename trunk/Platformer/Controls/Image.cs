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
    public class Image : Microsoft.Xna.Framework.DrawableGameComponent
    {
        protected Texture2D image;
        private SpriteBatch spriteBatch = null;
        protected DrawMode drawMode;
        /// <summary>
        /// Метод рисования
        /// </summary>
        public enum DrawMode
        { 
            Strech,
            Center,
            All
        
        
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="game">Игра</param>
        /// <param name="image">Спрайт изображения</param>
        /// <param name="drawMode">Способ рисования</param>
        public Image(Game game, ref Texture2D image, DrawMode drawMode)
            : base(game)
        {
            this.drawMode = drawMode;
            this.image = image;
            spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            
        }

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
            // TODO: Add your update code here

            base.Update(gameTime);
        }

        /// <summary>
        /// Draw image
        /// </summary>
        /// <param name="gameTime">Game Time</param>
        public override void Draw(GameTime gameTime)
        {
            switch (drawMode)
            { 
                case DrawMode.All:
                    {
                        DrawAll();
                        break;
                    }

                case DrawMode.Center:
                    {
                        spriteBatch.Draw(image, new Rectangle((Game.Window.ClientBounds.Width - image.Width) / 2,
                            (Game.Window.ClientBounds.Height - image.Height) / 2, image.Width, image.Height), Color.White);
                        break;
                    }


                case DrawMode.Strech:
                    {
                        spriteBatch.Draw(image, new Rectangle(0,
                            0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height), Color.White);
                        break;
                    }
            
            
            }


            base.Draw(gameTime);
        }

        /// <summary>
        /// Замостить изображением рабочую область
        /// </summary>
        private void DrawAll()
        {
            int wWidth = Game.Window.ClientBounds.Width;
            int wHight = Game.Window.ClientBounds.Height;

            for (int i = 0; i < (int)(wWidth / image.Width) + image.Width; i++)
            {
                for (int j = 0; j < (int)(wHight / image.Height) + image.Height; j++)
                {
                    spriteBatch.Draw(image, new Rectangle(image.Width*i,
                            image.Height*j, image.Width, image.Height), Color.White);
                }
            
            }
            
        }
    }
}