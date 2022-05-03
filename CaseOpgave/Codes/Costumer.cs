using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseOpgave.Codes;

internal class Costumer
{
    //opretter en vej til min data
    private string FilePath { get; set; }
    //opretter min liste som indeholder dataen
    private List<string> Lines { get; set; }
    //opretter en list for min ProductModel
    public List<CostumerModel> Info { get; set; }

    public Costumer()
    {
        //instantiere min liste
        Info = new List<CostumerModel>();
    }
    public void CategoriesCustomer()
    {
        //gemmer min filepath i FilePath
        FilePath = @"C:\Users\matcla\source\repos\DisplayFilmProduktFraDokument\Movie product data\Users.txt";
        //gemmer dataen i list lines
        Lines = File.ReadAllLines(FilePath).ToList();

        //søger i min list og categorisere det i ProductModel
        foreach (string line in Lines)
        {
            //splitter data'en på ',' sådan så dataen får flere entries
            string[] entries = line.Split(',');

            //opretter min model klasse
            CostumerModel costumer = new();

            //tilføjer de forskellige entries til de respektive pladser
            costumer.Id = entries[0];
            costumer.Name = entries[1];
            costumer.Viewed = entries[2];
            costumer.Purchased = entries[3];

            //tilføjer dem til min list<CostumerModel>
            Info.Add(costumer);
        }
    }
}
