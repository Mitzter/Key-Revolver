using System;
using System.Collections.Generic;
using System.Linq;

namespace Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] locks = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int intelValue = int.Parse(Console.ReadLine());

            Queue<int> lockQueue = new Queue<int>();
            Stack<int> bulletStack = new Stack<int>();

            int totalEarned = 0;

            foreach (var bullet in bullets)
            {
                bulletStack.Push(bullet);
            }
            foreach (var singleLock in locks)
            {
                lockQueue.Enqueue(singleLock);
            }
            int totalBulletsShot = 0;
            int bulletsShotBeforeReload = 0;
            while (true)
            {
                totalBulletsShot++;
                bulletsShotBeforeReload++;
                
                if (bulletStack.Peek() <= lockQueue.Peek())
                {
                    bulletStack.Pop();
                    lockQueue.Dequeue();
                    
                    Console.WriteLine("Bang!");
                }

                else
                {
                    bulletStack.Pop();
                    Console.WriteLine("Ping!");
                }
                if (bulletsShotBeforeReload == barrelSize && bulletStack.Count != 0)
                {
                    bulletsShotBeforeReload = 0;
                    Console.WriteLine("Reloading!");
                }
                if (bulletStack.Count == 0 && lockQueue.Count != 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {lockQueue.Count}");
                    break;
                }
                else if (lockQueue.Count == 0)
                {
                    totalEarned += intelValue;
                    int totalSpentOnBullets = totalBulletsShot * bulletPrice;
                    int total = totalEarned - totalSpentOnBullets; 
                    Console.WriteLine($"{bulletStack.Count} bullets left. Earned ${total}");
                    break;
                }

            }

        }
    }
}
