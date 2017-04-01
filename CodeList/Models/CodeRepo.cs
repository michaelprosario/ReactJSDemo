using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeList.Models
{
    public class CodeRepo
    {
        public string CurrentUser = "system";

        public List<Code> GetAll()
        {
            var repo = getRepo();
            return repo.ToList<Code>();
        }



        private static MongoRepository<Code> getRepo()
        {
            return new MongoRepository<Code>();
        }

        public bool RecordExists(string id)
        {
            if (id == null)
                throw new ArgumentNullException();

            var repo = getRepo();
            var results = repo.Where(r => r.Id == id);
            return results.Count() > 0;
        }



        public string Add(Code record)
        {
            if (record == null)
                throw new ArgumentNullException();


            record.CreatedBy = CurrentUser;
            record.CreatedAt = DateTime.Now;
            record.UpdatedAt = DateTime.Now;
            record.UpdatedBy = CurrentUser;

            var repo = getRepo();
            repo.Add(record);
            return record.Id;

        }

        public void Delete(string id)
        {
            if (id == null)
                throw new ArgumentNullException();

            var repo = getRepo();
            repo.Delete(r => r.Id == id);
        }

        public void DeleteAll()
        {
            var repo = getRepo();
            repo.DeleteAll();
        }

        public Code GetRecord(string id)
        {
            if (id == null)
                throw new ArgumentNullException();

            var repo = getRepo();
            var resultSet = repo.Where(r => r.Id == id);

            var record = resultSet.FirstOrDefault();
            if (record == null)
                throw new ApplicationException("Record not found.");
            else
                return record;
        }

        public void Update(Code record)
        {
            record.UpdatedAt = DateTime.Now;
            record.UpdatedBy = CurrentUser;

            if (!RecordExists(record.Id))
                throw new ApplicationException("Record currently not saved in system.");

            var repo = getRepo();
            repo.Update(record);
        }

       
    }
}