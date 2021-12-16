using System.Collections.Generic;

namespace TinhTienDienWebApp.Models
{
    public class CalculatedModel
    {
        public int Usage { get; set; } = 0;
        public List<CalculatedItem> Items { get; set; }
        public float Total { get; set; }
        public float TotalVat => Total * 1.1f;
    }

    public class CalculatedItem
    {
        public int From { get; set; }
        public int To { get; set; }
        public float StandardPrice { get; set; }
        public float Price { get; set; }
        public int Usage { get; set; }
    }
}