using System;
using ObjectLibrary;

namespace DataAccess
{
   public class ClientRepository : RepositoryBase
    {
       public override string Add<T>(T obj)
       {
           var client = obj as Client;

           if(client == null)
               throw new InvalidCastException("client");
           
           var id = base.Add(client);

           var compassNumber = base.GetCompassNumber(decimal.Parse(id));

           client.CompassNumber = compassNumber;

           base.Update(client);

           return id;
       }
    }
}
