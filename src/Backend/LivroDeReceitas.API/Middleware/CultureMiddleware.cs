using System.Globalization;

namespace LivroDeReceitas.API.Middleware;

public class CultureMiddleware
{
    private readonly RequestDelegate _next;

    public CultureMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var requestedCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault();

        var supportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures);

        var requestedCultureNotExists = !supportedLanguages.Any(c => c.Name.Equals(requestedCulture));

        CultureInfo cultureInfo;

        if (string.IsNullOrWhiteSpace(requestedCulture) || requestedCultureNotExists)
        {
            cultureInfo = new CultureInfo("en");
        }
        else
        {
            cultureInfo = new CultureInfo(requestedCulture);
        }

        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;

        await _next(context);

    }
}
