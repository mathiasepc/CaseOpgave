//opretter CurrentUser og den refresher min list ved loop
CurrentUserSession currentUser = new();

Console.WriteLine("\t\t  Our 3 best rated film.");


//finder det som er i display
foreach (var item in currentUser.DisplayProducts())
{
    //"Designer mit display"
    Console.WriteLine("----------------------------------------------------------------");
    Console.WriteLine($"Rating:{item.Rating} \t Film: {item.Name} Pris: {item.Price}");
}

//den er ude for array for at afskærme til næste Console.WriteLine
Console.WriteLine("----------------------------------------------------------------");
Console.WriteLine("\t\tPress any key to continue.");
Console.ReadKey();

while (true)
{
    //så man kun ser menuen
    Console.Clear();

    //laver menuen
    Console.WriteLine("\t\tType your Userid.");
    Console.WriteLine("-----------------------------------------------");
    Console.WriteLine("UserId = 1.");
    Console.WriteLine("UserId = 2.");
    Console.WriteLine("UserId = 3.");
    Console.WriteLine("UserId = 5.");
    Console.WriteLine("-----------------------------------------------");

    Console.WriteLine("\tChoice between userid 1, 2, 3 or 5.");

    //gemmer ReadKey i choice
    string getUserId = Console.ReadLine();

    //så man kun kan se svaret
    Console.Clear();

    //bruger switch for, at styrer udfaldet af det indtastede.
    switch (getUserId)
    {
        case "1":
            //går min CostumerView igennem
            foreach (var item in currentUser.CostumerView(getUserId))
            {
                Console.WriteLine($"name: {item.Id} {item.Name} rating: {item.Rating}");
            }

            break;
        case "2":
            //går min CostumerView igennem
            foreach (var item in currentUser.CostumerView(getUserId))
            {
                Console.WriteLine($"{item.Name}");
            }
            break;
        case "3":
            //går min CostumerView igennem
            foreach (var item in currentUser.CostumerView(getUserId))
            {
                Console.WriteLine($"{item.Name}");
            }
            break;
        case "5":
            //går min CostumerView igennem
            foreach (var item in currentUser.CostumerView(getUserId))
            {
                Console.WriteLine($"{item.Name}");
            }
            break;
        //hvis man taster forkert
        default:
            Console.WriteLine("Error. Choice userid 1, 2, 3 or 5. Then press enter.");
            break;

    }
    //foreach (var item in currentUser.SetSuggestions(getUserId))
    //{
    //    Console.WriteLine($"{item.Name} {item.Rating}");
    //}

    Console.ReadKey();
}

