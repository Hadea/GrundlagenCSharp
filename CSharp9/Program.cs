
System.Console.WriteLine("Hallo Welt!");

Auto A = new Auto();
A.blubber = 5;
var B = new Auto { blubber = A.blubber };
Auto C = new();

Buto meinButo;
meinButo.blubber = 10;

incA(A);
incB(meinButo);

System.Console.WriteLine(A.blubber);
System.Console.WriteLine(meinButo.blubber);

void incA(Auto a)
{
    a.blubber++;
}

void incB(Buto b)
{
    b.blubber++;
}

record Auto
{
    public int blubber;
}

struct Buto
{
    public int blubber;
}

