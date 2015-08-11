using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace BasicWebAPI.Models
{
    public class DocumentRepository
    {
        private const string pathToDocuments = @"~/App_Data/Documents.json";
        private string filePath = HostingEnvironment.MapPath(pathToDocuments);
        CaseRepository _caseRepo = new CaseRepository();

        internal Document Create(int caseId)
        {
            return new Document { CaseId = 1, DateCreated = DateTime.Now };
        }

        internal List<Document> Retrieve()
        {
            return JsonConvert.DeserializeObject<List<Document>>(File.ReadAllText(filePath));
        }

        internal Document Retrieve(int id)
        {
            var Documents = Retrieve();
            return Documents.FirstOrDefault(c => c.DocumentId == id);;
        }

        internal Document Save(Document Document)
        {
            var Documents = this.Retrieve();
            var maxId = Documents.Max(c => c.DocumentId);
            Document.DocumentId = maxId + 1;

            Documents.Add(Document);

            //Update the json file
            WriteData(Documents);
            return Document;
        }

        internal Document Save(int id, Document Document)
        {
            var Documents = this.Retrieve();

            var itemIndex = Documents.FindIndex(c => c.DocumentId == Document.DocumentId);

            if (itemIndex > 0)
            {
                Documents[itemIndex] = Document;
            }
            else
            {
                return null;
            }

            //Update the json file
            WriteData(Documents);
            return Document;
        }

        internal bool Delete(int docId)
        {
            //Delete DocIds from Case
            Document document = Retrieve(docId);

            var selectedCase = _caseRepo.Retrieve(document.CaseId);
            var removed = selectedCase.Documents.Remove(document.DocumentId);

            //Delete Doc
            var Documents = JsonConvert.DeserializeObject<List<Document>>(File.ReadAllText(filePath));
            var deleted = Documents.Remove(document);

            WriteData(Documents);
            return deleted;
      }

        //Write out JSON file
        private bool WriteData(List<Document> Documents)
        {
            var filePath = HostingEnvironment.MapPath(pathToDocuments);
            var json = JsonConvert.SerializeObject(Documents, Formatting.Indented);

            File.WriteAllText(filePath, json);

            return true;
        }

    }
}