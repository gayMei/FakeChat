Reset:
Console.Clear();

List<List<string>> messages = new List<List<string>>(); // declare messages

List<string> users = new List<string>();
List<byte> colors = new List<byte>();

SetupUser();
Console.Clear();
PrintWindow();

while (true) // typing loop
{
    while(true)
    {
        List<string> message = new List<string>(); // declare message
        bool fuckup = false;

        Console.Write("______________________________________________________________________________________\n> ");
        string input = Console.ReadLine(); // input, checking
        Console.Clear();
        PrintWindow();

            switch (input)
        {
            case "reset":
                goto Reset;
            case "help me daddy":
                fuckup = true;
                break;
            case "help me mommy":
                fuckup = true;
                break;
        }

        message.Add(Convert.ToString(users[0])); // add shit to message
        message.Add(Convert.ToString(colors[0]));
        message.Add(input);

        SortMessage(message);
        PrintMessages();
        
        if (message[2] != "" && message[2] != "help me mommy" && message[2] != "help me daddy")
        {
            NPCResponse();
        }

        if (fuckup)
        {
            Console.WriteLine("\n  Commands:\n  reset - Reset FagChat");
        }
    }
}

void PrintMessages() 
{
    string lastUser = "";
    for (int i = 0; i < messages.Count; i++)
    {
        if (lastUser != messages[i][0])
        {
            int color = Convert.ToInt32(messages[i][1]);
            ColoredText(color, "  " + users.Find(user => user == messages[i][0]));
        }
        lastUser = messages[i][0];
        Console.Write("  " + messages[i][2]);
        Console.WriteLine("");
        //Console.WriteLine(pointingAt);
    }
}

void SortMessage(List<string> message)
{
    if (message[2] != "" && message[2] != "help me daddy" && message[2] != "help me mommy")
    {
        messages.Add(message);
    }
}

void ColoredText(int color, string text) // colored text :3 color me mommy
{
    switch(color)
    {
        case 1:
            Console.ForegroundColor = ConsoleColor.Magenta; break;
        case 2:
            Console.ForegroundColor = ConsoleColor.Red; break;
        case 3:
            Console.ForegroundColor = ConsoleColor.Blue; break;
        case 4:
            Console.ForegroundColor = ConsoleColor.Green; break;
        case 5:
            Console.ForegroundColor = ConsoleColor.Yellow; break;
    }
    Console.WriteLine(text);
    Console.ForegroundColor = ConsoleColor.White;
}

void PrintWindow()
{
    Console.BackgroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine("FakeFag - type [help me mommy] for help~                                        - [] X\n");
    Console.BackgroundColor = ConsoleColor.Black;
}

void SetupUser()
{
    Console.Clear();
    Console.Write($"\n  Please enter your username: ");
    users.Add(Console.ReadLine());
    colors.Add(1);

    users.Add("Submissive catgirl");
    users.Add("Gay puppygirl");
    users.Add("Dommy mommy <3");
    users.Add("Autism itself");
    colors.Add(2); colors.Add(5); colors.Add(3); colors.Add(4);
}

void NPCResponse()
{
    string lastUser = messages[messages.Count - 1][0];
    Random r = new Random();
    int responses = r.Next(3, 7);
    int callie = 1; // go read challenger deep i beg you it's so fucking good

    for (int j = 0; j < responses; j++)
    {
        int random = r.Next(1, 13);
        if (random != 1)
        {
            int npc = r.Next(1, 5);
            callie = npc;
        }

        int words = r.Next(1, 13);
        string input = "";
        List<string[]> speakwords = new List<string[]>();
        string[] speakwords1 = { "meow", "mrrrow", "mrrrp", "nyaaa", "nya", "mew", "meowwww" };
        speakwords.Add(speakwords1);
        string[] speakwords2 = { "wruff", "woof", "*wags tail*", "wrauff", "woef", "wrafu" };
        speakwords.Add(speakwords2);
        string[] speakwords3 = { "miss", "wife", "love", "wifey", "girlfriend", "cute", "faggot", "need", "gay", "I", "say gex", "uwu" };
        speakwords.Add(speakwords3);
        string[] speakwords4 = { "womp womp", "bwaah", "silly", "car", "cat", ">w<", ":3", "*bite*", "on top" };
        speakwords.Add(speakwords4);

        int last = 0;
        for (int i = 0; i < words; i++)
        {
            int chosenword = r.Next(0, speakwords[callie - 1].Length);
            if (chosenword != last)
            {
                input += speakwords[callie - 1][chosenword] + " ";
            }
            else { i--; }
            last = chosenword;
        }

        input = input.Trim();

        List<string> message = new List<string>();
        message.Add(Convert.ToString(users[callie]));
        message.Add(Convert.ToString(colors[callie]));
        message.Add(input);
        SortMessage(message);

        int sleep = r.Next(300, 1500);
        Thread.Sleep(sleep);

        Console.Clear();
        PrintWindow();
        PrintMessages();
    }
}
