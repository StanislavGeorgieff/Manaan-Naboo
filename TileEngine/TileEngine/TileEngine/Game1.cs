using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using TileEngine.Sprites;

namespace TileEngine
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private TileMap myMap;
        private int squaresAcross = 17;
        private int squaresDown = 37;

        private int baseOffsetX = -32;
        private int baseOffsetY = -64;

        float heightRowDepthMod = 0.0000001f;

        private SpriteFont pericles6;

        private Texture2D hilight;

        private bool showCoordinates;

        private SpriteAnimation vlad;


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

            this.IsMouseVisible = true;

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

            myMap = new TileMap(Content.Load<Texture2D>(@"Textures/TileSets/mousemap"));
            hilight = Content.Load<Texture2D>(@"Textures/TileSets/hilight");

            //Initializing the camera.

            Camera.ViewWidth = this.graphics.PreferredBackBufferWidth;
            Camera.ViewHeight = this.graphics.PreferredBackBufferHeight;
            Camera.WorldWidth = ((myMap.MapWidth - 2)*Tile.TileStepX);
            Camera.WorldHeight = ((myMap.MapHeight - 2)*Tile.TileStepY);
            Camera.DisplayOffset = new Vector2(baseOffsetX, baseOffsetY);

            showCoordinates = true;


            // Here we initialize the player animation.

            vlad = new SpriteAnimation(Content.Load<Texture2D>(@"Textures/Characters/T_Vlad_Sword_Walking_48x48"));

            vlad.AddAnimation("WalkEast", 0, 48 * 0, 48, 48, 8, 0.1f);
            vlad.AddAnimation("WalkNorth", 0, 48 * 1, 48, 48, 8, 0.1f);
            vlad.AddAnimation("WalkNorthEast", 0, 48 * 2, 48, 48, 8, 0.1f);
            vlad.AddAnimation("WalkNorthWest", 0, 48 * 3, 48, 48, 8, 0.1f);
            vlad.AddAnimation("WalkSouth", 0, 48 * 4, 48, 48, 8, 0.1f);
            vlad.AddAnimation("WalkSouthEast", 0, 48 * 5, 48, 48, 8, 0.1f);
            vlad.AddAnimation("WalkSouthWest", 0, 48 * 6, 48, 48, 8, 0.1f);
            vlad.AddAnimation("WalkWest", 0, 48 * 7, 48, 48, 8, 0.1f);


            vlad.AddAnimation("IdleEast", 0, 48 * 0, 48, 48, 1, 0.2f);
            vlad.AddAnimation("IdleNorth", 0, 48 * 1, 48, 48, 1, 0.2f);
            vlad.AddAnimation("IdleNorthEast", 0, 48 * 2, 48, 48, 1, 0.2f);
            vlad.AddAnimation("IdleNorthWest", 0, 48 * 3, 48, 48, 1, 0.2f);
            vlad.AddAnimation("IdleSouth", 0, 48 * 4, 48, 48, 1, 0.2f);
            vlad.AddAnimation("IdleSouthEast", 0, 48 * 5, 48, 48, 1, 0.2f);
            vlad.AddAnimation("IdleSouthWest", 0, 48 * 6, 48, 48, 1, 0.2f);
            vlad.AddAnimation("IdleWest", 0, 48 * 7, 48, 48, 1, 0.2f);

            vlad.Position = new Vector2(100, 100);
            vlad.DrawOffset = new Vector2(-24, -38);
            vlad.CurrentAnimation = "WalkEast";
            vlad.IsAnimating = true;

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
            GetKeyboardInput();


            float vladX = MathHelper.Clamp(
                vlad.Position.X, 0 + vlad.DrawOffset.X, Camera.WorldWidth);
            float vladY = MathHelper.Clamp(
                vlad.Position.Y, 0 + vlad.DrawOffset.Y, Camera.WorldHeight);
            vlad.Position = new Vector2(vladX, vladY);

            Vector2 testPosition = Camera.WorldToScreen(vlad.Position);

            if (testPosition.X < 100)
            {
                Camera.Move(new Vector2(testPosition.X - 100, 0));
            }
            if (testPosition.X > (Camera.ViewWidth - 100))
            {
                Camera.Move(new Vector2(testPosition.X - (Camera.ViewWidth - 100), 0));
            }

            if (testPosition.Y < 100)
            {
                Camera.Move(new Vector2(0, testPosition.Y - 100));
            }

            if (testPosition.Y > (Camera.ViewHeight - 100))
            {
                Camera.Move(new Vector2(0, testPosition.Y - (Camera.ViewHeight - 100)));
            }

            vlad.Update(gameTime);


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

            DrawTheMap();

            // Here we draw the player.
            Point vladStandingOn = myMap.WorldToMapCell(new Point((int) vlad.Position.X, (int) vlad.Position.Y));
            int vladHeight = myMap.Rows[vladStandingOn.Y].Columns[vladStandingOn.X].HeighTiles.Count*
                             Tile.HeightTileOffset;
            vlad.Draw(spriteBatch, 0, - vladHeight);

            // Here we draw hilighted tile under the cursor.
            DrawHiLightTile();

            spriteBatch.End();

            base.Draw(gameTime);
        }

        
        private void DrawTheMap()
        {
            Vector2 firstSquare = new Vector2(Camera.Location.X / Tile.TileStepX, Camera.Location.Y / Tile.TileStepY);
            int firstX = (int) firstSquare.X;
            int firstY = (int) firstSquare.Y;

            Vector2 squareOffset = new Vector2(Camera.Location.X % Tile.TileStepX, Camera.Location.Y % Tile.TileStepY);
            int offsetX = (int) squareOffset.X;
            int offsetY = (int) squareOffset.Y;

            float maxDepth = ((myMap.MapWidth + 1) + ((myMap.MapHeight + 1)*Tile.TileWidth))*10;

            for (int y = 0; y < squaresDown; y++)
            {
                int rowOffset = 0;
                if ((firstY + y)%2 == 1)
                {
                    rowOffset = Tile.OddRowXOffset;
                }

                for (int x = 0; x < squaresAcross; x++)
                {
                    int mapX = (firstX + x);
                    int mapY = (firstY + y);
                    float depthOffset = 0.7f - ((mapX + (mapY*Tile.TileWidth))/maxDepth);

                    //Drawing out Base Tiles. This is the ground, the things that are always further away from the camera.

                    //If mapX and mapY are located outside the map, we simply exit the loop and continue on
                    if ((mapX >= myMap.MapWidth) || (mapY >= myMap.MapHeight))
                        continue;

                    foreach (int baseTileId in myMap.Rows[mapY].Columns[mapX].BaseTiles)
                    {
                        spriteBatch.Draw(
                            Tile.TileSetTexture,
                            Camera.WorldToScreen(
                                new Vector2(
                                    (mapX * Tile.TileStepX) + rowOffset,
                                    mapY * Tile.TileStepY)),
                            Tile.GetSourceRectangle(baseTileId),
                            Color.White,
                            0.0f,
                            Vector2.Zero,
                            1.0f,
                            SpriteEffects.None,
                            1.0f);
                    }

                    //Now we draw our Height Tiles.

                    int heightRow = 0;

                    foreach (int heightId in myMap.Rows[mapY].Columns[mapX].HeighTiles)
                    {
                        spriteBatch.Draw(
                            Tile.TileSetTexture,
                            Camera.WorldToScreen(
                                new Vector2(
                                    (mapX * Tile.TileStepX) + rowOffset,
                                    mapY * Tile.TileStepY - (heightRow * Tile.HeightTileOffset))),
                            Tile.GetSourceRectangle(heightId),
                            Color.White,
                            0.0f,
                            Vector2.Zero,
                            1.0f,
                            SpriteEffects.None,
                            depthOffset - ((float)heightRow * heightRowDepthMod));
                        heightRow++;
                    }


                    //Here we draw the Topper Tiles.

                    foreach (int topperId in myMap.Rows[y + firstY].Columns[x + firstX].TopperTiles)
                    {
                        spriteBatch.Draw(
                            Tile.TileSetTexture,
                            Camera.WorldToScreen(
                                new Vector2(
                                    (mapX * Tile.TileStepX) + rowOffset,
                                    mapY * Tile.TileStepY)),
                            Tile.GetSourceRectangle(topperId),
                            Color.White,
                            0.0f,
                            Vector2.Zero,
                            1.0f,
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
        }

        private void DrawHiLightTile()
        {
            Vector2 hilightLoc = Camera.ScreenToWorld(new Vector2(Mouse.GetState().X, Mouse.GetState().Y));
            Point hilightPoint = myMap.WorldToMapCell(new Point((int)hilightLoc.X, (int)hilightLoc.Y));

            int hilightrowOffset = 0;
            if ((hilightPoint.Y) % 2 == 1)
                hilightrowOffset = Tile.OddRowXOffset;

            spriteBatch.Draw(
                hilight,
                Camera.WorldToScreen(
                    new Vector2(
                        (hilightPoint.X * Tile.TileStepX) + hilightrowOffset,
                        (hilightPoint.Y + 2) * Tile.TileStepY)),
                new Rectangle(0, 0, 64, 32),
                Color.White * 0.3f,
                0.0f,
                Vector2.Zero,
                1.0f,
                SpriteEffects.None,
                0.0f);
        }

        private void GetKeyboardInput()
        {
            //KeyboardState ks = Keyboard.GetState();

            //if (ks.IsKeyDown(Keys.Left))
            //{
            //    Camera.Move(new Vector2(-2, 0));
            //}

            //if (ks.IsKeyDown(Keys.Right))
            //{
            //    Camera.Move(new Vector2(2, 0));
            //}

            //if (ks.IsKeyDown(Keys.Up))
            //{
            //    Camera.Move(new Vector2(0, -2));
            //}

            //if (ks.IsKeyDown(Keys.Down))
            //{
            //    Camera.Move(new Vector2(0, 2));
            //}


            //We are adding a new method, because now we have a character.

            Vector2 moveVector = Vector2.Zero;
            Vector2 moveDir = Vector2.Zero;
            string animation = "";

            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.NumPad7))
            {
                moveDir = new Vector2(-2, -1);
                animation = "WalkNorthWest";
                moveVector += new Vector2(-2, -1);
            }

            if (ks.IsKeyDown(Keys.NumPad8))
            {
                moveDir = new Vector2(0, -1);
                animation = "WalkNorth";
                moveVector += new Vector2(0, -1);
            }

            if (ks.IsKeyDown(Keys.NumPad9))
            {
                moveDir = new Vector2(2, -1);
                animation = "WalkNorthEast";
                moveVector += new Vector2(2, -1);
            }

            if (ks.IsKeyDown(Keys.NumPad4))
            {
                moveDir = new Vector2(-2, 0);
                animation = "WalkWest";
                moveVector += new Vector2(-2, 0);
            }

            if (ks.IsKeyDown(Keys.NumPad6))
            {
                moveDir = new Vector2(2, 0);
                animation = "WalkEast";
                moveVector += new Vector2(2, 0);
            }

            if (ks.IsKeyDown(Keys.NumPad1))
            {
                moveDir = new Vector2(-2, 1);
                animation = "WalkSouthWest";
                moveVector += new Vector2(-2, 1);
            }

            if (ks.IsKeyDown(Keys.NumPad2))
            {
                moveDir = new Vector2(0, 1);
                animation = "WalkSouth";
                moveVector += new Vector2(0, 1);
            }

            if (ks.IsKeyDown(Keys.NumPad3))
            {
                moveDir = new Vector2(2, 1);
                animation = "WalkSouthEast";
                moveVector += new Vector2(2, 1);
            }

            if (moveDir.Length() != 0)
            {
                vlad.MoveBy((int)moveDir.X, (int)moveDir.Y);
                if (vlad.CurrentAnimation != animation)
                    vlad.CurrentAnimation = animation;
            }
            else
            {
                vlad.CurrentAnimation = "Idle" + vlad.CurrentAnimation.Substring(4);
            }

        }
    }
}
