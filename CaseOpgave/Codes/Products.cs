using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CaseOpgave.Codes;

//laver den her som parent class
internal abstract class Products
{
    //opretter en list for min ProductModel
    public List<ProductModel>? Product { get; set; }
    //opretter en vej til min data
    private string FilePath { get; set; }
    //opretter min liste som indeholder dataen
    private List<string>? Lines { get; set; }

    public Products()
    {
        //instantiere min liste
        Product = new List<ProductModel>();

        //indsætter data
        InsertProducts();
    }

    //uddelere data i min model ProductModel
    public void InsertProducts()
    {
        //gemmer min filepath i filepath
        FilePath = @"C:\Users\matcla\source\repos\DisplayFilmProduktFraDokument\Movie product data\Products.txt";

        //gemmer dataen i list lines
        Lines = File.ReadAllLines(FilePath).ToList();

        //søger i min list og categorisere det i ProductModel
        foreach (string line in Lines)
        {
            //splitter data'en på ',' sådan så dataen får flere entries
            string[] entries = line.Split(',');

            //instantiere min model klasse
            ProductModel product = new();

            //tilføjer de forskellige entries til de respektive pladser
            product.Id = entries[0];
            product.Name = entries[1];
            product.Year = entries[2];

            //for at gemme det i min Keywords er jeg nød til at instansiere min refence type
            product.Keywords = new();

            //da en film kan have flere keyword, opretter jeg et loppe og tilføjer i Keyword
            for (int i = 3; i <= 7; i++)
            {
                //hvis entries ikke er tom eller et mellemrum, gem.
                if (!string.IsNullOrWhiteSpace(entries[i]))
                    product.Keywords.Add(entries[i]);
            }

            product.Rating = entries[8];
            product.Price = entries[9];

            //tilføjer dem til min list<ProductModel>
            Product.Add(product);
        }
    }
    public abstract List<ProductModel> DisplayProducts();
}
