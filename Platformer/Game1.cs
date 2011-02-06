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
using Platformer.Scenes;

namespace Platformer
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D image;
        Image img;
        Cursor cursor;
        Texture2D cursorTexture,nullTexture;
        Button button;
        SpriteFont font;
        Menu menu;
        GameScane activeScene;
        HelpScene helpScene;
        ActionScene actionScene;
        


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            this.IsMouseVisible = true;



            //graphics.PreferredBackBufferHeight = 768;
            //graphics.PreferredBackBufferWidth = 1366;
            //graphics.ToggleFullScreen();  
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Services.AddService(typeof(SpriteBatch), spriteBatch);
            Services.AddService(typeof(ContentManager), Content);
            cursorTexture = Content.Load<Texture2D>("cursor");
            //image = Content.Load<Texture2D>("testFon");
            //nullTexture = Content.Load<Texture2D>("null");
            //font = Content.Load<SpriteFont>("Font");
            cursor = new Cursor(this, ref cursorTexture);
            //img = new Image(this, ref image, Image.DrawMode.All);
            //button = new Button(this, ref nullTexture, font);
            //button.Text = "X";
            //button.Size = new Vector2(20,20);
            //button.MouseClick += new Button.Hendler(button_MouseClick);
            //Components.Add(img);

            //Components.Add(button);

            actionScene = new ActionScene(this);
            Components.Add(actionScene);
            actionScene.EscPress += new ActionScene.HandleAction(actionScene_EscPress);
            actionScene.Initialize();
            
            
            helpScene = new HelpScene(this, Content);
            Components.Add(helpScene);
            helpScene.btnBackClick += new HelpScene.HendleHelpScene(helpScene_btnBackClick);
            helpScene.Initialize();

            menu = new Menu(this,Content);
            menu.BtnAboutClick += new Menu.HendleMenu(menu_BtnAboutClick);
            menu.BtnNewGameClick += new Menu.HendleMenu(menu_BtnNewGameClick);
            Components.Add(menu);
            activeScene = menu;
            activeScene.Show();




            //Components.Add(cursor); //Должен быть последним
        }

        void menu_BtnNewGameClick()
        {
            ShowScene(actionScene);
        }

        void actionScene_EscPress()
        {
            ShowScene(menu);
        }

        void helpScene_btnBackClick()
        {
            ShowScene(menu);
        }

        void menu_BtnAboutClick()
        {
            ShowScene(helpScene);
        }

        private void ShowScene(GameScane scene)
        {
            activeScene.Hide();
            activeScene = scene;
            activeScene.Show();
        }

        void button_MouseClick(EventArgs e)
        {
            this.Exit();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            //System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.PanWest;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
