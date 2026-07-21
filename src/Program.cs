using System.Diagnostics.Tracing;

class Program
{
    static void Main()
    {

        while(true)
        {
            Console.Write("$ ");
            string command = Console.ReadLine()!;
            if(command == "exit")
            {
                break;
            }
            if (command.Contains("echo"))
            {
                string[] commandArray = command.Split(' ');
                foreach (string c_arg in commandArray)
                {
                    if(c_arg != "echo")
                    {
                        Console.Write($"{c_arg} ");
                    }

                }
                Console.Write("\n");
                continue;
            }
            Console.WriteLine($"{command}: command not found");

        }        
    }
}
