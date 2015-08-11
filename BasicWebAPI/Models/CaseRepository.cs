using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;

namespace BasicWebAPI.Models
{
    public class CaseRepository
    {
       private const string pathToJson = @"~/App_Data/Cases.json";
       private string filePath = HostingEnvironment.MapPath(pathToJson);

       internal Case Create()
       {
           return new Case { DateCreated = DateTime.Now };
       }

       internal List<Case> Retrieve()
       {
           return JsonConvert.DeserializeObject<List<Case>>(File.ReadAllText(filePath));
       }

       internal Case Retrieve(int id)
       {
           var cases = JsonConvert.DeserializeObject<List<Case>>(File.ReadAllText(filePath));
           Case selectedCase = cases.FirstOrDefault(c => c.CaseId == id);
           return selectedCase;
       }

       internal Case Save(Case Case)
       {
           var Cases = this.Retrieve();
           var maxId = Cases.Max(c => c.CaseId);
           Case.CaseId = maxId + 1;

           Cases.Add(Case);

           //Update the json file
           WriteData(Cases);
           return Case;
       }

       internal Case Save(int id, Case Case)
       {
           var Cases = this.Retrieve();

           var itemIndex = Cases.FindIndex(c => c.CaseId == Case.CaseId);

           if (itemIndex > 0)
           {
               Cases[itemIndex] = Case;
           }
           else
           {
               return null;
           }

           //Update the json file
           WriteData(Cases);
           return Case;
       }

       internal bool Delete(Case Case)
       {
           var Cases = JsonConvert.DeserializeObject<List<Case>>(File.ReadAllText(filePath));
           var deleted = Cases.Remove(Case);

           WriteData(Cases);
           return deleted;
       }

        //Write out JSON file
        private bool WriteData(List<Case> cases)
        {
            var filePath = HostingEnvironment.MapPath(pathToJson);
            var json = JsonConvert.SerializeObject(cases, Formatting.Indented);

            File.WriteAllText(filePath, json);

            return true;
        } 
        
    }
}