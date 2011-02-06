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
using Platformer.Controls;
using Platformer.Elements;


namespace Platformer.Scenes
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class ActionScene:GameScane
    {
        protected Texture2D bgTexture;
        protected Image background;
        private ContentManager content = null;
        private CoinsBar coinsBar;
        private Stock stock;
        private Fruit fruht;
        private Market market;
        Fruit tf = null;

        public delegate void HandleAction();
        public event HandleAction EscPress;

        private KeyboardState oldKS; 
         

        public ActionScene(Game game)
            : base(game)
        {
            Enabled = false;
            Visible = false;
            
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            content = (ContentManager)Game.Services.GetService(typeof(ContentManager));
            bgTexture = content.Load<Texture2D>("trava");
            background = new Image(Game, ref bgTexture, Image.DrawMode.All);
            coinsBar = new CoinsBar(Game);
            coinsBar.Initialize();
            Components.Add(background);
            Components.Add(coinsBar);

            stock = new Stock(Game);
            stock.Initialize();
            Components.Add(stock);


            fruht = new Fruit(Game,content.Load<Texture2D>("icontexto-green-01"));
            fruht.FruitState = Fruit.State.InTable;
            fruht.Name = "Kapusta";
            fruht.Count = 20;
            fruht.Show();

            stock.AddFruit(fruht);
            fruht = new Fruit(Game, content.Load<Texture2D>("Tomat"));
            fruht.Name = "Tomat";
            fruht.Count = 20;
            stock.AddFruit(fruht);
            stock.selectedFruit += new Stock.HandleStock(stock_selectedFruit);


            market = new Market(Game);
            Components.Add(market);


            base.Initialize();
        }

        void stock_selectedFruit(Fruit f)
        {
            if (tf == null)
            {
                tf = new Fruit(Game, f.Texture);
                tf.Show();

                tf.FruitState = Fruit.State.Selected;
                tf.UnSelected += new Fruit.HandleFruit(tf_UnSelected);
                tf.Pasted += new Fruit.HandleFruit(tf_Pasted);
                Components.Add(tf);
            }
        }



        void tf_Pasted(Fruit fruit)
        {
            if (tf != null)
            {
                Fruit pFruit = new Fruit(Game, fruit.Texture);
                pFruit.FruitState = Fruit.State.Pasted;
                pFruit.Show();
                pFruit.Position = new Vector2(Mouse.GetState().X - pFruit.Texture.Width / 2, Mouse.GetState().Y - pFruit.Texture.Height);
                Components.Add(pFruit);
                tf.Hide();
                tf = null;

            }
        }

        void tf_UnSelected(Fruit fruit)
        {
            tf.FruitState = Fruit.State.InTable;
            stock.AddFruit(tf);
            tf.Hide();
            tf = null;

        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.M) )
            {
                market.Show();
            }

            if (keyboardState.IsKeyDown(Keys.N))
            {
                market.Hide();
            }


            if (keyboardState.IsKeyDown(Keys.Escape) &&
                oldKS.IsKeyUp(Keys.Escape))
            {
                EscPress();
            }



            oldKS = keyboardState;

            base.Update(gameTime);
        }
    }
}