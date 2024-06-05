using System.Globalization;

namespace CashFlow.Api.Middleware
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _next;
        public CultureMiddleware(RequestDelegate next) // requestdelegate -> ve se pode ou não continuar
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            //extrai o idioma do header
            var culture = context.Request.Headers.AcceptLanguage.FirstOrDefault();

            var cultureInfo = new CultureInfo("en"); // linguagem padrao

            if (string.IsNullOrWhiteSpace(culture) == false)
            {
                cultureInfo = new CultureInfo(culture);
            }
            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;
            // Permite o fluxo continuar
            await _next(context);
        }
    }
}
