using System;
using System.Speech.Synthesis;

namespace Speech
{
    class Program
    {
        static void Main()
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.SelectVoice("Microsoft Hedda Desktop"); // namen der stimmen können mit GetInstalledVoices() herausgefunden werden. englisch geht immer
            synth.Speak("Hallo Welt");
            Console.ReadLine();
        }
    }
}
