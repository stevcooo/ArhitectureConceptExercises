using ArhitectureConcept.Interfaces.Services;
using ArhitectureConcept.Models;
using ArhitectureConcept.Services;
using ArhitectureConcept.Services.Services;

namespace ArhitectureConcept.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseContext.PopulateDatabaseWithMockData();

            ILoggerService loggerService = new TextFileLoggerService();
            IAppointmentService appointmentService = new AppointmentService(loggerService);
            IEntityService<Doctor> doctorService = new DoctorService(loggerService);
            IEntityService<Patient> patientService = new PatientService(loggerService);

            var appointments = appointmentService.GetAppointments();
            var doctor1Appointments = appointmentService.GetDoctorAppointments(1);
            var doctor2Appointments = appointmentService.GetDoctorAppointments(2);
            var patient1Appointments = appointmentService.GetPatientAppointments(1);
            var patient2Appointments = appointmentService.GetPatientAppointments(2);

            var doctors = doctorService.GetAll();
            var patients = patientService.GetAll();

        }
    }
}
