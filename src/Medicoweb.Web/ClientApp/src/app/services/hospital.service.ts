import { HttpClient, HttpParams } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import "rxjs/add/operator/map";
import { DepartamentListing } from "../models/departament-listing.model";
import { Departament } from "../models/departament.model";
import { DepartamentsFromDoctorListing } from "../models/departaments-fromDoctor-listing.model";
import { DoctorFromDepListing } from "../models/doctor-fromDep-listing";
import { DoctorListing } from "../models/doctor-listing.model";
import { DoctorsFromSpecialization } from "../models/doctors-fromSpecialization-listing.model";
import { DrugListing } from "../models/drug-listing.model";
import { Drug } from "../models/drug.model";
import { HospitalListing } from "../models/hospital-listing.model";
import { Hospital } from "../models/hospital.model";
import { PatientListing } from "../models/patient-listing.model";
import { PrescriptionListing } from "../models/prescription-listing.model";
import { AddDrugToPrescription } from "../models/Request/Add-drug-toPrescription.model";
import { AddDepToDoctorRequest } from "../models/Request/AddDepToDoctorRequest";
import { AddSpecToDoctorRequest } from "../models/Request/AddSpecToDoctorRequest";
import { CreateDepartamentRequest } from "../models/Request/create-departament-request.model";
import { CreateDoctorRequest } from "../models/Request/create-doctor-request.model";
import { CreateDrugRequest } from "../models/Request/create-drug-request.model";
import { CreateHospitalRequest } from "../models/request/create-hospital-request.model";
import { CreateSpecialityRequest } from "../models/Request/create-speciality-request.model";
import { CreateVisitRequest } from "../models/Request/create-visit-request.model";
import { SpecializationListing } from "../models/specialization-listing.model";
import { Specialization } from "../models/specialization.model";
import { VisitListing } from "../models/visit-listing.model";
import { BaseService } from "./base.service";
import { CreatePrescriptionRequest } from "../models/Request/create-prescription-request";
import { Prescription } from "../models/prescription.model";
import { CreatePharmacyRequest } from "../models/Request/create-pharmacy-request.model";
import { DrugFromPharmacy } from "../models/drug-pharmacy.model";
import { Pharmacy } from "../models/Pharmacy.model";
import { AddDrugToPharmacy } from "../models/Request/AddDrugToPharmacy.model";
import { PharmacyListing } from "../models/pharmacy-listing.model";


@Injectable()
export class HospitalService extends BaseService {
  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    super(http, baseUrl);
  }

  getHospitals(page, postsPerPage = 10) {
    //w controller ok
    const url = this.baseUrl + "Hospital/GetHospitalsByName";
    const params = new HttpParams()
      .set("page", page)
      .set("postsPerPage", postsPerPage.toString());

    return this.http.get<HospitalListing>(url, { params: params, headers: this.headers });
  }


  getHospital(id) {
    //controller ok
    const url = this.baseUrl + "Hospital/getHospital";
    const params = new HttpParams()
      .set("id", id);

    return this.http.get<Hospital>(url, { params: params, headers: this.headers });
  }

  createHospital(name: string, address: string) {

    const url = this.baseUrl + "hospital/CreateHospital";
    const body = new CreateHospitalRequest(name, address);

    return this.http.post(url, body, { headers: this.headers });
  }

  updateHospital(hospitalId:string, name: string, address: string) {
 
     let url = this.baseUrl + "Hospital/UpdateHospital";
     let body = new Hospital(hospitalId, name, address);
 
     return this.http.put(url, body, { headers: this.headers });
   }
   deleteHospital(hospitalId) {
     let url = this.baseUrl + "Hospital/DeleteHospital";    
     const params = new HttpParams()
       .set("id", hospitalId);

     return this.http.delete(url, { params: params, headers: this.headers });
   }
  getDepartaments(hospitalId, page, postsPerPage = 10) {

    const url = this.baseUrl + "Hospital/GetDepartamentsFromHospital";

    const params = new HttpParams()
      .set("page", page)
      .set("postsPerPage", postsPerPage.toString())
      .set("hospitalId", hospitalId);

    return this.http.get<DepartamentListing>(url, { params: params, headers: this.headers });
  }

  createDepartament(hospitalId: string, name: string) {

    const url = this.baseUrl + "Hospital/CreateDepartament";
    const body = new CreateDepartamentRequest(hospitalId, name);

    return this.http.post(url, body, { headers: this.headers });
  }

  updateDepartament(hospitalId: string, name: string) {

    let url = this.baseUrl + "Hospital/UpdateDepartament";
    let body = new Departament(hospitalId, name);

    return this.http.put(url, body, { headers: this.headers });
  }
  deleteDepartament(id) {
    let url = this.baseUrl + "Hospital/DeleteDepartament";
    const params = new HttpParams()
      .set("id", id);

    return this.http.delete(url, { params: params, headers: this.headers });
  }

  createSpecialzation(name: string) {

    const url = this.baseUrl + "Hospital/CreateSpecialization";
    const body = new CreateSpecialityRequest(name);

    return this.http.post(url, body, { headers: this.headers });
  }

  deleteSpecialization(specializationId: string) {
   
    const url = this.baseUrl + "Hospital/DeleteSpecialization";
    const params = new HttpParams()
      .set("id", specializationId);

    return this.http.delete(url, { params: params, headers: this.headers });
  }

  updateSpecialization(specializationId: string, name: string) {
    const url = this.baseUrl + "Hospital/UpdateSpecialization";
    const body = new Specialization(specializationId, name);

    return this.http.put(url, body, { headers: this.headers });
  }

  createDoctor(patientId: string) {
    const url = this.baseUrl + "Hospital/CreateDoctor";
    const body = new CreateDoctorRequest(patientId);

    return this.http.post(url, body, { headers: this.headers });
  }

  getSpecialzations(page, postsPerPage = 10) {
    const url = this.baseUrl + "Hospital/GetSpecializations";
    const params = new HttpParams()
      .set("page", page)
      .set("postsPerPage", postsPerPage.toString());

    return this.http.get<SpecializationListing>(url, { params: params, headers: this.headers });
  }

  getDoctorsFromDep(departamentId, page, postsPerPage = 10) {
    const url = this.baseUrl + "Hospital/GetDoctors";
    const params = new HttpParams()
      .set("page", page)
      .set("postsPerPage", postsPerPage.toString())
      .set("departamentId", departamentId);
   
    return this.http.get<DoctorFromDepListing>(url, { params: params, headers: this.headers });
  }
  getDoctorsFromSpeciaization(specializationId, page, postsPerPage = 10) {

    const url = this.baseUrl + "Hospital/GetDoctorsFromSpecialization";
    const params = new HttpParams()
      .set("page", page)
      .set("postsPerPage", postsPerPage.toString())
      .set("specializationId", specializationId);

    return this.http.get<DoctorsFromSpecialization>(url, { params: params, headers: this.headers });
  }

  getDoctors(departamentId, page, postsPerPage = 10) {

    const url = this.baseUrl + "Hospital/GetDoctors";
    const params = new HttpParams()
      .set("page", page)
      .set("postsPerPage", postsPerPage.toString())
      .set("departamentId", departamentId);

    return this.http.get<DoctorListing>(url, { params: params, headers: this.headers });
  }

  getPatients() {
    const url = this.baseUrl + "Hospital/GetPatients";

    return this.http.get<PatientListing>(url, { headers: this.headers });
  }

  getDepartamentsFromDoctor(doctorId, page, postsPerPage = 10) {
    const url = this.baseUrl + "Hospital/GetDepartamentsFromDoctor";
    const params = new HttpParams()
      .set("page", page)
      .set("postsPerPage", postsPerPage.toString())
      .set("doctorId", doctorId);

    return this.http.get<DepartamentsFromDoctorListing>(url, { params: params, headers: this.headers });
  }

  getSpecializationsFromDoctor(doctorId, page, postsPerPage = 10) {
    const url = this.baseUrl + "Hospital/GetSpecializationFromDoctor";
    const params = new HttpParams()
      .set("page", page)
      .set("postsPerPage", postsPerPage.toString())
      .set("doctorId", doctorId);

    return this.http.get<DoctorsFromSpecialization>(url, { params: params, headers: this.headers });
  }

  addDepartamentToDoctor(departamentId: string, doctorId: string) {
    const url = this.baseUrl + "Hospital/AddDoctorDepartament";
    const body = new AddDepToDoctorRequest(doctorId, departamentId);
    
    return this.http.post(url, body, { headers: this.headers });
  }

  addSpecializationToDoctor(specializationId: string, doctorId: string) {
    const url = this.baseUrl + "Hospital/AddDoctorSpecialization";
    const body = new AddSpecToDoctorRequest(doctorId, specializationId);
    
    return this.http.post(url, body, { headers: this.headers });
  }
  deleteDepartamentFromDoctor(doctorId: string, departamentId: string) {
    const url = this.baseUrl + "Hospital/DeleteDoctorDepartament";
    const params = new HttpParams()
      .set("doctorId", doctorId)
      .set("departamentId",departamentId);

    return this.http.delete(url, { params: params, headers: this.headers });    
  }

  deleteSpecializationFromDoctor(doctorId: string, specializationId: string) {
    const url = this.baseUrl + "Hospital/DeleteDoctorSpecialization";
    const params = new HttpParams()
      .set("doctorId", doctorId)
      .set("specializationId", specializationId);

    return this.http.delete(url, { params: params, headers: this.headers });
  }

  //kontruktor drug
  getDrugs(page, postsPerPage = 10) {

    const url = this.baseUrl + "drug/GetDrugs";
    const params = new HttpParams()
      .set("page", page)
      .set("postsPerPage", postsPerPage.toString());

    return this.http.get<DrugListing>(url, { params: params, headers: this.headers });
  }

  createDrug(name: string, company: string) {
    const url = this.baseUrl + "drug/CreateDrug";
    const body = new CreateDrugRequest(name, company);

    return this.http.post(url, body, { headers: this.headers });
  }

  deleteDrug(drugId: string) {
    const url = this.baseUrl + "drug/DeleteDrug";
    const params = new HttpParams()
      .set("id", drugId);

    return this.http.delete(url, { params: params, headers: this.headers });
  }

  updateDrug(drugId: string, drugName: string, drugCompany: string) {
    const url = this.baseUrl + "drug/UpdateDrug";
    debugger;
    const body = new Drug(drugId, drugName, drugCompany);

    return this.http.put(url, body, { headers: this.headers });
  }

  //kontruktor visit
  getHoursFromDay(date: Date) {
    
    const url = this.baseUrl + "visit/GetHoursFromDay";
    const params = new HttpParams()
      .set("date", date.toString());

    return this.http.get<Date[]>(url, { params: params, headers: this.headers }); 
  }
  getVisitsFromPatient(id: string) {
    const url = this.baseUrl + "visit/GetPatientVisits";
    const params = new HttpParams()
      .set("id", id);
    
    return this.http.get<VisitListing>(url, { params: params, headers: this.headers });
  }
  getVisitsFromDoctor(id: string) {
    const url = this.baseUrl + "visit/GetDoctorVisits";
    const params = new HttpParams()
      .set("id", id);

    return this.http.get<VisitListing>(url, { params: params, headers: this.headers });
  }
  createVisit(hospitalId: string, doctorId: string, patientId: string, date: string) {
    const url = this.baseUrl + "visit/CreateVisit";
    const body = new CreateVisitRequest(hospitalId,doctorId,patientId,date);
  
    return this.http.post(url, body, { headers: this.headers });
  }

  createPrescription(visitId: string) {
    const url = this.baseUrl + "visit/CreatePrescription";
    const body = new CreatePrescriptionRequest(visitId);

    return this.http.post < Prescription>(url, body, { headers: this.headers });
  }

  getPrescriptionsFromVisit(visitId: string) {
    const url = this.baseUrl + "visit/GetPrescriptionsFromVisit";
    const params = new HttpParams()
      .set("visitId", visitId);

    return this.http.get<PrescriptionListing>(url, { params: params, headers: this.headers });
  }
  addDrugToPrescription(drugId: string, drugQuantity: number, prescriptionId: string) {
    const url = this.baseUrl + "visit/AddDrugToPrescription";
    const body = new AddDrugToPrescription(drugId, drugQuantity, prescriptionId);
   
    return this.http.post(url, body, { headers: this.headers });
  }
  getPrescripion(prescriptionId: string) {
    const url = this.baseUrl + "visit/GetPrescription";
    const params = new HttpParams()
      .set("prescriptionId", prescriptionId);

    return this.http.get<Prescription>(url, { params: params, headers: this.headers });
  }
  //kontroller Pharmacy

  createPharmacy(name: string, address: string) {
    const url = this.baseUrl + "Pharmacy/CreatePharmacy";
    const body = new CreatePharmacyRequest(name,address);

    return this.http.post(url, body, { headers: this.headers });
  }

  getDrugsFromPharmacy(pharmacyId: string, page, postsPerPage = 10) {
    const url = this.baseUrl + "Pharmacy/GetDrugsFromPharmacy";
    const params = new HttpParams()
      .set("page", page)
      .set("postsPerPage", postsPerPage.toString())
      .set("pharmacyId", pharmacyId);

    return this.http.get<DrugFromPharmacy>(url, { params: params, headers: this.headers });
  }

  deleteDrugFromPharmacy(drugId: string, pharmacyId: string) {
    const url = this.baseUrl + "Pharmacy/DeleteDrugFromPharmacy";
    const params = new HttpParams()
      .set("drugId", drugId)
      .set("pharmacyId", pharmacyId);

    return this.http.delete(url, { params: params, headers: this.headers });    
  }

  updatePharmacy(pharmacyId: string, name: string, address: string) {
    const url = this.baseUrl + "Pharmacy/UpdatePharmacy";
    const body = new Pharmacy(pharmacyId, name, address);

    return this.http.put(url, body, { headers: this.headers });
  }
  addDrugToPharmacy(drugId: string, pharmacyId: string) {
    const url = this.baseUrl + "Pharmacy/AddDrugToPharmacy";
    const body = new AddDrugToPharmacy(drugId,pharmacyId);

    return this.http.post(url, body, { headers: this.headers });
  }
  getPharmacies(page, postsPerPage = 10) {
    const url = this.baseUrl + "Pharmacy/GetPharmacies";
    const params = new HttpParams()
      .set("page", page)
      .set("postsPerPage", postsPerPage.toString());

    return this.http.get<PharmacyListing>(url, { params: params, headers: this.headers });
  }
  deletePharmacy(pharmacyId: string) {
    const url = this.baseUrl + "Pharmacy/DeletePharmacy";
    const params = new HttpParams()
     .set("pharmacyId", pharmacyId);

    return this.http.delete(url, { params: params, headers: this.headers });    
  }
}
