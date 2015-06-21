using System;
using GameProject.Graphics;
using GameProject.Graphics.Sprites;
using GameProject.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProject
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {


        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private TileMap myMap;
        private int squaresAcross = 22;
        private int squaresDown = 41;

        private int baseOffsetX = -32;
        private int baseOffsetY = -64;

        float heightRowDepthMod = 0.0000001f;

        private SpriteFont pericles6;

        private Texture2D hilight;

        private bool showCoordinates;

        private SpriteAnimation gandalf;

        private MobileSprite spell;

        private MobileSprite enemy;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 600;

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

            myMap = new TileMap(Content.Load<Texture2D>(@"Textures/TileSets/mousemap"),
                                Content.Load<Texture2D>(@"Textures/TileSets/slopemaps"));
            hilight = Content.Load<Texture2D>(@"Textures/TileSets/hilight");

            //Initializing the camera.

            Camera.Initialize(graphics, myMap, baseOffsetX, baseOffsetY);

            showCoordinates = true;


            // The enemy.

            enemy = new MobileSprite(Content.Load<Texture2D>(@"Textures/Characters/T_Vlad_Sword_Walking_48x48"));

            enemy.Sprite.AddAnimation("WalkEast", 0, 48 * 0, 48, 48, 8, 0.1f);
            enemy.Sprite.AddAnimation("WalkNorth", 0, 48 * 1, 48, 48, 8, 0.1f);
            enemy.Sprite.AddAnimation("WalkNorthEast", 0, 48 * 2, 48, 48, 8, 0.1f);
            enemy.Sprite.AddAnimation("WalkNorthWest", 0, 48 * 3, 48, 48, 8, 0.1f);
            enemy.Sprite.AddAnimation("WalkSouth", 0, 48 * 4, 48, 48, 8, 0.1f);
            enemy.Sprite.AddAnimation("WalkSouthEast", 0, 48 * 5, 48, 48, 8, 0.1f);
            enemy.Sprite.AddAnimation("WalkSouthWest", 0, 48 * 6, 48, 48, 8, 0.1f);
            enemy.Sprite.AddAnimation("WalkWest", 0, 48 * 7, 48, 48, 8, 0.1f);

            enemy.Sprite.AddAnimation("IdleEast", 0, 48 * 0, 48, 48, 1, 0.2f);
            enemy.Sprite.AddAnimation("IdleNorth", 0, 48 * 1, 48, 48, 1, 0.2f);
            enemy.Sprite.AddAnimation("IdleNorthEast", 0, 48 * 2, 48, 48, 1, 0.2f);
            enemy.Sprite.AddAnimation("IdleNorthWest", 0, 48 * 3, 48, 48, 1, 0.2f);
            enemy.Sprite.AddAnimation("IdleSouth", 0, 48 * 4, 48, 48, 1, 0.2f);
            enemy.Sprite.AddAnimation("IdleSouthEast", 0, 48 * 5, 48, 48, 1, 0.2f);
            enemy.Sprite.AddAnimation("IdleSouthWest", 0, 48 * 6, 48, 48, 1, 0.2f);
            enemy.Sprite.AddAnimation("IdleWest", 0, 48 * 7, 48, 48, 1, 0.2f);

            enemy.Speed = 0.3f;
            enemy.Sprite.CurrentAnimation = "WalkEast";
            enemy.IsCollidable = true;




            // Here we initialize the player animation.


            gandalf = new SpriteAnimation(Content.Load<Texture2D>(@"Textures/Characters/mage"));

            spell = new MobileSprite(Content.Load<Texture2D>(@"Textures/TileSets/FireBombSheet"));
            spell.Sprite.AddAnimation("CastSpell", 0, 0, 48, 48, 25, 0.001f);
            spell.Sprite.CurrentAnimation = "CastSpell";
            spell.HorizontalCollisionBuffer = 10;
            spell.Speed = 7f;
            spell.DeactivateAfterPathing = true;
            



            gandalf.AddAnimation("WalkEast", 0, 48 * 0, 48, 48, 8, 0.1f);
            gandalf.AddAnimation("WalkNorth", 0, 48 * 1, 48, 48, 8, 0.1f);
            gandalf.AddAnimation("WalkNorthEast", 0, 48 * 2, 48, 48, 8, 0.1f);
            gandalf.AddAnimation("WalkNorthWest", 0, 48 * 3, 48, 48, 8, 0.1f);
            gandalf.AddAnimation("WalkSouth", 0, 48 * 4, 48, 48, 8, 0.1f);
            gandalf.AddAnimation("WalkSouthEast", 0, 48 * 5, 48, 48, 8, 0.1f);
            gandalf.AddAnimation("WalkSouthWest", 0, 48 * 6, 48, 48, 8, 0.1f);
            gandalf.AddAnimation("WalkWest", 0, 48 * 7, 48, 48, 8, 0.1f);


            gandalf.AddAnimation("IdleEast", 0, 48 * 0, 48, 48, 1, 0.2f);
            gandalf.AddAnimation("IdleNorth", 0, 48 * 1, 48, 48, 1, 0.2f);
            gandalf.AddAnimation("IdleNorthEast", 0, 48 * 2, 48, 48, 1, 0.2f);
            gandalf.AddAnimation("IdleNorthWest", 0, 48 * 3, 48, 48, 1, 0.2f);
            gandalf.AddAnimation("IdleSouth", 0, 48 * 4, 48, 48, 1, 0.2f);
            gandalf.AddAnimation("IdleSouthEast", 0, 48 * 5, 48, 48, 1, 0.2f);
            gandalf.AddAnimation("IdleSouthWest", 0, 48 * 6, 48, 48, 1, 0.2f);
            gandalf.AddAnimation("IdleWest", 0, 48 * 7, 48, 48, 1, 0.2f);

            gandalf.AddAnimation("CastSpellEast", 0, 48 * 8, 48, 48, 13, 0.01f);
            gandalf.AddAnimation("CastSpellNorth", 0, 48 * 9, 48, 48, 13, 0.01f);
            gandalf.AddAnimation("CastSpellNorthEast", 0, 48 * 10, 48, 48, 13, 0.01f);
            gandalf.AddAnimation("CastSpellNorthWest", 0, 48 * 11, 48, 48, 13, 0.01f);
            gandalf.AddAnimation("CastSpellSouth", 0, 48 * 12, 48, 48, 13, 0.01f);
            gandalf.AddAnimation("CastSpellSouthEast", 0, 48 * 13, 48, 48, 13, 0.01f);
            gandalf.AddAnimation("CastSpellSouthWest", 0, 48 * 14, 48, 48, 13, 0.01f);
            gandalf.AddAnimation("CastSpellWest", 0, 48 * 15, 48, 48, 13, 0.01f);



            gandalf.Position = new Vector2(500, 500);
            gandalf.DrawOffset = new Vector2(-24, -38);
            gandalf.CurrentAnimation = "WalkEast";
            gandalf.IsAnimating = true;

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

            //Now we want to move around. 
            Vector2 moveVector;
            Vector2 moveDirection;
            string playerAnimation;

            moveDirection = GetNextMove(out moveVector, out playerAnimation);

            moveDirection = CheckIfPosibleMove(moveDirection); // If not posible returns Vector2.Zero


            MakeNextMove(gandalf, playerAnimation, moveDirection);

            gandalf.Update(gameTime);
            spell.Update(gameTime);

            enemy.Target = gandalf.Position;
            enemy.Update(gameTime);


            base.Update(gameTime);
        }




        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            Vector2 firstSquare = new Vector2(Camera.Location.X / Tile.TileStepX, Camera.Location.Y / Tile.TileStepY);
            int firstX = (int)firstSquare.X;
            int firstY = (int)firstSquare.Y;

            Vector2 squareOffset = new Vector2(Camera.Location.X % Tile.TileStepX, Camera.Location.Y % Tile.TileStepY);
            int offsetX = (int)squareOffset.X;
            int offsetY = (int)squareOffset.Y;

            float maxdepth = ((myMap.MapWidth + 1) * ((myMap.MapHeight + 1) * Tile.TileWidth)) / 10;
            float depthOffset;

            Point gandalfMapPoint = myMap.WorldToMapCell(new Point((int)gandalf.Position.X, (int)gandalf.Position.Y));

            for (int y = 0; y < squaresDown; y++)
            {
                int rowOffset = 0;
                if ((firstY + y) % 2 == 1)
                    rowOffset = Tile.OddRowXOffset;

                for (int x = 0; x < squaresAcross; x++)
                {
                    int mapx = (firstX + x);
                    int mapy = (firstY + y);
                    depthOffset = 0.7f - ((mapx + (mapy * Tile.TileWidth)) / maxdepth);

                    if ((mapx >= myMap.MapWidth) || (mapy >= myMap.MapHeight))
                        continue;

                    foreach (int tileID in myMap.Rows[mapy].Columns[mapx].BaseTiles)
                    {
                        spriteBatch.Draw(
                            Tile.TileSetTexture,
                            Camera.WorldToScreen(
                                new Vector2((mapx * Tile.TileStepX) + rowOffset, mapy * Tile.TileStepY)),
                            Tile.GetSourceRectangle(tileID),
                            Color.White,
                            0.0f,
                            Vector2.Zero,
                            1.0f,
                            SpriteEffects.None,
                            1.0f);
                    }
                    int heightRow = 0;

                    foreach (int tileID in myMap.Rows[mapy].Columns[mapx].HeighTiles)
                    {
                        spriteBatch.Draw(
                            Tile.TileSetTexture,
                            Camera.WorldToScreen(
                                new Vector2(
                                    (mapx * Tile.TileStepX) + rowOffset,
                                    mapy * Tile.TileStepY - (heightRow * Tile.HeightTileOffset))),
                            Tile.GetSourceRectangle(tileID),
                            Color.White,
                            0.0f,
                            Vector2.Zero,
                            1.0f,
                            SpriteEffects.None,
                            depthOffset - ((float)heightRow * heightRowDepthMod));
                        heightRow++;
                    }

                    foreach (int tileID in myMap.Rows[y + firstY].Columns[x + firstX].TopperTiles)
                    {
                        spriteBatch.Draw(
                            Tile.TileSetTexture,
                            Camera.WorldToScreen(
                                new Vector2((mapx * Tile.TileStepX) + rowOffset, mapy * Tile.TileStepY)),
                            Tile.GetSourceRectangle(tileID),
                            Color.White,
                            0.0f,
                            Vector2.Zero,
                            1.0f,
                            SpriteEffects.None,
                            depthOffset - ((float)heightRow * heightRowDepthMod));
                    }

                    if ((mapx == gandalfMapPoint.X) && (mapy == gandalfMapPoint.Y))
                    {
                        gandalf.DrawDepth = depthOffset - (float)(heightRow + 2) * heightRowDepthMod;
                    }
                    if (showCoordinates)
                    {
                        spriteBatch.DrawString(pericles6, (y + firstY).ToString() + ", " + (x + firstX).ToString(),
                            new Vector2((x * Tile.TileStepX) - offsetX + rowOffset + baseOffsetX + 24,
                                (y * Tile.TileStepY) - offsetY + baseOffsetY + 48), Color.White, 0f, Vector2.Zero,
                            1.0f, SpriteEffects.None, 0.0f);
                    }
                }
            }

            gandalf.Draw(spriteBatch, 0, -myMap.GetOverallHeight(gandalf.Position));

            //Spell drawing
            if (spell.IsActive)
            {
                spell.Draw(spriteBatch);
            }

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

            //Enemy Drawing.
            enemy.Draw(spriteBatch);

            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
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



        public Vector2 GetNextMove(out Vector2 moveVector, out string animation)
        {
            moveVector = Vector2.Zero;
            Vector2 moveDir = Vector2.Zero;
            animation = String.Empty;

            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.W) && ks.IsKeyDown(Keys.A))
            {
                moveDir = new Vector2(-2, -1);
                animation = "WalkNorthWest";
                moveVector += new Vector2(-2, -1);
            }

            else if (ks.IsKeyDown(Keys.S) && ks.IsKeyDown(Keys.D))
            {
                moveDir = new Vector2(2, 1);
                animation = "WalkSouthEast";
                moveVector += new Vector2(2, 1);
            }

            else if (ks.IsKeyDown(Keys.W) && ks.IsKeyDown(Keys.D))
            {
                moveDir = new Vector2(2, -1);
                animation = "WalkNorthEast";
                moveVector += new Vector2(2, -1);
            }

            else if (ks.IsKeyDown(Keys.A) && ks.IsKeyDown(Keys.S))
            {
                moveDir = new Vector2(-2, 1);
                animation = "WalkSouthWest";
                moveVector += new Vector2(-2, 1);
            }

            else if (ks.IsKeyDown(Keys.W))
            {
                moveDir = new Vector2(0, -1);
                animation = "WalkNorth";
                moveVector += new Vector2(0, -1);
            }

            else if (ks.IsKeyDown(Keys.A))
            {
                moveDir = new Vector2(-2, 0);
                animation = "WalkWest";
                moveVector += new Vector2(-2, 0);
            }

            else if (ks.IsKeyDown(Keys.D))
            {
                moveDir = new Vector2(2, 0);
                animation = "WalkEast";
                moveVector += new Vector2(2, 0);
            }

            else if (ks.IsKeyDown(Keys.S))
            {
                moveDir = new Vector2(0, 1);
                animation = "WalkSouth";
                moveVector += new Vector2(0, 1);
            }



            return moveDir;
        }

        public Vector2 CheckIfPosibleMove(Vector2 moveDir)
        {
            if (myMap.GetCellAtWorldPoint(gandalf.Position + moveDir).Walkable == false)
            {
                moveDir = Vector2.Zero;
            }

            if (Math.Abs(myMap.GetOverallHeight(gandalf.Position) - myMap.GetOverallHeight(gandalf.Position + moveDir)) > 10)
            {
                moveDir = Vector2.Zero;
            }

            return moveDir;
        }

        public void MakeNextMove(SpriteAnimation playerAnimation, string animation, Vector2 moveDir)
        {
            if (moveDir.Length() != 0)
            {
                playerAnimation.MoveBy((int)moveDir.X, (int)moveDir.Y);
                if (playerAnimation.CurrentAnimation != animation)
                    playerAnimation.CurrentAnimation = animation;
            }
            else
            {
                playerAnimation.CurrentAnimation = "Idle" + playerAnimation.CurrentAnimation.Substring(4);
            }



            // Test!!! Animated Spell Casting
            MouseState ms = Mouse.GetState();
            int mouseX = ms.X;
            int mouseY = ms.Y;
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Space))
            {
                playerAnimation.CurrentAnimation = "CastSpell" + playerAnimation.CurrentAnimation.Substring(4);

                spell.Position = playerAnimation.Position + playerAnimation.DrawOffset;
                spell.Target = new Vector2(ms.X, ms.Y);
                spell.IsActive = true;
            }



            float vladX = MathHelper.Clamp(
                playerAnimation.Position.X, 0 + playerAnimation.DrawOffset.X, Camera.WorldWidth);
            float vladY = MathHelper.Clamp(
                playerAnimation.Position.Y, 0 + playerAnimation.DrawOffset.Y, Camera.WorldHeight);
            playerAnimation.Position = new Vector2(vladX, vladY);

            Vector2 testPosition = Camera.WorldToScreen(playerAnimation.Position);

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
        }
    }
}
