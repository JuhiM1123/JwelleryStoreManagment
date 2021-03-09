import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import { AuthenticationService } from 'src/app/services/authenticationService';
import { AESEncryptionDecryptionService } from 'src/app/services/aesEncryptionDecrptionService'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: [  './login.component.css']
})
export class LoginComponent implements OnInit, OnDestroy {
  loginForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;
  error = '';

  constructor(
      private formBuilder: FormBuilder,
      private route: ActivatedRoute,
      private router: Router,
      private authenticationService: AuthenticationService,
      private encryptionDecrptionService : AESEncryptionDecryptionService
  ) { 
            // redirect to home if already logged in
            if (this.authenticationService.currentUserValue) { 
              this.router.navigate(['/']);
      }
    
  }

  ngOnInit() {
      this.loginForm = this.formBuilder.group({
          username: ['', Validators.required],
          password: ['', Validators.required]
      });

      // get return url from route parameters or default to '/'
      this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  // convenience getter for easy access to form fields
  get f() { return this.loginForm.controls; }

    onSubmit() {
      this.submitted = true;

      // stop here if form is invalid
      if (this.loginForm.invalid) {
          return;
      }
      
      let encryptedPassword = this.encryptionDecrptionService.encrypt(this.f.password.value);
      this.loading = true;
      this.authenticationService.login(this.f.username.value, encryptedPassword.result)
          .pipe(first())
          .subscribe(
              data => {
                  this.router.navigate([this.returnUrl]);
              },
              error => {
                  this.error = error;
                  this.loading = false;
              });
  }

  ngOnDestroy(): void {

  }
}
