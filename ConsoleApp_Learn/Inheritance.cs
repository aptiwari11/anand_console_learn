using System;

class BC
{
    public virtual void Display()
    {
        System.Console.WriteLine("BC::Display");
    }
}

class DC : BC
{
    public override void Display()
    {
        System.Console.WriteLine("DC::Display");
    }
}

class TC : DC
{
    public override void Display()
    {
        System.Console.WriteLine("TC::Display");
    }
}

class Demo
{
    public static void Run()
    {
        BC b;
        b = new BC();
        b.Display();

        b = new DC();
        b.Display();

        b = new TC();
        b.Display();
    }
}
