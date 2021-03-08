import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import { NgForm } from '@angular/forms';
import { User } from 'src/app/models/User';
import { AuthenticationService } from 'src/app/services/authenticationService';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EstimationModel } from 'src/app/models/EstimationModel'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  priceCalculatorForm : FormGroup;
  loading = false;
  user: User;
  estimation = new EstimationModel();
  error:'';
  submitted = false;
  
  constructor(private authenticationService: AuthenticationService,  private formBuilder: FormBuilder) {
  
   }

  ngOnInit() {
      this.loading = true;
      this.user = this.authenticationService.currentUserValue;
      this.estimation.discountPrice = this.user.discountPrice;
      console.log(this.estimation.discountPrice);
      console.log(this.user.discountPrice);
      this.priceCalculatorForm = this.formBuilder.group({
        goldPrice: ['', Validators.required],
        weight: ['', Validators.required],
    });
    
  }
 // convenience getter for easy access to form fields
   get f() { return this.priceCalculatorForm.controls; }


   onSubmit() {
      
    this.submitted = true;

      // stop here if form is invalid
      if (this.priceCalculatorForm.invalid) {
          return;
      }

      this.loading = true;


      console.log("c.licked");

      if(this.user.roleName == 'NormalUser')
      {
          this.estimation.totalPrice = (this.f.goldPrice.value * this.f.weight.value) - (this.f.goldPrice.value * this.f.weight.value*this.estimation.discountPrice/100)
      }
      else{
        this.estimation.totalPrice = (this.f.goldPrice.value * this.f.weight.value) - (this.f.goldPrice.value * this.f.weight.value*this.estimation.discountPrice/100)
      }

      this.estimation.goldPrice = this.f.goldPrice.value;
      this.estimation.weight = this.f.weight.value;

      console.log(this.estimation);   
  }

  ClearDetails():void{
    this.estimation.goldPrice = null;
      this.estimation.weight = this.f.weight.value;
  }

}
