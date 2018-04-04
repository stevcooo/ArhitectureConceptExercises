using System;
using ArhitectureConcept.Interfaces.Services;
using ArhitectureConcept.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using ArhitectureConcept.Models;

namespace ArhitectureConcept.Tests.Services
{
    [TestClass]
    public class AppointmentServiceTests
    {
        private ILoggerService _loggerService;
        private IAppointmentService _appointmentService;

        [TestInitialize]
        public void Initialize()
        {   
            DatabaseContext.PopulateDatabaseWithMockData();
            var mock = new Mock<ILoggerService>();
            mock.Setup(t => t.LogLine(It.IsAny<string>()));
            mock.Setup(t => t.Log(It.IsAny<string>()));
            _loggerService = mock.Object;
            _appointmentService = new AppointmentService(_loggerService);
        }

        [TestMethod]
        public void GetAppointmentsTest()
        {
            var appointments = _appointmentService.GetAppointments();
            Assert.IsTrue(appointments.Any());
        }

        [TestMethod]
        public void Get_existing_appointment()
        {
            var appointment = _appointmentService.GetAppointment(0);
            Assert.IsNotNull(appointment);
        }

        [TestMethod]
        public void Get_nonexisting_appointment_should_return_null()
        {
            var appointment = _appointmentService.GetAppointment(-1);
            Assert.IsNull(appointment);
        }

        [TestMethod]
        public void Get_existing_appointment_for_doctor()
        {
            var doctor = DatabaseContext.Doctors[0];
            Appointment app = new Appointment()
            {
                Doctor = doctor,
                Patient = DatabaseContext.Patients[0],
                Date = DateTime.Now
            };

            _appointmentService.AddAppointment(app);
            var appointment = _appointmentService.GetDoctorAppointments(doctor.Id);
            Assert.IsNotNull(appointment);
        }

        [TestMethod]
        public void Get_existing_appointment_for_patient()
        {
            var patient = DatabaseContext.Patients[0];
            Appointment app = new Appointment()
            {
                Doctor = DatabaseContext.Doctors[0],
                Patient = patient,
                Date = DateTime.Now
            };

            _appointmentService.AddAppointment(app);
            var appointment = _appointmentService.GetPatientAppointments(patient.Id);
            Assert.IsNotNull(appointment);
        }

        [TestMethod]
        public void Add_appointment()
        {
            int beforeAdd = DatabaseContext.Appointments.Count;
            Appointment app = new Appointment()
            {
                Doctor = DatabaseContext.Doctors[0],
                Patient = DatabaseContext.Patients[0],
                Date = DateTime.Now
            };
            _appointmentService.AddAppointment(app);

            int afterAdd = DatabaseContext.Appointments.Count;

            Assert.IsTrue(afterAdd - beforeAdd == 1);
        }

        [TestMethod]
        public void Remove_appointment()
        {
            var beforeRemove = DatabaseContext.Appointments.Count;
            var appointmentToRemove = DatabaseContext.Appointments.FirstOrDefault();

            _appointmentService.RemoveAppointment(appointmentToRemove);

            var afterRemove = DatabaseContext.Appointments.Count;
            Assert.IsTrue(beforeRemove - afterRemove == 1);
        }
    }
}
