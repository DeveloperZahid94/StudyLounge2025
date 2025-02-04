import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CabinListComponent } from './cabin-list.component';

describe('CabinListComponent', () => {
  let component: CabinListComponent;
  let fixture: ComponentFixture<CabinListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CabinListComponent]
    });
    fixture = TestBed.createComponent(CabinListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
