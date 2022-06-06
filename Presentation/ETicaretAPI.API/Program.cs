using ETicaretAPI.Application.Validators.Products;
using ETicaretAPI.Persistence;
using FluentValidation.AspNetCore;
using ETicaretAPI.Infrastructure.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices(); //persistanceservices methodunu builderda kullanmak için invoke etme iþlemi
// Add services to the container.
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod()));/// <summary>
/// cors ayarlarý
/// </summary>

builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>()).AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>()).ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);//bütün validatorlarý bu assembly içinde bulup kullanmak için kullanýlýr.
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
app.UseCors();//cors middleware ini çaðýrmak gerekiyor

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();