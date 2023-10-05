using SIRHU.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIRHU.Models
{
    internal interface IWorkerRepository
    {
        void Add(WorkerModel worker);
        void Edit(WorkersViewModel workerModel);
        void Remove(WorkerModel worker);
        
        ObservableCollection<WorkerModel> Get(WorkerModel workerModel);

        WorkerModel GetById(string cedula);
        WorkerModel GetByName(string name);



        IEnumerable<WorkerModel> GetByAll();
    }
}
