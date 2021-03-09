import { Component, OnInit, Inject } from '@angular/core';

import {MatDialogRef, MAT_DIALOG_DATA, MatDialog} from  '@angular/material/dialog';

@Component({
  selector: 'app-print-to-screen-dialog',
  templateUrl: './print-to-screen-dialog.component.html',
  styleUrls: ['./print-to-screen-dialog.component.css']
})
export class PrintToScreenDialogComponent implements OnInit {

  constructor(private  dialogRef:  MatDialogRef<PrintToScreenDialogComponent>, @Inject(MAT_DIALOG_DATA) public  data:  any) {
  }

  onClose(): void {
    this.dialogRef.close();
  }

  ngOnInit(): void {
  }

}
