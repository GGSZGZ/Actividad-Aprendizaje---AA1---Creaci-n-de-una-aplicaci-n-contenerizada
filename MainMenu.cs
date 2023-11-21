
using System;
using Class;

public class MainMenu
{
    
    private static string key = "";

    public static void BeginMenu()
    {
        var option = 0;
        var secondOption = 0;

        do
        {
            ShowMenu();
            option = ReadOption();

            switch (option)
            {
                case 1:
                    
                    break;
                case 2:
                    

                    if (key == null)
                    {
                        break;
                    }
                    
                    do
                    {
                        ShowSecondMenu();
                        secondOption = ReadSecondOption();
                        CoffeeMenu(secondOption, key);
                    } while (secondOption != 3);
                    break;

                    case 3:



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

    private static void CoffeeMenu(int secondOption, string key)
    {
        
        switch (secondOption)
        {
            case 1:
                AddCoffee();
                break;
            case 2:
                ShowThirdMenu();
            var option=ReadOption();
                Console.WriteLine("has elegido " + option);
                break;
            case 3:
                
                break;
        }
    }
}
