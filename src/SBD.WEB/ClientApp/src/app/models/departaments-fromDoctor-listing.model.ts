import { Departament } from "./departament.model";
import { Doctor } from "./doctor.model";

export class DepartamentsFromDoctorListing {
  constructor(
    public doctorName: string,
    public doctorSurname: string,
    public totalCount: number,   
    public departmanets: Departament[]) { }
}
