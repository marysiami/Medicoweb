import { Departament } from "./departament.model";

export class DepartamentsFromDoctorListing {
  constructor(
    public doctorName: string,
    public doctorSurname: string,
    public totalCount: number,
    public departmanets: Departament[]) {
  }
}
