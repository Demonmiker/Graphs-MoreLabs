using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphsLib;

namespace HeapTest
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryHeap<string> heap = new BinaryHeap<string>();
            while(true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "exit") break;
                else if (cmd[0] == '+')
                {
                    string[] buf = cmd.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    int key = int.Parse(buf[2]);
                    heap.Add(key, buf[1]);
                }
                else if (cmd == "-")
                    Console.WriteLine("Удален:" + heap.GetMin());

                Console.WriteLine($"#{heap.Size}#: {heap}");
            }
        }
    }
}
