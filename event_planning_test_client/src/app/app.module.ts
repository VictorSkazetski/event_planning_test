import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app.routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { RegistrationComponent } from 'src/components/registration/registration.component';
import { EmailConfirmComponent } from 'src/components/email-confirm/email-confirm.component';
import { VerifyEmailComponent } from 'src/components/verify-email/verify-email.component';

@NgModule({
  declarations: [
    AppComponent,
    RegistrationComponent,
    EmailConfirmComponent,
    VerifyEmailComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule,
    AppRoutingModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
