using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HangManGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] messages = {
                @"'##::::'##::::'###::::'##::: ##::'######:::'##::::'##::::'###::::'##::: ##:'####:
 ##:::: ##:::'## ##::: ###:: ##:'##... ##:: ###::'###:::'## ##::: ###:: ##: ####:
 ##:::: ##::'##:. ##:: ####: ##: ##:::..::: ####'####::'##:. ##:: ####: ##: ####:
 #########:'##:::. ##: ## ## ##: ##::'####: ## ### ##:'##:::. ##: ## ## ##:: ##::
 ##.... ##: #########: ##. ####: ##::: ##:: ##. #: ##: #########: ##. ####::..:::
 ##:::: ##: ##.... ##: ##:. ###: ##::: ##:: ##:.:: ##: ##.... ##: ##:. ###:'####:
 ##:::: ##: ##:::: ##: ##::. ##:. ######::: ##:::: ##: ##:::: ##: ##::. ##: ####:
..:::::..::..:::::..::..::::..:::......::::..:::::..::..:::::..::..::::..::....::",

@"'##:::'##::'#######::'##::::'##::::'##:::::'##:'####:'##::: ##:'####:
. ##:'##::'##.... ##: ##:::: ##:::: ##:'##: ##:. ##:: ###:: ##: ####:
:. ####::: ##:::: ##: ##:::: ##:::: ##: ##: ##:: ##:: ####: ##: ####:
::. ##:::: ##:::: ##: ##:::: ##:::: ##: ##: ##:: ##:: ## ## ##:: ##::
::: ##:::: ##:::: ##: ##:::: ##:::: ##: ##: ##:: ##:: ##. ####::..:::
::: ##:::: ##:::: ##: ##:::: ##:::: ##: ##: ##:: ##:: ##:. ###:'####:
::: ##::::. #######::. #######:::::. ###. ###::'####: ##::. ##: ####:
:::..::::::.......::::.......:::::::...::...:::....::..::::..::....::",
            @"'##:::'##::'#######::'##::::'##::::'##::::::::'#######:::'######::'########:'####:
. ##:'##::'##.... ##: ##:::: ##:::: ##:::::::'##.... ##:'##... ##: ##.....:: ####:
:. ####::: ##:::: ##: ##:::: ##:::: ##::::::: ##:::: ##: ##:::..:: ##::::::: ####:
::. ##:::: ##:::: ##: ##:::: ##:::: ##::::::: ##:::: ##:. ######:: ######:::: ##::
::: ##:::: ##:::: ##: ##:::: ##:::: ##::::::: ##:::: ##::..... ##: ##...:::::..:::
::: ##:::: ##:::: ##: ##:::: ##:::: ##::::::: ##:::: ##:'##::: ##: ##:::::::'####:
::: ##::::. #######::. #######::::: ########:. #######::. ######:: ########: ####:
:::..::::::.......::::.......::::::........:::.......::::......:::........::....::",
            @":'######::::::'###::::'##::::'##:'########:::::'#######::'##::::'##:'########:'########::'####:
'##... ##::::'## ##::: ###::'###: ##.....:::::'##.... ##: ##:::: ##: ##.....:: ##.... ##: ####:
 ##:::..::::'##:. ##:: ####'####: ##:::::::::: ##:::: ##: ##:::: ##: ##::::::: ##:::: ##: ####:
 ##::'####:'##:::. ##: ## ### ##: ######:::::: ##:::: ##: ##:::: ##: ######::: ########::: ##::
 ##::: ##:: #########: ##. #: ##: ##...::::::: ##:::: ##:. ##:: ##:: ##...:::: ##.. ##::::..:::
 ##::: ##:: ##.... ##: ##:.:: ##: ##:::::::::: ##:::: ##::. ## ##::: ##::::::: ##::. ##::'####:
. ######::: ##:::: ##: ##:::: ##: ########::::. #######::::. ###:::: ########: ##:::. ##: ####:
:......::::..:::::..::..:::::..::........::::::.......::::::...:::::........::..:::::..::....::"};
            string[] counters = { @":::'##:::
:'####:::
:.. ##:::
::: ##:::
::: ##:::
::: ##:::
:'######:
:......::",
            @":'#######::
'##.... ##:
..::::: ##:
:'#######::
'##::::::::
 ##::::::::
 #########:
.........::",
            @":'#######::
'##.... ##:
..::::: ##:
:'#######::
:...... ##:
'##:::: ##:
. #######::
:.......:::",
            @"'##::::::::
 ##:::'##::
 ##::: ##::
 ##::: ##::
 #########:
...... ##::
:::::: ##::
::::::..:::
",
            @"'########:
 ##.....::
 ##:::::::
 #######::
...... ##:
'##::: ##:
. ######::
:......:::"};

            bool gameOver = false;


            //Type the word in that you will guess here!!!
            string startWord = "airborne";


            char[] maskStartWord = new string('-', startWord.Length).ToCharArray();
            string currentGuessedCharacter = "";
            string guessedCharacterList = "";

            int guessingTries = startWord.Length * 2;
            int violations = 0;

            Console.CursorVisible = false;
            
            for (int i = counters.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(messages[0]);
                Console.WriteLine(counters[i]);
                Thread.Sleep(1000);
                Console.Clear();
            }

            while (!gameOver)
            {
                Console.WriteLine("Guess the word : {0}", new string (maskStartWord));
                Console.WriteLine("Guessed characters: {0} ", guessedCharacterList);
                Console.WriteLine("You have {0} tries left!", guessingTries);
                Console.WriteLine();
                Console.Write("Your next guess is: ");

                currentGuessedCharacter = Console.ReadLine();
                guessedCharacterList += currentGuessedCharacter[0] + ", ";

                if (currentGuessedCharacter.Length > 1)
                {
                    if (violations >=1)
                    {
                        guessingTries--;
                    }

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nYou can only enter ONE letter at a time, dummy!");
                    Console.WriteLine("You will lose two tries for each violation of the rule!");
                    Thread.Sleep(2000);
                    Console.ResetColor();


                    violations++;

                }

                if (startWord.Contains(currentGuessedCharacter[0].ToString()))
                {
                    for (int i = 0; i < startWord.Length; i++)
                    {
                        if (startWord[i] == (currentGuessedCharacter[0]))
                        {
                            maskStartWord[i] = (currentGuessedCharacter[0]);
                        }
                    }
                }
                

                guessingTries--;

                Console.Clear();

                if (guessingTries == 0)
                {
                    gameOver = true;
                    Console.WriteLine(messages[3]);

                }
                else if (!(new string(maskStartWord).Contains('-')))
                {
                    gameOver = true;
                    Console.WriteLine(messages[1]);
                }
            }
        }
    }
}
