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
        bool SelectedAttackBool = false;
        bool PlayerDealtDamage = false;
        bool EnemyDealtDamage = false;
        int SelectedEnemy = 0;
        int SelectedAttack = 0;
        int TurnPlayerDamage;
        int TurnEnemyDamage; 

        int defaultEnemyAttack0 = 2;
        int defaultEnemyAttack1 = 4;
        int defaultEnemyAttack2 = 8;

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
        int Experience = 0;
        int ExperienceReward;
        int Gold = 0;
        int GoldReward;
        int ExperienceRequired = 100;
        int EnemyMaxHealth;
        bool EnemyMaxHealthSet = false;
        int getEnemyHP;
        int SelectedEnemyAttack;
        Random r = new Random();

        

        List<Enemy> Enemies = new List<Enemy>();
        Enemy enemy0 = new Enemy();
        Enemy enemy1 = new Enemy();
        Enemy enemy2 = new Enemy();



        List<Attacks> attacks = new List<Attacks>();
        Attacks attack0 = new Attacks();
        Attacks attack1 = new Attacks();
        Attacks attack2 = new Attacks();
        Attacks attack3 = new Attacks();
        Attacks attack4 = new Attacks();
        Attacks attack5 = new Attacks();
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = false;            
            graphics.PreferredBackBufferWidth = 1366;
            graphics.PreferredBackBufferHeight = 768;
            PCHitbox.Add(new Rectangle(0, 0, 25, 25));
            Enemies.Add(enemy0);
            Enemies.Add(enemy1);
            Enemies.Add(enemy2);


            attacks.Add(attack0);
            attacks.Add(attack1);
            attacks.Add(attack2);
            attacks.Add(attack3);
            attacks.Add(attack4);
            attacks.Add(attack5);
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
                    Experience -= ExperienceRequired;
                    ExperienceRequired += 50 + 4 * Level;
                }

                PCBaseDamage = 4 + Level;
                PCHP = 20 + 5 * Level;



                // Värden för enemies. Bestäms i "gamestate == "overworld"" eftersom dem inte ska konstant ändras i "gamestate = "Battle"".
                Enemies[0].SetEnemyAttack(2);                
                Enemies[0].SetEnemyHP(20);
                Enemies[0].SetEnemyAttackRange(2); // Attack range 2 innebär att fienden kan välja mellan attacks[0] och attacks[1]
                Enemies[0].SetEnemyName("Skeleton");
                Enemies[1].SetEnemyAttack(3);                
                Enemies[1].SetEnemyHP(25);
                Enemies[1].SetEnemyAttackRange(3);
                Enemies[1].SetEnemyName("Goblin");
                Enemies[2].SetEnemyAttack(4);                
                Enemies[2].SetEnemyAttackRange(4);
                Enemies[2].SetEnemyHP(30);
                Enemies[2].SetEnemyName("Orc");

                



                // Värden för Attacks.
                attacks[0].SetAttackName("Punch");
                attacks[0].SetAttackDamage(2);
                attacks[0].SetAttackChance(80);
                attacks[0].SetIsUnlocked(true);
                attacks[1].SetAttackName("Kick");
                attacks[1].SetAttackDamage(4);
                attacks[1].SetAttackChance(50);
                attacks[1].SetIsUnlocked(true);
                attacks[2].SetAttackName("Arrow");
                attacks[2].SetAttackDamage(1);
                attacks[2].SetAttackChance(100);                
                attacks[2].SetIsUnlocked(true);
                attacks[3].SetAttackName("Fireball");
                attacks[3].SetAttackDamage(6);
                attacks[3].SetAttackChance(100);
                attacks[3].SetIsUnlocked(true);
                attacks[4].SetAttackName("Heal");
                attacks[4].SetAttackDamage(-3);
                attacks[4].SetAttackChance(100);
                attacks[4].SetIsUnlocked(true);
                attacks[4].SetAttackName("KILL");
                attacks[4].SetAttackDamage(10000);
                attacks[4].SetAttackChance(1);
                attacks[4].SetIsUnlocked(false);

                



                if (PC.Intersects(ArenaRect))
                {
                    if (kstate.IsKeyDown(Keys.Z) || kstate.IsKeyDown(Keys.Enter))
                    {
                        if (menutime == 0)
                        {
                            dialogue = true;
                            cursordelay = true;
                            cursorstateY = 1;
                        }
                    }
                }
                if (PC.Intersects(ShopRect))
                {
                    if (kstate.IsKeyDown(Keys.Z) || kstate.IsKeyDown(Keys.Enter))
                    {
                        if (menutime == 0)
                        {
                            dialogue = true;
                            cursordelay = true;
                            cursorstateY = 1;
                        }
                    }
                }
                if (dialogue == true)
                {
                    

                    if (cursordelay == true)
                    {
                        cursortime++;
                        if (cursortime > 20)
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
                    /*
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
                    */
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
                        if (cursortime == 0)
                        {
                            if (cursorstateX == 1 && cursorstateY == 1)
                            {
                                menutime = 20;
                                dialogue = false;
                            }
                            if (cursorstateX == 0 && cursorstateY == 1 && PCpos.X < 700)
                            {
                                SelectedEnemy = r.Next(0, 3);
                                GoldReward = r.Next(0, SelectedEnemy + 1 * 10);
                                ExperienceReward = r.Next(40, 100);
                                gamestate = "Battle";

                            }
                            else if (cursorstateX == 0 && cursorstateY == 1 && PCpos.X > 700)
                            {
                                gamestate = "Shop";
                            }
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
                    int AttackHit = r.Next(0, 101);
                    
                    EndingAnimation = true;                    
                    
                }
                //if (PCHP <= 0)
                //Exit();

                if (EndingAnimation == true && kstate.IsKeyDown(Keys.Z) && menutime == 0)
                {
                    gamestate = "overworld";
                    PCpos.X = 400;
                    PCpos.Y = 250;
                    dialogue = false;
                    Gold += GoldReward;
                    Experience += ExperienceReward;
                }          

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
                if (cursorstateX == 1 && cursorstateY == 0 && kstate.IsKeyDown(Keys.Z) && Attacks == false && menutime == 0 && PlayerTurn == true && AttackAnimation == false && EndingAnimation == false)
                {
                    Magic = true;
                    menutime = 20;
                }

                if (cursorstateX == 0 && cursorstateY == 0 && kstate.IsKeyDown(Keys.Z) && Attacks == true && menutime == 0 && PlayerTurn == true && AttackAnimation == false && EndingAnimation == false)
                {
                    
                    SelectedAttack = 0;
                    SelectedAttackBool = true;

                }
                if (cursorstateX == 1 && cursorstateY == 0 && kstate.IsKeyDown(Keys.Z) && Attacks == true && menutime == 0 && PlayerTurn == true && AttackAnimation == false && EndingAnimation == false)
                {
                    SelectedAttack = 1;
                    SelectedAttackBool = true;

                }
                if (cursorstateX == 0 && cursorstateY == 1 && kstate.IsKeyDown(Keys.Z) && Attacks == true && menutime == 0 && PlayerTurn == true && AttackAnimation == false && EndingAnimation == false)
                {
                    SelectedAttack = 2;
                    SelectedAttackBool = true;

                }
                if (cursorstateX == 1 && cursorstateY == 1 && kstate.IsKeyDown(Keys.Z) && Attacks == true && menutime == 0 && PlayerTurn == true && AttackAnimation == false && EndingAnimation == false)
                {
                    Attacks = false;

                }
                if (cursorstateX == 0 && cursorstateY == 0 && kstate.IsKeyDown(Keys.Z) && Magic == true && menutime == 0 && PlayerTurn == true && AttackAnimation == false && EndingAnimation == false)
                {

                    SelectedAttack = 3;
                    SelectedAttackBool = true;

                }
                if (cursorstateX == 1 && cursorstateY == 0 && kstate.IsKeyDown(Keys.Z) && Magic == true && menutime == 0 && PlayerTurn == true && AttackAnimation == false && EndingAnimation == false)
                {
                    SelectedAttack = 4;
                    SelectedAttackBool = true;

                }
                if (cursorstateX == 0 && cursorstateY == 1 && kstate.IsKeyDown(Keys.Z) && Magic == true && menutime == 0 && PlayerTurn == true && AttackAnimation == false && EndingAnimation == false)
                {
                    SelectedAttack = 5;
                    SelectedAttackBool = true;

                }
                if (cursorstateX == 1 && cursorstateY == 1 && kstate.IsKeyDown(Keys.Z) && Magic == true && menutime == 0 && PlayerTurn == true && AttackAnimation == false && EndingAnimation == false)
                {
                    Magic = false;
                    

                }

                if (SelectedAttackBool == true)
                {
                    int AttackHit = r.Next(0, 101); // vill generera ett slumpmässigt nummer från 0 till 100, attacker som har 100 i Chance borde inte kunna missa
                    if (attacks[SelectedAttack].GetAttackChance() > AttackHit)
                    {
                        PlayerDealtDamage = true;
                        if (attacks[SelectedAttack].GetAttackDamage() > 0)
                        {
                            TurnPlayerDamage = PCBaseDamage * attacks[SelectedAttack].GetAttackDamage();
                            Enemies[SelectedEnemy].SetEnemyHP(getEnemyHP - TurnPlayerDamage);
                            

                        }
                        /*
                        if (attacks[SelectedAttack].GetAttackDamage() == 0)
                        {
                            int EnemyCurrentAttack = Enemies[SelectedEnemy].GetEnemyAttack();
                            EnemyCurrentAttack -= 3;
                            Enemies[SelectedEnemy].SetEnemyAttack(EnemyCurrentAttack);
                        }
                        */

                    }


                    Attacks = false;
                    Magic = false;
                    menutime = 20;
                    AttackAnimation = true;
                    PCBaseDamage = 4;
                    if (getEnemyHP < 0)
                        getEnemyHP = 0;
                    SelectedAttackBool = false;
                }
                if (AttackAnimation == true && PlayerTurn == true && menutime == 0 && kstate.IsKeyDown(Keys.Z) && EndingAnimation == false)
                {

                    SelectedEnemyAttack = r.Next(0, Enemies[SelectedEnemy].GetEnemyAttackRange());
                    int EnemyHit = r.Next(0, 101);
                    if (attacks[SelectedEnemyAttack].GetAttackChance() > EnemyHit)
                    {
                        EnemyDealtDamage = true;
                        if (attacks[SelectedEnemyAttack].GetAttackDamage() > 0)
                        {
                            TurnEnemyDamage = Enemies[SelectedEnemy].GetEnemyAttack() * attacks[SelectedEnemyAttack].GetAttackDamage();
                            PCHP = PCHP - TurnEnemyDamage;
                        }
                        /*
                        if (attacks[SelectedEnemyAttack].GetAttackDamage() == 0)
                        {
                            PCBaseDamage -= 3;

                        }
                        */
                    }
                    menutime = 20;
                    PlayerTurn = false;
                    AttackAnimation = false;
                }
                if (AttackAnimation == false && PlayerTurn == false && menutime == 0 && kstate.IsKeyDown(Keys.Z) && EndingAnimation == false)
                {
                    if (SelectedEnemy == 0)
                        Enemies[SelectedEnemy].SetEnemyAttack(defaultEnemyAttack0);
                    if (SelectedEnemy == 1)
                        Enemies[SelectedEnemy].SetEnemyAttack(defaultEnemyAttack1);
                    if (SelectedEnemy == 2)
                        Enemies[SelectedEnemy].SetEnemyAttack(defaultEnemyAttack2);
                    menutime = 20;
                    PlayerDealtDamage = false;
                    EnemyDealtDamage = false;
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
                if (attacks[1].GetIsUnlocked() == true)
                spriteBatch.DrawString(font, "" + attacks[1].GetAttackName(), new Vector2(700, 550), Color.White);
                if (attacks[2].GetIsUnlocked() == true)
                spriteBatch.DrawString(font, "" + attacks[2].GetAttackName(), new Vector2(300, 650), Color.White);
                spriteBatch.DrawString(font, "Back", new Vector2(700, 650), Color.White);
                

            }
            if (gamestate == "Battle" && Attacks == false && Magic == true && PlayerTurn == true && AttackAnimation == false && EndingAnimation == false)
            {
                if (attacks[3].GetIsUnlocked() == true)
                spriteBatch.DrawString(font, "" + attacks[3].GetAttackName(), new Vector2(300, 550), Color.White);
                if (attacks[4].GetIsUnlocked() == true)
                 spriteBatch.DrawString(font, "" + attacks[4].GetAttackName(), new Vector2(700, 550), Color.White);
                if (attacks[5].GetIsUnlocked() == true)
                spriteBatch.DrawString(font, "" + attacks[5].GetAttackName(), new Vector2(300, 650), Color.White);
                
                spriteBatch.DrawString(font, "Back", new Vector2(700, 650), Color.White);
                
                
            }
            if (gamestate == "Battle" && PlayerTurn == false && AttackAnimation == false && EndingAnimation == false && EnemyDealtDamage == true)
            {
                spriteBatch.DrawString(font, "" + Enemies[SelectedEnemy].GetEnemyName() + " attacks with: ", new Vector2(300, 550), Color.White);
                spriteBatch.DrawString(font, "" + attacks[SelectedEnemyAttack].GetAttackName() +  " for: " + TurnEnemyDamage + " damage", new Vector2(300, 650), Color.White);
            }
            if (gamestate == "Battle" && PlayerTurn == false && AttackAnimation == false && EndingAnimation == false && EnemyDealtDamage == false)
            {
                spriteBatch.DrawString(font, "" + Enemies[SelectedEnemy].GetEnemyName() + " attacks with: ", new Vector2(300, 550), Color.White);
                spriteBatch.DrawString(font, "" + attacks[SelectedEnemyAttack].GetAttackName() + " but it failed", new Vector2(300, 650), Color.White);
            }
            if (gamestate == "Battle" && PlayerTurn == true && AttackAnimation == true && EndingAnimation == false && PlayerDealtDamage == true)
            {
                spriteBatch.DrawString(font, "You attack with: ", new Vector2(300, 550), Color.White);
                spriteBatch.DrawString(font, "" + attacks[SelectedAttack].GetAttackName() + " for: " + TurnPlayerDamage + " damage", new Vector2(300, 650), Color.White);
            }
            if (gamestate == "Battle" && PlayerTurn == true && AttackAnimation == true && EndingAnimation == false && PlayerDealtDamage == false)
            {
                spriteBatch.DrawString(font, "You attack with: ", new Vector2(300, 550), Color.White);
                spriteBatch.DrawString(font, "" + attacks[SelectedAttack].GetAttackName() + " but it failed", new Vector2(300, 650), Color.White);
            }

            if (gamestate == "Battle" && EndingAnimation == true)
            {
                spriteBatch.DrawString(font, "You won!", new Vector2(300, 550), Color.White);
                spriteBatch.DrawString(font, "Got: " + ExperienceReward + " Exp + " + GoldReward + " Gold", new Vector2(300, 650), Color.White);
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
                spriteBatch.DrawString(font, "Level:" + Level + " Exp:" + Experience, new Vector2(10, 10), Color.White);
                spriteBatch.DrawString(font, "Gold:" + Gold, new Vector2(10, 110), Color.White);
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
                    spriteBatch.DrawString(font, "WELCOME", new Vector2(200, 455), Color.White);
                    spriteBatch.DrawString(font, "", new Vector2(300, 550), Color.White);
                    spriteBatch.DrawString(font, "", new Vector2(700, 550), Color.White);                    
                    spriteBatch.DrawString(font, "Enter", new Vector2(300, 650), Color.White);
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
