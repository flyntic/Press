using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPressa.DBService
{
    public class DBService//:IDBService
    {
        private readonly pressDBEntities pressContext;
        public static DBService Instance { get => DBServiceCreate.instance; }
        private DBService()
        {
            pressContext = new pressDBEntities();
           
        }
        private class DBServiceCreate
        {
            static DBServiceCreate() { }
            internal static readonly DBService instance = new DBService();
        }

     //   public Task<IEntity> AddObject(IEntity entity)
     //   {
     //     //  All_Publications newPublication = (All_Publications)entity;
     //     //
     //     //  pressContext.All_Publications.Include("All_Publications").FirstOrDefault(m => m.Id == 1).Clients.Add(newPublication);
     //     //  //await _context.SaveChangesAsync();
     //     //  return newPublication;
     //   }
     //
     //   public Task<IEntity> GetObject(int id)
     //   {
     //       throw new NotImplementedException();
     //   }
     //
     //   public Task<bool> RemoveObject(int id)
     //   {
     //       throw new NotImplementedException();
     //   }
    }
}
