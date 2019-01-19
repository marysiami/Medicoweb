import { Drug } from "./drug.model";

export class DrugListing {
  constructor(
    public totalCount: number,
    public drugs: Drug[]) {
  }
}
