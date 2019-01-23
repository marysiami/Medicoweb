import { Drug } from "./drug.model";

export class DrugPrescriptionListing
{
  constructor(
    public drug: Drug[],
    public quantity: number) {
  }
}
