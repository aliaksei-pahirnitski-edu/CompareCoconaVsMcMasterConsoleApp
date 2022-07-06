using Cocona;
using Cocona.Lite;
using Services.EF;

// CoconaLiteApp ( without normal DI!!!! - see ICoconaLightServicesCollection)
var coconaBuilder = CoconaLiteApp.CreateBuilder(args);

// coconaBuilder.Services.AddSqLiteBlogs(); // ? ICoconaLightServicesCollection
// coconaBuilder.Services.AddBlogServices();

var app = coconaBuilder.Build();

app.UseFilter((context, deleg) =>
{
    Console.WriteLine($"filter context: {context} [{context.CommandTarget}] ({context.Command}) <{context.ParsedCommandLine}>");
    Console.WriteLine($"filter CommandTarget: [{context.CommandTarget?.GetType()}] ");
    Console.WriteLine($"filter Command: [{context.Command?.Name}]  [{context.Command?.Arguments}]  [{context.Command?.Options}]  [{context.Command?.CommandType}]  ");
    Console.WriteLine($"filter ParsedCommandLine: [{context.ParsedCommandLine?.Arguments}] [{context.ParsedCommandLine?.Options}] ");
    if (context.Command?.Arguments.Count > 3) // example of validation, for example user has no permissions
    {
        Console.WriteLine($"too manu arguments");
        return ValueTask.FromResult(-1);
    }
    var result = deleg.Invoke(context!);
    Console.WriteLine($"result completed={result.IsCompleted}");
    return result;
});

// var app = CoconaLiteApp.Create(args);

app.AddCommand("hallo", ([Option('n')]string name) => { Console.WriteLine($"Hallo {name} with using Cocona "); });

/// <summary>
/// bFlag -> b-flag
/// anArg -> anArg
/// </summary>
app.AddCommand("testExc", async (bool bFlag, [Argument]string anArg) => {
    Console.WriteLine($"test.... {bFlag} {anArg}");
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    throw new ApplicationException("My business logic exception");
    Console.WriteLine($"test end.... ");
});



app.AddCommand("clone", async () => {
    Console.WriteLine("Starting.... ");
    await Task.Delay(TimeSpan.FromMilliseconds(1500));
    // Console.WriteLine("In Middle.... ");
    // await Task.Delay(TimeSpan.FromMilliseconds(2000));
    Console.WriteLine("Ending.... ");
});


app.Run();
Console.WriteLine("Finish!");

