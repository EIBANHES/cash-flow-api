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
            var supportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures).ToList();

            //extrai o idioma do header
            var requestedCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault();

            var cultureInfo = new CultureInfo("en"); // linguagem padrao

            // tratativa para verificar se não é null e possui espaços em branco e se a linguagem existe 
            if (string.IsNullOrWhiteSpace(requestedCulture) == false && supportedLanguages.Exists(language => language.Name.Equals(requestedCulture)))
            {
                cultureInfo = new CultureInfo(requestedCulture);
            }
            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;
            // Permite o fluxo continuar
            await _next(context);
        }
    }
}
