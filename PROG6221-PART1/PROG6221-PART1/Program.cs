using System;
using System.Linq;
using System.Media;
using System.Threading.Tasks;

namespace CybersecurityAiChatBot
{
    class Program
    {


        static void Main(string[] args)
        {

            DisplayImage();
            PLayVoiceGreeting();


            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nEnter Name: ", 60);
            string userName = Console.ReadLine();
            if (userName.Equals(""))
            {
                Console.WriteLine("Please enter a name!");

            }
            else
            {

                Print("\nWelcome " + userName + "!");
            }

            UserInteraction(userName);




            static void PLayVoiceGreeting()
            {


                var myPlayer = new SoundPlayer();
                myPlayer.SoundLocation = @"C:\Users\contr\source\repos\TestCode\TestCode\ElevenLabs_2025-03-26T15_56_04_George_pre_s50_sb75_se57_b_m2.wav";
                myPlayer.PlaySync();

            }



            static void DisplayImage()
            {

                string logo = "      ───▄█▌─▄─▄─▐█▄\r\n" +
                    "      ───██▌▀▀▄▀▀▐██\r\n" +
                    "      ───██▌─▄▄▄─▐██\r\n" +
               "      ───▀██▌▐█▌▐██▀\r\n" +
                    "      ▄██████─▀─██████▄\r\n";






                Console.WriteLine(logo);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("THE CYBERSECURITY AWARENESS BOT");

            }



            static async Task UserInteraction(string userName)
            {


                string query;
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;

                    Print("\nWhat can I help you with? (Type exit to leave application)\n");

                    Console.ForegroundColor = ConsoleColor.White;
                    query = Console.ReadLine();


                    if (query.Equals(""))
                    {
                        Print("\nI didn't quite understnad that. Could you rephrase");
                        Console.WriteLine();
                    }

                    else if (query.Equals("exit") || query.Equals("EXIT"))
                    {
                        Print("\nThank you for chatting " + userName + " stay safe online!");
                        break;
                    }
                    else
                    {
                        StartQuery(query, userName);
                    }



                }

                static void StartQuery(string query, string userName)
                {


                    if (query.Equals("How are you") || query.Equals("how are you") || query.Contains("feelings") || query.Contains("Feelings") || query.Equals("How are you?") || query.Equals("how are you?"))
                    {
                        Print("I'm a bot, I don't have feelings but I'm here to help you with any cybersecurity questions you may have");

                    }
                    else if (query.Equals("What's your purpose?") || query.Contains("Purpose") || query.Contains("purpose"))
                    {
                        Print("I'm here to help you with any cybersecurity questions you may have");

                    }
                    else if (query.Equals("What can I ask you about?") || query.Contains("ask about") || query.Contains("ask you") || query.Equals("what can you help me with") || query.Contains("help me"))
                    {
                        Print("You can ask me about anything related to cybersecurity");

                    }
                    else if (query.Equals("what is password phishing") || query.Contains("Phishing") || query.Contains("password phishing") || query.Contains("phishing") || query.Equals("could you explain passowrd phishing"))
                    {
                        Print("Password phishing is the process whereby individuals fake their identities in order to steal a victims password");
                    }

                    else if (query.Equals("How can I ensure my password's safe?") || query.Contains("password") || query.Contains("password safety"))
                    {
                        Print("You can ensure your password is safe by using a strong password that includes a combination of letters, numbers, and special characters. You should also avoid using the same password for multiple accounts and enable two-factor authentication whenever possible.");

                    }
                    else if (query.Equals("what is safe browsing?") || query.Contains("Browsing") || query.Contains("browsing") || query.Contains("safe browsing"))
                    {
                        Print("Safe browsing is the process of using a trusted and well secured browser for any research");

                    }
                    else
                    {
                        Print("I'm sorry I don't have an answer to that question. Could you please rephrase");
                    }
                }
            }
        }
        public static void Print(string text, int speed = 50)
        {
            foreach (char c in text)

            {
                Console.Write(c);
                System.Threading.Thread.Sleep(speed);

            }
            Console.WriteLine();
        }


    }
}

