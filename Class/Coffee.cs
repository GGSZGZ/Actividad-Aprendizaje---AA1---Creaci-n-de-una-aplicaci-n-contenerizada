namespace Class;

public class Coffee{
    public string? NAME{get;set;}

    public string? DESCRIPTION{get;set;}

    public string? ORIGIN{get;set;}

    public decimal? PRICE{get;set;}

    public bool? SUGAR{get;set;}

    public bool? MILK{get;set;}

    public static List<Coffee> coffeeList = new List<Coffee>();

    public Coffee(){

    }

    public Coffee(string name,string description,string origin,decimal price,bool sugar=false,bool milk=false){
        NAME=name;
        DESCRIPTION=description;
        ORIGIN=origin;
        PRICE=price;
        SUGAR=sugar;
        MILK=milk;
    }

    private void AddCoffee(){
        for (int i = 1; i <= 5; i++)
            {
                Coffee coffee = FillCoffee(i);
                Console.WriteLine($"Coffee {i}:");
                Console.WriteLine($"Name: {coffee.NAME}");
                Console.WriteLine($"Description: {coffee.DESCRIPTION}");
                Console.WriteLine($"Origin: {coffee.ORIGIN}");
                Console.WriteLine($"Price: {coffee.PRICE}");
                Console.WriteLine($"Sugar: {coffee.SUGAR}");
                Console.WriteLine($"Milk: {coffee.MILK}");
                Console.WriteLine();
                coffeeList.Add(coffee);
            }
        }
    private Coffee FillCoffee(int index){
        return new Coffee(
                name: $"Coffee {index}",
                description: $"Description for Coffee {index}",
                origin: $"Origin {index}",
                price: 2.99m + index,
                sugar: (index % 2 == 0), 
                milk: (index % 2 == 0)  
                );
        }
}