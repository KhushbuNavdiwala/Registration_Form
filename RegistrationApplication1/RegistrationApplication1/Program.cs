using Microsoft.EntityFrameworkCore;


using RegistrationApplication1.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod());
});


//
//database connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>

options.UseSqlServer("Server=KHUSHI\\SQLEXPRESS01;Database=RegistrationDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;"));


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

/* app.UseCors(policy =>
policy.WithOrigins("http://localhost:4200")
.AllowAnyMethod()
.AllowAnyHeader());*/





// Error handling configuration
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
