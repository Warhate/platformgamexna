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


namespace Platformer.Scenes
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Menu : GameScane
    {
        Texture2D defaultBtnTexture;
        Texture2D bgFone;
        Button btnNewGame, btnLoadGame, btnSaveGame, btnAbout, btnExit;
        ContentManager content;
        SpriteFont defaultFont;
        Game game;
        Label menuLabel;
        Image fone;
        public delegate void HendleMenu();
        public event HendleMenu BtnAboutClick;
        public event HendleMenu BtnNewGameClick; 


        public Menu(Game game,ContentManager content)
            : base(game)
        {
            this.content = content;
            this.game = game;
            defaultBtnTexture = content.Load<Texture2D>("null");
            defaultFont = content.Load<SpriteFont>("Font");
            bgFone = content.Load<Texture2D>("fon-46");
            InitializeButton();
            Enabled = false;
            Visible = false;
           
        }

        protected override void LoadContent()
        {
            
            base.LoadContent();
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
        /// Инициализация кнопок меню
        /// </summary>
        /// <param name="game">Клас игры</param>
        private void InitializeButton()
        {


            //Images
            fone = new Image(game,ref bgFone, Image.DrawMode.All);
            Components.Add(fone);
            //Labels
            menuLabel = new Label(game, defaultFont);
            Components.Add(menuLabel);
            



            //Buttons
            btnNewGame = new Button(game, ref defaultBtnTexture, defaultFont);
            btnLoadGame = new Button(game, ref defaultBtnTexture, defaultFont);
            btnSaveGame = new Button(game, ref defaultBtnTexture, defaultFont);
            btnAbout = new Button(game, ref defaultBtnTexture, defaultFont);
            btnExit = new Button(game, ref defaultBtnTexture, defaultFont);
            Components.Add(btnNewGame);
            Components.Add(btnLoadGame);
            Components.Add(btnSaveGame);
            Components.Add(btnAbout);
            Components.Add(btnExit);

            btnExit.MouseClick += new Button.Hendler(btnExit_MouseClick);
            btnAbout.MouseClick += new Button.Hendler(btnAbout_MouseClick);
            btnNewGame.MouseClick += new Button.Hendler(btnNewGame_MouseClick);
            btnLoadGame.MouseClick += new Button.Hendler(btnLoadGame_MouseClick);
            btnSaveGame.MouseClick += new Button.Hendler(btnSaveGame_MouseClick);



            BtnSetParametr();
        }

        void btnSaveGame_MouseClick(EventArgs e)
        {
            menuLabel.Text = "Save Game Menu (=(debug)";
        }

        void btnLoadGame_MouseClick(EventArgs e)
        {
            
        }

        void btnNewGame_MouseClick(EventArgs e)
        {
            BtnNewGameClick();
        }

        void btnAbout_MouseClick(EventArgs e)
        {
            BtnAboutClick();
        }

        void btnExit_MouseClick(EventArgs e)
        {
            game.Exit();
        }

        /// <summary>
        /// Установка значений кнопок меню
        /// </summary>
        private void BtnSetParametr()
        {
            float btnHight = defaultFont.MeasureString(btnNewGame.Text).Y;
            int wWidth = Game.Window.ClientBounds.Width;
            int wHight = Game.Window.ClientBounds.Height;

           //BtnNewGame
            btnNewGame.Text = "New Game";
            btnNewGame.Size = defaultFont.MeasureString(btnNewGame.Text);
            btnNewGame.Position = new Vector2(wWidth - btnNewGame.Size.X, wHight - btnHight * 5);

            //BtnLoadGame
            btnLoadGame.Text = "Load Game";
            btnLoadGame.Size = defaultFont.MeasureString(btnLoadGame.Text);
            btnLoadGame.Position = new Vector2(wWidth - btnLoadGame.Size.X, wHight - btnHight * 4);

            //BtnSaveGame
            btnSaveGame.Text = "Save Game";
            btnSaveGame.Size = defaultFont.MeasureString(btnSaveGame.Text);
            btnSaveGame.Position = new Vector2(wWidth - btnSaveGame.Size.X, wHight - btnHight * 3);

            //BtnAbout
            btnAbout.Text = "About";
            btnAbout.Size = defaultFont.MeasureString(btnAbout.Text);
            btnAbout.Position = new Vector2(wWidth - btnAbout.Size.X, wHight - btnHight * 2);

            //BtnExit
            btnExit.Text = "Exit";
            btnExit.Size = defaultFont.MeasureString(btnExit.Text);
            btnExit.Position = new Vector2(wWidth - btnExit.Size.X, wHight - btnHight * 1);


            //Label
            menuLabel.Position = new Vector2(50,50);
            menuLabel.Text = "Game Menu";
            menuLabel.Shadows = true;
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