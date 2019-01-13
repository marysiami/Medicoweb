using SBD.DATA.Models;
using SBD.HOSPITAL.Models;
using System.Threading.Tasks;

namespace SBD.HOSPITAL.Contracts
{
    public interface IHospitalService
    {
        Task<Departament> CreateDepartamentAsync( string name, Hospital hospital);
        Task<Hospital> CreateHospital( string name,string address);
        Task<HospitalListing> GetHospitalByName(int skip = 0, int take = 10);
        DepartamentListing GetHospitalDepartamenst(Hospital hospital, int skip = 0, int take = 10);        
        Task<Hospital> GetHospital(string hospitalId);

        Task<Specialization> CreateSpecialization(string name);
        Task<SpecializationListing> GetSpecializationsAsync( int skip = 0, int take = 10);

        DoctorDepartamentListing GetDepartamentDoctor(Doctor doctor, int skip = 0, int take = 10);
        DoctorSpecListing GetSpecDoctor(Doctor doctor, int skip = 0, int take = 10);
        Task<Doctor> CreateDoctor(Patient patient);
        Task<Doctor> AddDoctorDepartament(Doctor doctor, Departament departament);
        Task<Doctor> AddDoctorSpecialization(Doctor doctor, Specialization specialization);
        DoctorListing GetDoctorsFromDepartament(Departament departament, int skip = 0, int take = 10);

        PatientListing GetPatients();

        Task<Patient> GetPatientById(string id);
        Task<Doctor> GetDoctorById(string id);
        Task<Departament> GetDepartamentById(string id);
        Task<Specialization> GetSpecializationByIdAsync(string id);





    }
}
