using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameProject
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D pixel;
        Texture2D background;
        Texture2D sword;

        Texture2D PC_stagnant_FacingSouth;
        Texture2D PC_Moving1_FacingSouth;
        Texture2D PC_Moving2_FacingSouth;
        Texture2D PC_StartMoving1_FacingSouth;
        Texture2D PC_StartMoving2_FacingSouth;
        Texture2D PC_StopMoving1_FacingSouth;
        Texture2D PC_StopMoving2_FacingSouth;

        Texture2D PC_stagnant_FacingNorth;
        Texture2D PC_Moving1_FacingNorth;
        Texture2D PC_Moving2_FacingNorth;
        Texture2D PC_StartMoving1_FacingNorth;
        Texture2D PC_StartMoving2_FacingNorth;
        Texture2D PC_StopMoving1_FacingNorth;
        Texture2D PC_StopMoving2_FacingNorth;

        Texture2D PC_stagnant_FacingEast;
        Texture2D PC_Moving1_FacingEast;
        Texture2D PC_Moving2_FacingEast;
        Texture2D PC_StartMoving1_FacingEast;
        Texture2D PC_StartMoving2_FacingEast;
        Texture2D PC_StopMoving1_FacingEast;
        Texture2D PC_StopMoving2_FacingEast;

        Texture2D PC_stagnant_FacingWest;
        Texture2D PC_Moving1_FacingWest;
        Texture2D PC_Moving2_FacingWest;
        Texture2D PC_StartMoving1_FacingWest;
        Texture2D PC_StartMoving2_FacingWest;
        Texture2D PC_StopMoving1_FacingWest;
        Texture2D PC_StopMoving2_FacingWest;

        private SpriteFont font;
        string gamestate = "menu";
        int cursorstate = 0;
        int cursortime;
        int menutime;
        bool cursordelay;
        bool fullscreen = false;
        bool selected = false;
        public List<Rectangle> PCHitbox = new List<Rectangle>();
        Rectangle swordcursor = new Rectangle(515, 250, 50, 50);
        Rectangle backgroundRect = new Rectangle(0, 0, 1366, 768);
        Rectangle backgroundRectSub = new Rectangle(162, 150, 998, 455);
        Rectangle backgroundRectLeftWall = new Rectangle(160, 150, 10, 455);
        Rectangle backgroundRectRightWall = new Rectangle(1150, 150, 10, 455);
        Rectangle backgroundRectCeiling = new Rectangle(160, 150, 1000, 10);
        Rectangle backgroundRectFloor = new Rectangle(160, 600, 1000, 10);


        Rectangle PC = new Rectangle(400, 250, 25, 25);
        Vector2 PCpos = new Vector2(100, 300);

        string PCfacing = "South";
        int PCmovementstate = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = fullscreen;
            graphics.PreferredBackBufferWidth = 1366;
            graphics.PreferredBackBufferHeight = 768;
            PCHitbox.Add(new Rectangle(0, 0, 25, 25));

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
            pixel = Content.Load<Texture2D>("pixel");
            font = Content.Load<SpriteFont>("spritefont");
            background = Content.Load<Texture2D>("background");
            sword = Content.Load<Texture2D>("sword");
            PC_stagnant_FacingSouth = Content.Load<Texture2D>("PC_stagnant_FacingSouth");
            PC_Moving1_FacingSouth = Content.Load<Texture2D>("PC_Moving1_FacingSouth");
            PC_Moving2_FacingSouth = Content.Load<Texture2D>("PC_Moving2_FacingSouth");
            PC_StartMoving1_FacingSouth = Content.Load<Texture2D>("PC_StartMoving1_FacingSouth");
            PC_StartMoving2_FacingSouth = Content.Load<Texture2D>("PC_StartMoving2_FacingSouth");
            PC_StopMoving1_FacingSouth = Content.Load<Texture2D>("PC_StopMoving1_FacingSouth");
            PC_StopMoving2_FacingSouth = Content.Load<Texture2D>("PC_StopMoving2_FacingSouth");


            PC_stagnant_FacingNorth = Content.Load<Texture2D>("PC_stagnant_FacingNorth");
            PC_Moving1_FacingNorth = Content.Load<Texture2D>("PC_Moving1_FacingNorth");
            PC_Moving2_FacingNorth = Content.Load<Texture2D>("PC_Moving2_FacingNorth");
            PC_StartMoving1_FacingNorth = Content.Load<Texture2D>("PC_StartMoving1_FacingNorth");
            PC_StartMoving2_FacingNorth = Content.Load<Texture2D>("PC_StartMoving2_FacingNorth");
            PC_StopMoving1_FacingNorth = Content.Load<Texture2D>("PC_StopMoving1_FacingNorth");
            PC_StopMoving2_FacingNorth = Content.Load<Texture2D>("PC_StopMoving2_FacingNorth");

            PC_stagnant_FacingEast = Content.Load<Texture2D>("PC_stagnant_FacingEast");
            PC_Moving1_FacingEast = Content.Load<Texture2D>("PC_Moving1_FacingEast");
            PC_Moving2_FacingEast = Content.Load<Texture2D>("PC_Moving2_FacingEast");
            PC_StartMoving1_FacingEast = Content.Load<Texture2D>("PC_StartMoving1_FacingEast");
            PC_StartMoving2_FacingEast = Content.Load<Texture2D>("PC_StartMoving2_FacingEast");
            PC_StopMoving1_FacingEast = Content.Load<Texture2D>("PC_StopMoving1_FacingEast");
            PC_StopMoving2_FacingEast = Content.Load<Texture2D>("PC_StopMoving2_FacingEast");

            PC_stagnant_FacingWest = Content.Load<Texture2D>("PC_stagnant_FacingWest");
            PC_Moving1_FacingWest = Content.Load<Texture2D>("PC_Moving1_FacingWest");
            PC_Moving2_FacingWest = Content.Load<Texture2D>("PC_Moving2_FacingWest");
            PC_StartMoving1_FacingWest = Content.Load<Texture2D>("PC_StartMoving1_FacingWest");
            PC_StartMoving2_FacingWest = Content.Load<Texture2D>("PC_StartMoving2_FacingWest");
            PC_StopMoving1_FacingWest = Content.Load<Texture2D>("PC_StopMoving1_FacingWest");
            PC_StopMoving2_FacingWest = Content.Load<Texture2D>("PC_StopMoving2_FacingWest");



            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            KeyboardState kstate = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (kstate.IsKeyDown(Keys.F9) && fullscreen == false)
                fullscreen = true;
            if (kstate.IsKeyDown(Keys.F9) && fullscreen == true)
                fullscreen = false;
            if (menutime > 0)
                menutime--;

            if (gamestate == "menu")
            {
                if (cursordelay == true) // kollar ifall pekaren ska vänta, alltså ifall den nyligen rört på sig, och  räknar sedan upp till värdet som cursortime ska vara mindre än, innan den låter pekaren röra på sig igen. 
                {
                    cursortime++;
                    if (cursortime > 10)
                    {
                        cursortime = 0;
                        cursordelay = false;
                    }
                }




                if (kstate.IsKeyDown(Keys.Down) && cursorstate < 2 && cursortime == 0)
                {
                    cursorstate++;
                    cursordelay = true;
                }


                if (kstate.IsKeyDown(Keys.Up) && cursorstate > 0 && cursortime == 0)
                {
                    cursorstate--;
                    cursordelay = true;
                }

                if (cursorstate == 0)
                {
                    swordcursor.Y = 265;
                }
                if (cursorstate == 1)
                {
                    swordcursor.Y = 365;
                }
                if (cursorstate >= 2)
                {
                    swordcursor.Y = 465;
                }
                if (kstate.IsKeyDown(Keys.Enter) || kstate.IsKeyDown(Keys.Z))
                {
                    if (swordcursor.Y == 265)
                        gamestate = "overworld";
                    if (swordcursor.Y == 365 && menutime == 0)
                    {
                        gamestate = "menuControls";
                        swordcursor.Y = 500;
                        menutime = 10;
                    }
                    if (swordcursor.Y == 465)
                        Exit();
                }
            }
            if (gamestate == "menuControls")
                if (kstate.IsKeyDown(Keys.Enter) && menutime == 0 || kstate.IsKeyDown(Keys.Z) && menutime == 0)
                {
                    gamestate = "menu";
                    menutime = 10;
                }




            if (gamestate == "overworld")
            {
                PC.X = (int)PCpos.X + 20;
                PC.Y = (int)PCpos.Y + 20;


                if (kstate.IsKeyDown(Keys.Down) && kstate.IsKeyUp(Keys.Up))
                {
                    PCfacing = "South";
                    PCpos.Y = PCpos.Y + 5;
                    PCmovementstate++;
                    if (PCmovementstate > 40)
                        PCmovementstate = 1;
                }
                if (kstate.IsKeyUp(Keys.Down) && kstate.IsKeyUp(Keys.Up) && kstate.IsKeyUp(Keys.Left) && kstate.IsKeyUp(Keys.Right))
                {
                    PCmovementstate = 0;
                }

                if (kstate.IsKeyDown(Keys.Up) && kstate.IsKeyUp(Keys.Down))
                {
                    PCfacing = "North";
                    PCpos.Y = PCpos.Y - 5;
                    PCmovementstate++;
                    if (PCmovementstate > 40)
                        PCmovementstate = 1;
                }
                if (kstate.IsKeyDown(Keys.Right) && kstate.IsKeyUp(Keys.Left))
                {
                    PCfacing = "East";
                    PCpos.X = PCpos.X + 5;
                    PCmovementstate++;
                    if (PCmovementstate > 40)
                        PCmovementstate = 1;
                }
                if (kstate.IsKeyDown(Keys.Left) && kstate.IsKeyUp(Keys.Right))
                {
                    PCfacing = "West";
                    PCpos.X = PCpos.X - 5;
                    PCmovementstate++;
                    if (PCmovementstate > 40)
                        PCmovementstate = 1;
                }

                /*
                if (kstate.IsKeyDown(Keys.Left) && kstate.IsKeyDown(Keys.Right))
                    PCmovementstate = 0;
                if (kstate.IsKeyDown(Keys.Up) && kstate.IsKeyDown(Keys.Down))
                    PCmovementstate = 0;
                if (kstate.IsKeyDown(Keys.Up) && kstate.IsKeyDown(Keys.Left))
                    PCmovementstate--;
                if (kstate.IsKeyDown(Keys.Up) && kstate.IsKeyDown(Keys.Right))
                    PCmovementstate--;
                if (kstate.IsKeyDown(Keys.Down) && kstate.IsKeyDown(Keys.Left))
                    PCmovementstate--;
                if (kstate.IsKeyDown(Keys.Down) && kstate.IsKeyDown(Keys.Left))
                    PCmovementstate--;
                */

            }


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            if (gamestate == "menu")
            {
                spriteBatch.Draw(background, backgroundRect, Color.White);
                spriteBatch.Draw(pixel, backgroundRectSub, Color.Black);
                spriteBatch.Draw(pixel, backgroundRectLeftWall, Color.Red);
                spriteBatch.Draw(pixel, backgroundRectRightWall, Color.Red);
                spriteBatch.Draw(pixel, backgroundRectCeiling, Color.Red);
                spriteBatch.Draw(pixel, backgroundRectFloor, Color.Red);
                spriteBatch.DrawString(font, " ", new Vector2(550, 160), Color.White);               
                spriteBatch.DrawString(font, "Start", new Vector2(599, 250), Color.White);
                spriteBatch.DrawString(font, "Controls", new Vector2(599, 350), Color.White);
                spriteBatch.DrawString(font, "Exit", new Vector2(599, 450), Color.White);                               
                spriteBatch.Draw(sword, swordcursor, Color.White);
            }
            if (gamestate == "menuControls")
            {
                spriteBatch.Draw(background, backgroundRect, Color.White);
                spriteBatch.Draw(pixel, backgroundRectSub, Color.Black);
                spriteBatch.Draw(pixel, backgroundRectLeftWall, Color.Red);
                spriteBatch.Draw(pixel, backgroundRectRightWall, Color.Red);
                spriteBatch.Draw(pixel, backgroundRectCeiling, Color.Red);
                spriteBatch.Draw(pixel, backgroundRectFloor, Color.Red);
                spriteBatch.DrawString(font, " ", new Vector2(550, 160), Color.White);
                spriteBatch.DrawString(font, "Movement - Arrow Keys", new Vector2(199, 155), Color.White);
                spriteBatch.DrawString(font, "Interact - Z or Enter", new Vector2(199, 250), Color.White);
                spriteBatch.DrawString(font, "Back", new Vector2(599, 485), Color.White);
                spriteBatch.Draw(sword, swordcursor, Color.White);
            }

            if (gamestate == "overworld") //gamestate = overworld innebär att spelet är igång, då ska alltså menyn försvinna och karaktärer m.m ska kunna bli synliga. 
            {
                spriteBatch.Draw(pixel, PC, Color.White);
                if (PCfacing == "South" && PCmovementstate == 0)
                    spriteBatch.Draw(PC_stagnant_FacingSouth, PCpos, Color.White);
                if (PCfacing == "South" && PCmovementstate > 0 && PCmovementstate < 5)
                    spriteBatch.Draw(PC_StartMoving1_FacingSouth, PCpos, Color.White);
                if (PCfacing == "South" && PCmovementstate >= 5 && PCmovementstate < 14)
                    spriteBatch.Draw(PC_Moving1_FacingSouth, PCpos, Color.White);
                if (PCfacing == "South" && PCmovementstate >= 14 && PCmovementstate < 20)
                    spriteBatch.Draw(PC_StopMoving1_FacingSouth, PCpos, Color.White);
                if (PCfacing == "South" && PCmovementstate >= 20 && PCmovementstate < 23)
                    spriteBatch.Draw(PC_StartMoving2_FacingSouth, PCpos, Color.White);
                if (PCfacing == "South" && PCmovementstate >= 23 && PCmovementstate < 34)
                    spriteBatch.Draw(PC_Moving2_FacingSouth, PCpos, Color.White);
                if (PCfacing == "South" && PCmovementstate >= 34 && PCmovementstate <= 40)
                    spriteBatch.Draw(PC_StopMoving2_FacingSouth, PCpos, Color.White);

                if (PCfacing == "North" && PCmovementstate == 0)
                    spriteBatch.Draw(PC_stagnant_FacingNorth, PCpos, Color.White);
                if (PCfacing == "North" && PCmovementstate > 0 && PCmovementstate < 5)
                    spriteBatch.Draw(PC_StartMoving1_FacingNorth, PCpos, Color.White);
                if (PCfacing == "North" && PCmovementstate >= 5 && PCmovementstate < 14)
                    spriteBatch.Draw(PC_Moving1_FacingNorth, PCpos, Color.White);
                if (PCfacing == "North" && PCmovementstate >= 14 && PCmovementstate < 20)
                    spriteBatch.Draw(PC_StopMoving1_FacingNorth, PCpos, Color.White);
                if (PCfacing == "North" && PCmovementstate >= 20 && PCmovementstate < 23)
                    spriteBatch.Draw(PC_StartMoving2_FacingNorth, PCpos, Color.White);
                if (PCfacing == "North" && PCmovementstate >= 23 && PCmovementstate < 34)
                    spriteBatch.Draw(PC_Moving2_FacingNorth, PCpos, Color.White);
                if (PCfacing == "North" && PCmovementstate >= 34 && PCmovementstate <= 40)
                    spriteBatch.Draw(PC_StopMoving2_FacingNorth, PCpos, Color.White);

                if (PCfacing == "East" && PCmovementstate == 0)
                    spriteBatch.Draw(PC_stagnant_FacingEast, PCpos, Color.White);
                if (PCfacing == "East" && PCmovementstate > 0 && PCmovementstate < 5)
                    spriteBatch.Draw(PC_StartMoving1_FacingEast, PCpos, Color.White);
                if (PCfacing == "East" && PCmovementstate >= 5 && PCmovementstate < 14)
                    spriteBatch.Draw(PC_Moving1_FacingEast, PCpos, Color.White);
                if (PCfacing == "East" && PCmovementstate >= 14 && PCmovementstate < 20)
                    spriteBatch.Draw(PC_StopMoving1_FacingEast, PCpos, Color.White);
                if (PCfacing == "East" && PCmovementstate >= 20 && PCmovementstate < 23)
                    spriteBatch.Draw(PC_StartMoving2_FacingEast, PCpos, Color.White);
                if (PCfacing == "East" && PCmovementstate >= 23 && PCmovementstate < 34)
                    spriteBatch.Draw(PC_Moving2_FacingEast, PCpos, Color.White);
                if (PCfacing == "East" && PCmovementstate >= 34 && PCmovementstate <= 40)
                    spriteBatch.Draw(PC_StopMoving2_FacingEast, PCpos, Color.White);

                if (PCfacing == "West" && PCmovementstate == 0)
                    spriteBatch.Draw(PC_stagnant_FacingWest, PCpos, Color.White);
                if (PCfacing == "West" && PCmovementstate > 0 && PCmovementstate < 5)
                    spriteBatch.Draw(PC_StartMoving1_FacingWest, PCpos, Color.White);
                if (PCfacing == "West" && PCmovementstate >= 5 && PCmovementstate < 14)
                    spriteBatch.Draw(PC_Moving1_FacingWest, PCpos, Color.White);
                if (PCfacing == "West" && PCmovementstate >= 14 && PCmovementstate < 20)
                    spriteBatch.Draw(PC_StopMoving1_FacingWest, PCpos, Color.White);
                if (PCfacing == "West" && PCmovementstate >= 20 && PCmovementstate < 23)
                    spriteBatch.Draw(PC_StartMoving2_FacingWest, PCpos, Color.White);
                if (PCfacing == "West" && PCmovementstate >= 23 && PCmovementstate < 34)
                    spriteBatch.Draw(PC_Moving2_FacingWest, PCpos, Color.White);
                if (PCfacing == "West" && PCmovementstate >= 34 && PCmovementstate <= 40)
                    spriteBatch.Draw(PC_StopMoving2_FacingWest, PCpos, Color.White);
            }



            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
