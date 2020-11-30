using System;
using System.Speech.Synthesis;

namespace Speech
{
    class Program
    {
        static void Main()
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            foreach (var item in synth.GetInstalledVoices()) // zeigt die namen aller installierten stimmen an
            {
                Console.WriteLine(item.VoiceInfo.Name);
            }

            synth.SelectVoice("Microsoft Hedda Desktop"); 
            synth.Speak("Hallo Welt");
            Console.ReadLine();
        }
    }
}
