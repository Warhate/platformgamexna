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


namespace Platformer.Elements
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Fruit : Microsoft.Xna.Framework.DrawableGameComponent
    {
        protected int cost,count;
        protected Texture2D texture;
        protected Vector2 position;
        protected State state;
        private SpriteBatch spriteBatch = null;
        protected String name;
        private MouseState oldMs;
        private MouseState oldMsU;
        protected Texture2D blackFon;
        protected SpriteFont font;
        private ContentManager content;
        protected bool inFocus;
        protected int id;

        public delegate void HandleFruit(Fruit fruit);
        public event HandleFruit Selected;
        public event HandleFruit UnSelected;
        public event HandleFruit Pasted;




        public Fruit(Game game,Texture2D texture)
            : base(game)
        {
            this.position = Vector2.Zero;
            this.cost = 0;
            count = 1;
            this.name = "Unknow";
            this.texture = texture;
            Visible = false;
            Enabled = false;
            state = State.InTable;
            spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            content = (ContentManager)Game.Services.GetService(typeof(ContentManager));
            Initialize();
        }

       
        public Fruit(Game game)
            :base(game)
        { 
            
        
        }

        /// <summary>
        /// Количество доступних
        /// </summary>
        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        /// <summary>
        /// Название фрукта
        /// </summary>
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Текстура
        /// </summary>
        public Texture2D Texture
        {
            get { return texture;}
        
        }

        /// <summary>
        /// Состояние овоща:
        /// -в меню
        /// -у курсора
        /// -посажен
        /// </summary>
        public enum State
        { 
            InTable,
            Selected,
            Pasted,
            InMarket
        
        }

        /// <summary>
        /// Состояние
        /// </summary>
        public State FruitState
        {
            get { return state; }
            set { state = value; }
        
        }

        /// <summary>
        /// Позиция
        /// </summary>
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        
        }

        /// <summary>
        /// Цена
        /// </summary>
        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        
        }

        /// <summary>
        /// Показать
        /// </summary>
        public void Show()
        {
            Enabled = true;
            Visible = true;
        
        }
        /// <summary>
        /// Спрятать
        /// </summary>
        public void Hide()
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
            font = content.Load<SpriteFont>("FruitFont");
            blackFon = content.Load<Texture2D>("blackFon");
            

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            if (Enabled)
            {
                MouseState ms = Mouse.GetState();
                switch (state)
                {
                    case State.InTable:
                        {
                            if (count <= 0)
                            {
                                Hide();
                            }
                            else
                            {

                                Show();
                            }
                            //Если наведен курсор
                            if (ms.X > position.X && ms.X < position.X + 32 &&
                                ms.Y > position.Y && ms.Y < position.Y + 32)
                            {
                                inFocus = true;


                                //если произошёл клик мышкой
                                if (oldMs.LeftButton == ButtonState.Pressed &&
                                    ms.LeftButton == ButtonState.Released)
                                {
                                    count--;
                                    Selected(this);
                                }



                            }
                            else 
                            {
                                inFocus = false;
                            }
                            oldMs = ms;
                            break;

                        }

                    case State.Selected:
                        {
                            //если нажата правая кнопка мышки
                            if (ms.RightButton == ButtonState.Pressed)
                            {

                                //this.Hide();
                                UnSelected(this);
                                count++;


                            }
                            //елси клик ЛКМ
                            if (oldMsU.LeftButton == ButtonState.Pressed &&
                                    ms.LeftButton == ButtonState.Released)
                            {

                                state = State.Pasted;
                                Pasted(this);
                                //position = new Vector2(ms.X - 16, ms.Y - 16);

                            }

                            oldMsU = ms;
                            break;

                        }

                }
            }

           
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            switch (state)
            {
                case State.InTable:
                    {
                        spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, 32, 32), Color.White);
                        spriteBatch.DrawString(font, count.ToString(), position, Color.White);
                        base.Draw(gameTime);
                        if (inFocus)
                        {
                            ShowToolTip(gameTime);
                        }
                        break;
                    
                    }
                case State.Selected:
                    {

                        spriteBatch.Draw(texture, new Rectangle(Mouse.GetState().X + 16, Mouse.GetState().Y + 16, 16, 16), Color.White);
                        base.Draw(gameTime);
                        break;
                    
                    }
                case State.Pasted:
                    {
                        spriteBatch.Draw(texture, position, Color.White);
                        base.Draw(gameTime);
                        break;
                    
                    }
            
            }



            
        }

       
        private void ShowToolTip(GameTime gameTime)
        {
            Rectangle rec = new Rectangle();
            MouseState ms = Mouse.GetState();
            rec.X = ms.X+8;
            rec.Y = ms.Y+12;
            int width = 100;
            int hight = (int)font.MeasureString(count.ToString()).Y*5;
            rec.Width = width;
            rec.Height = hight;
            spriteBatch.Draw(blackFon, rec, Color.White);
            spriteBatch.DrawString(font, name, new Vector2(rec.X+5,rec.Y+5), Color.Green);
            spriteBatch.DrawString(font, String.Format("Count: {0}", count.ToString()), new Vector2(rec.X + 5, rec.Y + 20), Color.Gray);
          //  spriteBatch.DrawString(font, PowerStatus.BatteryLifePercent.Value.ToString(), new Vector2(rec.X + 5, rec.Y + 30), Color.Gray);
        }


    }
}