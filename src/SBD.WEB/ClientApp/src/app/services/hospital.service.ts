import { HttpClient, HttpParams } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import 'rxjs/add/operator/map';
import { DepartamentListing } from '../models/departament-listing.model';
import { DepartamentsFromDoctorListing } from '../models/departaments-fromDoctor-listing.model';
import { DoctorFromDepListing } from '../models/doctor-fromDep-listing';
import { DoctorListing } from '../models/doctor-listing.model';
import { HospitalListing } from '../models/hospital-listing.model';
import { Hospital } from '../models/hospital.model';
import { PatientListing } from '../models/patient-listing.model';
import { AddDepToDoctorRequest } from '../models/Request/AddDepToDoctorRequest';
import { AddSpecToDoctorRequest } from '../models/Request/AddSpecToDoctorRequest';
import { CreateDepartamentRequest } from '../models/Request/create-departament-request.model';
import { CreateDoctorRequest } from '../models/Request/create-doctor-request.model';
import { CreateHospitalRequest } from '../models/request/create-hospital-request.model';
import { CreateSpecialityRequest } from '../models/Request/create-speciality-request.model';
import { SpecializationListing } from '../models/specialization-listing.model';
import { SpecializationsFromDoctorListing } from '../models/specializations-fromDoctor-listing.model';
import { BaseService } from './base.service';




@Injectable()
export class HospitalService extends BaseService {
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    super(http, baseUrl);
  }
  
  getHospitals(page, postsPerPage = 10) {
    //w controller ok
    let url = this.baseUrl + 'Hospital/getHospitals';
    let params = new HttpParams()
      .set("page", page)
      .set("postsPerPage", postsPerPage.toString());
        
    return this.http.get<HospitalListing>(url, { params: params, headers: this.headers });
  }
  
  getHospital(id) {
    //controller ok
    let url = this.baseUrl + 'Hospital/getHospital';
    let params = new HttpParams()
      .set("id", id);
    
    return this.http.get<Hospital>(url, { params: params, headers: this.headers });
  } 

  createHospital(name: string, address: string) {
   
    let url = this.baseUrl + "hospital/CreateHospital";
    let body = new CreateHospitalRequest(name, address);

    return this.http.post(url, body, { headers: this.headers });
    }

 /* updateHospital(hospital) {      
      let url = this.baseUrl + "Hospital/updateHospital";
      return this.http.put(url, JSON.stringify(hospital), { headers: this.headers });       
      }*/
  
  getDepartaments(hospitalId, page, postsPerPage = 10) {
 
    let url = this.baseUrl + 'Hospital/GetDepartamentsFromHospital';

    let params = new HttpParams()
      .set("page", page)
      .set("postsPerPage", postsPerPage.toString())
      .set("hospitalId", hospitalId);

    return this.http.get<DepartamentListing>(url, { params: params, headers: this.headers });
  }

  createDepartament(hospitalId: string, name: string) {

    let url = this.baseUrl + "Hospital/CreateDepartament";
    let body = new CreateDepartamentRequest(hospitalId, name);

    return this.http.post(url, body, { headers: this.headers });
  }

  createSpecialzation(name: string) {
    
    let url = this.baseUrl + "Hospital/CreateSpecialization";
    let body = new CreateSpecialityRequest(name);

    return this.http.post(url, body, { headers: this.headers });
  }

  createDoctor(patientId: string) {
    let url = this.baseUrl + "Hospital/CreateDoctor";
    let body = new CreateDoctorRequest(patientId);    

    return this.http.post(url,body, {headers: this.headers });
  }

  getSpecialzations(page, postsPerPage = 10) {
    let url = this.baseUrl + 'Hospital/GetSpecializations';
    let params = new HttpParams()
      .set("page", page)
      .set("postsPerPage", postsPerPage.toString());

    return this.http.get<SpecializationListing>(url, { params: params, headers: this.headers }); 
  }

  getDoctorsFromDep(departamentId, page, postsPerPage = 10) {
    
    let url = this.baseUrl + 'Hospital/GetDoctorsFromDep';
    let params = new HttpParams()
      .set("page", page)
      .set("postsPerPage", postsPerPage.toString())
      .set("departamentId", departamentId);

    return this.http.get<DoctorFromDepListing>(url, { params: params, headers: this.headers });
  }

  getDoctors(departamentId, page, postsPerPage = 10) {

    let url = this.baseUrl + 'Hospital/GetDoctors';
    let params = new HttpParams()
      .set("page", page)
      .set("postsPerPage", postsPerPage.toString())
      .set("departamentId", departamentId);

    return this.http.get<DoctorListing>(url, { params: params, headers: this.headers });
  }

  getPatients() {
    let url = this.baseUrl + 'Hospital/GetPatients';

    return this.http.get<PatientListing>(url, { headers: this.headers }); 
  }

  getDepartamentsFromDoctor(doctorId, page, postsPerPage = 10) {
    let url = this.baseUrl + 'Hospital/GetDepartamentsFromDoctor';
    let params = new HttpParams()
      .set("page", page)
      .set("postsPerPage", postsPerPage.toString())
      .set("doctorId", doctorId);

    return this.http.get<DepartamentsFromDoctorListing>(url, { params: params, headers: this.headers }); 
  }

  getSpecializationsFromDoctor(doctorId, page, postsPerPage = 10) {
    let url = this.baseUrl + 'Hospital/GetSpecializationFromDoctor';
    let params = new HttpParams()
      .set("page", page)
      .set("postsPerPage", postsPerPage.toString())
      .set("doctorId", doctorId);

    return this.http.get<SpecializationsFromDoctorListing>(url, { params: params, headers: this.headers }); 
  }

  addDepartamentToDoctor(departamentId: string, doctorId: string) {

    let url = this.baseUrl + 'Hospital/AddDoctorSpecialization';
    let body = new AddDepToDoctorRequest(doctorId, departamentId);        

    return this.http.post(url, body, { headers: this.headers });
  }

  addSpecializationToDoctor(doctorId: string, specializationId: string) {
    let url = this.baseUrl + 'Hospital/AddDoctorDepartament';
    let body = new AddSpecToDoctorRequest(doctorId, specializationId)

    return this.http.post(url, body, { headers: this.headers });
  }

 

}
