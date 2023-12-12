using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to BYU-I-DO - Your Dating Adventure at BYU-Idaho!");
        Console.WriteLine("Embark on a journey filled with romance, choices, and surprises.");

        DatingAdventure adventure = new DatingAdventure();

        while (!adventure.IsEnd())
        {
            Console.WriteLine(adventure.GetCurrentScene());
            Console.WriteLine("Choices:");
            string[] choices = adventure.GetChoices();

            for (int i = 0; i < choices.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {choices[i]}");
            }

            Console.Write("Enter your choice (1-" + choices.Length + "): ");
            if (int.TryParse(Console.ReadLine(), out int choiceIndex) && choiceIndex >= 1 && choiceIndex <= choices.Length)
            {
                adventure.MakeChoice(choiceIndex - 1);
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }

            Console.WriteLine();
        }

        Console.WriteLine("Congratulations! You've completed BYU-I-DO. Thanks for playing!");
        Console.WriteLine("Pre-order the next chapter for more exciting adventures.");
    }
}

class DatingAdventure
{
    private int currentScene;
    private string[] scenes;
    private string[][] choices;

    private bool metJessica;
    private bool metAlex;

    public DatingAdventure()
    {
        currentScene = 0;
        metJessica = false;
        metAlex = false;

        scenes = new string[]
        {
            "You just arrived at BYU-Idaho. What's your first move?",
            "It's the first day of a new semester. How will you spend your time?",
            "You received an invitation to a ward activity. Will you attend?"
        };

        choices = new string[][]
        {
            new string[] { "Attend a ward activity", "Explore campus" },
            new string[] { "Join a club", "Focus on studies" },
            new string[] { "Attend the ward activity", "Decline the invitation" }
        };
    }

    public string GetCurrentScene()
    {
        return scenes[currentScene];
    }

    public string[] GetChoices()
    {
        return choices[currentScene];
    }

    public void MakeChoice(int choiceIndex)
    {
        if (choiceIndex >= 0 && choiceIndex < choices[currentScene].Length)
        {
            Console.WriteLine($"You chose: {choices[currentScene][choiceIndex]}");

            // Update the story based on the choices
            if (currentScene == 2 && choiceIndex == 0)
            {
                // Attend the ward activity
                metJessica = true;
                metAlex = true;
            }

            currentScene++;
        }
    }

    public bool IsEnd()
    {
        return currentScene >= scenes.Length;
    }
}
