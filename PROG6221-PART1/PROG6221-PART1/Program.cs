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
                        return;
                    }
                    
                       if (query.ToLower().Contains("do not understand") || query.Contains("explain it") || query.Contains("confused"))
    {
        Print("I can explain it in simpler terms. Just let me know what you need help with.");
        Console.ForegroundColor = ConsoleColor.White;
        string clarification = Console.ReadLine();

        foreach (var topic in interests.Keys)
        {
            if (clarification.ToLower().Contains(topic.ToLower()))
            {
                Print("\nLet me explain this in a simpler way:");
                // Provide topic-specific simple explanations
                if (topic.ToLower().Contains("phishing"))
                {
                    string[] simplePhishing = {
                        "Think of phishing like a fake friend request. Someone pretends to be your bank or a company you trust, but they're actually trying to steal your information.",
                        "Phishing is like a digital con artist. They send you an email that looks real (like from your bank) but it's fake, and they want you to click on a link or give them your password.",
                        "Imagine someone dressing up as a bank teller to trick you into giving them your account details. That's what phishing is, but online."
                    };
                    Print(simplePhishing[rand.Next(simplePhishing.Length)]);
                }
                else if (topic.ToLower().Contains("password"))
                {
                    string[] simplePassword = {
                        "Think of a strong password like a complex lock on your door. The more complicated it is, the harder it is for someone to break in.",
                        "A good password is like a secret code that only you know. It should be long, have different types of characters, and be unique for each account.",
                        "Imagine your password as a unique key to your house. You wouldn't use the same key for your house, car, and office, right? Same with passwords!"
                    };
                    Print(simplePassword[rand.Next(simplePassword.Length)]);
                }
                else if (topic.ToLower().Contains("safe browsing"))
                {
                    string[] simpleBrowsing = {
                        "Safe browsing is like being careful about which stores you visit in a mall. Some websites are safe, others might try to trick you.",
                        "Think of safe browsing like crossing the street. You look both ways (check the website), make sure it's safe (look for HTTPS), and only go when it's clear.",
                        "Safe browsing is like being a smart shopper online. You check if the store is legitimate before giving them your information."
                    };
                    Print(simpleBrowsing[rand.Next(simpleBrowsing.Length)]);
                }
                else if (topic.ToLower().Contains("online safety"))
                {
                    string[] simpleSafety = {
                        "Online safety is like being careful about what you share with strangers. Don't give out personal information unless you're sure it's safe.",
                        "Think of online safety like protecting your home. You lock your doors (use strong passwords), don't let strangers in (be careful with downloads), and keep your valuables safe (protect your personal info).",
                        "Online safety is like being street-smart, but on the internet. You learn to spot dangers and protect yourself from scams and hackers."
                    };
                    Print(simpleSafety[rand.Next(simpleSafety.Length)]);
                }
                else if (topic.ToLower().Contains("cybersecurity awareness"))
                {
                    string[] simpleAwareness = {
                        "Cybersecurity awareness is like learning to spot danger signs. You learn to recognize when something online might be trying to trick you.",
                        "Think of cybersecurity awareness like learning to drive. You need to know the rules, watch for dangers, and be prepared to protect yourself.",
                        "Cybersecurity awareness is like having a security system for your digital life. You learn to protect your information and spot potential threats."
                    };
                    Print(simpleAwareness[rand.Next(simpleAwareness.Length)]);
                }

                Print("\nDoes this explanation help? If you're still confused, I can try explaining it another way.");
                Console.ForegroundColor = ConsoleColor.White;
                string isClear = Console.ReadLine();
                if (isClear.ToLower().Contains("no") || isClear.ToLower().Contains("still") || isClear.ToLower().Contains("confused"))
                {
                    Print("Let me try one more time with an even simpler explanation:");
                    // Provide alternative simple explanations
                    if (topic.ToLower().Contains("phishing"))
                    {
                        Print("Phishing is like a fake friend request. Someone pretends to be your bank to steal your information. Always check if the email or message is really from who it says it's from.");
                    }
                    else if (topic.ToLower().Contains("password"))
                    {
                        Print("A strong password is like a secret code that's hard to guess. Use different passwords for different accounts, and make them long with letters, numbers, and symbols.");
                    }
                    else if (topic.ToLower().Contains("safe browsing"))
                    {
                        Print("Safe browsing is like being careful about which websites you visit. Look for the padlock symbol and 'https' in the address to make sure it's safe.");
                    }
                    else if (topic.ToLower().Contains("online safety"))
                    {
                        Print("Online safety is about protecting your personal information. Don't share sensitive details unless you're sure it's safe, and be careful about what you click on.");
                    }
                    else if (topic.ToLower().Contains("cybersecurity awareness"))
                    {
                        Print("Cybersecurity awareness is about knowing how to stay safe online. Learn to spot suspicious emails, use strong passwords, and be careful about what you share.");
                    }
                }
                else
                {
                    Print("Great! let me know if you have other questions.");
                }
                return;
            }
        }
        Print("I'm not sure which topic you're confused about. Could you please specify which cybersecurity topic you'd like me to explain?");
        return;
    }

    // Handle requests for specific tips
    if (query.Contains("phishing tip", StringComparison.OrdinalIgnoreCase) || query.Contains("give me a tip on phishing"))
    {
        Print("\nSure! Here's a phishing tip:");
        Print(phishingTips[rand.Next(phishingTips.Count)]);

        Console.ForegroundColor = ConsoleColor.Blue;
        Print("\nWould you like more phishing tips?");
        Console.ForegroundColor = ConsoleColor.White;
        string followUp = Console.ReadLine();
        if (followUp.Equals("yes", StringComparison.OrdinalIgnoreCase))
        {
            Print(phishingTips[rand.Next(phishingTips.Count)]);
        }
        else
        {
            Print("Okay! Let me know if you have any other questions.");
        }
        return;
    }

    // Handle password tip requests
    if (query.Contains("password tips", StringComparison.OrdinalIgnoreCase))
    {
        Print("Here's a good password safety tip:");
        Print(passwordTips[rand.Next(passwordTips.Count)]);
        return;
    }

    // Handle general topic-based answers
    bool responseGiven = false;
    foreach (var topic in interests.Keys)
    {
        if (query.ToLower().Contains(topic.ToLower()))
        {
            responseGiven = true;
            if (userInterests.Contains(topic))
            {
                Print($"\nSince you're interested in {topic}, here's some useful information:");
            }
            Print(interests[topic]);

            // Ask if they want more information
            Console.ForegroundColor = ConsoleColor.Blue;
            Print($"\nWould you like to know more about {topic}?");
            Console.ForegroundColor = ConsoleColor.White;
            string moreInfo = Console.ReadLine();

            if (moreInfo.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                Print($"\nHere's some additional information about {topic}:");
                // Provide topic-specific additional information
                if (topic.ToLower().Contains("phishing"))
                {
                    Random random = new Random();
                    string[] phishingInfo = { 
                        "Phishing happens when someone sends you a fake email, message, or website that looks real to steal your personal information. It's like someone dressing up as a bank employee to fool you into giving them your account details.",
                        "Phishing is a social engineering attack often delivered via email, SMS (smishing), or malicious websites. It aims to deceive users into clicking malicious links or downloading malware to harvest credentials, financial data, or other personal information.",
                        "Phishing is a scam where attackers pose as trusted sources to trick people into giving up private data.",
                        "Phishing is a deceptive technique used by cybercriminals to impersonate legitimate organizations, such as banks or online services, through fake emails or websites. These attacks are designed to trick victims into providing personal information, such as usernames, passwords, or credit card numbers, which the attacker can then use to commit fraud or identity theft.",
                        "Phishing is when a cybercriminal sends you a fake email that looks like it's from your bank. The email might say, \"Your account is locked—click here to fix it.\" If you click the link and enter your info, the hacker now has your credentials."
                    };
                    Print(phishingInfo[random.Next(phishingInfo.Length)]);
                }
                else if (topic.ToLower().Contains("strong passwords"))
                {
                    Random random = new Random();
                    string[] strongPasswordInfo = { "A strong password is one that's hard to guess, usually with letters, numbers, and symbols.", "A strong password is long, unique, and includes a mix of uppercase and lowercase letters, numbers, and special characters. It's not a name or word you can find in a dictionary.", "A strong password has high entropy—meaning it's difficult to predict or crack. It typically contains 12+ characters, a mix of character types, and avoids patterns or reused phrases." };
                    Print(strongPasswordInfo[random.Next(strongPasswordInfo.Length)]);
                }
                else if (topic.ToLower().Contains("password safety"))
                {
                    Random random = new Random();
                    string[] passwordInfo = { "Password safety means keeping your passwords secret and hard to guess so others can't access your accounts.", "Password safety involves creating strong, unique passwords for each account, changing them regularly, and never sharing them with anyone.", "Password safety refers to following best practices for managing credentials, including using complex passwords, avoiding reuse across platforms, and utilizing password managers to store them securely." };
                    Print(passwordInfo[random.Next(passwordInfo.Length)]);
                }
                else if (topic.ToLower().Contains("safe browsing"))
                {
                    Random random = new Random();
                    string[] safeBrowsingInfo = { "Safe browsing means using the internet in a careful way to avoid dangerous websites, viruses, and scams", "Safe browsing is the practice of visiting only trusted websites, avoiding suspicious links, and being cautious about downloads and pop-ups to stay safe online.", "Safe browsing involves adopting security-conscious habits like using HTTPS websites, avoiding drive-by downloads, disabling untrusted scripts, and keeping browsers and plugins updated to reduce vulnerability to cyber threats." };
                    Print(safeBrowsingInfo[random.Next(safeBrowsingInfo.Length)]);
                }
                else if (topic.ToLower().Contains("online safety"))
                {
                    Random random = new Random();
                    string[] onlineSafetyInfo = { "Online safety means protecting yourself from risks while using the internet, like scams, viruses, or strangers who want to harm you.", "Online safety is the practice of using the internet responsibly and securely—avoiding harmful websites, not oversharing personal information, and being cautious about who you interact with", "Online safety encompasses behaviors and precautions users take to protect their personal data, devices, and identities from online threats such as malware, phishing, and social engineering." };
                    Print(onlineSafetyInfo[random.Next(onlineSafetyInfo.Length)]);
                }
                else if (topic.ToLower().Contains("cybersecurity awareness"))
                {
                    Random random = new Random();
                    string[] safeBrowsingInfo = { "Cybersecurity awareness means knowing about online dangers like hacking and how to protect yourself.", "Cybersecurity awareness is the understanding of cyber threats and knowing how to avoid them—like recognizing suspicious links, protecting personal info, and following security best practices.", "Cybersecurity awareness involves educating users about digital threats such as phishing, malware, and social engineering, and training them to adopt safe online behaviors to reduce risk." };
                    Print(safeBrowsingInfo[random.Next(safeBrowsingInfo.Length)]);
                }
            }
            else if (moreInfo.Equals("no", StringComparison.OrdinalIgnoreCase))
            {
                Print("Okay! Let me know if you have any other questions.");
            }
            else
            {
                Print("I don't have more information on that topic right now, but I can help with other cybersecurity questions.");
            }

            // Ask if they want tips
            Console.ForegroundColor = ConsoleColor.Blue;
            if (topic.ToLower().Contains("phishing") || topic.Contains("password "))
            {
                Print($"\nWould you like some practical tips about {topic}?");
                Console.ForegroundColor = ConsoleColor.White;
                string wantTips = Console.ReadLine();
                if (wantTips.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    Print($"\nHere are some helpful tips about {topic}:");
                    if (topic.ToLower().Contains("phishing"))
                    {
                        Print(phishingTips[rand.Next(phishingTips.Count)]);
                    }
                    else if (topic.ToLower().Contains("password"))
                    {
                        Print(passwordTips[rand.Next(passwordTips.Count)]);
                    }
                }
                else
                {
                    Print("Okay! Let me know if you have any other questions");
                }
            }
            break;
        }
    }

    // Handle unrecognized queries
    if (!responseGiven)
    {
        Print("I'm sorry, I don't have an answer to that. Could you try rephrasing?");
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


