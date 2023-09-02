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
import { AdminComponent } from 'src/components/admin/admin.component';
import { LoginComponent } from 'src/components/login/login.component';
import { UserComponent } from 'src/components/user/user.component';
import { NoAvailableComponent } from 'src/components/no-available/no-available.component';

@NgModule({
  declarations: [
    AppComponent,
    RegistrationComponent,
    EmailConfirmComponent,
    VerifyEmailComponent,
    LoginComponent,
    AdminComponent,
    UserComponent,
    NoAvailableComponent,
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
