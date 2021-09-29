using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;

namespace Business.Abstract
{
    public interface IClinicService
    {
        IDataResult<List<Clinic>> GetAll();
        IDataResult<PagedList<Clinic>> GetAllClinicWithEquipment(string sort,int currentPage, int pageSize);
        IDataResult<List<Clinic>> GetAllClinicBySearchWithEquipment(string search);
        IDataResult<Clinic> GetClinicByIdWithEquipment(int clinicId);
        IDataResult<Clinic> GetById(int clinicId);
        IResult Create(Clinic clinic);
        IResult Update(Clinic clinic);
        IResult Delete(int clinicId);
    

    }
}
