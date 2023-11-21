namespace Class;

public class Booking{


    public DateTime DATEBOOKED {get;set;}

    private List<Coffee> bookingCoffees=new List<Coffee>();

    public decimal? DESKNUMBER {get;set;}

    public int? NUMBERPEOPLE {get;set;}

    public bool? BOOKED {get;set;}

    public string? NOTES {get;set;}


    public Booking(){

    }

    public Booking(DateTime datebooked,decimal desknumber,int numberpeople,bool booked=false,string notes=""){
         DATEBOOKED = datebooked == default ? DateTime.Now.Date : datebooked;
         DESKNUMBER=desknumber;
         NUMBERPEOPLE=numberpeople;
         BOOKED=booked;
         NOTES=notes;
    }

}