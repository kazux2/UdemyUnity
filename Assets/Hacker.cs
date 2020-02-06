using System;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game state
    const string menuHint = "To go back to menu, enter 'menu'";
    int level;

    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;

    string password;

    string[] level1passwords = { "math", "english", "music", "science", "study" };
    string[] level2passwords = { "liberal", "conservative", "taxation", "public", "cacophony" };
    string[] level3passwords = { "database", "excellence", "private", "programming", "goodsalary" };

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }

    }


    void RunMainMenu(string input)
    {
        var isValidLevelNumber = (input == "1" || input == "2"|| input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Wrong command");
			Terminal.WriteLine(menuHint);
        }
    }
    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();

        }
        else
        { 
            Terminal.WriteLine("Wrong password");
            StartGame();
		}

    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
		Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
   ____
  /   /
 /   /
/___/

				");
                break;
            case 2:
                Terminal.WriteLine("Have a politician...");
                Terminal.WriteLine(@"
   ____
  /   /
 /   /
/___/

				");
                break;
            case 3:
                Terminal.WriteLine("Have a good job...");
                Terminal.WriteLine(@"
   ____
  /   /
 /   /
/___/

				");
                Terminal.WriteLine("there is something more...");
                break;
            default:
                Debug.LogError("some error");
                break;
	
		}
    }

    void StartGame()
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Password;
        SetPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());

    }

    private void SetPassword()
    {
        switch (level)
        {
            case 1:
                password = level1passwords[UnityEngine.Random.Range(0, level1passwords.Length)];
                break;
            case 2:
                password = level2passwords[UnityEngine.Random.Range(0, level2passwords.Length)];
                break;
            case 3:
                password = level3passwords[UnityEngine.Random.Range(0, level3passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level numer");
                break;
        }
    }
}
