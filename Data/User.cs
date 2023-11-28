namespace Data;
using Models;

public class User{

    public string? name{get;set;}

    public string? surname{get;set;}

    public int? age{get;set;}
    
    public List<Booking> bookings=new List<Booking>();
    
    public List<Coffee> userCoffees=new List<Coffee>();

    public DateTime date {get;set;}

    public string? password{get;set;}
    
    public string? email{get;set;}



    //CONSTRUCTOR
    public User(string password,string name = "GUEST", string surname = "GUEST", int age = 0,string email="guest@gmail.com"){
    date = DateTime.Now.Date;
    this.name = name;
    this.surname = surname;
    this.age = age;
    this.password = password;
    this.email=email;
    
}

public bool isLogged(){
    if (name == "GUEST" && surname == "GUEST")
    {   
        return false;
    }else{
        return true;
    }
}

 public override string ToString()
    {
        return $"Name: {name ?? "N/A"}, Surname: {surname ?? "N/A"}, Age: {age?.ToString() ?? "N/A"}, Password: {password ?? "N/A"}";
    }
}