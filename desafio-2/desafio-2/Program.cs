using AutoMapper;
using desafio_2.Class;
using desafio_2.DTO;
using Newtonsoft.Json;
using Rest;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//

var client = new HttpClient();

#region 1
    var pessoa = new Pessoa("Jose", "123.456.789-00", 22, "Rua Jose da Silva", "São Paulo", "SP");
    string output = JsonConvert.SerializeObject(pessoa);
    Console.WriteLine(output);
#endregion
    

#region 2
    var desPessoa = JsonConvert.DeserializeObject<Pessoa>(output);
    Console.WriteLine(desPessoa?.nome);
#endregion


#region 3 
    var pessoa2 = new Pessoa("Maria", "456.789.123-45", 33, "Rua Maria", "Campinas", "SP");
    var configuration = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Pessoa, PessoaDto>();
    });
    var mapper = configuration.CreateMapper();
    var pessoaDto = mapper.Map<PessoaDto>(pessoa2);
    Console.WriteLine(JsonConvert.SerializeObject(pessoaDto));
#endregion


#region 4-5
app.MapGet("/pessoa", () => JsonConvert.SerializeObject(pessoaDto))
    .WithName("Pessoa")
    .WithOpenApi();
app.MapGet("/viaCep", (string cep) =>
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://viacep.com.br/ws/{cep}/json"),
        };  
        using var response = client.SendAsync(request);
        return response.Result.Content.ReadAsStringAsync().Result;
    })
.WithName("Dados da Pessoa")
.WithOpenApi();
#endregion

#region 6 
    var date = DateTime.Now.ToString("dd@MM@yyyy##HH##mm##ss");
    Console.WriteLine(date);
#endregion

#region 7

    var dateNow = DateTime.Now.ToUniversalTime();
    var dateLong = DateTime.Now.AddDays(45).ToUniversalTime();
    Console.WriteLine(dateLong.Ticks - dateNow.Ticks);
#endregion


app.Run();
