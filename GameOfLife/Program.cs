﻿using System;
using System.Collections.Generic;

namespace GameOfLife
{
    class Program
    {
        static private readonly Stack<Scene> scenes = new();
        static public readonly List<IDrawable> NeedsRedraw = new();

        public static void SceneAdd(Scene NewScene)
        {
            NeedsRedraw.Clear();//HACK: shouldn't be filled!
            scenes.Push(NewScene);// Neue Szene auf den Stapel an Szenen legen
            NewScene.Activate(); // Neue Szene aktivieren
        }

        public static void SceneRemove()
        {
            NeedsRedraw.Clear();//HACK: shouldn't be filled!
            scenes.Pop(); // Szene vom Szenenstapel entfernen
            if (scenes.Count > 0) // Nachschauen ob noch Szenen vorhanden sind
            {
                scenes.Peek().Activate(); // falls noch eine Szene vorhanden ist diese Aktivieren.
            }
        }

        static void Main()
        {
            Console.CursorVisible = false;
            SceneAdd(new Intro());

            do
            {
                //prüfen ob etwas neu gezeichnet werden muss
                if (NeedsRedraw.Count > 0)
                {
                    foreach (var item in NeedsRedraw)
                    {
                        item.Draw();
                    }
                    NeedsRedraw.Clear();
                }

                scenes.Peek().Update();
            } while (scenes.Count > 0);
        }

    }
}
