using CSharpPracticum.Menu;


namespace CSharpPracticum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var menuRunner = new MenuRunner();
            menuRunner.Run();
        }
    }
}
