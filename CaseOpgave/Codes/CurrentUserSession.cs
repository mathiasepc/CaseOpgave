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
    //laver min list til match af de samlignede film keywords og userid
    List<ProductModel> matchCostumerSession { get; set; }

    //laver en til min print af suggestions
    List<ProductModel> displaySuggestions { get; set; }

    //opretter en vej til min data
    private string FilePath { get; set; }
    //opretter min liste som indeholder dataen
    private List<string> Lines { get; set; }

    public CurrentUserSession() : base()
    {
        //instantiere min liste
        UserSession = new List<CurrentUserSessionModel>();
        matchCostumerSession = new List<ProductModel>();

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
        //refesher min liste.
        matchCostumerSession = new();
        //if min string ikke er tom
        if (!string.IsNullOrEmpty(getUserId))
        {
            //add output userinput til matchProductId
            List<CurrentUserSessionModel> matchProductId = UserSession.Where(x => x.UserId == getUserId).ToList();

            //gennemgår min matchProductId for at matche
            foreach (var userInfo in matchProductId)
            {
                //tilføjer match
                matchCostumerSession.Add(Product.FirstOrDefault(x => x.Id == userInfo.ProductId));
            }
        }
        return matchCostumerSession;
    }

    public List<ProductModel> SetSuggestions(string getUserId)
    {
        //laver et output til mine keywords

        foreach (var matchKeywords in matchCostumerSession)
        {
            displaySuggestions = Product.Where(x => x.Keywords.FirstOrDefault() == matchKeywords.Keywords.FirstOrDefault()).Take(3).ToList();
        }
        displaySuggestions.OrderByDescending(x => x.Rating).ToList();

        return displaySuggestions;
    }

}
