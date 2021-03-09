import { Component, OnInit } from '@angular/core';
import {MatDialogRef} from  '@angular/material/dialog';

@Component({
  selector: 'app-print-to-paper-dialog',
  templateUrl: './print-to-paper-dialog.component.html',
  styleUrls: ['./print-to-paper-dialog.component.css']
})
export class PrintToPaperDialogComponent implements OnInit {

  constructor(private  dialogRef:  MatDialogRef<PrintToPaperDialogComponent>) {
  }

  onClose(): void {
    this.dialogRef.close();
  }


  ngOnInit(): void {
  }

}
