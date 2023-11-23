
using System.Text.Json;
using Models;
public class BookingService{
public static List<Booking> bookingList = new List<Booking>();
    public static void ShowBookedJson(){

            string jsonString = File.ReadAllText("BookingJson.json");
                // Realizar la deserialización del JSON a mi modelo transacciones
                var bookedRawJson = JsonSerializer.Deserialize<Booking[]>(jsonString);

       foreach (var item in bookedRawJson)
       {
                bookingList.Add(item);
        
       }
  

}
}