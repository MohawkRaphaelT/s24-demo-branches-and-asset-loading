﻿using Raylib_cs;
using System.Numerics;
using System.Runtime.CompilerServices;

public class Program
{
    // If you need variables in the Program class (outside functions), you must mark them as static
    static string title = "Game Title"; // Window title
    static int screenWidth = 800; // Screen width
    static int screenHeight = 600; // Screen height
    static int targetFps = 60; // Target frames-per-second

    static Texture2D asteroid;
    static Sound sfx;

    static void Main()
    {
        // Create a window to draw to. The arguments define width and height
        Raylib.InitWindow(screenWidth, screenHeight, title);
        // Set the target frames-per-second (FPS)
        Raylib.SetTargetFPS(targetFps);
        // Enable audio
        Raylib.InitAudioDevice();
        // Setup your game. This is a function YOU define.
        Setup();
        // Loop so long as window should not close
        while (!Raylib.WindowShouldClose())
        {
            // Enable drawing to the canvas (window)
            Raylib.BeginDrawing();
            // Clear the canvas with one color
            Raylib.ClearBackground(Color.RayWhite);
            // Your game code here. This is a function YOU define.
            Update();
            // Stop drawing to the canvas, begin displaying the frame
            Raylib.EndDrawing();
        }
        // Stop audio
        Raylib.CloseAudioDevice();
        // Close the window
        Raylib.CloseWindow();
    }

    static void Setup()
    {
        // Figure out here we are running from
        //string cwd = Directory.GetCurrentDirectory();
        //Console.WriteLine($"Where are we runnign from? {cwd}");

        // Your one-time setup code here
        // Get out of net8.0, Debug, bin, VS project, then go into assets
        string path = "../../../../assets/graphics/asteroid.png";
        Image image = Raylib.LoadImage(path);
        asteroid = Raylib.LoadTextureFromImage(image);
        Raylib.UnloadImage(image);

        LoadSFX();
    }

    static void Update()
    {
        // Your game code run each frame here
        int x = Raylib.GetMouseX();
        int y = Raylib.GetMouseY();
        Raylib.DrawTexture(asteroid, x, y, Color.White);

        PlaySFX();
    }

    static void LoadSFX()
    {
        string path = "../../../../assets/audio/target.ogg";
        sfx = Raylib.LoadSound(path);
    }

    static void PlaySFX()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.Space))
        {
            Raylib.PlaySound(sfx);
        }
    }
}