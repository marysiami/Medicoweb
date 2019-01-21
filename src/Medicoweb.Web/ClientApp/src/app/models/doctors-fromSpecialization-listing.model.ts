import { Doctor } from "./doctor.model";

export class DoctorsFromSpecialization {
  constructor(
    public specializationName: string,
    public totalCount: number,
    public doctors: Doctor[]) {
  }
}
