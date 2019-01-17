using SBD.DATA.Models;
using SBD.DATA.Models.Account;
using SBD.HOSPITAL.Models;
using System.Threading.Tasks;

namespace SBD.HOSPITAL.Contracts
{
    public interface IHospitalService
    {
        Task<Departament> CreateDepartamentAsync(string name, Hospital hospital);
        Task<Hospital> CreateHospital(string name, string address);
        Task<HospitalListing> GetHospitalsByName(int skip = 0, int take = 10);
        Task<HospitalListing> GetoHospitalsByAddressAsync(int skip = 0, int take = 10);
        DepartamentListing GetHospitalDepartamenst(Hospital hospital, int skip = 0, int take = 10);
        Task<Hospital> GetHospital(string hospitalId);
        Task<Hospital> GetHospitalByName(string name);
        Task<Departament> GetDepartamentByName(string name);

        void DeleteDepartament(Departament departament);
        void UpdateDepartament(Departament departament);
        void UpdateHospital(Hospital hospital);
        void UpdateSpecialization(Specialization specialization);
        void DeleteSpecialization(Specialization specialization);


        Task<Specialization> CreateSpecialization(string name);
        Task<SpecializationListing> GetSpecializationsAsync(int skip = 0, int take = 10);
        Task<SpecializationListing> GetSpecializationsByName(int skip = 0, int take = 10);
        Task<Specialization> GetSpecializationByName(string name);

        DoctorDepartamentListing GetDepartamentDoctor(Doctor doctor, int skip = 0, int take = 10);
        DoctorSpecListing GetSpecDoctor(Doctor doctor, int skip = 0, int take = 10);
        Task<Doctor> CreateDoctor(SBDUser patient);
        Task<Doctor> AddDoctorDepartament(Doctor doctor, Departament departament);
        Task<Doctor> AddDoctorSpecialization(Doctor doctor, Specialization specialization);
        DoctorListing GetDoctorsFromDepartament(Departament departament, int skip = 0, int take = 10);

        PatientListing GetPatients();
        PatientListing GetPatientsByName();
        PatientListing GetPatientBySurname();
        PatientListing GetPatientByPesel();
        Task<SBDUser> GetPatientById(string id);
        Task<Doctor> GetDoctorById(string id);
        Task<Departament> GetDepartamentById(string id);
        Task<Specialization> GetSpecializationByIdAsync(string id);





    }
}
