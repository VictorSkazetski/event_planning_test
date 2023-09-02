import { inject } from '@angular/core';
import { AccountService } from '../services/account.service';
import {
  ActivatedRouteSnapshot,
  Router,
  RouterStateSnapshot,
} from '@angular/router';
import { RolesType } from 'src/models/RolesType';
import { LocalStorageService } from 'src/services/localStorage.service';

export const AuthGuard = (
  route: ActivatedRouteSnapshot,
  state: RouterStateSnapshot
): boolean => {
  const localStorage = inject(LocalStorageService);
  const router = inject(Router);
  if (localStorage.isKeyExists('token')) {
    const isUserAdmin = inject(AccountService).isUserAdmin();
    if (route.routeConfig?.path == RolesType.Admin && !isUserAdmin) {
      router.navigateByUrl('/no-available');

      return false;
    } else if (route.routeConfig?.path == RolesType.User && isUserAdmin) {
      router.navigateByUrl('/no-available');

      return false;
    } else {
      return true;
    }
  } else {
    router.navigateByUrl('/no-available');

    return false;
  }
};
