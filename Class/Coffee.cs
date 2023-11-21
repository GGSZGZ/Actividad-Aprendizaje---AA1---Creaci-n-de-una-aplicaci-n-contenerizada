namespace Class;

public class Coffee{
    public string? name{get;set;}

    public string? description{get;set;}

    public string? origin{get;set;}

    public decimal? price{get;set;}

    public bool? sugar{get;set;}

    public bool? milk{get;set;}

    public static List<Coffee> coffeeList = new List<Coffee>();

    public Coffee(){

    }

    public Coffee(string name,string description,string origin,decimal price,bool sugar=false,bool milk=false){
        this.name=name;
        this.description=description;
        this.origin=origin;
        this.price=price;
        this.sugar=sugar;
        this.milk=milk;
    }

    public void AddCoffee(){
        for (int i = 1; i <= 5; i++)
            {
                Coffee coffee = FillCoffee(i);
                Console.WriteLine($"Coffee {i}:");
                Console.WriteLine($"Name: {coffee.name}");
                Console.WriteLine($"Description: {coffee.description}");
                Console.WriteLine($"Origin: {coffee.origin}");
                Console.WriteLine($"Price: {coffee.price}");
                Console.WriteLine($"Sugar: {coffee.sugar}");
                Console.WriteLine($"Milk: {coffee.milk}");
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