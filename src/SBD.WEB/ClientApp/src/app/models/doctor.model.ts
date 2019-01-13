import { Departament } from "./departament.model";
import { Specialization } from "./specialization.model";

export class Doctor {
  constructor(
    public id: string,
    public Name: string,
    public Surname: string,
    public Pesel: string,
    public Specializations: Specialization[],
    public Departaments: Departament[],
    //co z czasem pracy?

  ) { }
}
