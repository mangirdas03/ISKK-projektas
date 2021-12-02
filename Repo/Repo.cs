using decaf.Models;
using Microsoft.AspNetCore.Http;
using System;


namespace decaf.Repo
{
    public class Repo
    {
        
        // randa modelio pavadinima pagal modelio ID
        public static string GetModelName(int id)
        {
            iskkContext db = new iskkContext();
            foreach (var item in db.Modelis)
            {
                if (item.IdModelis == id)
                    return item.Pavadinimas;
            }
            return "Model not found";
        }

        // randa dizainerio pavardę pagal a.k
        public static string GetDesignerName(int id)
        {
            iskkContext db = new iskkContext();
            foreach (var item in db.Dizaineris)
            {
                if (item.AsmensKodas == id)
                    return item.Pavardė;
            }
            return "Designer not found";
        }

        // randa gamintojo pavadinimą pagal ID
        public static string GetBrandName(int id)
        {
            iskkContext db = new iskkContext();
            foreach (var item in db.Gamintojas)
            {
                if (item.IdGamintojas == id)
                    return item.Pavadinimas;
            }
            return "Brand not found";
        }
        // randa medziagos pavadinimą pagal ID
        public static string GetMaterialName(int id)
        {
            iskkContext db = new iskkContext();
            foreach (var item in db.Medžiagas)
            {
                if (item.IdMedžiaga == id)
                    return item.Pavadinimas;
            }
            return "Material not found";
        }








        //@decaf.Repo.Repo.DateConvert(item.ĮkūrimoData)
        //public static string DateConvert(DateTime date)
        //{
        //    return date.ToShortDateString();
        //}


    }
}