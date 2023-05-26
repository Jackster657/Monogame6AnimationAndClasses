using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;

namespace Monogame6AnimationAndClasses
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D tribbleBrownTexture;

        Texture2D tribbleCreamTexture;


        List<Texture2D> tribbleTextures;
        List<TribbleClass> tribbles;

        Texture2D tribbleTexture;
        Rectangle tribbleGreyRect;
        Texture tribbleGreyTexture;
        Texture2D tribbleOrangeTexture;
        SoundEffect hit;
        int colour;

        Vector2 tribbleGreySpeed;

   
        Random generator;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            generator = new Random();
            tribbleTextures = new List<Texture2D>();
            tribbles = new List<TribbleClass>();
            base.Initialize();

            // Create random tribbles
            for (int i = 0; i < 40; i++)
                tribbles.Add(new TribbleClass(tribbleTextures[generator.Next(tribbleTextures.Count)], new Rectangle(300, 10, generator.Next(25, 300), generator.Next(25, 300)), new Vector2(generator.Next(1,4), generator.Next(1, 4)),  hit));
            
            
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            // TODO: use this.Content to load your game content here
            
            tribbleTextures.Add(Content.Load<Texture2D>("tribbleGrey"));
            tribbleTextures.Add(Content.Load<Texture2D>("tribbleCream"));
            tribbleTextures.Add(Content.Load<Texture2D>("tribbleBrown"));
            tribbleTextures.Add(Content.Load<Texture2D>("tribbleOrange"));
            hit = Content.Load<SoundEffect>("mwop");







        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            foreach (TribbleClass tribble in tribbles)
                tribble.Move(_graphics);
            


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            foreach (TribbleClass tribble in tribbles)
                tribble.Draw(_spriteBatch);
            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}