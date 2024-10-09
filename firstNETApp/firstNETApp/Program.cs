using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Welcome in First NET Application");
app.MapPost("/employees/add-employee", async(HttpContext httpcontext)=>{
    //var key = httpcontext.Request.Headers["myKey"];
    //await httpcontext.Response.WriteAsync($"Welcome Mahmoud Elwakel  {key}");
    using (StreamReader stream = new StreamReader(httpcontext.Request.Body))
    {
        string body =await stream.ReadToEndAsync();
        var response = JsonSerializer.Deserialize<Employee>(body);
        await httpcontext.Response.WriteAsync($"{response?.name} {response?.age} {response?.gender}");
        await httpcontext.Response.WriteAsync("Welcome to Revert Testing");
    } 
});

app.Run();
class Employee
{
    public string name { get; set; }
    public int age { get; set; }
    public string gender { get; set; }
}