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
    Console.WriteLine("\n  Colors guide:\n  1 - Magenta\n  2 - Red\n  3 - Blue\n  4 - Green");
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

        Console.Write("______________________________________________________________________________________\n> ");
        string input = Console.ReadLine(); // input, checking
        Console.Clear();
        PrintWindow();

        switch (input)
        {
            case "reset":
                goto Reset;
            case "su": // user switching
                if (user == users.Count - 1)
                {
                    user = 0;
                }
                else
                {
                    user++;
                }
                break;
        }

        message.Add(users[user]); // add shit to message
        message.Add(Convert.ToString(colors[user]));
        message.Add(input);

        messages.Add(message);

        PrintMessages();
    }
}

void PrintMessages() // print em messages
{
    string lastUser = "";
    foreach (List<string> msg in messages)
    {
        if (msg[2] != "" && msg[2] != "su")
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
    }
    Console.WriteLine(text);
    Console.ForegroundColor = ConsoleColor.White;
}

void PrintWindow()
{
    Console.BackgroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine("FakeChat - chat with yourself! reset to reset all data, su to switch user       - [] X\n");
    Console.BackgroundColor = ConsoleColor.Black;
}