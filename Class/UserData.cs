namespace Class;

public class UserData{

    public string? NAME{get;set;}

    public string? SURNAME{get;set;}
    public int? AGE{get;set;}
    
    private List<Booking>bookings=new List<Booking>();
    public DateTime DATE {get;set;}
    public string? KEY{get;set;}

    public UserData(){
        
    }

    public UserData(string name,string surname,int age,DateTime date,string key){
        DATE = date == default ? DateTime.Now.Date : date;
        NAME=name;
        SURNAME=surname;
        AGE=age;
        KEY=key;
    }




   





}