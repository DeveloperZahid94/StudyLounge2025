import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FeeDetailDialogComponent } from './fee-detail-dialog.component';

describe('FeeDetailDialogComponent', () => {
  let component: FeeDetailDialogComponent;
  let fixture: ComponentFixture<FeeDetailDialogComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FeeDetailDialogComponent]
    });
    fixture = TestBed.createComponent(FeeDetailDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
