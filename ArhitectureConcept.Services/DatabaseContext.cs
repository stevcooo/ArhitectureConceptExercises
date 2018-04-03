using System;
using System.Collections.Generic;
using ArhitectureConcept.Models;

namespace ArhitectureConcept.Services
{
    public static class DatabaseContext
    {
        public static List<Appointment> Appointments { get; set; }
        public static List<Patient> Patients { get; set; }
        public static List<Doctor> Doctors { get; set; }

        public static void PopulateDatabaseWithMockData()
        {
            PopulateFirstNames();
            PopulateLastNames();
            GenerateDoctors();
            GeneratePatients();
            GenerateAppointments();
        }

        private static void GenerateDoctors()
        {
            Doctors = new List<Doctor>();
            for (int i = 0; i < 20; i++)
            {
                Doctors.Add(new Doctor()
                {
                    Id = i,
                    YearsOfExperience = i + 4,
                    DegreeTitle = "SomeDegree",
                    FirstName = GetRandomFirstName(),
                    LastName = GetRandomLastName(),

                });
            }
        }
        private static void GeneratePatients()
        {
            Patients = new List<Patient>();
            
            for (int i = 0; i < 20; i++)
            {
                Patients.Add(new Patient()
                {
                    Id = i,
                    Age = i + 20,
                    FirstName = GetRandomFirstName(),
                    LastName = GetRandomLastName(),
                });
            }
        }
        private static void GenerateAppointments()
        {
            Random r = new Random();
            Appointments = new List<Appointment>();
            for (int i = 0; i < 30; i++)
            {
                var doctor = Doctors[r.Next(Doctors.Count)];
                var patient = Patients[r.Next(Patients.Count)];
                Appointment app = new Appointment()
                {
                    Patient = patient,
                    Doctor = doctor,
                    Id = i,
                    Date = DateTime.Now.AddDays(i)
                };
                Appointments.Add(app);
            }
        }

        private static List<string> FirstNames { get; set; }
        private static List<string> LastNames { get; set; }
        private static void PopulateFirstNames()
        {
            FirstNames = new List<string>
            {
                "James",
                "John",
                "Robert",
                "Michael",
                "William",
                "David",
                "Richard",
                "Joseph",
                "Thomas",
                "Charles",
                "Christopher",
                "Daniel",
                "Matthew",
                "Anthony",
            };
        }
        private static void PopulateLastNames()
        {
            LastNames = new List<string>
            {
                "Smith",
                "Johnson",
                "Williams",
                "Jones",
                "Brown",
                "Davis",
                "Miller",
                "Wilson",
                "Moore",
                "Taylor",
                "Anderson",
                "Thomas",
                "Jackson",
                "White",
                "Harris"
            };
        }
        private static string GetRandomFirstName()
        {
            Random r = new Random();
            return FirstNames[r.Next(FirstNames.Count)];
        }
        private static string GetRandomLastName()
        {
            Random r = new Random();
            return LastNames[r.Next(LastNames.Count)];
        }
    }
}
