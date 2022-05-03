using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseOpgave.Codes;

//arver child klasse til Products
internal sealed class CurrentUserSession : Products
{
    //opretter en list for min ProductModel
    public List<CurrentUserSessionModel> UserSession { get; set; }
    //opretter en vej til min data
    private string FilePath { get; set; }
    //opretter min liste som indeholder dataen
    private List<string> Lines { get; set; }

    public CurrentUserSession() : base()
    {
        //instantiere min liste
        UserSession = new List<CurrentUserSessionModel>();

        //putter dataen i min liste
        SetUserSession();
    }
    //indsætter data
    public void SetUserSession()
    {
        //gemmer min filepath i FilePath
        FilePath = @"C:\Users\matcla\source\repos\DisplayFilmProduktFraDokument\Movie product data\CurrentUserSession.txt";
        //gemmer data i min liste
        Lines = File.ReadAllLines(FilePath).ToList();

        //søger i min list og categorisere det i ProductModel
        foreach (string line in Lines)
        {
            //splitter data'en på ',' sådan så dataen får flere entries
            string[] entries = line.Split(',');

            //opretter min model klasse
            CurrentUserSessionModel current = new();

            //tilføjer de forskellige entries til de respektive pladser
            current.UserId = entries[0];
            current.ProductId = entries[1].Trim();


            //tilføjer dem til min list<ProductModel>
            UserSession.Add(current);
        }
    }

    //laver min DisplayProduct metode
    public override List<ProductModel> DisplayProducts()
    {
        //Søger i min product list for bedst rated og gemmer i en ny list ProductModel
        List<ProductModel> productRating = Product.OrderByDescending(x => x.Rating).Take(3).ToList();

        return productRating;
    }

    //hvad har kunden kigget på
    public List<ProductModel> CostumerView(string getUserId)
    {
        //laver min list til match af de samlignede id
        List<ProductModel> displayCostumerSession = new List<ProductModel>();
        //if min string ikke er tom
        if (!string.IsNullOrEmpty(getUserId))
        {
            //add output userinput til matchProductId
            List<CurrentUserSessionModel> matchProductId = UserSession.Where(x => x.UserId == getUserId).ToList();

            //gennemgår min matchProductId for at matche
            foreach (var userInfo in matchProductId)
            {
                //tilføjer match
                displayCostumerSession.Add(Product.FirstOrDefault(x => x.Id == userInfo.ProductId));
            }
        }
        return displayCostumerSession;
    }

    public List<ProductModel> SetSuggestions(string getUserId)
    {
        string output = null;
        List<ProductModel> suggestions = new();
        //laver et output til mine keywords
        if (CostumerView(getUserId) != null)
        {
            foreach (var keywords in Product)
            {
                foreach (string keyword in keywords.Keywords)
                {
                    output = keyword;
                }
                if (!string.IsNullOrEmpty(output))
                    suggestions = Product.Where(x => x.Keywords.Contains(output)).ToList();
                else
                    continue;
            }
        }
        return suggestions;
    }
}
