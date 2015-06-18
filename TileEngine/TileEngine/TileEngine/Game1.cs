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

namespace TileEngine
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        TileMap myMap = new TileMap();
        private int squaresAcross = 17;
        private int squaresDown = 37;

        private int baseOffsetX = -32;
        private int baseOffsetY = -64;

        float heightRowDepthMod = 0.0000001f;

        private SpriteFont pericles6;

        private bool showCoordinates;


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
            // TODO: Add your initialization logic here

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

            // TODO: use this.Content to load your game content here

            Tile.TileSetTexture = Content.Load<Texture2D>(@"Textures/Tilesets/tileset4");
            pericles6 = Content.Load<SpriteFont>(@"Fonts/Pericles6");

            showCoordinates = true;
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Escape))
                this.Exit();

            // TODO: Add your update logic here

            //Now we want to move around. The camera logic is here.
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Left))
            {
                Camera.Location.X = MathHelper.Clamp(Camera.Location.X - 2, 0, (myMap.MapWidth - squaresAcross) * Tile.TileStepX);
            }
            if (ks.IsKeyDown(Keys.Right))
            {
                Camera.Location.X = MathHelper.Clamp(Camera.Location.X + 2, 0, (myMap.MapWidth - squaresAcross) * Tile.TileStepX);
            }

            if (ks.IsKeyDown(Keys.Up))
            {
                Camera.Location.Y = MathHelper.Clamp(Camera.Location.Y - 2, 0, (myMap.MapHeight - squaresDown) * Tile.TileStepY);
            }

            if (ks.IsKeyDown(Keys.Down))
            {
                Camera.Location.Y = MathHelper.Clamp(Camera.Location.Y + 2, 0, (myMap.MapHeight - squaresDown) * Tile.TileStepY);
            }


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here


            //Here we are drawing out map. First thing to do is calculating the starting point of the drawing, based on the camera's position and offset.

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            Vector2 firstSquare = new Vector2(Camera.Location.X / Tile.TileStepX, Camera.Location.Y / Tile.TileStepY);
            int firstX = (int)firstSquare.X;
            int firstY = (int)firstSquare.Y;

            Vector2 squareOffset = new Vector2(Camera.Location.X % Tile.TileStepX, Camera.Location.Y % Tile.TileStepY);
            int offsetX = (int)squareOffset.X;
            int offsetY = (int)squareOffset.Y;

            float maxDepth = ((myMap.MapWidth + 1) + ((myMap.MapHeight + 1) * Tile.TileWidth)) * 10;
            float depthOffset;

            for (int y = 0; y < squaresDown; y++)
            {
                int rowOffset = 0;
                if ((firstY + y) % 2 == 1)
                {
                    rowOffset = Tile.OddRowXOffset;
                }

                for (int x = 0; x < squaresAcross; x++)
                {

                    int mapX = (firstX + x);
                    int mapY = (firstY + y);
                    depthOffset = 0.7f - ((mapX + (mapY * Tile.TileWidth)) / maxDepth);

                    //Drawing out Base Tiles. This is the ground, the things that are always further away from the camera.

                    foreach (int baseTile in myMap.Rows[mapY].Columns[mapX].BaseTiles)
                    {
                        spriteBatch.Draw(
                            Tile.TileSetTexture,
                            new Rectangle(
                                (x * Tile.TileStepX) - offsetX + rowOffset + baseOffsetX,
                                (y * Tile.TileStepY) - offsetY + baseOffsetY,
                                Tile.TileWidth,
                                Tile.TileHeight),
                            Tile.GetSourceRectangle(baseTile), 
                            Color.White,
                            0.0f,
                            Vector2.Zero, 
                            SpriteEffects.None,
                            1.0f);
                    }

                    //Now we draw our Height Tiles.

                    int heightRow = 0;

                    foreach (int heightTile in myMap.Rows[mapY].Columns[mapX].HeighTiles)
                    {
                        spriteBatch.Draw(
                            Tile.TileSetTexture,
                            new Rectangle(
                                (x * Tile.TileStepX) - offsetX + rowOffset + baseOffsetX,
                                (y * Tile.TileStepY) - offsetY + baseOffsetY - (heightRow * Tile.HeightTileOffset),
                                Tile.TileWidth,
                                Tile.TileHeight),
                            Tile.GetSourceRectangle(heightTile),
                            Color.White,
                            0.0f,
                            Vector2.Zero, SpriteEffects.None, 
                            depthOffset - ((float)heightRow * heightRowDepthMod));

                        heightRow++;
                    }


                    //Here we draw the Topper Tiles.

                    foreach (int topperTile in myMap.Rows[y + firstY].Columns[x + firstX].TopperTiles)
                    {
                        spriteBatch.Draw(
                            Tile.TileSetTexture,
                            new Rectangle(
                                (x * Tile.TileStepX) - offsetX + rowOffset + baseOffsetX,
                                (y * Tile.TileStepY) - offsetY + baseOffsetY - (heightRow * Tile.HeightTileOffset),
                                Tile.TileWidth, Tile.TileHeight),
                            Tile.GetSourceRectangle(topperTile),
                            Color.White,
                            0.0f,
                            Vector2.Zero, 
                            SpriteEffects.None, 
                            depthOffset - ((float)heightRow * heightRowDepthMod));
                    }

                    //Here we put a small extra, which will help us to know the coordinates of a tile on the map,

                    if (showCoordinates)
                    {
                        spriteBatch.DrawString(pericles6,
                            String.Format("{0},{1}", (x + firstX), (y + firstY)),
                            new Vector2(
                                (x*Tile.TileStepX) - offsetX + rowOffset + baseOffsetX + 24,
                                (y*Tile.TileStepY) - offsetY + baseOffsetY + 48),
                            Color.White,
                            0f,
                            Vector2.Zero,
                            1.0f,
                            SpriteEffects.None,
                            0.0f);
                    }
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
