namespace DiceRollGameCLI
{
    using System.Numerics;
    using Windows.ApplicationModel;

    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            RollTheDice diceRoll = new();
            while (true)
            {
                if (diceRoll.AreAllAttemptsExhausted())
                {
                    Environment.Exit(0);
                }
                Console.WriteLine("Enter your guess (you get 3 attempts to guess it right):");
                // Add logic to read user input and call RollIt and IsWin methods
                if(int.TryParse(Console.ReadLine(), out diceRoll.guessNum))
                {
                    if((diceRoll.guessNum < 1) || (diceRoll.guessNum > 6))
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 6.");
                        continue;
                    }
                    diceRoll.ValidateTrialAndTrack();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 6.");
                }
            }
        }
    }

    public class RollTheDice
    {
        public const int MaxNum = 7, MinNum = 1;
        private const ushort MaxAttempt = 3;
        private const string WinStr = "You won!", LoseStr = "You lose!";
        private static ushort attemptCount = 0;

        public int guessNum = 0;

        public void ValidateTrialAndTrack()
        {
            Random rnd = new();

            if (guessNum == rnd.Next(MinNum, MaxNum))
            {
                Console.WriteLine(WinStr);
                attemptCount = MaxAttempt;
            }
            else
            {
                Console.WriteLine(LoseStr);
            }

            attemptCount++;
        }

        public bool AreAllAttemptsExhausted()
        {
            if (attemptCount >= MaxAttempt)
            {
                Console.WriteLine("You guessed it right or All attempts exhausted!\nExiting...");
                Thread.Sleep(2000);
                return true;
            }
            return false;
        }
    }
}