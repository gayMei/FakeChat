Reset:
Console.Clear();

List<List<string>> messages = new List<List<string>>(); // declare messages

List<string> users = new List<string>(); // declare user
List<byte> colors = new List<byte>();
int user = 0;


SetupUsers();
Console.Clear();
PrintWindow();

while (true) // typing loop
{
    while(true)
    {
        List<string> message = new List<string>(); // declare message
        byte fuckup = 0;

        Console.Write("______________________________________________________________________________________\n> ");
        string input = Console.ReadLine(); // input, checking
        Console.Clear();
        PrintWindow();

        switch (input)
        {
            case "reset":
                goto Reset;
            case "help":
                fuckup = 1;
                break;
        }

        string[] words = input.Split(' '); // splitting words is harder than splitting people

        if (words[0] == "su")
        {
            if (Convert.ToInt32(words[1]) <= users.Count && Convert.ToInt32(words[1]) != 0) // new and refined user switching!!!!!! how cool and amazing and awesome
            {
                user = Convert.ToInt32(words[1]) - 1;
            }
            else
            {
                fuckup = 2; 
            }
        }
        else if (words[0] == "edit")
        {
            if (Convert.ToInt32(messages[messages.Count - 1][0]) == user + 1)
            {
                input = "";
                for (int i = 1; i < words.Length; i++)
                {
                    input += words[i] + " ";
                }
                messages[messages.Count - 1][2] = input;
            }

        }

        message.Add(users[user]); // add shit to message
        message.Add(Convert.ToString(colors[user]));
        message.Add(input);
        message.Add(words[0]);

        SortMessage(message);
        PrintMessages();

        switch (fuckup)
        {
            case 1:
                Console.WriteLine("\n  Commands:\n  su [user] - Switch to a user\n  reset - Reset FakeChat\n  edit [message] - Edit the last message (user sensitive)");
                break;
            case 2:
                Console.WriteLine("\n  This user does not exist!");
                break;
        }
    }
}

void PrintMessages() // print em messages
{
    string lastUser = "";
    foreach (List<string> msg in messages)
    {
        if (msg[2] != "" && msg[2] != "su" && msg[2] != "help" && msg[3] != "su" && msg[3] != "edit")
        {
            if (lastUser != msg[0])
            {
                ColoredText(Convert.ToInt32(msg[1]), "  " + msg[0]); // print the username
            }
            lastUser = msg[0];
            Console.WriteLine("  " + msg[2]);
        }
    }
}

void SortMessage(List<string> message)
{
    if (message[2] != "" && message[2] != "help" && message[3] != "su" && message[3] != "edit")
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
    Console.WriteLine("FakeChat - type [help] for help                                                 - [] X\n");
    Console.BackgroundColor = ConsoleColor.Black;
}

void SetupUsers()
{
    while (true)
    {
        Console.Clear();
        if (users.Count > 1) { Console.Write("\n  Type [start] to start the chat."); }
        Console.Write($"\n  Please enter the name of User {users.Count + 1}: ");
        string input = Console.ReadLine();
        if (input == "start" && users.Count > 1) // if input = start
        {
            break;
        }
        users.Add(input); // add input to users
        Console.Clear();
        Console.WriteLine("\n  Colors guide:\n  1 - Magenta\n  2 - Red\n  3 - Blue\n  4 - Green\n  5 - Yellow");
        Console.Write($"\n  Please enter the color of User {users.Count}: ");
        byte intput = Convert.ToByte(Console.ReadLine());
        colors.Add(intput); // add intput to colors
    }
}