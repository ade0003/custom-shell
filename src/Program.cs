using System.Diagnostics.Tracing;

class Program
{
    static void Main()
    {

        while(true)
        {
            Console.Write("$ ");
            string command = Console.ReadLine()!;


            if (command.Contains("type"))
            {
                string[] typeArray = command.Split(' ');

                if(typeArray[1] == "echo" || typeArray[1] == "exit" || typeArray[1] == "type")
                {
                    Console.WriteLine($"{typeArray[1]} is a shell builtin");
                    continue;
                }
                else
                {

                    string? filePath = Environment.GetEnvironmentVariable("PATH");
                    string[] paths = filePath!.Split(Path.PathSeparator);
                    
                    foreach(string path in paths)
                    {
                        
                        string fullPath  = Path.Combine(path, typeArray[1]);
                        if (!File.Exists(fullPath))
                        {
                            continue;
                        }
                        else
                        {
                            if (File.GetUnixFileMode(fullPath).HasFlag(UnixFileMode.UserExecute))
                            {
                                
                                Console.WriteLine($"{typeArray[1]} is {fullPath}");
                                break;
                            }
                            else continue;
                            
                        }

                    }
                    Console.WriteLine($"{typeArray[1]}: not found");
                    continue;
                }
            }
            else
            {
                        
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

                else
                {          
                      Console.WriteLine($"{command}: command not found");
                    
                }
            }

        }        
    }
}
