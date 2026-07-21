class Program
{
    static void Main()
    {

        while(true)
        {
            
            Console.Write("$ ");
            string command = Console.ReadLine()!;
            Console.Write($"{command}: command not found");

        }        
    }
}
