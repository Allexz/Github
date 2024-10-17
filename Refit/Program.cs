using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Refit;
using RefitExample.Model;
using RefitExample.Services;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

GitHubSettings settingValue = builder.Configuration.GetSection("GitHubSettings").Get<GitHubSettings>() !;

builder.Services.AddRefitClient<IGitHubApi>(new RefitSettings
{
    ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
    {
        ContractResolver = new CamelCasePropertyNamesContractResolver(),
        NullValueHandling = NullValueHandling.Ignore
    })
}) .ConfigureHttpClient((setting, client) =>
    {
        
        GitHubSettings? settings = setting
        .GetRequiredService<IOptions<GitHubSettings>>()
        .Value;

        client.BaseAddress = new Uri(settingValue.BaseAddress);
        client.DefaultRequestHeaders.UserAgent.ParseAdd(settingValue.AppName);
        client.DefaultRequestHeaders.Add("Authorization", settingValue.AccessToken);
        client.DefaultRequestHeaders.Add("X-GitHub-Api-Version", settingValue.GitHubHeader);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));

    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
