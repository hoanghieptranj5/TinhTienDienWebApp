using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using LumenWorks.Framework.IO.Csv;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TinhTienDienWebApp.Helpers;
using TinhTienDienWebApp.Models;

namespace TinhTienDienWebApp.Logics
{
    public class Calculator
    {
        public const string FilePath =
            "/Users/hieptran/Projects/TinhTienDienWebApp/TinhTienDienWebApp/Resources/Prices.csv";

        private readonly CsvHelper _helper;

        public Calculator(CsvHelper helper)
        {
            _helper = helper;
        }

        public CalculatedModel Calculate(int usage)
        {
            var results = new CalculatedModel
            {
                Items = new List<CalculatedItem>()
            };

            var models = _helper.GetPriceModels(FilePath);
            var remaining = usage;
            var total = 0.0f;

            foreach (var model in models)
            {
                if (remaining >= (model.To - model.From))
                {
                    remaining -= (model.To - model.From);
                    total += model.Price * (model.To - model.From);
                    
                    results.Items.Add(new CalculatedItem
                    {
                        From = model.From,
                        To = model.To,
                        StandardPrice = model.Price,
                        Price = model.Price * (model.To - model.From),
                        Usage = model.To - model.From
                    });
                    Console.WriteLine($"From {model.From} to {model.To}: {model.Price} * {(model.To - model.From)} = {model.Price * (model.To - model.From)}");
                }
                else
                {
                    total += model.Price * remaining;
                    
                    results.Items.Add(new CalculatedItem
                    {
                        From = model.From,
                        To = model.To,
                        StandardPrice = model.Price,
                        Price = model.Price * remaining,
                        Usage = remaining
                    });
                    
                    Console.WriteLine($"From {model.From} to {model.To}: {model.Price} * {remaining} = {model.Price * remaining}");
                    remaining = 0;
                }
            }

            results.Usage = usage;
            results.Total = total;
            
            return results;
        }
    }
}