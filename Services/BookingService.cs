
using System.Text.Json;
using Spectre.Console;
using Data;
using Models;
public class BookingService{
    public static List<Booking> ?bookingList;
    public static void ShowBookedJson(bool show){
    bookingList = new List<Booking>();
            string jsonString = File.ReadAllText("BookingJson.json");
                // Realizar la deserialización del JSON a mi modelo transacciones
                var bookedRawJson = JsonSerializer.Deserialize<Booking[]>(jsonString);

       foreach (var item in bookedRawJson!)
       {
                bookingList.Add(item);

       }
       if(show==true){
            foreach (var item in bookingList)
            {  
                if(item.booked == false){
                    Console.WriteLine(item.ToString());
                }
            }
       }
}

    public static void ShowPersonalBookings(string key){

        User user=DictionaryUsers.dictionaryAccounts[key];
        foreach (var item in user.bookings)
        {
            AnsiConsole.MarkupLine("[blue]*******************************[/]");
            AnsiConsole.MarkupLine("[green]    Detalles de la Reserva[/]");
            AnsiConsole.MarkupLine("[green]*******************************[/]");

            AnsiConsole.MarkupLine("[green]Reserva realizada a fecha: "+item.datebooked+"[/]");
            AnsiConsole.MarkupLine("[green]Número de la mesa reservada: "+item.desknumber+"[/]");
            AnsiConsole.MarkupLine("[green]Número de personas: "+item.numberpeople+"[/]");
    
            if (!string.IsNullOrEmpty(item.notes))
            {
            AnsiConsole.MarkupLine("[green]Anotaciones: "+item.notes+"[/]");      
            }
            AnsiConsole.MarkupLine("[blue]*******************************[/]");
        }
    }
    public static void CancelBooking(string key){

        User user=DictionaryUsers.dictionaryAccounts[key];

     foreach (var item in user.bookings)
        {
             AnsiConsole.MarkupLine("[blue]*******************************[/]");
            AnsiConsole.MarkupLine("[green]    Detalles de la Reserva[/]");
            AnsiConsole.MarkupLine("[green]*******************************[/]");

            AnsiConsole.MarkupLine("[green]Reserva realizada a fecha: "+item.datebooked+"[/]");
            AnsiConsole.MarkupLine("[green]Número de la mesa reservada: "+item.desknumber+"[/]");
            AnsiConsole.MarkupLine("[green]Número de personas: "+item.numberpeople+"[/]");
            if (!string.IsNullOrEmpty(item.notes))
            {
                AnsiConsole.MarkupLine("[green]Anotaciones: "+item.notes+"[/]"); 
            }
            AnsiConsole.MarkupLine("[blue]*******************************[/]");

        }
         int cancelOption;
        while (true)
        {
            
            if (!int.TryParse(AnsiConsole.Prompt(new TextPrompt<string>("[yellow]Ingrese el número de reserva que desea cancelar: (número de mesa)[/]")), out cancelOption) || cancelOption < 1 || cancelOption>10)

            {
                AnsiConsole.MarkupLine("[red]Entrada inválida. Ingrese un número de reserva válido: [/]");
                
                Logger.SaveLog(Logger.GetExceptionMessage());
            }
            else
            {
                break;
            }
        }

        // Restamos 1 porque los índices de la lista comienzan desde 0
        var removeBooking= new Booking();
        bool exitCancel=false;
        foreach (var i in user.bookings)
        {
            if(i.desknumber==cancelOption){
                removeBooking=i;
                exitCancel=true;
            }
        }
        if(exitCancel==false){
            AnsiConsole.MarkupLine("[red]No se encontró la reserva[/]");
            Logger.SaveLog("Booking not founded.");
        }
        user.bookings.Remove(removeBooking);
        foreach (var item in bookingList!){
            if(removeBooking.desknumber==item.desknumber){
                item.booked=false;
                item.userLogged=false;
                ModifyJsonBooked();
            }
        }
        if(exitCancel==true){
        AnsiConsole.MarkupLine("[green]Reserva cancelada con éxito.[/]");
        DictionaryUsers.dictionaryAccounts[key]=user;
        }
    }



   public static Booking SelectingBooked(int optionBooked,User user)
{
    

        int dia;
        while (true)
        {
            
            if (int.TryParse(AnsiConsole.Prompt(new TextPrompt<string>("[yellow]Ingresa el número de día:[/]")), out dia))
            {
                break;
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Por favor, ingrese el formato correcto[/]");
                Logger.SaveLog(Logger.GetExceptionMessage());
            }
        }

        string horaTexto = AnsiConsole.Ask<string>("[yellow]Ingresa la hora (formato HH:mm): [/]");


        string nota = AnsiConsole.Ask<string>("[yellow]Algún comentario: [/]");
        
        string fechaHoraTexto = $"{dia}/{DateTime.Now.Month}/{DateTime.Now.Year} {horaTexto}";

        
        if (DateTime.TryParse(fechaHoraTexto, out DateTime resultado))
        {
            
           AnsiConsole.MarkupLine("[green]"+resultado+" y comentario "+nota+"[/]");
        }
        else
        {
            
           AnsiConsole.MarkupLine("[red]Formato de fecha y hora incorrecto.[/]");
           Logger.SaveLog(Logger.GetExceptionMessage());
        }
    
    bookingList[optionBooked-1].userLogged=user.isLogged();
    bookingList[optionBooked-1].booked=true;
    bookingList[optionBooked-1].datebooked=resultado;
    bookingList[optionBooked-1].notes=nota;
    ModifyJsonBooked();
    return bookingList[optionBooked-1];

}

    public static void ModifyJsonBooked(){
      string updatedJson=JsonSerializer.Serialize(bookingList, new JsonSerializerOptions { WriteIndented = true });
      File.WriteAllText("BookingJson.json", updatedJson);
    }

    public static void RebootJsonBooked(){
        foreach (var item in bookingList)
        {
            item.userLogged=false;
            item.booked=false;
        }
        ModifyJsonBooked();
    
    }
}