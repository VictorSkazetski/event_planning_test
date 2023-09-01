import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from 'src/components/home/home.component';
import { RegistrationComponent } from 'src/components/registration/registration.component';
import { VerifyEmailComponent } from 'src/components/verify-email/verify-email.component';

const routes: Routes = [
  {
    path: 'account/registration',
    component: RegistrationComponent,
  },
  {
    path: 'account/verify',
    component: VerifyEmailComponent,
  },
  {
    path: '',
    component: HomeComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
