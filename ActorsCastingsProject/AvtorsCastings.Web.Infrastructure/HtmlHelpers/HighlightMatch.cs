using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;

namespace ActorsCastings.Web.Infrastructure.HtmlHelpers
{
    public static class HtmlHelper
    {
        public static IHtmlContent HighlightMatch(this IHtmlHelper html, string text, string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return new HtmlString(HtmlEncoder.Default.Encode(text));
            }

            string? safeText = HtmlEncoder.Default.Encode(text ?? string.Empty);
            string safeQuery = HtmlEncoder.Default.Encode(query);

            string highlightedText = Regex.Replace(
                safeText,
                Regex.Escape(safeQuery),
                match => $"<span class='highlight'>{match.Value}</span>",
                RegexOptions.IgnoreCase
            );

            return new HtmlString(highlightedText);
        }
    }
}
