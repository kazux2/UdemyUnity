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
        Terminal.WriteLine("Now, you're about hack in institutions.");
        Terminal.WriteLine("Enter 1 for school");
        Terminal.WriteLine("Enter 2 for government");
        Terminal.WriteLine("Enter 3 for Google");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (input == "exit")
        {
            Terminal.WriteLine("bye.");
		
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
        var isValidLevelNumber = (input == "1" || input == "2" || input == "3");
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
                Terminal.WriteLine("Congraturations. You've hack into a library...");
                Terminal.WriteLine(@"
:::|',             ,'|:::
---|'.|, _______ ,|.'|---
:::|'.|'|???????|'|.'|:::
:::|'.|'|???????|'|.'|:::
---|','   /%%%\   ','|---
===:'    /%%%%%\    ':===
				");
                break;
            case 2:
                Terminal.WriteLine("You've logged in to a governmental database...");
                Terminal.WriteLine(@"
         A 
        AWA       
   AA  AWXWA  AA 
    VWXWXWXWXWV 
    wVWXWXWXWVw   
         I  
         I 
                ");
                break;
            case 3:
                Terminal.WriteLine("You talented hacker. Soon they'll offer you a job...");
                Terminal.WriteLine(@"
  ___                _
 / __|___  ___  __ _| |___
| (_ / _ \/ _ \/ _` |   -_)
 \___\___/\___/\__, |_\___|
               |___/
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
