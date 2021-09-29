using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;
using Microsoft.EntityFrameworkCore;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Aspects.Logging;
using X.PagedList;

namespace Business.Concrete
{
    [LogAspect(typeof(FileLogger))]
    public class ClinicManager:IClinicService
    {
        IClinicDal _clinicDal;

        public ClinicManager(IClinicDal clinicDal)
        {
            _clinicDal = clinicDal;
        }

        

        [ValidationAspect(typeof(ClinicValidator))]
        public IResult Create(Clinic clinic)
        {
           
            _clinicDal.Add(clinic);
            return new SuccessResult(Messages.ClinicsAdded);

        }

        [ValidationAspect(typeof(ClinicValidator))]
        public IResult Update(Clinic clinic)
        {
            
            _clinicDal.Update(clinic);
            return new SuccessResult(Messages.ClinicsUpdated);
        }
         public IResult Delete(int id)
        {
            Clinic clinic = new Clinic { Id = id };
            _clinicDal.Delete(clinic);
            return new SuccessResult(Messages.ClinicsDeleted);
        }
        public IDataResult<List<Clinic>> GetAll()
        {
           
            return new SuccessDataResult<List<Clinic>>(_clinicDal.GetAll(),Messages.ClinicsListed);
        }
        public IDataResult<Clinic> GetById(int id)
        {
            
            return new SuccessDataResult<Clinic>(_clinicDal.Get(c => c.Id == id), Messages.ClinicsListed);
        }
        
        
        public IDataResult<PagedList<Clinic>> GetAllClinicWithEquipment(string sort,int currentPage, int pageSize)
        {
            var result = sort switch
            {
                "name" => _clinicDal.GetAllClinicWithEquipment().OrderBy(c => c.Name).ToPagedList(currentPage, pageSize),
                "name_desc" => _clinicDal.GetAllClinicWithEquipment().OrderByDescending(c => c.Name).ToPagedList(currentPage, pageSize),
                "id" => _clinicDal.GetAllClinicWithEquipment().OrderBy(c => c.Id).ToPagedList(currentPage, pageSize),
                "id_desc" => _clinicDal.GetAllClinicWithEquipment().OrderBy(c => c.Id).ToPagedList(currentPage, pageSize),
                _ => throw new NotImplementedException()
            };
            return new SuccessDataResult<PagedList<Clinic>>((PagedList<Clinic>)result, Messages.ClinicsListed);

        }

        public IDataResult<Clinic> GetClinicByIdWithEquipment(int clinicId)
        {
            return new SuccessDataResult<Clinic>(_clinicDal.GetClinicByIdWithEquipment(clinicId), Messages.ClinicsListed);
        }

        public IDataResult<List<Clinic>> GetAllClinicBySearchWithEquipment(string search)
        {
            return new SuccessDataResult<List<Clinic>>(_clinicDal.GetAllClinicsBySearch(search), Messages.ClinicsListed);
        }

    }
}
