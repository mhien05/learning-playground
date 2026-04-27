namespace CTS
{
    public class Person
    {
        public string Name;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // #VALUE TYPE
            int x = 10;
            int y = x;
            y = 20;
            Console.WriteLine(x);
            Console.WriteLine(y);

            Person p1 = new Person();
            p1.Name = "an";

            Person p2 = p1;
            p2.Name = "binh";

            Console.WriteLine(p1.Name); // print out "binh"
        }
    }
}
