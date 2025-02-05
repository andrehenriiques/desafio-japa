using AutoMapper;
using desafio_2.Class;
using desafio_2.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;

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
    var pessoa = new Pessoa("Jose", "12345678900", 22, "Rua Jose da Silva", "São Paulo", "SP", "123123000");
    string output = JsonConvert.SerializeObject(pessoa);
    Console.WriteLine(output);
#endregion
    

#region 2
    var desPessoa = JsonConvert.DeserializeObject<Pessoa>(output);
    Console.WriteLine(desPessoa?.nome);
#endregion


#region 3 
    var pessoa2 = new Pessoa("Maria", "45678912345", 33, "Rua Maria", "Campinas", "SP", "123123000");
    var configuration = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Pessoa, PessoaDto>()
            .ForMember(des => des.Cep, opt => opt.MapFrom(c => int.Parse(c.cep)));
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


#region 4

var client3 = new RestClient("https://pokeapi.co/api/v2/berry/1");

var request = new RestRequest();

var response2 =  client3.Execute<PokemonDto>(request);


if (response2.Content != null)
{
    var value = JsonConvert.DeserializeObject<PokemonDto>(response2.Content, new JsonSerializerSettings
    {
        ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        }
    });
    Console.WriteLine(JsonConvert.SerializeObject(value));
}

#endregion

#region 5

    var client2 = new RestClient("https://viacep.com.br/ws/58397000/json/");
;

    var response =  client2.Execute<ViaCepDto>(request);


    if (response.Content != null)
    {
        var value = JsonConvert.DeserializeObject<ViaCepDto>(response.Content, new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        });
        Console.WriteLine(JsonConvert.SerializeObject(value));
    }

    #endregion

#region 6 
    var date = DateTime.Now.ToString("dd@MM@yyyy##HH##mm##ss");
    Console.WriteLine(date);
#endregion

#region 7

    var dateNow = DateTime.Now.ToUniversalTime();
    var dateLong = DateTime.Now.AddDays(45).ToUniversalTime();
    TimeSpan difference = dateLong - dateNow;
    double totalSeconds = difference.TotalSeconds;
    Console.WriteLine(totalSeconds);
#endregion


app.Run();
