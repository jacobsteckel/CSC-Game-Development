//Jacob Steckel
//Homework 1: Cheating Hangman

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteckelCheatingHangman
{
    class Program_CheatingHangman
    {
        static void Main(string[] args)
        {
            //variables needed
            int wordLength;             
            string word;                
            bool addWord = true;      
            bool startLoop = true;
            int guesses;
            bool guessValid;

            var fileStream = new FileStream("words.txt",
                                             FileMode.Open, FileAccess.Read);

            List<string> wordBank = new List<string>();


            Console.WriteLine("Welcome to Cheating Hangman.");
            Console.WriteLine("Please enter the word length: ");
            wordLength = Convert.ToInt32(Console.ReadLine());   

            while (startLoop)
            {
                using (var streamReader = new StreamReader("words.txt"))
                {
                    while ((word = streamReader.ReadLine()) != null)
                    {
                        if (wordLength == word.Length)      
                        {
                            wordBank.Add(word);         

                            addWord = true;               
                            startLoop = false;              
                        }
                        if (wordBank.Count == 0)        
                        {
                            addWord = false;              
                        }

                    }
                    if (!addWord)                         
                    {
                        Console.WriteLine("Enter valid length!");
                        Console.WriteLine("Enter new word length: ");
                        wordLength = Convert.ToInt32(Console.ReadLine());   

                        using (streamReader) 
                        {
                            while ((word = streamReader.ReadLine()) != null)
                            {
                                if (wordLength == word.Length)
                                {
                                    wordBank.Add(word);

                                    addWord = true;
                                    startLoop = false;
                                }
                                if (wordBank.Count == 0)
                                {
                                    addWord = false;
                                }
                            }
                        }
                    }
                } 
            }

            Console.WriteLine("\nYou can have 1 - 26 guesses in this game.");
            Console.WriteLine("How many guesses would you like to play with: ");
            guesses = Convert.ToInt32(Console.ReadLine());    // was .ToInt32 ...

            if (guesses < 1 || guesses > 26)
            {
                guessValid = false;
            }
            else
            {
                guessValid = true;
            }

            while (guessValid == false)            
            {
                Console.WriteLine("\nSorry, that number is not valid!");
                Console.WriteLine("How many incorrect guesses would you like (1 - 26): ");
                    guesses = Convert.ToInt32(Console.ReadLine());

                    if (guesses >= 1 && guesses <= 26)                           
                    {
                        guessValid = true;                                     
                        Console.WriteLine("Your # of guesses: " + guesses);
                    }
                    else
                    {
                        guessValid = false;     
                    }
            }

            int runningTotal;
            runningTotal = wordBank.Count;

            char guess;
            List<char> usedLetters = new List<char>();
            HashSet<string> set = new HashSet<string>();
            List<string> newWordBank = new List<string>();
            Dictionary<string, Int32> dict = new Dictionary<string, Int32>();

            Console.WriteLine();
            do
            {
                Console.WriteLine("You have " + guesses + " guesses left.");
                Console.WriteLine("[ # of words possible: " + wordBank.Count + "]");

                Console.Write("\nWord: ");
                for (int i = 0; i < wordLength; i++)
                {
                    Console.Write(" _ ");
                }

                Console.Write("\nEnter letter to guess: ");

                guess = Console.ReadKey().KeyChar;

                if ((guess >= 'a' && guess <= 'z') || (guess >= 'A' && guess <= 'Z'))
                {
                    if (usedLetters.Contains(guess))   
                    {
                        Console.WriteLine("\nLetter was already guessed");
                        Console.WriteLine("\nPlease choose another letter:");
                        guess = Console.ReadKey().KeyChar;
                        guesses--;
                    }
                    else
                    {
                        guesses--;            
                        newWordBank.Equals(wordBank);

                        foreach (string s in wordBank)
                        {
                            if (s.Contains(guess))
                            {
                                newWordBank.Remove(s);
                            }
                        }
                        Console.WriteLine("\nYou have " + guesses + " guesses left.");
                    }
                    usedLetters.Add(guess);
                }
                else
                {
                    Console.WriteLine("\nError, " + guess + " is not a valid letter to guess." +
                                      "\nYou have " + guesses + " guesses left.");
                }
                Console.ReadKey();
                Console.WriteLine("\nUsed letters: ");
                foreach (char _char in usedLetters)
                    Console.Write(_char + " ");
                Console.WriteLine("\n");

            } 
            while (guesses != 0);
            {
                Console.WriteLine("Gameover");
            }

            newWordBank.ForEach(Console.WriteLine);
            Console.WriteLine(newWordBank.Count);
            
            HashSet<char> _guessedLetters = new HashSet<char>(usedLetters);

            Random rand = new Random();
            var specialWord = wordBank[rand.Next(0, wordBank.Count)].ToString();

            Console.WriteLine("\nThe word was: " + specialWord);

            char[] specialWordChar = specialWord.ToCharArray();

            Console.WriteLine("\nPress enter to close...");
            Console.ReadKey();

        } 
    } 
}

/*
Dr. Burns,

I Know my program is incomplete. I was unable to implement the correct guesses 
into my program in exchange for the underscores. I also realize that my new word
bank does not work because the # of possible words does not decrease. I have 
been working on it for about 5 or 6 days but i just could not figure it out. I 
tried adding in a new word bank to take the original word bank and subtract the #
of possible words by checking for the character index but could not find the correct
solution as i was moving in circles. I will be sure to put your office hours to 
good use next time around.

King Regards,
Jacob
*/
