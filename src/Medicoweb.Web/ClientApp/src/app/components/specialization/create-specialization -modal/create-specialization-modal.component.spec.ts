import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateSpecializationModalComponent } from './create-specialization-modal.component';

describe('CreateSpecializationModalComponent', () => {
  let component: CreateSpecializationModalComponent;
  let fixture: ComponentFixture<CreateSpecializationModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [CreateSpecializationModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateSpecializationModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
