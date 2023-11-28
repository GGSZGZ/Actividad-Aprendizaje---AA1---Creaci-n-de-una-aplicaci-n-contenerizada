namespace Services;
using Spectre.Console;
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
    }

    public static void AddCoffeeUser(Coffee optionCoffe,string key){

        DictionaryUsers.dictionaryAccounts[key].userCoffees.Add(optionCoffe);
        UserService.WriteJsonUser();
        foreach (var item in coffeeList)
        {
            int numeroAleatorio = new Random().Next(1, 101);
            if(item.Equals(optionCoffe)){
              AnsiConsole.MarkupLine("[green]Has elegido el siguiente café: "+ item.ToString()+ "[/]");
              AnsiConsole.MarkupLine("[green]Pase por caja con el siguiente número "+ numeroAleatorio+ " para pagar[/]");
            }
        }
    }
    public static List<Coffee> CoffeeFilter(){
        
        List<Coffee>coffeeListUpdated=new List<Coffee>();
        int contador=0;

       var optionSugar = AnsiConsole.Ask<string>("[yellow]¿Quieres azúcar?(si/no)[/]").ToUpper();
       var optionMilk = AnsiConsole.Ask<string>("[yellow]¿Quieres leche?(si/no)[/]").ToUpper();

        if(optionMilk.Equals("SI") && optionSugar.Equals("SI")){
            
            foreach (var item in coffeeList)
            {
              if(item.sugar==true && item.milk==true){
                AnsiConsole.MarkupLine("[blue]"+(contador+1)+"-"+item.ToString()+"[/]");
                contador++;
                coffeeListUpdated.Add(item);
              }  
            }
        }else if(optionMilk.Equals("NO") && optionSugar.Equals("SI")){
            foreach (var item in coffeeList)
            {
              if(item.sugar==true && item.milk==false){
                AnsiConsole.MarkupLine("[blue]"+(contador+1)+"-"+item.ToString()+"[/]");
                contador++;
                coffeeListUpdated.Add(item);
              }  
            }
        }else if(optionMilk.Equals("SI") && optionSugar.Equals("NO")){
            foreach (var item in coffeeList)
            {
              if(item.sugar==false && item.milk==true){
                AnsiConsole.MarkupLine("[blue]"+(contador+1)+"-"+item.ToString()+"[/]");
                contador++;
                coffeeListUpdated.Add(item);
              }  
            }

        }else{
            foreach (var item in coffeeList)
            {
              if(item.sugar==false && item.milk==false){
                 AnsiConsole.MarkupLine("[blue]"+(contador+1)+"-"+item.ToString()+"[/]");
                 contador++;
                 coffeeListUpdated.Add(item);
              }  
            }
        }
        return coffeeListUpdated;


    }
}