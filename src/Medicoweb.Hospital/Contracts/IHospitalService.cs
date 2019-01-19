using System.Threading.Tasks;
using Medicoweb.Data.Models;
using Medicoweb.Data.Models.Account;
using Medicoweb.Data.Models.Hospital;
using Medicoweb.Hospital.Models;

namespace Medicoweb.Hospital.Contracts
{
    public interface IHospitalService
    {
        Task<Departament> CreateDepartamentAsync(string name, Data.Models.Hospital.Hospital hospital);
        Task<Data.Models.Hospital.Hospital> CreateHospital(string name, string address);
        Task<HospitalListing> GetHospitalsByName(int skip = 0, int take = 10);
        Task<HospitalListing> GetoHospitalsByAddressAsync(int skip = 0, int take = 10);
        DepartamentListing GetHospitalDepartamenst(Data.Models.Hospital.Hospital hospital, int skip = 0, int take = 10);
        Task<Data.Models.Hospital.Hospital> GetHospital(string hospitalId);
        Task<Data.Models.Hospital.Hospital> GetHospitalByName(string name);
        Task<Departament> GetDepartamentByName(string name);

        void DeleteDepartament(Departament departament);
        Task UpdateDepartament(string id, string name);
        Task UpdateHospital(string id, string name, string address);
        Task UpdateSpecialization(string id, string name);
        void DeleteSpecialization(Specialization specialization);


        Task<Specialization> CreateSpecialization(string name);
        Task<SpecializationListing> GetSpecializationsAsync(int skip = 0, int take = 10);
        Task<SpecializationListing> GetSpecializationsByName(int skip = 0, int take = 10);
        Task<Specialization> GetSpecializationByName(string name);

        DoctorDepartamentListing GetDepartamentDoctor(Doctor doctor, int skip = 0, int take = 10);
        DoctorSpecListing GetSpecDoctor(Doctor doctor, int skip = 0, int take = 10);
        Task<Doctor> CreateDoctor(MedicowebUser patient);
        Task<Doctor> AddDoctorDepartament(Doctor doctor, Departament departament);
        Task<Doctor> AddDoctorSpecialization(Doctor doctor, Specialization specialization);
        DoctorListing GetDoctorsFromDepartament(Departament departament, int skip = 0, int take = 10);

        PatientListing GetPatients();
        PatientListing GetPatientsByName();
        PatientListing GetPatientBySurname();
        PatientListing GetPatientByPesel();
        Task<MedicowebUser> GetPatientById(string id);
        Task<Doctor> GetDoctorById(string id);
        Task<Departament> GetDepartamentById(string id);
        Task<Specialization> GetSpecializationByIdAsync(string id);
    }
}