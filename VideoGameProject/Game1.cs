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
        Texture2D Skeleton;
        Texture2D SkeletonDeath;
        Texture2D Goblin;
        Texture2D GoblinDeath;
        Texture2D Orc;
        Texture2D OrcDeath;

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

        Texture2D ARENAMASTER_Stagnant_FacingSouth;
        Texture2D ARENAMASTER_Stagnant_FacingWest;
        Texture2D ARENAMASTER_Stagnant_FacingEast;
        Texture2D ARENAMASTER_Stagnant_FacingNorth;
        /*
        Rectangle ArenamasterRect = new Rectangle(400, 100, 115, 145);
        Rectangle ArenamasterRectHitbox = new Rectangle(410, 140, 90, 90);
        Rectangle ArenamasterInteractRectWest = new Rectangle(300, 100, 150, 150);
        Rectangle ArenamasterInteractRectEast = new Rectangle(450, 100, 150, 150);
        Rectangle ArenamasterInteractRectSouth = new Rectangle(380, 150, 150, 150);
        */
        private SpriteFont font;
        string gamestate = "menu"; // string gamestate väljer vilket stadie spelet ska vara alltså i stort drag vad som ska ritas, det kan vara ett stadie för huvudmenyn eller ett stadie för när spelet är igång som vanligt.
        int cursorstateY = 0; // Y värde för pekaren.
        int cursorstateX = 0; // X värde för perkaren. Räknas inte i pixlar utan varierar bara mellan olika förbestämda lägen, till exempel så är läge cursorstate X = 0, cursorstate Y = 0 ursprungsläge, och X = 0, Y = 1 är samma X värde, men ett Y värde längre nedåt. 
        int cursortime;
        int menutime;
        int PCmovementspeed = 4;
        int Level = 0;
        bool cursordelay;
        bool KnowArenaRules = false;
        bool fullscreen = false;
        bool dialogue = false;
        bool selected = false;
        int SelectedEnemy = 0;
        int SelectedAttack = 0;
        
        public List<Rectangle> PCHitbox = new List<Rectangle>();
        Rectangle swordcursor = new Rectangle(515, 250, 50, 50);
        Rectangle backgroundRect = new Rectangle(0, 0, 1366, 768);
        Rectangle backgroundRectSub = new Rectangle(162, 150, 998, 455);
        Rectangle backgroundRectLeftWall = new Rectangle(160, 150, 10, 455);
        Rectangle backgroundRectRightWall = new Rectangle(1150, 150, 10, 455);
        Rectangle backgroundRectCeiling = new Rectangle(160, 150, 1000, 10);
        Rectangle backgroundRectFloor = new Rectangle(160, 600, 1000, 10);
        Rectangle dialogueCeiling = new Rectangle(160, 450, 1000, 10);
        Rectangle dialogueRightWall = new Rectangle(1150, 450, 10, 350);
        Rectangle dialogueLeftWall = new Rectangle(160, 450, 10, 350);
        Rectangle dialogueFloor = new Rectangle(160, 759, 1000, 10);
        Rectangle BattleMenuCeiling = new Rectangle(160, 520, 1000, 10);
        Rectangle BattleMenuRightWall = new Rectangle(1150, 520, 10, 350);
        Rectangle BattleMenuLeftWall = new Rectangle(160, 520, 10, 350);
        Rectangle BattleMenuFloor = new Rectangle(160, 759, 1000, 10);
        Rectangle ArenaRect = new Rectangle(300, 100, 300, 150);
        Rectangle ShopRect = new Rectangle(800, 100, 300, 150);


        Rectangle PC = new Rectangle(400, 250, 100, 140);
        Rectangle SkeletonRect = new Rectangle(-100, 35, 1500, 500);
        Rectangle GoblinRect = new Rectangle(400, 100, 500, 350);
        Rectangle OrcRect = new Rectangle(400, 100, 500, 350);
        Vector2 PCpos = new Vector2(100, 300);
        bool Attacks = false;
        bool Magic = false;
        bool PlayerTurn = true;
        bool AttackAnimation = false;
        bool EndingAnimation = false;

        string PCfacing = "South";
        int PCmovementstate = 0;
        int PCHP = 100;
        int PCMANA = 50;
        int PCBaseDamage;
        int Experience;
        int ExperienceRequired = 100;
        int EnemyMaxHealth;
        bool EnemyMaxHealthSet = false;
        int getEnemyHP;
        

        List<Enemy> Enemies = new List<Enemy>();
        Enemy Skeleton1 = new Enemy();
        Enemy Goblin1 = new Enemy();
        Enemy Orc1 = new Enemy();



        List<Attacks> attacks = new List<Attacks>();
        Attacks Punch = new Attacks();
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = true;            
            graphics.PreferredBackBufferWidth = 1366;
            graphics.PreferredBackBufferHeight = 768;
            PCHitbox.Add(new Rectangle(0, 0, 25, 25));
            Enemies.Add(Skeleton1);
            Enemies.Add(Goblin1);
            Enemies.Add(Orc1);


            attacks.Add(Punch);
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
            Skeleton = Content.Load<Texture2D>("Skeleton");
            SkeletonDeath = Content.Load<Texture2D>("SkeletonDeath");
            Orc = Content.Load<Texture2D>("Orc");
            OrcDeath = Content.Load<Texture2D>("OrcDeath");
            Goblin = Content.Load<Texture2D>("Goblin");
            GoblinDeath = Content.Load<Texture2D>("goblindeath");
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


            ARENAMASTER_Stagnant_FacingEast = Content.Load<Texture2D>("ARENAMASTER_Stagnant_FacingEast");
            ARENAMASTER_Stagnant_FacingNorth = Content.Load<Texture2D>("ARENAMASTER_Stagnant_FacingNorth");
            ARENAMASTER_Stagnant_FacingSouth = Content.Load<Texture2D>("ARENAMASTER_Stagnant_FacingSouth");
            ARENAMASTER_Stagnant_FacingWest = Content.Load<Texture2D>("ARENAMASTER_Stagnant_FacingWest");



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
            if (menutime > 0)
                menutime--;

            
            

            getEnemyHP = Enemies[SelectedEnemy].GetEnemyHP();
            Punch.SetAttackDamage(2);


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




                if (kstate.IsKeyDown(Keys.Down) && cursorstateY < 2 && cursortime == 0)
                {
                    cursorstateY++;
                    cursordelay = true;
                }


                if (kstate.IsKeyDown(Keys.Up) && cursorstateY > 0 && cursortime == 0)
                {
                    cursorstateY--;
                    cursordelay = true;
                }

                if (cursorstateY == 0)
                {
                    swordcursor.Y = 265;
                }
                if (cursorstateY == 1)
                {
                    swordcursor.Y = 365;
                }
                if (cursorstateY >= 2)
                {
                    swordcursor.Y = 465;
                }
                if (kstate.IsKeyDown(Keys.Enter) || kstate.IsKeyDown(Keys.Z))
                {
                    if (swordcursor.Y == 265)
                    {
                        gamestate = "overworld";
                        cursorstateY = 0;
                        cursorstateX = 0;
                    }
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
                PC.X = (int)PCpos.X;
                PC.Y = (int)PCpos.Y;
                Attacks = false;
                Magic = false;
                PlayerTurn = true;
                AttackAnimation = false;
                EndingAnimation = false;

                if (Experience >= ExperienceRequired)
                {
                    Level++;
                    Experience = 0;
                    ExperienceRequired += 50;
                }

                if (Level == 0)
                {
                    PCBaseDamage = 4;
                    PCHP = 20;
                }
                if (Level == 1)
                {
                    PCBaseDamage = 10;
                    PCHP = 40;
                }


                // Värden för enemies. Bestäms i "gamestate == "overworld"" eftersom dem inte ska konstant ändras i "gamestate = "Battle"".
                Enemies[0].SetEnemyAttack(2);
                Enemies[0].SetEnemyHP(20);
                Enemies[0].SetEnemyName("Skeleton");
                Enemies[1].SetEnemyAttack(4);
                Enemies[1].SetEnemyHP(40);
                Enemies[1].SetEnemyName("Goblin");
                Enemies[2].SetEnemyAttack(8);
                Enemies[2].SetEnemyHP(40);
                Enemies[2].SetEnemyName("Orc");



                // Värden för Attacks.
                attacks[0].SetAttackName("Punch");
                attacks[0].SetAttackDamage(2);
                attacks[0].SetAttackChance(100);
                attacks[0].SetIsUnlocked(true);                



                if (PC.Intersects(ArenaRect))
                {
                    if (kstate.IsKeyDown(Keys.Z) || kstate.IsKeyDown(Keys.Enter))
                    {
                        dialogue = true;
                        cursordelay = true;
                    }
                }
                if (dialogue == true)
                {
                    

                    if (cursordelay == true)
                    {
                        cursortime++;
                        if (cursortime > 10)
                        {
                            cursortime = 0;
                            cursordelay = false;
                        }
                    }
                    if (kstate.IsKeyDown(Keys.Right) && cursorstateX < 1 && cursortime == 0)
                    {
                        cursorstateX++;
                        cursordelay = true;
                    }
                    if (kstate.IsKeyDown(Keys.Left) && cursorstateX > 0 && cursortime == 0)
                    {
                        cursorstateX--;
                        cursordelay = true;
                    }
                    if (kstate.IsKeyDown(Keys.Down) && cursorstateY < 1 && cursortime == 0)
                    {
                        cursorstateY++;
                        cursordelay = true;
                    }
                    if (kstate.IsKeyDown(Keys.Up) && cursorstateY > 0 && cursortime == 0)
                    {
                        cursorstateY--;
                        cursordelay = true;
                    }
                    if (cursorstateX == 1 && cursorstateY == 0)
                    {
                        swordcursor.Y = 565;
                        swordcursor.X = 650;
                    }
                    if (cursorstateX == 1 && cursorstateY == 1)
                    {
                        swordcursor.Y = 665;
                        swordcursor.X = 650;
                    }
                    if (cursorstateX == 0 && cursorstateY == 0)
                    {
                        swordcursor.Y = 565;
                        swordcursor.X = 250;
                    }
                    if (cursorstateX == 0 && cursorstateY == 1)
                    {
                        swordcursor.Y = 665;
                        swordcursor.X = 250;
                    }
                    if (kstate.IsKeyDown(Keys.Enter) || kstate.IsKeyDown(Keys.Z))
                    {
                        if (cursorstateX == 1 && cursorstateY == 1)
                        {

                            dialogue = false;
                        }
                        if (cursorstateX == 0 && cursorstateY == 1)
                        {
                            gamestate = "Battle";
                            
                        }
                        if (cursorstateX == 1 && cursorstateY == 0)
                        {
                            SelectedEnemy = 1;
                        }
                    }

                }          

                if (kstate.IsKeyDown(Keys.Down) && kstate.IsKeyUp(Keys.Up) && dialogue == false)
                {
                    PCfacing = "South";
                    PCpos.Y = PCpos.Y + PCmovementspeed;
                    PCmovementstate++;
                    if (PCmovementstate > 40)
                        PCmovementstate = 1;
                }
                if (kstate.IsKeyUp(Keys.Down) && kstate.IsKeyUp(Keys.Up) && kstate.IsKeyUp(Keys.Left) && kstate.IsKeyUp(Keys.Right))
                {
                    PCmovementstate = 0;
                }

                if (kstate.IsKeyDown(Keys.Up) && kstate.IsKeyUp(Keys.Down) && dialogue == false)
                {
                    PCfacing = "North";
                    PCpos.Y = PCpos.Y - PCmovementspeed;
                    PCmovementstate++;
                    if (PCmovementstate > 40)
                        PCmovementstate = 1;
                }
                if (kstate.IsKeyDown(Keys.Right) && kstate.IsKeyUp(Keys.Left) && dialogue == false)
                {
                    PCfacing = "East";
                    PCpos.X = PCpos.X + PCmovementspeed;
                    PCmovementstate++;
                    if (PCmovementstate > 40)
                        PCmovementstate = 1;
                }
                if (kstate.IsKeyDown(Keys.Left) && kstate.IsKeyUp(Keys.Right) && dialogue == false)
                {
                    PCfacing = "West";
                    PCpos.X = PCpos.X - PCmovementspeed;
                    PCmovementstate++;
                    if (PCmovementstate > 40)
                        PCmovementstate = 1;
                }
            }
            if (gamestate == "Battle")
            {
                if (Enemies[SelectedEnemy].GetEnemyHP() <= 0)
                {
                    EndingAnimation = true;
                    
                    PC.X = 400;
                    PC.Y = 250;
                }

                if (EndingAnimation == true && kstate.IsKeyDown(Keys.Z) && menutime == 0)
                    gamestate = "overworld";
                            

                if (EnemyMaxHealthSet == false)
                {
                    EnemyMaxHealth = 20;
                    EnemyMaxHealthSet = true;
                }

                if (cursordelay == true)
                {
                    cursortime++;
                    if (cursortime > 10)
                    {
                        cursortime = 0;
                        cursordelay = false;
                    }
                }
                if (kstate.IsKeyDown(Keys.Right) && cursorstateX < 1 && cursortime == 0 && PlayerTurn == true && AttackAnimation == false && EndingAnimation == false)
                {
                    cursorstateX++;
                    cursordelay = true;
                }
                if (kstate.IsKeyDown(Keys.Left) && cursorstateX > 0 && cursortime == 0 && PlayerTurn == true && AttackAnimation == false && EndingAnimation == false)
                {
                    cursorstateX--;
                    cursordelay = true;
                }
                if (kstate.IsKeyDown(Keys.Down) && cursorstateY < 1 && cursortime == 0 && PlayerTurn == true && AttackAnimation == false && EndingAnimation == false)
                {
                    cursorstateY++;
                    cursordelay = true;
                }
                if (kstate.IsKeyDown(Keys.Up) && cursorstateY > 0 && cursortime == 0 && PlayerTurn == true && AttackAnimation == false && EndingAnimation == false)
                {
                    cursorstateY--;
                    cursordelay = true;
                }
                if (cursorstateX == 1 && cursorstateY == 0)
                {
                    swordcursor.Y = 565;
                    swordcursor.X = 650;
                }
                if (cursorstateX == 1 && cursorstateY == 1)
                {
                    swordcursor.Y = 665;
                    swordcursor.X = 650;
                }
                if (cursorstateX == 0 && cursorstateY == 0)
                {
                    swordcursor.Y = 565;
                    swordcursor.X = 250;
                }
                if (cursorstateX == 0 && cursorstateY == 1)
                {
                    swordcursor.Y = 665;
                    swordcursor.X = 250;
                }

                if (cursorstateX == 0 && cursorstateY == 0 && kstate.IsKeyDown(Keys.Z) && Attacks == false && menutime == 0 && PlayerTurn == true && AttackAnimation == false && EndingAnimation == false)
                {
                    
                    Attacks = true;
                    menutime = 20;
                }

                if (cursorstateX == 0 && cursorstateY == 0 && kstate.IsKeyDown(Keys.Z) && Attacks == true && menutime == 0 && PlayerTurn == true && AttackAnimation == false && EndingAnimation == false)
                {
                    SelectedAttack = 0;
                    Enemies[SelectedEnemy].SetEnemyHP(getEnemyHP - PCBaseDamage * attacks[SelectedAttack].GetAttackDamage());
                    Attacks = false;
                    menutime = 20;
                    AttackAnimation = true;
                    if (getEnemyHP < 0)
                        getEnemyHP = 0;

                }
                if (AttackAnimation == true && PlayerTurn == true && menutime == 0 && kstate.IsKeyDown(Keys.Z) && EndingAnimation == false)
                {
                    PCHP = PCHP - (Skeleton1.GetEnemyAttack() * Punch.GetAttackDamage());
                    menutime = 20;
                    PlayerTurn = false;
                    AttackAnimation = false;
                }
                if (AttackAnimation == false && PlayerTurn == false && menutime == 0 && kstate.IsKeyDown(Keys.Z) && EndingAnimation == false)
                {
                    menutime = 20;
                    PlayerTurn = true;
                }

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

            if (gamestate == "Battle")
            {
                
                spriteBatch.DrawString(font, "" + "Health: " + getEnemyHP, new Vector2(20, -10), Color.White); ;
                spriteBatch.DrawString(font, "Health: " + PCHP, new Vector2(20, 450), Color.White);
                spriteBatch.Draw(pixel, BattleMenuCeiling, Color.White);
                spriteBatch.Draw(pixel, BattleMenuRightWall, Color.White);
                spriteBatch.Draw(pixel, BattleMenuLeftWall, Color.White);
                spriteBatch.Draw(pixel, BattleMenuFloor, Color.White);             
                

            }
            if (gamestate == "Battle" && EndingAnimation == false && SelectedEnemy == 0)
            {
                spriteBatch.Draw(Skeleton, SkeletonRect, Color.White);
            }
            if (gamestate == "Battle" && EndingAnimation == false && SelectedEnemy == 1)
            {
                spriteBatch.Draw(Goblin, GoblinRect, Color.White);
            }
            if (gamestate == "Battle" && EndingAnimation == false && SelectedEnemy == 2)
            {
                spriteBatch.Draw(Orc, OrcRect, Color.White);
            }


            if (gamestate == "Battle" && PlayerTurn == true && AttackAnimation == false)
            {
                spriteBatch.Draw(sword, swordcursor, Color.White);
            }
            if (gamestate == "Battle" && Attacks == false && Magic == false && PlayerTurn == true && AttackAnimation == false && EndingAnimation == false)
            {
                spriteBatch.DrawString(font, "Attack", new Vector2(300, 550), Color.White);
                spriteBatch.DrawString(font, "Magic", new Vector2(700, 550), Color.White);
                spriteBatch.DrawString(font, "Check", new Vector2(300, 650), Color.White);
                spriteBatch.DrawString(font, "Flee", new Vector2(700, 650), Color.White);
            }
            if (gamestate == "Battle" && Attacks == true && Magic == false && PlayerTurn == true && AttackAnimation == false && EndingAnimation == false)
            {
                 if (attacks[0].GetIsUnlocked() == true)
                    spriteBatch.DrawString(font, "" + attacks[0].GetAttackName(), new Vector2(300, 550), Color.White);
                /*
                spriteBatch.DrawString(font, "Magic", new Vector2(700, 550), Color.White);
                spriteBatch.DrawString(font, "Check", new Vector2(300, 650), Color.White);
                spriteBatch.DrawString(font, "Flee", new Vector2(700, 650), Color.White);
                */

            }
            if (gamestate == "Battle" && Attacks == false && Magic == true && PlayerTurn == true && AttackAnimation == false && EndingAnimation == false)
            {
                spriteBatch.DrawString(font, "Fireball", new Vector2(300, 550), Color.White);
                /*
                 spriteBatch.DrawString(font, "Magic", new Vector2(700, 550), Color.White);
                spriteBatch.DrawString(font, "Check", new Vector2(300, 650), Color.White);
                spriteBatch.DrawString(font, "Flee", new Vector2(700, 650), Color.White);
                */
                
            }
            if (gamestate == "Battle" && PlayerTurn == false && AttackAnimation == false && EndingAnimation == false)
            {
                spriteBatch.DrawString(font, "" + Enemies[SelectedEnemy].GetEnemyName() + " attacks with: ", new Vector2(300, 550), Color.White);
                spriteBatch.DrawString(font, "" + attacks[SelectedAttack].GetAttackName() +  "for: " + Punch.GetAttackDamage() * Enemies[SelectedEnemy].GetEnemyAttack() + " damage", new Vector2(300, 650), Color.White);
            }
            if (gamestate == "Battle" && PlayerTurn == true && AttackAnimation == true && EndingAnimation == false)
            {
                spriteBatch.DrawString(font, "You attack with: ", new Vector2(300, 550), Color.White);
                spriteBatch.DrawString(font, "" + attacks[SelectedAttack].GetAttackName() + " for: " + Punch.GetAttackDamage() * PCBaseDamage + " damage", new Vector2(300, 650), Color.White);
            }
            if (gamestate == "Battle" && EndingAnimation == true)
            {
                spriteBatch.DrawString(font, "You won!", new Vector2(300, 550), Color.White);
            }
            if (gamestate == "Battle" && EndingAnimation == true && SelectedEnemy == 0)
            {
                spriteBatch.Draw(SkeletonDeath, SkeletonRect, Color.White);
            }
            if (gamestate == "Battle" && EndingAnimation == true && SelectedEnemy == 1)
            {
                spriteBatch.Draw(GoblinDeath, GoblinRect, Color.White);
            }
            if (gamestate == "Battle" && EndingAnimation == true && SelectedEnemy == 2)
            {
                spriteBatch.Draw(OrcDeath, OrcRect, Color.White);
            }


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
                spriteBatch.Draw(pixel, PC, Color.Transparent);
                spriteBatch.DrawString(font, "Level: " + Level, new Vector2(10, 10), Color.White);
                //spriteBatch.Draw(pixel, ArenamasterInteractRectEast, Color.Transparent);
                //spriteBatch.Draw(pixel, ArenamasterInteractRectWest, Color.Transparent);    
                //spriteBatch.Draw(pixel, ArenamasterInteractRectSouth, Color.Transparent);
                //spriteBatch.Draw(pixel, ArenamasterRectHitbox, Color.Transparent);
                spriteBatch.Draw(pixel, ArenaRect, Color.OrangeRed);
                spriteBatch.DrawString(font, "Arena", new Vector2(350, 130), Color.White);
                spriteBatch.Draw(pixel, ShopRect, Color.BlueViolet);
                spriteBatch.DrawString(font, "Shop", new Vector2(870, 130), Color.White);
                //if (PC.Y > ArenamasterRect.Y)
                //spriteBatch.Draw(ARENAMASTER_Stagnant_FacingSouth, ArenamasterRect, Color.White);
                //if (PC.X >= ArenamasterRect.X && PC.Y <= ArenamasterRect.Y)
                    //spriteBatch.Draw(ARENAMASTER_Stagnant_FacingEast, ArenamasterRect, Color.White);
                //if (PC.X <= ArenamasterRect.X && PC.Y <= ArenamasterRect.Y)
                    //spriteBatch.Draw(ARENAMASTER_Stagnant_FacingWest, ArenamasterRect, Color.White);



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



                if (dialogue == true)
                {
                    spriteBatch.Draw(pixel, dialogueCeiling, Color.White);
                    spriteBatch.Draw(pixel, dialogueRightWall, Color.White);
                    spriteBatch.Draw(pixel, dialogueLeftWall, Color.White);
                    spriteBatch.Draw(pixel, dialogueFloor, Color.White);
                    spriteBatch.DrawString(font, "Arenamaster", new Vector2(200, 455), Color.White);
                    spriteBatch.DrawString(font, "Talk", new Vector2(300, 550), Color.White);
                    spriteBatch.DrawString(font, "Check", new Vector2(700, 550), Color.White);                    
                    spriteBatch.DrawString(font, "Interact", new Vector2(300, 650), Color.White);
                    spriteBatch.DrawString(font, "Back", new Vector2(700, 650), Color.White);
                    spriteBatch.Draw(sword, swordcursor, Color.White);
                }
            }



            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
