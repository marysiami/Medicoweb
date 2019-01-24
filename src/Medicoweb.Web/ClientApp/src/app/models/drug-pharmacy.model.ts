import { Drug } from "./drug.model";

export class DrugFromPharmacy {
  constructor(
    public pharmacyName: string,
    public totalCount: number,
    public drugs: Drug[]) {
  }
}
