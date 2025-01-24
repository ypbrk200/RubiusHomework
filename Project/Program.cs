using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Регистрация сервисов
builder.Services.AddControllersWithViews();

// Регистрация контекста базы данных
builder.Services.AddDbContext<OnlineBankContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Регистрация ваших бизнес-сервисов
builder.Services.AddScoped<IAccountService, AccountService>(); // Пример сервиса управления счетами
builder.Services.AddScoped<ITransactionService, TransactionService>(); // Пример сервиса управления транзакциями

// Другие сервисы и настройки
// builder.Services.AddScoped<IUserService, UserService>(); // Регистрация ещё одного сервиса, если необходимо

var app = builder.Build();

// Настройка middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Настройки для использования статических файлов и маршрутизации
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Настройка маршрутов
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
