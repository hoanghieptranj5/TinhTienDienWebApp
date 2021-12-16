
using System.Globalization;
using System.Linq;
using TinhTienDienWebApp.Models;

namespace TinhTienDienWebApp.Helpers
{
    public class CurrencyFormatter
    {
        public string FormatToVnd(int value)
        {
            // string.Format(new CultureInfo("en-US"), "{0:c}", 112.236677); //$112.24
            // string.Format(new CultureInfo("de-DE"), "{0:c}", 112.236677); //112,24 €
            // string.Format(new CultureInfo("hi-IN"), "{0:c}", 112.236677); //₹ 112.24
            
            return string.Format(new CultureInfo("fr-FR"), "{0:C}", value); //112,24 €;
        }
        
        public string FormatToVnd(float value)
        {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            return string.Format(nfi, "{0:C0}", value);
        }

        public FormattedCalculatedModel FormatModel(CalculatedModel model)
        {
            return new FormattedCalculatedModel
            {
                Usage = model.Usage,
                Total = FormatToVnd(model.Total),
                TotalVat = FormatToVnd(model.TotalVat),
                Items = model.Items.Select(x => new FormattedCalculatedItem()
                {
                    From = x.From,
                    To = x.To,
                    StandardPrice = FormatToVnd(x.StandardPrice),
                    Price = FormatToVnd(x.Price),
                    Usage = x.Usage
                }).ToList()
            };
        } 
    }
}