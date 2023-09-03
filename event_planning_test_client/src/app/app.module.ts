import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app.routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RegistrationComponent } from 'src/components/registration/registration.component';
import { EmailConfirmComponent } from 'src/components/email-confirm/email-confirm.component';
import { VerifyEmailComponent } from 'src/components/verify-email/verify-email.component';
import { AdminComponent } from 'src/components/admin/admin.component';
import { LoginComponent } from 'src/components/login/login.component';
import { UserComponent } from 'src/components/user/user.component';
import { NoAvailableComponent } from 'src/components/no-available/no-available.component';
import { NgJsonEditorModule } from 'ang-jsoneditor';
import { DynamicMaterialFormComponent } from '@ng-dynamic-forms/ui-material';
import { CustomDynamicFormComponent } from 'src/components/custom-dynamic-form/custom-dynamic-form.component';
import {
  NgxMatDatetimePickerModule,
  NgxMatTimepickerModule,
} from '@angular-material-components/datetime-picker';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { NgxMatNativeDateModule } from '@angular-material-components/datetime-picker';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { JwtInterceptor } from 'src/interceptors/JwtInterceptor ';
import { JsonParsePipe } from 'src/pipes/json.pipe';
import { NgxMatNumberInputSpinnerModule } from 'ngx-mat-number-input-spinner';

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
    CustomDynamicFormComponent,
    JsonParsePipe,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule,
    AppRoutingModule,
    ReactiveFormsModule,
    NgJsonEditorModule,
    DynamicMaterialFormComponent,
    NgxMatTimepickerModule,
    NgxMatDatetimePickerModule,
    MatDatepickerModule,
    MatInputModule,
    NgxMatNativeDateModule,
    FormsModule,
    MatFormFieldModule,
    NgxMatNumberInputSpinnerModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
