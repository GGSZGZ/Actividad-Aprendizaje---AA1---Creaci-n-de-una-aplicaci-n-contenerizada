using System.Text.Json;
using Class;

public class CoffeMethod{
    public static List<CoffeeModel> coffeeList = new List<CoffeeModel>();


    // public void AddCoffee(){
    //     for (int i = 1; i <= 5; i++)
    //         {
    //             CoffeeModel coffee = FillCoffee(i);
    //             Console.WriteLine($"Coffee {i}:");
    //             Console.WriteLine($"Name: {coffee.name}");
    //             Console.WriteLine($"Description: {coffee.description}");
    //             Console.WriteLine($"Origin: {coffee.origin}");
    //             Console.WriteLine($"Price: {coffee.price}");
    //             Console.WriteLine($"Sugar: {coffee.sugar}");
    //             Console.WriteLine($"Milk: {coffee.milk}");
    //             Console.WriteLine();
    //             coffeeList.Add(coffee);
    //         }
    //     }
    // private CoffeeModel FillCoffee(int index){
    //     return new CoffeeModel(
    //             name: $"Coffee {index}",
    //             description: $"Description for Coffee {index}",
    //             origin: $"Origin {index}",
    //             price: 2.99m + index,
    //             sugar: (index % 2 == 0), 
    //             milk: (index % 2 == 0)  
    //             );
    //     }


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