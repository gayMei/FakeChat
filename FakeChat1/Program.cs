﻿Reset:
Console.Clear();

List<List<string>> messages = new List<List<string>>(); // declare messages

List<string> users = new List<string>(); // declare user
List<byte> colors = new List<byte>();
int user = 0;
int pointingAt = 0;

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
            case "delete":
                fuckup = 3;
                break;
        }

        string[] words = input.Split(' '); // splitting words is harder than splitting people

        switch (words[0])
        {
            case "su":
                if (words.Length > 1)
                {
                    if (Convert.ToInt32(words[1]) <= users.Count && Convert.ToInt32(words[1]) != 0) // user switching
                    {
                        user = Convert.ToInt32(words[1]) - 1;
                    }
                    else
                    {
                        fuckup = 2;
                    }
                }
                else
                {
                    fuckup = 2;
                }
                break;
            case "edit":
                if (Convert.ToInt32(messages[pointingAt][0]) == user)
                {
                    input = "";
                    for (int i = 1; i < words.Length; i++)
                    {
                        input += words[i] + " ";
                    }
                    messages[pointingAt][2] = input;
                }
                break;
            case "up":
                pointingAt--;
                break;
            case "down":
                pointingAt++;
                break;
            case "select":
                while(true)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        pointingAt--;
                    }
                    else if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        pointingAt++;
                    }
                    else
                    {
                        break;
                    }
                }
                break;
        }

        message.Add(Convert.ToString(user)); // add shit to message
        message.Add(Convert.ToString(colors[user]));
        message.Add(input);
        message.Add(words[0]);

        SortMessage(message);
        PrintMessages();

        switch (fuckup)
        {
            case 1:
                Console.WriteLine("\n  Commands:\n  up/down - Select a message\n  su [user] - Switch to a user\n  reset - Reset FakeChat\n  edit [message] - Edit selected message (user sensitive)\n  delete - Delete selected message (user sensitive)");
                break;
            case 2:
                Console.WriteLine("\n  This user does not exist!");
                break;
            case 3:
                if (Convert.ToInt32(messages[pointingAt][0]) == user)
                {
                    messages.Remove(messages[pointingAt]);
                    if (pointingAt == messages.Count)
                    {
                        pointingAt--;
                    }
                    Console.Clear();
                    PrintWindow();
                    PrintMessages();

                }
                break;
        }
    }
}

void PrintMessages() // print em messages
{
    string lastUser = "";
    for (int i = 0; i < messages.Count; i++)
    {
        if (lastUser != messages[i][0])
        {
            ColoredText(Convert.ToInt32(messages[i][1]), "  " + users[Convert.ToInt32(messages[i][0])]); // print the username
        }
        lastUser = messages[i][0];
        Console.Write("  " + messages[i][2]);
        if (i == pointingAt)
        {
            Console.Write(" *");
        }
        Console.WriteLine("");
        //Console.WriteLine(pointingAt);
    }
}

void SortMessage(List<string> message)
{
    if (message[2] != "" && message[2] != "help" && message[2] != "delete" 
        && message[3] != "su" && message[3] != "edit" && message[3] != "up" 
        && message[3] != "down" && message[3] != "select")
    {
        messages.Add(message);
        pointingAt = messages.Count - 1;
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