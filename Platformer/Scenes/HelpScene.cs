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
    public class HelpScene : GameScane
    {
        protected Button btnBack;
        private ContentManager content;
        private Game game;
        protected SpriteFont font;
        protected Texture2D nullTexture;
        public delegate void HendleHelpScene();
        public event HendleHelpScene btnBackClick;
        protected Image fon;
        protected Texture2D bgImage;
        protected Label text;

        

        public HelpScene(Game game,ContentManager content)
            : base(game)
        {
            this.content = content;
            this.game = game;
            Enabled = false;
            Visible = false;
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {

           

            font = content.Load<SpriteFont>("Font");
            nullTexture = content.Load<Texture2D>("null");
            bgImage = content.Load<Texture2D>("fon-55");
            fon = new Image(game, ref bgImage, Image.DrawMode.All);
            Components.Add(fon);

            text = new Label(game, font);
            text.Position = new Vector2(50, 50);
            text.Shadows = true;
            text.Text = "Help menu";
            Components.Add(text);


            btnBack = new Button(game, ref nullTexture, font);
            Components.Add(btnBack);
            btnBack.Text = "Back to menu";
            btnBack.Size = font.MeasureString(btnBack.Text);
            btnBack.Position = new Vector2(Game.Window.ClientBounds.Width-btnBack.Size.X,
                Game.Window.ClientBounds.Height-btnBack.Size.Y);
            btnBack.MouseClick += new Button.Hendler(btnBack_MouseClick);

           

            base.Initialize();
        }



       
        void btnBack_MouseClick(EventArgs e)
        {
            btnBackClick();
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
    }
}