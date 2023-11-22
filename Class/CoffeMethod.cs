using System.Text.Json;
using Class;

public class CoffeMethod{
    public static List<CoffeeModel> coffeeList = new List<CoffeeModel>();

     public void readJsonCoffee(){

            string jsonString = File.ReadAllText("CoffeeJson.json");
                // Realizar la deserialización del JSON a mi modelo transacciones
                var coffeeRawJson = JsonSerializer.Deserialize<CoffeeModel[]>(jsonString);

       foreach (var item in coffeeRawJson)
       {
                coffeeList.Add(item);
        
       }
               
        


        for (int i = 0; i <coffeeList.Count; i++)
    {
        coffeeList[i].name = (i + 1).ToString() + ": " + coffeeList[i].name;
    }

        

        
                
    }
}