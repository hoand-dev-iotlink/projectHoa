using System.Data.Entity;

namespace ProjectService.DatacontextRep
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext()
            : base("ProjectConnection")
        { }
    }
}
