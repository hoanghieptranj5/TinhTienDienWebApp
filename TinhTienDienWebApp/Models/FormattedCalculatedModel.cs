using System.Collections.Generic;

namespace TinhTienDienWebApp.Models
{
    public class FormattedCalculatedModel
    {
        public int Usage { get; set; } = 0;
        public List<FormattedCalculatedItem> Items { get; set; }
        public string Total { get; set; }
        public string TotalVat { get; set; }
    }
    
    public class FormattedCalculatedItem
    {
        public int From { get; set; }
        public int To { get; set; }
        public string StandardPrice { get; set; }
        public string Price { get; set; }
        public int Usage { get; set; }
    }
}