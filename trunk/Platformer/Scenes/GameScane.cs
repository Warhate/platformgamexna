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


namespace Platformer.Scenes
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class GameScane : Microsoft.Xna.Framework.DrawableGameComponent
    {
        protected readonly List<GameComponent> components;

        public GameScane(Game game)
            : base(game)
        {
            components = new List<GameComponent>();
            // TODO: Construct any child components here
        }


        public List<GameComponent> Components
        {
            get { return components; }
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

            for (int i = 0; i < components.Count; i++)
            {
                if (components[i].Enabled)
                {
                    components[i].Update(gameTime);
                
                }
            
            }

                base.Update(gameTime);
        }


        /// <summary>
        /// Show
        /// </summary>
        public virtual void Show()
        {
            Enabled = true;
            Visible = true;
        
        }


        /// <summary>
        /// Hide
        /// </summary>
        public virtual void Hide()
        {
            Enabled = false;
            Visible = false;
        
        }

        /// <summary>
        /// Draw scene
        /// </summary>
        /// <param name="gameTime">Game time</param>
        public override void Draw(GameTime gameTime)
        {
            for (int i = 0; i < components.Count; i++)
            {
                GameComponent component = components[i];
                if (component is DrawableGameComponent && ((DrawableGameComponent)component).Visible)
                {
                    ((DrawableGameComponent)component).Draw(gameTime);
                }
            
            }


                base.Draw(gameTime);
        }
    }
}