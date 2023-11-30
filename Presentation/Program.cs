using Services;
AppDomain.CurrentDomain.ProcessExit += OnProcessExit!;
MainMenu.BeginMenu();

static void OnProcessExit(object sender, EventArgs e)
    {
        BookingService.RebootJsonBooked();
    }
