using SIRHU.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIRHU.Repositories
{
    public class SucursalRepository : Repositories.RepositoryBase, ISucursalRepository
    {
        public void Add(SucursalModel sucursalModel)
        {
            throw new NotImplementedException();
        }

        public void Edit(SucursalModel sucursalModel)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<SucursalModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<SucursalModel> GetByAll(string searchString)
        {
            throw new NotImplementedException();
        }

        public bool NoRepeatName(string name)
        {
            throw new NotImplementedException();
        }

        public void Remove(SucursalModel sucursalModel)
        {
            throw new NotImplementedException();
        }

        public bool RepeatName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
