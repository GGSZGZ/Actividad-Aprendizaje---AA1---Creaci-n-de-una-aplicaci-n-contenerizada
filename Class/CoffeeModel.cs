namespace Class;

public class CoffeeModel{
    public string? name{get;set;}

    public string? description{get;set;}

    public string? origin{get;set;}

    public decimal? price{get;set;}

    public bool? sugar{get;set;}

    public bool? milk{get;set;}

    

    public CoffeeModel(){

    }

    public CoffeeModel(string name,string description,string origin,decimal price,bool sugar=false,bool milk=false){
        this.name=name;
        this.description=description;
        this.origin=origin;
        this.price=price;
        this.sugar=sugar;
        this.milk=milk;
    }


    public override string ToString()
        {
            return $"Name: {name}, Description: {description}, Origin: {origin}, Price: {price}, Sugar: {sugar}, Milk: {milk}";
        }

    
}