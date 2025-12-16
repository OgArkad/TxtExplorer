using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TxtExplorer
{
    internal class Program
    { 
        public static void Create(string name, DirectoryInfo Folder)
        {
            string input;
            Console.WriteLine("You can start to write:");
            Console.WriteLine("You can stop, if you close the window!");
            File.WriteAllText($"{Folder}/{name}.txt", $"---{name}---\n");
            while ((input = Console.ReadLine()) != null)
            {
                File.AppendAllText($"{Folder}/{name}.txt", $"{input}\n");
            }
        }
        public static void Edit(int input, FileInfo[] txtfiles, string content, int name, DirectoryInfo Folder)
        {
            string editInput;
            Console.WriteLine($"You are now editing:{txtfiles[input]}");
            Console.WriteLine("You can stop, if you close the window!");
            Console.WriteLine("You can now edit this file:");
            Console.WriteLine(content);
            //string content = File.ReadAllText($"{Folder}/{txtFiles[input-1]}");
            while ((editInput = Console.ReadLine()) != null)
            {
                File.AppendAllText($"{Folder}/{txtfiles[input]}", $"{editInput}\n");
            }
        }

        static void Main(string[] args)
        {
            //please write the FULL path to the folder, where you want to store your .txt files!----------------------------------
            DirectoryInfo Folder = new DirectoryInfo(@"HERE");
            //--------------------------------------------------------------------------------------------------------------------
            FileInfo[] txtFiles = Folder.GetFiles("*.txt", SearchOption.AllDirectories);

            Console.WriteLine("Hello! This program helps you to organize your .txt files(For example:journey plan,reciptes,etc.)");
            Console.WriteLine("Lets start!");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine($"{Folder}");
            int i = 0;
            foreach (FileInfo file in txtFiles)
            {
                i++;
                Console.WriteLine($"{i}. {file.Name}");
            }

            int number;
            do
            {
                Console.WriteLine("Do you want to create or choose an existing .txt file?(1 = create,2 = choose)");
            } while (!int.TryParse(Console.ReadLine(), out number) || (number != 1 && number != 2));

            if (number == 1)
            {
                Console.WriteLine("you choosed creation mode");
                Console.WriteLine("name it(without .txt at the end)");
                string input = Console.ReadLine();
                Create(input,Folder);

            }
            else if (number == 2)
            {
                Console.WriteLine("You choosed editing mode");
                Console.WriteLine("Which .txt folder do you want to choose?(give the ordinal number of it without dot)");
                int input = int.Parse(Console.ReadLine());
                string content = File.ReadAllText($"{Folder}/{txtFiles[input-1]}");
                Edit(input - 1, txtFiles, content, input, Folder);
            }

        }
    }
}
