using System;
using Raylib_cs;

namespace vinterprojekt_BlendaJensen
{
    class Program
    {
        //Spelares karaktär
        static Rectangle spelare = new Rectangle(100, 100, 50, 50);
        static void Main(string[] args)
        {
            // Initialisering
            //--------------------------------------------------------------------------------------
            const int fönsterB = 810;
            const int fönsterH = 600;

            Raylib.InitWindow(fönsterB, fönsterH, "Jakt");
            Raylib.SetTargetFPS(60);

            // TODO: Infoga variabler och objekt här
            // Game state variabler
            float sekEtt = 30;

            //Variabler
            //Skapar en generator
            Random generator = new Random();
            //Användares poäng nivå 1
            int poäng = 0;
            //användare hastighet
            int hastighet = 4;
            string slutScen = "0";

            //Belöning karaktär
            Rectangle belöning = new Rectangle(generator.Next(10, 700),generator.Next(10, 500), 64, 64);
            Texture2D tårta = Raylib.LoadTexture(@"cake.png");

            //hinder 1
            Rectangle hinder = new Rectangle(generator.Next(400, 720), generator.Next(0, 520), 32, 32);
            Texture2D granat = Raylib.LoadTexture(@"grenade.png");
            //hinder 2
            Rectangle hinder1 = new Rectangle(generator.Next(400, 720), generator.Next(0, 520), 32, 32);
            Texture2D granat1 = Raylib.LoadTexture(@"grenade.png");
            //hinder 3
            Rectangle hinder2 = new Rectangle(generator.Next(400, 720), generator.Next(0, 520), 32, 32);
            Texture2D granat2 = Raylib.LoadTexture(@"grenade.png");
             //hinder 4
            Rectangle hinder3 = new Rectangle(generator.Next(400, 720), generator.Next(0, 520), 32, 32);
            Texture2D granat3 = Raylib.LoadTexture(@"grenade.png");
            //hinder 5
            Rectangle hinder4 = new Rectangle(generator.Next(400, 720), generator.Next(0, 520), 32, 32);
            Texture2D granat4 = Raylib.LoadTexture(@"grenade.png");
             //hinder 6
            Rectangle hinder5 = new Rectangle(generator.Next(400, 720), generator.Next(0, 520), 32, 32);
            Texture2D granat5 = Raylib.LoadTexture(@"grenade.png");

            //--------------------------------------------------------------------------------------

            // Animationsloopen
            while (!Raylib.WindowShouldClose())
            {
                if (slutScen == "0")
                {
                    Raylib.ClearBackground(Color.BLACK);
                    Raylib.DrawText($"Tryck mellanslag för att starta", 10, 240, 50, Color.WHITE);
                    Raylib.DrawText("Du ska jaga tårtan med pilarna på tid tangent bord och se upp för fiender!", 10, 290, 50, Color.WHITE);
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
                    {
                        slutScen = "1";
                    }
                }

                if (slutScen == "1")
                {
                // Rita
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.DARKBLUE);


                    //Byt bakgrundsfärg
                    Raylib.ClearBackground(Color.BLACK);

                    //Rita ut objekt
                    //Skriver ut nivån
                    Raylib.DrawText("Nivå 1", 5, 5, 40, Color.WHITE);
                    //Hur mycket tid man har kvar
                    Raylib.DrawText($"{(int)sekEtt}", 740, 10, 50, Color.WHITE);
                    //Antal poäng
                    Raylib.DrawText($"{(int)poäng}", 380, 20, 60, Color.WHITE);
                    //Rita ut spelare
                    Raylib.DrawRectangleRec(spelare, Color.WHITE);

                    //Spelarens hastighet
                    rörelse(hastighet);

                    //Tårtans karaktär
                    Raylib.DrawRectangleRec(belöning, Color.BLANK);
                    Raylib.DrawTexture(tårta, (int)belöning.x - 5, (int)belöning.y - 5, Color.WHITE);

                    //Hinder
                    Raylib.DrawRectangleRec(hinder, Color.BLANK);
                    Raylib.DrawTexture(granat, (int)hinder.x, (int)hinder.y, Color.WHITE);
                    Raylib.DrawRectangleRec(hinder1, Color.BLANK);
                    Raylib.DrawTexture(granat1, (int)hinder1.x, (int)hinder1.y, Color.WHITE);
                    Raylib.DrawRectangleRec(hinder2, Color.BLANK);
                    Raylib.DrawTexture(granat2, (int)hinder2.x, (int)hinder2.y, Color.WHITE);
                    Raylib.DrawRectangleRec(hinder3, Color.BLANK);
                    Raylib.DrawTexture(granat3, (int)hinder3.x, (int)hinder3.y, Color.WHITE);
                    Raylib.DrawRectangleRec(hinder4, Color.BLANK);
                    Raylib.DrawTexture(granat4, (int)hinder4.x, (int)hinder4.y, Color.WHITE);
                    Raylib.DrawRectangleRec(hinder5, Color.BLANK);
                    Raylib.DrawTexture(granat5, (int)hinder5.x, (int)hinder5.y, Color.WHITE);

                    //Upptäcka kollision
                    if (Raylib.CheckCollisionRecs(spelare, belöning))
                    {
                        poäng++;
                        belöning.x = generator.Next(0, 720);
                        belöning.y = generator.Next(0, 570);
                        hinder.x = generator.Next(0, 450);
                        hinder.y = generator.Next(0, 520);
                        hinder1.x = generator.Next(0, 450);
                        hinder1.y = generator.Next(0, 510);
                        hinder2.x = generator.Next(0, 710);
                        hinder2.y = generator.Next(0, 510);
                        hinder3.x = generator.Next(450, 710);
                        hinder3.y = generator.Next(0, 510);
                        hinder4.x = generator.Next(450, 710);
                        hinder4.y = generator.Next(0, 510);
                        hinder5.x = generator.Next(450, 710);
                        hinder5.y = generator.Next(0, 510);
                    }

                    //Upptäcka kollision mellan spelare och hinder
                    if (Raylib.CheckCollisionRecs(spelare, hinder)|| Raylib.CheckCollisionRecs(spelare, hinder1)|| Raylib.CheckCollisionRecs(spelare, hinder2) || Raylib.CheckCollisionRecs(spelare, hinder3) || Raylib.CheckCollisionRecs(spelare, hinder4))
                    {
                        poäng--;
                        hinder.x = generator.Next(0, 450);
                        hinder.y = generator.Next(0, 520);
                        hinder1.x = generator.Next(0, 450);
                        hinder1.y = generator.Next(0, 510);
                        hinder2.x = generator.Next(0, 710);
                        hinder2.y = generator.Next(0, 510);
                        hinder3.x = generator.Next(450, 710);
                        hinder3.y = generator.Next(0, 510);
                        hinder4.x = generator.Next(450, 710);
                        hinder4.y = generator.Next(0, 510);
                        hinder5.x = generator.Next(450, 710);
                        hinder5.y = generator.Next(0, 510);
                        if(poäng< -2)
                        {
                            slutScen = "2";
                        }
                    }

                    // Räkna ned tiden 
                    sekEtt -= Raylib.GetFrameTime();
                    //Vad som händer när tiden tar slut
                    if (sekEtt <= 0)
                    {
                        slutScen = "2";
                    }
                }
                if (slutScen == "2")
                {
                    Raylib.ClearBackground(Color.BLACK);
                    Raylib.DrawText($"Du fick {poäng} poäng", 130, 240, 50, Color.WHITE);
                }

                
                //----------------------------------------------------------------------------------

                Raylib.EndDrawing();
                //----------------------------------------------------------------------------------
            }
        }
        static void rörelse(int snabbhet)
        {
            //Spelare rörelse
            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                spelare.x += snabbhet;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                spelare.x -= snabbhet;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
            {
                spelare.y += snabbhet;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
            {
                spelare.y -= snabbhet;
            }
        }
    }
}