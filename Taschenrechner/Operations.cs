
namespace Taschenrechner
{
    // dieses enum ist intern kein int mehr sondern ein byte.
    // Spart etwas speicher gerade wenn es später in eine Datei geschrieben werden sollte
    enum Operations : byte
    {
        UnSet,
        Addition,
        Substration,
        Multiplication,
        Division,
        Modulo
    }
}
