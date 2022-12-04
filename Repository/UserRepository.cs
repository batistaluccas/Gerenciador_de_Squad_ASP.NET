using Repository.Context;
using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository: IUserRepository
    {
        protected EFContext _dataContext;

        public UserRepository(EFContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(UserEntity entity)
        {
            _dataContext.Add(entity);
            _dataContext.SaveChanges();
        }
    }
}
