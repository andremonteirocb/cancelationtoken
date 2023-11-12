using Bogus;

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

var usuarios = new List<string>();

app.MapGet("/sem-cancelation", async (ILogger<Program> logger) =>
{
    try
    {
        logger.LogInformation($"Iniciando o request {DateTime.Now}");

        await Task.Delay(3000);

        usuarios.Add(new Faker().Person.FullName);
        logger.LogInformation($"Finalizando o request {DateTime.Now}");
    }
    catch// (TaskCanceledException ex)
    {
        logger.LogInformation($"Request cancelado {DateTime.Now}");
    }

    return new
    {
        Sucesso = true,
        Data = usuarios
    };
})
.WithName("sem-cancelation");

app.MapGet("/com-cancelation", async (ILogger<Program> logger, CancellationToken cancellation) =>
{
    try
    {
        logger.LogInformation($"Iniciando o request {DateTime.Now}");

        await Task.Delay(3000, cancellation);

        usuarios.Add(new Faker().Person.FullName);
        logger.LogInformation($"Finalizando o request {DateTime.Now}");
    }
    catch// (TaskCanceledException ex)
    {
        logger.LogInformation($"Request cancelado {DateTime.Now}");
    }

    return new
    {
        Sucesso = true,
        Data = usuarios
    };
})
.WithName("com-cancelation");

app.Run();