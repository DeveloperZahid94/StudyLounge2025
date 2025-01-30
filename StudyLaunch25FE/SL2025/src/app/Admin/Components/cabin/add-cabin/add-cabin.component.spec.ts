import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddCabinComponent } from './add-cabin.component';

describe('AddCabinComponent', () => {
  let component: AddCabinComponent;
  let fixture: ComponentFixture<AddCabinComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddCabinComponent]
    });
    fixture = TestBed.createComponent(AddCabinComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
