using System.Collections.Generic;

namespace GameOfLife
{
    public class StoredGame
    {
        public string Description;
        public List<List<bool>> Field;
        public override string ToString()
        {
            //TODO: copy&paste ASCII-Edition
            return "";
        }

        public byte[] ToByteArray()
        {
            //TODO: copy&paste Binary-Edition
            return new byte[5];
        }

        public string ToXML()
        {
            //TODO: copy&paste XML-Edition
            return "";
        }

        public StoredGame(string FileContent)
        {
            //TODO: implement constructor
        }

        public StoredGame(byte[] FileContent)
        {
            //TODO: implement constructor
        }

        public StoredGame() : base() // HACK: remove when specialized are ready
        {

        }
    }

}