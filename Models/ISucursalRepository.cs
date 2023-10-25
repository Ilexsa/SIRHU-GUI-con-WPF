using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIRHU.Models
{
    internal interface ISucursalRepository
    {
        bool NoRepeatName(string name);
        bool RepeatName(string name);
        void Add(SucursalModel sucursalModel);
        void Edit(SucursalModel sucursalModel);
        void Remove(SucursalModel sucursalModel);

        ObservableCollection<SucursalModel> GetAll();
        ObservableCollection<SucursalModel> GetByAll(string searchString);
    }
}
