using System;
using System.Collections.Generic;
using ArhitectureConcept.Interfaces.Services;
using ArhitectureConcept.Models;

namespace ArhitectureConcept.Services.Services
{
    public class PatientService : IEntityService<Patient>
    {
        private readonly ILoggerService _loggerService;

        public PatientService(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }
        public IEnumerable<Patient> GetAll()
        {
            _loggerService.LogLine("PatientService->GetAll : " + DateTime.Now);
            return DatabaseContext.Patients;
        }

        public void Add(Patient item)
        {
            _loggerService.LogLine("PatientService->Add : " + DateTime.Now);
            item.Id = DatabaseContext.Patients.Count;
            DatabaseContext.Patients.Add(item);
        }

        public bool Remove(Patient item)
        {
            _loggerService.LogLine("PatientService->Remove : " + DateTime.Now);
            return DatabaseContext.Patients.Remove(item);
        }
    }
}
