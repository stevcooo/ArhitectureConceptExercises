using System;
using System.Collections.Generic;
using System.Linq;
using ArhitectureConcept.Interfaces.Services;
using ArhitectureConcept.Models;

namespace ArhitectureConcept.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ILoggerService _loggerService;

        public AppointmentService(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }
        public IEnumerable<Appointment> GetAppointments()
        {
            _loggerService.LogLine("GetAppointments " + DateTime.Now);
            return DatabaseContext.Appointments;            
        }

        public IEnumerable<Appointment> GetDoctorAppointments(int doctorId)
        {
            _loggerService.LogLine("GetDoctorAppointments  doctorId = " + doctorId + " " + DateTime.Now);
            return DatabaseContext.Appointments.Where(t => t.Doctor.Id == doctorId);
        }

        public IEnumerable<Appointment> GetPatientAppointments(int patientId)
        {
            _loggerService.LogLine("GetPatientAppointments patientId = " + patientId + " " + DateTime.Now);
            return DatabaseContext.Appointments.Where(t => t.Patient.Id == patientId);
        }

        public Appointment GetAppointment(int id)
        {
            _loggerService.LogLine("GetAppointment id= " + id + " " + DateTime.Now);
            return DatabaseContext.Appointments.FirstOrDefault(t => t.Id == id);
        }

        public void AddAppointment(Appointment appointment)
        {
            _loggerService.LogLine("AddAppointment " + DateTime.Now);
            appointment.Id = DatabaseContext.Appointments.Count;
            DatabaseContext.Appointments.Add(appointment);
        }
    }
}
