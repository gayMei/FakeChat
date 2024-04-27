Reset:
Console.Clear();

List<List<string>> messages = new List<List<string>>(); // declare messages

List<string> users = new List<string>(); // declare users
List<int> colors = new List<int>();
int user = 0;

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
    int intput = Convert.ToInt32(Console.ReadLine());
    colors.Add(intput); // add intput to colors
}

Console.Clear();
PrintWindow();

while (true) // typing loop
{
    while(true)
    {
        List<string> message = new List<string>(); // declare message
        bool help = false;

        Console.Write("______________________________________________________________________________________\n> ");
        string input = Console.ReadLine(); // input, checking
        Console.Clear();
        PrintWindow();

        switch (input)
        {
            case "reset":
                goto Reset;
            case "help":
                help = true;
                break;
        }
        string[] words = input.Split(' ');
        if (words[0] == "su")
        {
            if (Convert.ToInt32(words[1]) <= users.Count) // new and refined user switching!!!!!! how cool and amazing and awesome
            {
                user = Convert.ToInt32(words[1]) - 1;
            }
            else
            {
                Console.WriteLine("\n  This user does not exist!");
                Console.WriteLine($"  the number you wrote is {Convert.ToInt32(words[1])}");
                Console.WriteLine($" it is bigger than {users.Count}");
            }
        }

        message.Add(users[user]); // add shit to message
        message.Add(Convert.ToString(colors[user]));
        message.Add(input);

        messages.Add(message);

        PrintMessages();
        if (help)
        {
            Console.WriteLine("\n  Commands:\n  su [user] - Switch to a user\n  reset - Reset FakeChat");
        }
    }
}

void PrintMessages() // print em messages
{
    string lastUser = "";
    foreach (List<string> msg in messages)
    {
        if (msg[2] != "" && msg[2] != "su" && msg[2] != "help" && msg[2] != "su " + Convert.ToString(user + 1))
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