using LHBOL;
using LHDAL;
using System;
using System.Collections.Generic;

namespace LHBLL
{
    public interface ILHUrlBs
    {
        IEnumerable<LHUrl> GetAll();
        LHUrl GetById(int id);
        bool Create(LHUrl LHUrl);
        bool Update(LHUrl LHUrl);
        bool Delete(int id);
        IEnumerable<LHUrl> GetAll(bool IsApproved);
    }
    public class LHUrlBs : ILHUrlBs
    {
        ILHUrlDb LHUrlDb;

        public LHUrlBs(ILHUrlDb _LHUrlDb)
        {
            LHUrlDb = _LHUrlDb;
        }

        public bool Create(LHUrl LHUrl)
        {
            return LHUrlDb.Create(LHUrl);
        }

        public bool Delete(int id)
        {
            return LHUrlDb.Delete(id);
        }

        public IEnumerable<LHUrl> GetAll()
        {
            var categories = LHUrlDb.GetAll();
            return categories;
        }

        public LHUrl GetById(int id)
        {
            var LHUrl = LHUrlDb.GetById(id);
            return LHUrl;
        }

        public bool Update(LHUrl LHUrl)
        {
            return LHUrlDb.Update(LHUrl);
        }

        public IEnumerable<LHUrl> GetAll(bool IsApproved)
        {
            return LHUrlDb.GetAll(IsApproved);
         }
 

    }
}
