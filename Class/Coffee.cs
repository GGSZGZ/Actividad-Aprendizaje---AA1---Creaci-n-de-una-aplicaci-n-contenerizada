namespace Class;

public class Coffee{
    public string? NAME{get;set;}
    public string? DESCRIPTION{get;set;}
    public string? ORIGIN{get;set;}
    public decimal? PRICE{get;set;}
    public bool? SUGAR{get;set;}
    public bool? MILK{get;set;}


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
    
}