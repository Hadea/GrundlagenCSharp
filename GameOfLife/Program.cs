using System;
using System.Collections.Generic;

namespace GameOfLife
{
    class Program
    {
        static readonly Stack<Scene> scenes = new(); //TODO: Methoden schreiben für einfügen, lesen und entfernen von szenen. Dann Stack verstecken

        public static void AddScene(Scene NewScene)
        {
            scenes.Push(NewScene);// Neue Szene auf den Stapel an Szenen legen
            NewScene.Activate(); // Neue Szene aktivieren
        }

        public static Scene RemoveScene()
        {
            Scene temp = scenes.Pop(); // Szene vom Szenenstapel entfernen
            if (scenes.Count > 0) // Nachschauen ob noch Szenen vorhanden sind
            {
                scenes.Peek().Activate(); // falls noch eine Szene vorhanden ist diese Aktivieren.
            }
            return temp;
        }

        static void Main()
        {
            Console.CursorVisible = false;

            AddScene(new Intro());

            do
            {
                scenes.Peek().Update();
            } while (scenes.Count > 0);
        }

    }
}
