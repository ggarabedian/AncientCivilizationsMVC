namespace AncientCivilizations.Web.Common.Extensions
{
    using Ganss.XSS;

    public static class Sanitizer
    {
        public static string Sanitize(string html)
        {
            var sanitizer = new HtmlSanitizer();
            sanitizer.AllowedAttributes.Add("class");
            var sanitizedHtml = sanitizer.Sanitize(html);

            return sanitizedHtml;
        }
    }
}
