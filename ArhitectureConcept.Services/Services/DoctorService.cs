using ArhitectureConcept.Interfaces.Services;
using ArhitectureConcept.Models;
using System;
using System.Collections.Generic;

namespace ArhitectureConcept.Services.Services
{
    public class DoctorService : IEntityService<Doctor>
    {
        private readonly ILoggerService _loggerService;

        public DoctorService(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }
        public IEnumerable<Doctor> GetAll()
        {
            _loggerService.LogLine("DoctorService->GetAll : " + DateTime.Now);
            return DatabaseContext.Doctors;
        }

        public void Add(Doctor item)
        {
            _loggerService.LogLine("DoctorService->Add : " + DateTime.Now);
            item.Id = DatabaseContext.Doctors.Count;
            DatabaseContext.Doctors.Add(item);
        }

        public bool Remove(Doctor item)
        {
            _loggerService.LogLine("DoctorService->Remove : " + DateTime.Now);
            return DatabaseContext.Doctors.Remove(item);
        }
    }
}
