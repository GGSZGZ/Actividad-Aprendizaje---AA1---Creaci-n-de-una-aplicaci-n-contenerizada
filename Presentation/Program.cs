namespace Presentation;
using Services;

public class Program{
    public static void Main(){
        AppDomain.CurrentDomain.ProcessExit += OnProcessExit!;
        MainMenu.BeginMenu();
    }
    static void OnProcessExit(object sender, EventArgs e)
    {
        BookingService.RebootJsonBooked();
    }
}



