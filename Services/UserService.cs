namespace Services;
using Spectre.Console;
using System.Text.RegularExpressions;
using Data;
using Models;
using System.Text.Json;

public class UserService{
     public string CreateUser()
    {
        
        string name = AnsiConsole.Ask<string>("[yellow]Nombre del usuario:[/]");
        
        
        string surname = AnsiConsole.Ask<string>("[yellow]Apellidos:[/]");

        int age;
        while (true)
        {
            
            if (int.TryParse(AnsiConsole.Prompt(new TextPrompt<string>("[yellow]Ingrese su edad:[/]")), out age))
            {
                break;
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Por favor, ingrese una edad válida[/]");
                Logger.SaveLog(Logger.GetExceptionMessage());
            }
        }

        string email;
        do
        {
            
            email = AnsiConsole.Ask<string>("[yellow]Ingrese su correo electrónico:[/]");

            if (DictionaryUsers.dictionaryAccounts.ContainsKey(email) || ValidarEmail(email)==false)
            {
                AnsiConsole.MarkupLine("[red]Ingrese un correo electrónico válido[/]");
            }
            else
            {
                break;
            }
        } while (true);

        string password;
        do
        {
            
            password = AnsiConsole.Ask<string>("[yellow]Ingrese su contraseña:[/]");
            
            
            if (EsNumero(password))
            {
                AnsiConsole.MarkupLine("[red]La contraseña debe contener caracteres numéricos y letras[/]");
            }
            else
            {
                User user = new User(password, name, surname, age, email);
                DictionaryUsers.dictionaryAccounts.Add(email, user);
                AnsiConsole.MarkupLine("[green]Usuario creado correctamente[/]");
                return email;
            }
        } while (true);

    }

    public void CreateGuest(){
        string guestUser = Environment.GetEnvironmentVariable("USER_GUEST");
        if(guestUser=="" || guestUser==null){
            guestUser="guest@gmail.com";
        }
                User user=new User(guestUser);
                DictionaryUsers.dictionaryAccounts.Add(user.email!, user);

    }

    public static bool EsNumero(string input){
        double resultado;
        return double.TryParse(input, out resultado);
    }

    public bool ValidarEmail(string email){
        return email != null && Regex.IsMatch(email, "^(([\\w-]+\\.)+[\\w-]+|([a-zA-Z]{1}|[\\w-]{2,}))@(([a-zA-Z]+[\\w-]+\\.){1,2}[a-zA-Z]{2,4})$");
    }


    public bool Login()
{

     string email = AnsiConsole.Ask<string>("[yellow]Dime tu correo:[/]");
     string pass = AnsiConsole.Ask<string>("[yellow]Dime la contraseña:[/]");


    if (DictionaryUsers.dictionaryAccounts.ContainsKey(email) && DictionaryUsers.dictionaryAccounts[email].password == pass)
    {
        AnsiConsole.MarkupLine("[green]Inicio de sesión exitoso[/]");
        return true;
    }
    else
    {
        AnsiConsole.MarkupLine("[red]Correo o contraseña incorrecta[/]");
        return false;
    }
}

    


    public static void WriteJsonUser(){
        string filePath = "Data/users.json";
        var jsonData = new List<Dictionary<string, object>>();

        foreach (var userEntry in DictionaryUsers.dictionaryAccounts)
        {
            var user = userEntry.Value;

            var bookingsArray = user.bookings.Select(booking =>
                new
                {
                    DateBooked = booking.datebooked,
                    UserLogged = booking.userLogged,
                    DeskNumber = booking.desknumber,
                    NumberPeople = booking.numberpeople,
                    Booked = booking.booked,
                    Notes = booking.notes
                }).ToArray();

            var userCoffeesArray = user.userCoffees.Select(coffee =>
                new
                {
                    Name = coffee.name,
                    Description = coffee.description,
                    Origin = coffee.origin,
                    Price = coffee.price,
                    Sugar = coffee.sugar,
                    Milk = coffee.milk
                }).ToArray();

            var userData = new Dictionary<string, object>
            {
                {"Name", user.name ?? ""},
                {"Surname", user.surname ?? ""},
                {"Age", user.age ?? 0},
                {"Bookings", bookingsArray},
                {"UserCoffees", userCoffeesArray},
                {"Date", user.date},
                {"Password", user.password ?? ""},
                {"Email", user.email ?? ""}
            };
            jsonData.Add(userData);
        }

        string jsonString = JsonSerializer.Serialize(jsonData, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(filePath, jsonString);
    }
}