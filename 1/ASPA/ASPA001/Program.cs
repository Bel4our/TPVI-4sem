using Microsoft.AspNetCore.HttpLogging; //подключаем пространство имен дл€ логировани€ HTTP-запросов

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args); //создаем экземпл€р WebApplicationBuilder с переданными аргументами
        builder.Services.AddHttpLogging(options => //добавл€ем службу логировани€ HTTP-запросов
        {
            options.LoggingFields = HttpLoggingFields.All; //указываем, что нужно логировать все пол€ HTTP-запросов
        });

        //добавл€ем службы в контейнер
        builder.Services.AddRazorPages(); //добавл€ем поддержку Razor Pages

        var app = builder.Build(); //создаем экземпл€р приложени€

        app.UseHttpLogging(); //включаем логирование HTTP-запросов

        //настраиваем конвейер обработки HTTP-запросов
        if (!app.Environment.IsDevelopment()) //если среда выполнени€ не €вл€етс€ средой разработки,
        {
            app.UseExceptionHandler("/Error"); //используем обработчик исключений дл€ перенаправлени€ на страницу ошибок
            app.UseHsts(); //включаем HTTP Strict Transport Security (HSTS) дл€ повышени€ безопасности
        }

        app.UseHttpsRedirection(); //перенаправл€ем HTTP-запросы на HTTPS
        app.UseStaticFiles(); //включаем поддержку статических файлов

        app.UseRouting(); //включаем маршрутизацию

        app.UseAuthorization(); //включаем авторизацию

        app.MapRazorPages(); //настраиваем маршрутизацию дл€ Razor Pages

        app.Run(); //запускаем приложение
    }
}