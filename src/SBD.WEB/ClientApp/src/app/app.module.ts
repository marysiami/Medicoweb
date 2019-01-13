import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from '@angular/router';
import { AppComponent } from "./app.component";
import { DepartamentComponent } from './components/departament/departament.component';
import { DoctorComponent } from './components/doctor/doctor.component';
import { HomeComponent } from "./components/home/home.component";
import { CreateHospitalModalComponent } from "./components/hospital-list/create-hospital-modal/create-hospital-modal.component";
import { HospitalListComponent } from './components/hospital-list/hospital-list.component';
import { CreateDepartamentModalComponent } from "./components/hospital/create-departament-modal/create-departament-modal.component";
import { HospitalComponent } from "./components/hospital/hospital.component";
import { LoginComponent } from './components/login/login.component';
import { NavMenuComponent } from "./components/nav-menu/nav-menu.component";
import { RegisterComponent } from './components/register/register.component';
import { MaterialModule } from './material.module';
import { AuthService } from "./services/auth.service";
import { HospitalService } from "./services/hospital.service";
import { JwtUtil } from "./utils/jwt.util";
import { PatientListComponent } from './components/patient/patient-list.component';
import { DoctorListComponent } from './components/doctor-list/doctor-list.component';
import { SpecializationComponent } from './components/specialization/specialization.component';
import { CreateSpecializationModalComponent } from './components/specialization/create-specialization -modal/create-specialization-modal.component';
import { Patient } from './models/patient.model';
import { AdminHomeComponent } from './components/admin-home/admin-home.component';




@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    HospitalListComponent,
    HospitalComponent,
    CreateHospitalModalComponent,
    CreateDepartamentModalComponent,    
    DepartamentComponent,
    DoctorComponent,    
    SpecializationComponent,
    PatientListComponent,
    DoctorListComponent,
    CreateSpecializationModalComponent,
    AdminHomeComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
      { path: "login", component: LoginComponent },
      { path: "register", component: RegisterComponent },
      { path: "adminpanel", component: AdminHomeComponent},

      { path: "hospitals", component: HospitalListComponent },
      { path: "hospital/:id", component: HospitalComponent },
      { path: "departament/:id", component: DepartamentComponent },
      { path: "specialization", component: SpecializationComponent },
      { path: "specialization/:id", component: SpecializationComponent }, 
      
      { path: "patients", component: PatientListComponent },
      { path: "doctors", component: DoctorListComponent },
      { path: "doctor/:id", component: DoctorComponent }
    ]),
    HttpClientModule,
    HttpModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule
  ],
  providers: [
    AuthService,
    JwtUtil,
    HospitalService
  ],
  bootstrap: [AppComponent],
  entryComponents: [
    CreateHospitalModalComponent,
    CreateDepartamentModalComponent,
    CreateSpecializationModalComponent
  ]
})
export class AppModule {
}
