namespace Services;
using System.Text.Json;
using Models;

public class CoffeeService{
    public static List<Coffee> coffeeList;

     public void readJsonCoffee(){
        coffeeList = new List<Coffee>();
            string jsonString = File.ReadAllText("CoffeeJson.json");
                // Realizar la deserialización del JSON a mi modelo transacciones
                var coffeeRawJson = JsonSerializer.Deserialize<Coffee[]>(jsonString);

       foreach (var item in coffeeRawJson)
       {
                coffeeList.Add(item);
        
       }


        for (int i = 0; i <coffeeList.Count; i++)
    {
        coffeeList[i].name = (i + 1).ToString() + ": " + coffeeList[i].name;
    }   
    }

    public static void AddCoffeeUser(int optionCoffe,string key){

        DictionaryUsers.dictionaryAccounts[key].userCoffees.Add(coffeeList[optionCoffe-1]);
        UserService.WriteJsonUser();
        foreach (var item in coffeeList)
        {
            int numeroAleatorio = new Random().Next(1, 101);
            if(item.Equals(coffeeList[optionCoffe-1])){
                Console.WriteLine("Has elegido el siguiente café: " + item.ToString());
                Console.WriteLine("Pase por caja con el siguiente número " + numeroAleatorio + " para pagar.");
            }
        }


    }
}