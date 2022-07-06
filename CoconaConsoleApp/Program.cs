using Cocona;
using Services;
using CoconaConsoleApp;

// CoconaApp ( with DI)
var coconaBuilder = CoconaApp.CreateBuilder(args);

coconaBuilder.Services.AddSqLiteBlogs(); 
coconaBuilder.Services.AddBlogServices();

var app = coconaBuilder.Build();


app.AddCommand("hallo", ([Option('n')] string name) => { Console.WriteLine($"Hallo {name} with using Cocona "); });

app.AddCommands<BlogCommands>();

app.AddSubCommand("blog", b =>
{
    b.AddCommands<BlogCommentsSubCommands>();
});

/// <summary>
/// bFlag -> b-flag
/// anArg -> anArg
/// </summary>
app.AddCommand("testExc", async (bool bFlag, [Argument] string anArg) => {
    Console.WriteLine($"test.... {bFlag} {anArg}");
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    throw new ApplicationException("My business logic exception");
    Console.WriteLine($"test end.... ");
});

await app.RunAsync();
Console.WriteLine("Finish!");