using Cocona;

// CoconaApp ( with DI)
var coconaBuilder = CoconaLiteApp.CreateBuilder(args);
var app = coconaBuilder.Build();

// var app = CoconaLiteApp.Create(args);

app.AddCommand("hallo", ([Option('n')]string name) => { Console.WriteLine($"Hallo {name} with using Cocona "); });
app.AddCommand("clone", async () => {
    Console.WriteLine("Starting.... ");
    await Task.Delay(TimeSpan.FromMilliseconds(1500));
    // Console.WriteLine("In Middle.... ");
    // await Task.Delay(TimeSpan.FromMilliseconds(2000));
    Console.WriteLine("Ending.... ");
});


app.Run();
Console.WriteLine("Finish!");

