import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintToScreenDialogComponent } from './print-to-screen-dialog.component';

describe('PrintToScreenDialogComponent', () => {
  let component: PrintToScreenDialogComponent;
  let fixture: ComponentFixture<PrintToScreenDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintToScreenDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PrintToScreenDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
