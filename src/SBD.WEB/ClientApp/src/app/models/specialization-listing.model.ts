import { Specialization } from "./specialization.model";

export class SpecializationListing {
  constructor(   
    public totalCount: number,
    public specialization: Specialization[])
  { }
}
