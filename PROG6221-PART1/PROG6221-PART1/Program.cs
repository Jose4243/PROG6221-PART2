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
            // Dictionary to store cybersecurity topics and their definitions
var interests = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
{
    { "phishing", "Phishing is when attackers trick users into revealing sensitive info by pretending to be a trustworthy entity."},
    { "password safety", "Password safety means using unique, complex passwords and never sharing them." },
    { "safe browsing", "Safe browsing means using secure websites (HTTPS), avoiding suspicious links, and updating your browser." },
    { "online safety", "Online safety includes protecting your personal data, avoiding scams, and using secure connections." },
    { "strong passwords", "A strong password includes upper/lowercase letters, numbers, symbols, and is 12+ characters long." },
    { "cybersecurity awareness", "Cybersecurity awareness is knowing how to detect and avoid online threats like phishing and malware." }
};

// List of tips for phishing prevention
var phishingTips = new List<string>
{
    "Never click suspicious links. Hover over them to preview the URL first.",
    "Verify email sender addresses. Fake ones often have odd spellings or domains.",
    "Watch for grammar and spelling errors in emails. Real companies rarely make such mistakes.",
    "Don't act on urgent scare tactics like 'Account closing in 24 hours!'—verify first.",
    "Avoid downloading unknown attachments. They might carry malware or ransomware.",
    "Look for HTTPS and the padlock icon before entering sensitive info online."
};

// List of tips for password security
var passwordTips = new List<string>
{
    "Use a password manager to create and store strong passwords securely.",
    "Enable 2FA (two-factor authentication) for extra protection.",
    "Avoid reusing passwords across different websites or apps.",
    "Change passwords regularly, especially after a breach.",
    "Pick security question answers that are not publicly guessable."
};

// List to track user's interests for personalized responses
var userInterests = new List<string>();

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
                 UserInteraction(userName, interests, userInterests, phishingTips, passwordTips).Wait();

            }

    

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



            static async Task UserInteraction(string userName, Dictionary<string, string> interests, List<string> userInterests, List<string> phishingTips, List<string> passwordTips)

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
                    if (query.ToLower().Contains("thank you") || query.ToLower().Contains("thanks"))
                      {
                          Print("\nYou're welcome! I'm here to help.");
                          continue;
                      }

             if (query.ToLower().Contains("worried") || query.ToLower().Contains("worries"))
        {
            bool handled = false;
            foreach (var topic in interests.Keys)
            {
                if (query.ToLower().Contains(topic.ToLower()))
                {
                    Print($"\nIt's completely understandable to feel worried about {topic}. Would you like to know more about it?");
                    Console.ForegroundColor = ConsoleColor.White;
                    string response = Console.ReadLine();
                    if (response.ToLower().Contains("yes"))
                    {
                        Print(interests[topic]);
                    }
                    else
                    {
                        Print("Okay! Let me know if you have any other questions.");
                    }
                    handled = true;
                    break;
                }
            }
            if (handled) continue;
        }

        // Handle expressions of frustration
        else if (query.ToLower().Contains("tired of") || query.ToLower().Contains("frustrates") || query.ToLower().Contains("frustrated"))
        {
            bool handled = false;
            foreach (var topic in interests.Keys)
            {
                if (query.ToLower().Contains(topic.ToLower()))
                {
                    Print($"\nI understand that {topic} can be frustrating. Would you like to know more about it?");
                    Console.ForegroundColor = ConsoleColor.White;
                    string response = Console.ReadLine();
                    if (response.ToLower().Contains("yes"))
                    {
                        Print(interests[topic]);
                    }
                    else
                    {
                        Print("Okay! Let me know if you have any other questions.");
                    }
                    handled = true;
                    break;
                }
            }
            if (handled) continue;
        }

        // Handle expressions of curiosity
        else if(query.ToLower().Contains("questioning")|| query.ToLower().Contains("wondering") || query.ToLower().Contains("enthusiastic") || query.ToLower().Contains("learn more about") || query.ToLower().Contains("curious"))
        {
            bool handled = false;
            foreach (var topic in interests.Keys)
            {
                if (query.ToLower().Contains(topic.ToLower()))
                {
                    Print($"\nIt's great to be curious about {topic}. Would you like to know more about it?");
                    Console.ForegroundColor = ConsoleColor.White;
                    string response = Console.ReadLine();
                    if (response.ToLower().Contains("yes"))
                    {
                        Print(interests[topic]);
                    }
                    else
                    {
                        Print("Okay! Let me know if you have any other questions.");
                    }
                    handled = true;
                    break;
                }
            }
            if (handled) continue;
        }

        // Handle expressions of interest in topics
        if (query.ToLower().Contains("i am interested in") || query.ToLower().Contains("i'm interested in") || query.ToLower().Contains("im interested in") || query.ToLower().Contains("i'm interested in"))
        {
            bool interestHandled = false;
            foreach (var topic in interests.Keys)
            {
                if (query.ToLower().Contains(topic.ToLower()))
                {
                    if (!userInterests.Contains(topic))
                    {
                        userInterests.Add(topic);
                        Print($"\nGreat! I'll remember that you're interested in {topic}.");
                    }
                    interestHandled = true;
                    break;
                }
            }
            if (interestHandled) continue;
        }

        // Process general queries
        StartQuery(query, userName, interests, userInterests, phishingTips, passwordTips);
            }
        }
                
 
                static void StartQuery(string query, string userName, Dictionary<string, string> interests, List<string> userInterests, List<string> phishingTips, List<string> passwordTips)

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

