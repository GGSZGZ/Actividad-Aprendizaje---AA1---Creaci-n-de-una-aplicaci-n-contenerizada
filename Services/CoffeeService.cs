namespace Services;
using System.Text.Json;
using Models;

public class CoffeeService{
    public static List<Coffee> coffeeList;
    // public static List<Coffee> backupCoffeeList;

     public void readJsonCoffee(){
        coffeeList = new List<Coffee>();
        // backupCoffeeList = new List<Coffee>();
            string jsonString = File.ReadAllText("CoffeeJson.json");
                // Realizar la deserialización del JSON a mi modelo transacciones
                var coffeeRawJson = JsonSerializer.Deserialize<Coffee[]>(jsonString);

       foreach (var item in coffeeRawJson)
       {
                coffeeList.Add(item);
        
       }
      //  backupCoffeeList=coffeeList;


    //     for (int i = 0; i <coffeeList.Count; i++)
    // {
    //     coffeeList[i].name = (i + 1).ToString() + ": " + coffeeList[i].name;
    // }   
    }

    public static void SaveListCoffee(){
        // coffeeList=backupCoffeeList;
    }

    public static void AddCoffeeUser(Coffee optionCoffe,string key){

        DictionaryUsers.dictionaryAccounts[key].userCoffees.Add(optionCoffe);
        UserService.WriteJsonUser();
        foreach (var item in coffeeList)
        {
            int numeroAleatorio = new Random().Next(1, 101);
            if(item.Equals(optionCoffe)){
                Console.WriteLine("Has elegido el siguiente café: " + item.ToString());
                Console.WriteLine("Pase por caja con el siguiente número " + numeroAleatorio + " para pagar.");
            }
        }
    }
    public static List<Coffee> CoffeeFilter(){
        
        List<Coffee>coffeeListUpdated=new List<Coffee>();
        int contador=0;
        Console.WriteLine("¿Quieres azúcar?(si/no)");
        var optionSugar=Console.ReadLine()!.ToUpper();
        Console.WriteLine("¿Quieres leche?(si/no)");
        var optionMilk=Console.ReadLine()!.ToUpper();
        if(optionMilk.Equals("SI") && optionSugar.Equals("SI")){
            
            foreach (var item in coffeeList)
            {
              if(item.sugar==true && item.milk==true){
                Console.WriteLine((contador+1)+"-"+item.ToString());
                contador++;
                coffeeListUpdated.Add(item);
              }  
            }
        }else if(optionMilk.Equals("NO") && optionSugar.Equals("SI")){
            foreach (var item in coffeeList)
            {
              if(item.sugar==true && item.milk==false){
                Console.WriteLine((contador+1)+"-"+item.ToString());
                contador++;
                coffeeListUpdated.Add(item);
              }  
            }
        }else if(optionMilk.Equals("SI") && optionSugar.Equals("NO")){
            foreach (var item in coffeeList)
            {
              if(item.sugar==false && item.milk==true){
                Console.WriteLine((contador+1)+"-"+item.ToString());
                contador++;
                coffeeListUpdated.Add(item);
              }  
            }

        }else{
            foreach (var item in coffeeList)
            {
              if(item.sugar==false && item.milk==false){
                 Console.WriteLine((contador+1)+"-"+item.ToString());
                 contador++;
                 coffeeListUpdated.Add(item);
              }  
            }
        }
        // coffeeList=coffeeListUpdated;
        return coffeeListUpdated;


    }
}