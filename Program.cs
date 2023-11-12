var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

List<string> requests = new List<string>();
app.MapGet("/datas", async (ILogger<Program> logger, CancellationToken cancellation) =>
{
    try
    {
        logger.LogInformation($"Iniciando o request {DateTime.Now}");

        await Task.Delay(5000, cancellation);

        requests.Add(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
        logger.LogInformation($"Finalizando o request {DateTime.Now}");
    }
    catch// (TaskCanceledException ex)
    {
        logger.LogInformation($"Request cancelado {DateTime.Now}");
    }

    return new
    {
        Sucesso = true,
        Data = requests
    };
})
.WithName("datas");

app.Run();