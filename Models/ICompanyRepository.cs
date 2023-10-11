using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIRHU.Models
{
    public interface ICompanyRepository
    {
        void AddCompany(CompanyModel companyModel);
        void AddSucursal(CompanyModel companyModel);
        void AddDepartamentos(CompanyModel companyModel);
        void RemoveCompany(CompanyModel companyModel);
        void RemoveCSucursal(CompanyModel companyModel);
        void RemoveDepartamentos(CompanyModel companyModel);
    }
}
