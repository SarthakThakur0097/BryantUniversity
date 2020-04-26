using BryantUniversity.Models;
using System.Data.Entity;

namespace BryantUniversity.Data
{
    public class RDSContext : DbContext
    {
        public RDSContext()
          : base(Helpers.GetRDSConnectionString())
        {
        }

        public static RDSContext Create()
        {
            return new RDSContext();
        }
    }
}