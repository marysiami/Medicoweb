import { Departament } from "../departament.model";
import { Specialization } from "../specialization.model";

export class CreateDoctorRequest {
  constructor(
    public Name: string,
    public Surname: string,
    public Specializations: Specialization[],
    public Departaments: Departament[]) { }
}
