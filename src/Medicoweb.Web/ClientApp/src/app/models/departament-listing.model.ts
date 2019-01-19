import { Departament } from './departament.model';

export class DepartamentListing {
  constructor(
    public hospitalName: string,
    public totalCount: number,
    public departaments: Departament[]) { }
}
