import { HttpClient, HttpParams } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import "rxjs/add/operator/map";
import { DepartamentListing } from "../models/departament-listing.model";
import { DepartamentsFromDoctorListing } from "../models/departaments-fromDoctor-listing.model";
import { DoctorFromDepListing } from "../models/doctor-fromDep-listing";
import { DoctorListing } from "../models/doctor-listing.model";
import { HospitalListing } from "../models/hospital-listing.model";
import { Hospital } from "../models/hospital.model";
import { PatientListing } from "../models/patient-listing.model";
import { AddDepToDoctorRequest } from "../models/Request/AddDepToDoctorRequest";
import { AddSpecToDoctorRequest } from "../models/Request/AddSpecToDoctorRequest";
import { CreateDepartamentRequest } from "../models/Request/create-departament-request.model";
import { CreateDoctorRequest } from "../models/Request/create-doctor-request.model";
import { CreateHospitalRequest } from "../models/request/create-hospital-request.model";
import { CreateSpecialityRequest } from "../models/Request/create-speciality-request.model";
import { SpecializationListing } from "../models/specialization-listing.model";
import { SpecializationsFromDoctorListing } from "../models/specializations-fromDoctor-listing.model";
import { BaseService } from "./base.service";
import { DrugListing } from "../models/drug-listing.model";
import { CreateDrugRequest } from "../models/Request/create-drug-request.model";
import { Drug } from "../models/drug.model";
import { Specialization } from "../models/specialization.model";


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

  getHospitalsByAddress(page, postsPerPage = 10) {
    //w controller ok
    const url = this.baseUrl + "Hospital/GetHospitalsByAddress";
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

  /*updateHospital(hospitalId:string, name: string, address: string) {
 
     let url = this.baseUrl + "Hospital/UpdateHospital";
     let body = new UpdateHospitalRequest(hospitalId, name, address);
 
     return this.http.put(url, body, { headers: this.headers });
   }
   deleteHospital(hospitalId) {
     let url = this.baseUrl + "Hospital/";
    
     return this.http.put(url, body, { headers: this.headers });
   }*/
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

  getSpecialzationsByName(page, postsPerPage = 10) {
    const url = this.baseUrl + "Hospital/GetSpecializationsByName";
    const params = new HttpParams()
      .set("page", page)
      .set("postsPerPage", postsPerPage.toString());

    return this.http.get<SpecializationListing>(url, { params: params, headers: this.headers });
  }

  getDoctorsFromDep(departamentId, page, postsPerPage = 10) {

    const url = this.baseUrl + "Hospital/GetDoctorsFromDep";
    const params = new HttpParams()
      .set("page", page)
      .set("postsPerPage", postsPerPage.toString())
      .set("departamentId", departamentId);

    return this.http.get<DoctorFromDepListing>(url, { params: params, headers: this.headers });
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

  getPatientsByName() {
    const url = this.baseUrl + "Hospital/GetPatientsByName";

    return this.http.get<PatientListing>(url, { headers: this.headers });
  }

  getPatientsBySurname() {
    const url = this.baseUrl + "Hospital/GetPatientsBySurname";

    return this.http.get<PatientListing>(url, { headers: this.headers });
  }

  getPatientsByPesel() {
    const url = this.baseUrl + "Hospital/GetPatientsByPesel";

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

    return this.http.get<SpecializationsFromDoctorListing>(url, { params: params, headers: this.headers });
  }

  addDepartamentToDoctor(departamentId: string, doctorId: string) {

    const url = this.baseUrl + "Hospital/AddDoctorSpecialization";
    const body = new AddDepToDoctorRequest(doctorId, departamentId);

    return this.http.post(url, body, { headers: this.headers });
  }

  addSpecializationToDoctor(doctorId: string, specializationId: string) {
    const url = this.baseUrl + "Hospital/AddDoctorDepartament";
    const body = new AddSpecToDoctorRequest(doctorId, specializationId);

    return this.http.post(url, body, { headers: this.headers });
  }

  //kontruktor VISIT
  getDrugs(page, postsPerPage = 10) {

    const url = this.baseUrl + "Visit/GetDrugs";
    const params = new HttpParams()
      .set("page", page)
      .set("postsPerPage", postsPerPage.toString());

    return this.http.get<DrugListing>(url, { params: params, headers: this.headers });
  }

  createDrug(name: string, company: string) {
    const url = this.baseUrl + "Visit/CreateDrug";
    const body = new CreateDrugRequest(name, company);

    return this.http.post(url, body, { headers: this.headers });
  }

  deleteDrug(drugId: string) {
    const url = this.baseUrl + "visit/DeleteDrug";
    const params = new HttpParams()
      .set("id", drugId);

    return this.http.delete(url, { params: params, headers: this.headers });
  }

  updateDrug(drugId: string, drugName: string, drugCompany: string) {
    const url = this.baseUrl + "visit/UpdateDrug";
    debugger;
    const body = new Drug(drugId, drugName, drugCompany);

    return this.http.put(url, body, { headers: this.headers });
  }

}
