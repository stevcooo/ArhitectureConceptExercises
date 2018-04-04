using ArhitectureConcept.Models;
using System.Collections.Generic;

namespace ArhitectureConcept.Interfaces.Services
{
    public interface IAppointmentService
    {
        IEnumerable<Appointment> GetAppointments();
        IEnumerable<Appointment> GetDoctorAppointments(int doctorId);
        IEnumerable<Appointment> GetPatientAppointments(int patientId);
        Appointment GetAppointment(int id);
        void AddAppointment(Appointment appointment);
        bool RemoveAppointment(Appointment appointment);
    }
}
