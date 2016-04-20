using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Speech.Synthesis;


namespace Magic8BallApplication
{
    /// <summary>
    /// Entry point for Magic 8 Ball program (by: Mike F), coded along a youtube-video by Barnacules(Codegasm).
    /// </summary>

    class Program
    {

        private static SpeechSynthesizer synth = new SpeechSynthesizer();

        static void Main(string[] args)
        {
            // Preserve current console text color
            ConsoleColor oldColor = Console.ForegroundColor;

            TellPeopleWhatProgramThisIs();

            // Create a random object.
            Random randomObject = new Random();

            List<string> noQuestionAsked = new List<string>();
            noQuestionAsked.Add("You need to type a question, genious!");
            noQuestionAsked.Add("Can't give you an answer if you don't ask a question!");
            noQuestionAsked.Add("Don't ask a question if you can't handle the answer... Guess you just couldn't handle the answer...");
            noQuestionAsked.Add("Oh, don't feel the need to ask a question? You think you know everything already, don't you...");

            Random randAnswer = new Random();

            



            // Loop forever!!!
            while (true)
            {
                string questionString = GetQuestionFromUser();

                // Make the computer pause for between 1 and 5 seconds before
                // giving an answer...
                /*int numberOfSecondsToSleep = randomObject.Next(5) + 1;
                Console.WriteLine("Thinking about your answer, stand by...");
                Thread.Sleep(numberOfSecondsToSleep * 1000);
                I did not like this function but I kept it to learn.
                 */

                string noQuestionMessage = noQuestionAsked[randAnswer.Next(4)];

                if (questionString.Length == 0)
                {
                    Console.WriteLine(noQuestionMessage);
                    synth.Speak(noQuestionMessage);
                    continue;
                }
                // See if the user typed 'quit' as the question.
                if(questionString.ToLower() == "quit")
                {
                    break;
                }

                // Be nice or you will get booted.
                if(questionString.ToLower() == "you suck")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("You suck even more! BYE!");
                    break;
                }

            
                // Get a random #.
                int randomNumber = randomObject.Next(6);

                
                // Setting a random color for the console text, I did however set individual colors for each response.
                // Console.ForegroundColor = (ConsoleColor)randomNumber;


                // Use random number to determine response.
                switch (randomNumber)
                {
                    case 0:
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("YES!");
                            synth.Speak("YES!");
                            break;
                        }
                    case 1:
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("NO!");
                            synth.Speak("NO!");
                            break;
                        }
                    case 2:
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("HELL YEAH!");
                            synth.Speak("HELL YEAH!");
                            break;
                        }
                    case 3:
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("HELL NO!");
                            synth.Speak("HELL NO!");
                            break;
                        }
                    case 4:
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("I don't know, what do you think?");
                            synth.Speak("I don't know, what do you think?");
                            break;
                        }
                    case 5:
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Hm... I got nothing...");
                            synth.Speak("Hm... I got nothing...");
                            break;
                        }
                }
                              

            }


            // Cleaning up
            Console.ForegroundColor = oldColor;
        }

        /// <summary>
        /// This will print the name of the program and who created it
        /// to the console.
        /// </summary>
        
        static void TellPeopleWhatProgramThisIs()
        {
            // Change console text color
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Magic 8 Ball");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(" (by: Mike F)");
            //synth.Rate = 2;
            synth.Speak("Hi. I am a magic eightball. Ask me a question.");
        }

        /// <summary>
        /// This function will return the text the user types.
        /// </summary>
        /// <returns></returns>
        static string GetQuestionFromUser()
        {
            // This block of code will ask the user for a question
            // and store the question text in questionString variable.
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Ask a question?: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            string questionString = Console.ReadLine();

            return questionString;
        }

        
    }
}
