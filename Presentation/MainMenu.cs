
using Spectre.Console;
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
            BookingService.ShowBookedJson(false);
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
                    key="guest@gmail.com";
                    CoffeeMenu(secondOption, key);

                    break;
            }
        } while (option != 4);
    }

    private static void ShowMenu()
{
    AnsiConsole.MarkupLine(@"[yellow]1:[/] [bold]Crear cuenta[/]");
    AnsiConsole.MarkupLine(@"[yellow]2:[/] [bold]Iniciar sesión[/]");
    AnsiConsole.MarkupLine(@"[yellow]3:[/] [bold]Iniciar sesión como invitado[/]");
    AnsiConsole.MarkupLine(@"[yellow]4:[/] [bold]Salir[/]");
    Console.Write("Elige una opción: ");
}

private static void ShowSecondMenu()
{
        AnsiConsole.MarkupLine(@"[yellow]1:[/] [bold]Pedir café[/]");
        AnsiConsole.MarkupLine(@"[yellow]2:[/] [bold]Reservas[/]");
        AnsiConsole.MarkupLine(@"[yellow]3:[/] [bold]Salir[/]");
        Console.Write("Elige una opción: ");
}

private static void ShowBookingMenu()
{
        
        AnsiConsole.MarkupLine("[yellow]1:[/] [bold]Reservar mesa[/]");
        AnsiConsole.MarkupLine("[yellow]2:[/] [bold]Cancelar mesa[/]");
        AnsiConsole.MarkupLine("[yellow]3:[/] [bold]Mostrar mis reservas[/]");
        AnsiConsole.MarkupLine("[yellow]4:[/] [bold]Salir[/]");
        Console.Write("Elige una opción: ");
}

private static List<Coffee> showCoffeeMenu(){

   List<Coffee> coffeeListUpdated=CoffeeService.CoffeeFilter();
   return coffeeListUpdated;

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
                AnsiConsole.MarkupLine("[red]Debes introducir un valor entre 1 y 4[/]");
            }
            else
            {
                break;
            }
        }
        catch (FormatException)
        {
            AnsiConsole.MarkupLine("[red]Debes introducir un valor numérico[/]");
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
                    AnsiConsole.MarkupLine("[red]Debes introducir un valor entre 1 y 3[/]");
                }
                else
                {
                    break;
                }
            }
            catch (FormatException)
            {
                AnsiConsole.MarkupLine("[red]Debes introducir un valor numérico[/]");
            }
        } while (true);

        return option;
    }

    private static int ReadOptionCB(int contador)
{
    int option;
    do
    {
        try
        {
            option = int.Parse(Console.ReadLine()!);
            if (option <= 0 || option>contador)
            {
                AnsiConsole.MarkupLine("[red]Debes introducir un valor entre 1 y " + contador+"[/]");
            }
            else
            {
                break;
            }
        }
        catch (FormatException)
        {
            AnsiConsole.MarkupLine("[red]Debes introducir un valor numérico[/]");
        }
    } while (true);

    return option;
}

    private static void CoffeeMenu(int secondOption, string key)
    {
        BookingService bookingService= new BookingService();
        switch (secondOption)
        {
            case 1:
            int optionCoffee=0;
            
                List<Coffee> coffeeListUpdated=showCoffeeMenu();
                optionCoffee=ReadOptionCB(coffeeListUpdated.Count);
                
                //cafés
                CoffeeService.AddCoffeeUser(coffeeListUpdated[optionCoffee-1],key);
                
                    ShowSecondMenu();
                    secondOption = ReadSecondOption();
                    CoffeeMenu(secondOption,key);
                break;
            case 2:
            var option=0;
            do{
                ShowBookingMenu();
                option=ReadOption();
                switch (option){
                    case 1:
                        BookingService.ShowBookedJson(true);
                        int optionBooked=ReadOptionCB(10); 
                    if(BookingService.bookingList[optionBooked-1].booked==true){
                            Console.WriteLine("Lo sentimos esta mesa no esta disponible");
                            break;
                        }else{
                        Booking booked=BookingService.SelectingBooked(optionBooked);
                        DictionaryUsers.dictionaryAccounts[key].bookings.Add(booked);
                        UserService.WriteJsonUser();
                        
                    }
                    break;
                    case 2:
                    //cancelar reserva
                    BookingService.CancelBooking(key);
                    UserService.WriteJsonUser();
                    break;
                    case 3:
                    //ver reservas
                    BookingService.ShowPersonalBookings(key);
                    break;
                    
                    
                }
            }while(option!=4);
                    ShowSecondMenu();
                    secondOption = ReadSecondOption();
                    CoffeeMenu(secondOption,key);
                break;
            case 3:
                CheckGuest();
                break;
        }
    }
}
