import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from 'src/components/admin/admin.component';
import { HomeComponent } from 'src/components/home/home.component';
import { LoginComponent } from 'src/components/login/login.component';
import { NoAvailableComponent } from 'src/components/no-available/no-available.component';
import { RegistrationComponent } from 'src/components/registration/registration.component';
import { UserComponent } from 'src/components/user/user.component';
import { VerifyEmailComponent } from 'src/components/verify-email/verify-email.component';
import { AuthGuard } from 'src/guards/auth.guard';

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
    path: 'account/login',
    component: LoginComponent,
  },
  {
    path: 'admin',
    component: AdminComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'user',
    component: UserComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'account/verify',
    component: VerifyEmailComponent,
  },
  {
    path: 'no-available',
    component: NoAvailableComponent,
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
