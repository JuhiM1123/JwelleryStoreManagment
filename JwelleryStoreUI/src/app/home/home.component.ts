
import { Component, ViewChild, OnInit, ElementRef } from '@angular/core';
import { User } from 'src/app/models/User';
import { AuthenticationService } from 'src/app/services/authenticationService';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EstimationModel } from 'src/app/models/EstimationModel'
import { MatDialog } from '@angular/material/dialog';
import { PrintToScreenDialogComponent } from 'src/app/home/print-to-screen-dialog/print-to-screen-dialog.component'
import { PrintToPaperDialogComponent } from 'src/app/home/print-to-paper-dialog/print-to-paper-dialog.component'
import { jsPDF } from 'jspdf';
import html2canvas from 'html2canvas';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  priceCalculatorForm : FormGroup;
  user: User;
  estimation = new EstimationModel();
  submitted = false;
  
  @ViewChild('content') content:ElementRef;

  constructor(private authenticationService: AuthenticationService,  private formBuilder: FormBuilder, public dialog: MatDialog) {
  
   }
   
  get priceCalculatorFormControl() { return this.priceCalculatorForm.controls; }

  ngOnInit() {
 
      this.user = this.authenticationService.currentUserValue;
      this.estimation.discountPrice = this.user.discountPrice;
      this.priceCalculatorForm = this.formBuilder.group({
        goldPrice: ['', Validators.required],
        weight: ['', Validators.required],
    });
    
  }

   onSubmit() {
    this.submitted = true;
      // stop here if form is invalid
      if (this.priceCalculatorForm.invalid) {
          return;
      }
      if(this.user.roleName == 'Normal')
      {
          this.estimation.totalPrice = (this.priceCalculatorFormControl.goldPrice.value * this.priceCalculatorFormControl.weight.value)
      }
      else{
        this.estimation.totalPrice = (this.priceCalculatorFormControl.goldPrice.value * this.priceCalculatorFormControl.weight.value) - (this.priceCalculatorFormControl.goldPrice.value * this.priceCalculatorFormControl.weight.value*this.estimation.discountPrice/100)
      }

      this.estimation.goldPrice = this.priceCalculatorFormControl.goldPrice.value;
      this.estimation.weight = this.priceCalculatorFormControl.weight.value; 
  }

  clearDetails():void{
    this.estimation.goldPrice = null;
    this.estimation.totalPrice = null;
    this.estimation.weight = null;
    this.priceCalculatorForm.reset();
    
  }

  openPrintTosScreenDialog(): void{
    const dialogRef = this.dialog.open(PrintToScreenDialogComponent, {
      width: '500px;',
      height: '500px;',
      data: { estimation : this.estimation, user : this.user }
    });
  }

  openPrintToFileDialog(): void{
    const data = document.getElementById('content');
    html2canvas(data).then(canvas => {
        const fileWidth = 200;
        const fileHeight = canvas.height * fileWidth / canvas.width;
        const position = 5;
        const fileUri = canvas.toDataURL('image/png')
        const pdf = new jsPDF('p', 'mm', 'a4');
        pdf.addImage(fileUri, 'PNG', 5, position, fileWidth, fileHeight)       
        pdf.save(this.user.firstName+'_'+this.user.lastName+'.pdf');
    });        
  }

  openPrintToPaper() : void{
    const dialogRef = this.dialog.open(PrintToPaperDialogComponent, {
      width: '500px;',
    });
  }
}
