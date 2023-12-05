using System;
using System.Collections;
using System.Xml;
using System.Diagnostics.SymbolStore;
using System.Resources;
using System.Reflection;
using System.Threading;
using System.Globalization;

//코드 정리할 것 목록: InputHandler 부분 => void 대신 string 쓰는 건 어떰?
class GameTitle
{
    static ResourceManager text = 
        new ResourceManager("Console1.Languages.lang", Assembly.GetExecutingAssembly());
    static string command = "";

    static void Main() // 시작 전 세팅
    {
        Console.ForegroundColor = ConsoleColor.White;
        UserLang();
        Lobby();
    }
    static void UserLang(string userLang = "en") //유저언어세팅
    {

        Thread.CurrentThread.CurrentUICulture = 
            CultureInfo.CreateSpecificCulture(userLang); /* https://www.youtube.com/watch?v=QZtW9S-WvPA */
    }

    static string? BringText(string resxName = "Empty_Text")
    {
        try { return text.GetString(resxName); } 
        catch { return $"({resxName})"; } 
    }

    static string InputHandler() //유저 입력을 제어
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        string userInput = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();
        return userInput.Trim(); //Trim() : 양쪽 공백 제거
    }

    static void Lobby() // 로비
    {
        
        Console.WriteLine($"{BringText("Title_name")} \n\n");
        Console.WriteLine($"1){BringText("Title_start")} \n");
        Console.WriteLine($"2){BringText("Title_option")} \n");
        
        command = InputHandler();
            
        if (command == "1" || command == BringText("Title_start"))
        {
            //구현하기
        }
        else if (command == "2" || command == BringText("Title_option"))
        {
            OptionSpace();
        }
        else{ Lobby(); }
    }


    static void OptionSpace()
    {
        Console.WriteLine("1)English");
        Console.WriteLine("2)한국어");
        command = InputHandler();
        if (command == "English" || command == "1") { UserLang("en"); }
        else if (command == "한국어" || command == "2") { UserLang("ko"); }
        Lobby();
    }
}
/*





 
 */


