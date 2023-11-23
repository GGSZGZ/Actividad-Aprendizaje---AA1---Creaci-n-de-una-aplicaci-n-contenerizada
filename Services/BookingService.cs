
using System.Text.Json;
using Models;
public class BookingService{
    public static List<Booking> bookingList;
    public static void ShowBookedJson(){
    bookingList = new List<Booking>();
            string jsonString = File.ReadAllText("BookingJson.json");
                // Realizar la deserialización del JSON a mi modelo transacciones
                var bookedRawJson = JsonSerializer.Deserialize<Booking[]>(jsonString);

       foreach (var item in bookedRawJson)
       {
                bookingList.Add(item);

       }
    foreach (var item in bookingList)
    {  
        if(item.booked == false){
            Console.WriteLine(item.ToString());
        }
    }
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
}