using System;
using System.Diagnostics;

namespace PrimeNumbersAgain
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, prime;
            Stopwatch timer = new Stopwatch();

            PrintBanner();
            n = GetNumber();

            timer.Start();
            prime = FindNthPrime(n);
            timer.Stop();
            
            
            Console.WriteLine($"\nToo easy.. {prime} is the nth prime when n is {n}. I found that answer in {timer.Elapsed.Seconds} seconds.");

            EvaluatePassingTime(timer.Elapsed.Seconds);
        }

             static int FindNthPrime(int n)
        {
            int count = 0;   // how many primes we've found so far
            int number = 1;  // current number being checked

            // Keep going until we've found n primes
            while (count < n)
            {
                number++;

                // check if the current number is prime
                bool isPrime = true;

                // skip even numbers except 2 for a small speed boost
                if (number > 2 && number % 2 == 0)
                {
                    isPrime = false;
                }
                else
                {
                    // test divisibility from 2 up to the square root of the number
                    for (int i = 3; i * i <= number; i+=2)
                    {
                        if (number % i == 0)
                        {
                            isPrime = false;
                            break; // not a prime, stop checking
                        }
                    }
                }

                // if it's prime, increase the count
                if (isPrime)
                    count++;
            }

            // when count == n, "number" is the nth prime
            return number;
        }

        static int GetNumber()
        {
            int n = 0;
            while (true)
            {
                Console.Write("Which nth prime should I find?: ");
                
                string num = Console.ReadLine();
                if (Int32.TryParse(num, out n))
                {
                    return n;
                }

                Console.WriteLine($"{num} is not a valid number.  Please try again.\n");
            }
        }

        static void PrintBanner()
        {
            Console.WriteLine(".................................................");
            Console.WriteLine(".#####...#####...######..##...##..######...####..");
            Console.WriteLine(".##..##..##..##....##....###.###..##......##.....");
            Console.WriteLine(".#####...#####.....##....##.#.##..####.....####..");
            Console.WriteLine(".##......##..##....##....##...##..##..........##.");
            Console.WriteLine(".##......##..##..######..##...##..######...####..");
            Console.WriteLine(".................................................\n\n");
            Console.WriteLine("Nth Prime Solver O-Matic Online..\nGuaranteed to find primes up to 2 million in under 30 seconds!\n\n");
            
        }

        static void EvaluatePassingTime(int time)
        {
            Console.WriteLine("\n");
            Console.Write("Time Check: ");

            if (time <= 10)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Pass");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fail");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            
        }
    }
}
