import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { CreateDepartamentModalComponent } from "./create-departament-modal.component";

describe("CreateDepartamentModalComponent",
  () => {
    let component: CreateDepartamentModalComponent;
    let fixture: ComponentFixture<CreateDepartamentModalComponent>;

    beforeEach(async(() => {
      TestBed.configureTestingModule({
          declarations: [CreateDepartamentModalComponent]
        })
        .compileComponents();
    }));

    beforeEach(() => {
      fixture = TestBed.createComponent(CreateDepartamentModalComponent);
      component = fixture.componentInstance;
      fixture.detectChanges();
    });

    it("should create",
      () => {
        expect(component).toBeTruthy();
      });
  });
