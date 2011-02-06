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
    public class Stock : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private List<Fruit> fruits;
        private SpriteBatch spriteBatch = null;
        private ContentManager content;
        private SpriteFont font;
        private bool needUpdate;
        protected Texture2D blackFon;

        public delegate void HandleStock(Fruit f);
        public event HandleStock selectedFruit;

        public Stock(Game game)
            : base(game)
        {
            fruits = new List<Fruit>();
        }


        public void AddFruit(Fruit fruit)
        {
            bool isAvalible = false;

                for (int i = 0; i < fruits.Count; i++)
                {

                    if (fruit.Name ==fruits[i].Name)
                    {
                        isAvalible = true;
                        fruits[i].Count++;
                    }
                }
            
            if (!isAvalible)
            {
                fruits.Add(fruit);
            }
            needUpdate = true;
        }



        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            content = (ContentManager)Game.Services.GetService(typeof(ContentManager));
            font = content.Load<SpriteFont>("Font");
            blackFon = content.Load<Texture2D>("blackFon");
            EvendHandle();
            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            if (needUpdate)
            {
                if (fruits.Count > 0)
                {

                    EvendHandle();
                    Fruit fruitTemp = null;
                    for (int i = 0; i < fruits.Count; i++)
                    {

                        fruits[i].Update(gameTime);

                        if (fruits[i].Count > 0)
                        {
                            fruits[i].Show();
                        }
                        else
                        {
                            fruits[i].Hide();
                        }


                        if (fruitTemp == null)
                        {
                            fruits[i].Position = new Vector2(0, 0);
                            fruitTemp = fruits[i];
                        }
                        else 
                        {
                            fruits[i].Position = new Vector2(0, fruitTemp.Position.X + 32);
                            fruitTemp = fruits[i];
                        }
                    
                    }

                
                }
            
            }

            base.Update(gameTime);
        }

        void Stock_Selected(Fruit fruit)
        {
            selectedFruit(fruit);
        }

        public Fruit this[int index]
        {
            get { return fruits[index]; }
            set { fruits[index] = value; }

    }
        public int Count
        {
            get { return fruits.Count; }
        }

        private void EvendHandle()
        {
            for (int i = 0; i < fruits.Count; i++)
            {
                fruits[i].Selected += new Fruit.HandleFruit(Stock_Selected);

            }

        }


        public override void Draw(GameTime gameTime)
        {
            if(fruits.Count>0){
                spriteBatch.Draw(blackFon, new Rectangle((int)fruits[0].Position.X, (int)fruits[0].Position.Y,
                    fruits[fruits.Count - 1].Texture.Width, fruits[fruits.Count - 1].Texture.Height), Color.White);
            }


            for (int i = 0; i < fruits.Count; i++)
            {
                if (fruits[i].Visible && fruits[i].Enabled)
                {
                    fruits[i].Draw(gameTime);
                }
            
            }

           
            base.Draw(gameTime);
        }
    }
}