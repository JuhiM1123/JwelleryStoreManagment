import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintToPaperDialogComponent } from './print-to-paper-dialog.component';

describe('PrintToPaperDialogComponent', () => {
  let component: PrintToPaperDialogComponent;
  let fixture: ComponentFixture<PrintToPaperDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintToPaperDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PrintToPaperDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
