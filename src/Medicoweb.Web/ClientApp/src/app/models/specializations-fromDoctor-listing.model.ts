import { Specialization } from "./specialization.model";

export class SpecializationsFromDoctorListing {
  constructor(
    public doctorName: string,
    public doctorSurname: string,
    public totalCount: number,
    public specializations: Specialization[]) {
  }
}
