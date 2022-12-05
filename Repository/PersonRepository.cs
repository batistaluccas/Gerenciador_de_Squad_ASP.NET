using Repository.Context;
using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PersonRepository : IPersonRepository
    {
        protected EFContext _dataContext;

            public PersonRepository(EFContext dataContext)
            {
                _dataContext = dataContext;
            }
       
            public void Add(PersonEntity entity)
            {
                _dataContext.Add(entity);
                _dataContext.SaveChanges();
            }

    }
}
