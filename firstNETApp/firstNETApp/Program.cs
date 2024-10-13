using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Welcome in First NET Application");
//run short circuit not send to other middleware
//if i want to Use be short circuit should identify httpContext and RequestDelehate
app.Use(async ( httpContext,next) =>
{
   await httpContext.Response.WriteAsync("Hello ");
   await next(httpContext);
    await httpContext.Response.WriteAsync("After mid 1 ");
});

app.Use( async ( httpContext,next) =>
{
    await httpContext.Response.WriteAsync("Hello2 ");
   await  next(httpContext);
    await httpContext.Response.WriteAsync("after mid 2 ");
});
app.Run(async (httpContext) =>
{
    await httpContext.Response.WriteAsync("Hello3 ");
    await httpContext.Response.WriteAsync("after mid 3 ");
});
//app.MapPost("/employees/add-employee", async(HttpContext httpcontext)=>{
//    //var key = httpcontext.Request.Headers["myKey"];
//    //await httpcontext.Response.WriteAsync($"Welcome Mahmoud Elwakel  {key}");
//    using (StreamReader stream = new StreamReader(httpcontext.Request.Body))
//    {
//        string body =await stream.ReadToEndAsync();
//        var response = JsonSerializer.Deserialize<Employee>(body);
//        await httpcontext.Response.WriteAsync($"{response?.name} {response?.age} {response?.gender}");

//    } 
//});

app.Run();
class Employee
{
    public string name { get; set; }
    public int age { get; set; }
    public string gender { get; set; }
}