
using Models;
using Services;

public class MainMenu
{
    
    private static string key = "";
   
   
    

    public static void BeginMenu(){
        CoffeeService coffeMethod=new CoffeeService();
        UserService credentials=new UserService();
        coffeMethod.readJsonCoffee();
         
        var option = 0;
        var secondOption = 0;

        do
        {
            ShowMenu();
            option = ReadOption();
           
            switch (option)
            {
                case 1:
                    key=credentials.CreateUser();
                    break;
                case 2:

                   bool success= credentials.Login();
                   if(success==true){
                    do
                    {
                        UserService.WriteJsonUser();
                        ShowSecondMenu();
                        secondOption = ReadSecondOption();
                        CoffeeMenu(secondOption, key);
                    } while (secondOption != 3);
                   }
                    break;

                    case 3:
                    Console.WriteLine("Sesión iniciada como invitado");
                    credentials.CreateGuest();
                    UserService.WriteJsonUser();
                    ShowSecondMenu();
                    secondOption = ReadSecondOption();
                    CoffeeMenu(secondOption, key);

                    break;
            }
        } while (option != 4);
        
    }

    private static void ShowMenu()
{
    Console.WriteLine("1:Crear cuenta");
    Console.WriteLine("2:Iniciar sesión");
    Console.WriteLine("3:Iniciar sesión como invitado");
    Console.WriteLine("4:Salir");
    Console.Write("Elige una opción: ");
}

private static void ShowSecondMenu()
{
    
        Console.WriteLine("1:Pedir café");
        Console.WriteLine("2:Reservas");
        Console.WriteLine("3:Salir");
        Console.Write("Elige una opción: ");
}

private static void ShowThirdMenu()
{
    
        Console.WriteLine("1:Reservar mesa");
        Console.WriteLine("2:Cancelar mesa");
        Console.WriteLine("3:Salir");
        Console.Write("Elige una opción: ");
}

private static void showCoffeeMenu(){

  foreach (var item in CoffeeService.coffeeList)
        {
            Console.WriteLine(item.ToString());
        } 

}

private static void CheckGuest(){
    if(DictionaryUsers.dictionaryAccounts.ContainsKey("guest@gmail.com")){
            DictionaryUsers.dictionaryAccounts.Remove("guest@gmail.com");
            UserService.WriteJsonUser();
        }
}

    

    private static int ReadOption()
{
    int option;
    do
    {
        try
        {
            option = int.Parse(Console.ReadLine()!);
            if (option <= 0 || option > 4)
            {
                Console.WriteLine("Debes introducir un valor entre 1 y 4");
            }
            else
            {
                break;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Debes introducir un valor numérico");
        }
    } while (true);

    return option;
}


    private static int ReadSecondOption()
    {
        int option;

        do
        {
            try
            {
                option = int.Parse(Console.ReadLine()!);

                if (option < 1 || option > 3)
                {
                    
                    Console.WriteLine("Debes introducir valores comprendidos entre 1 y 3");
                }
                else
                {
                    break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Debes introducir valores numéricos");
            }
        } while (true);

        return option;
    }

    private static int ReadCoffeeOption()
{
    int option;
    do
    {
        try
        {
            option = int.Parse(Console.ReadLine()!);
            if (option <= 0 || option > 10)
            {
                Console.WriteLine("Debes introducir un valor entre 1 y 10");
            }
            else
            {
                break;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Debes introducir un valor numérico");
        }
    } while (true);

    return option;
}

    private static void CoffeeMenu(int secondOption, string key)
    {
        
        switch (secondOption)
        {
            case 1:
                showCoffeeMenu();
                var opctionCoffee=ReadCoffeeOption();
                
                break;
            case 2:
                ShowThirdMenu();
            var option=ReadOption();
                Console.WriteLine("has elegido " + option);
                break;
            case 3:
                CheckGuest();
                break;
        }
    }
}
