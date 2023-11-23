
using System.Text.Json;
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
            Console.WriteLine("*******************************");
            Console.WriteLine("    Detalles de la Reserva");
            Console.WriteLine("*******************************");
            Console.WriteLine("Reserva realizada a fecha: " + item.datebooked);
            Console.WriteLine("Número de la mesa reservada: " + item.desknumber);
            Console.WriteLine("Número de personas: " + item.numberpeople);
            if (!string.IsNullOrEmpty(item.notes))
            {
                Console.WriteLine("Anotaciones: " + item.notes);
            }
            Console.WriteLine("*******************************");

        }
    }
    public static void CancelBooking(string key){

        User user=DictionaryUsers.dictionaryAccounts[key];

     foreach (var item in user.bookings)
        {
            Console.WriteLine("*******************************");
            Console.WriteLine("    Detalles de la Reserva");
            Console.WriteLine("*******************************");
            Console.WriteLine("Reserva realizada a fecha: " + item.datebooked);
            Console.WriteLine("Número de la mesa reservada: " + item.desknumber);
            Console.WriteLine("Número de personas: " + item.numberpeople);
            if (!string.IsNullOrEmpty(item.notes))
            {
                Console.WriteLine("Anotaciones: " + item.notes);
            }
            Console.WriteLine("*******************************");

        }
        Console.Write("Ingrese el número de reserva que desea cancelar: (número de mesa)");
        int cancelOption;

        while (!int.TryParse(Console.ReadLine(), out cancelOption) || cancelOption < 1 || cancelOption>10)
        {
            Console.Write("Entrada inválida. Ingrese un número de reserva válido: ");
        }

        // Restamos 1 porque los índices de la lista comienzan desde 0
        var removeBooking= new Booking();
        foreach (var i in user.bookings)
        {
            if(i.desknumber==cancelOption){
                removeBooking=i;
            }
        }
        user.bookings.Remove(removeBooking);

        Console.WriteLine("Reserva cancelada con éxito.");
        DictionaryUsers.dictionaryAccounts[key]=user;
    }



   public static Booking SelectingBooked(int optionBooked)
{
        
        Console.Write("Ingresa el número de día: ");
        int dia = int.Parse(Console.ReadLine()!);

        
        Console.Write("Ingresa la hora (formato HH:mm): ");
        string horaTexto = Console.ReadLine()!;

        Console.Write("Algún comentario: ");
        string nota=Console.ReadLine()!;
        
        string fechaHoraTexto = $"{dia}/{DateTime.Now.Month}/{DateTime.Now.Year} {horaTexto}";

        
        if (DateTime.TryParse(fechaHoraTexto, out DateTime resultado))
        {
            
            Console.WriteLine(resultado + " y comentario " + nota);
        }
        else
        {
            
           Console.WriteLine("Formato de fecha y hora incorrecto.");
        }

    
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