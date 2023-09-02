import { Component, Output } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { filter } from 'rxjs';
import { UserAccount } from 'src/models/UserAccount';
import { UserToken } from 'src/models/UserToken';
import { AccountService } from 'src/services/account.service';
import { LocalStorageService } from 'src/services/localStorage.service';

@Component({
  template: '',
})
export abstract class BaseAccountComponent {
  protected form: FormGroup = new FormGroup({});
  protected submitted: boolean = false;
  isRegistrationStep: boolean = true;
  @Output() emailUrl: string = '';

  constructor(
    private account: AccountService,
    private route: ActivatedRoute,
    private router: Router,
    private localStorage: LocalStorageService
  ) {}

  get formControls() {
    return this.form.controls;
  }

  registration(): void {
    this.account
      .registerUser(
        this.route.snapshot.routeConfig?.path || '',
        this.form.value
      )
      .pipe(filter((user) => user !== null))
      .subscribe((user: UserAccount) => {
        this.isRegistrationStep = false;
        this.emailUrl = user.emailHost;
      });
  }

  close(): void {
    this.router.navigateByUrl('');
  }

  login(): void {
    this.account
      .getUserToken(
        this.route.snapshot.routeConfig?.path || '',
        this.form.value
      )
      .pipe(filter((userTokens) => userTokens !== null))
      .subscribe((userToken: UserToken) => {
        this.localStorage.saveToken('token', userToken);
        if (this.account.isUserAdmin()) {
          this.router.navigateByUrl('/admin');
        } else {
          this.router.navigateByUrl('/user');
        }
      });
  }
}
