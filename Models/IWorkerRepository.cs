using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIRHU.Models
{
    internal interface IWorkerRepository
    {
        void Add(WorkerModel workerModel);
        void Edit(WorkerModel workerModel);
        void Remove(string cedula);

        WorkerModel GetById(string cedula);
        WorkerModel GetByName(string name);

        IEnumerable<WorkerModel> GetByAll();

    }
}
