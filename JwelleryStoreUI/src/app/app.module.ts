import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
//import { fakeBackendProvider } from 'src/app/helpers/backend';
import { ErrorInterceptor  } from 'src/app/helpers/errorInterceptor';
import { JwtInterceptor } from 'src/app/helpers/jwtInterceptor';
import { PrintToScreenDialogComponent } from './home/print-to-screen-dialog/print-to-screen-dialog.component';
import { PrintToPaperDialogComponent } from './home/print-to-paper-dialog/print-to-paper-dialog.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDialog, MatDialogModule, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    PrintToScreenDialogComponent,
    PrintToPaperDialogComponent,
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatDialogModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    
  //  fakeBackendProvider
],
  bootstrap: [AppComponent]
})
export class AppModule { }
