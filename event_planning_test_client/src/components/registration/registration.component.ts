import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AccountService } from 'src/services/account.service';
import {
  RegexConstants,
  RegexPasswordCapitalLetterValidator,
  RegexPasswordLeastNumberValidator,
  RegexPasswordLowerLetterValidator,
  RegexPasswordOneSymbolValidator,
} from 'src/validators/regex.validator';
import { BaseAccountComponent } from '../account/base-account.component';

@Component({
  selector: 'registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css'],
})
export class RegistrationComponent extends BaseAccountComponent {
  constructor(
    account: AccountService,
    route: ActivatedRoute,
    router: Router,
  ) {
    super(account, route, router);
  }

  ngOnInit() {
    this.buildForm();
  }

  buildForm() {
    this.form = new FormGroup({
      UserEmail: new FormControl(null, [
        Validators.required,
        Validators.email,
        Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$'),
      ]),
      UserPassword: new FormControl(null, [
        Validators.required,
        Validators.minLength(6),
        RegexPasswordCapitalLetterValidator(RegexConstants.OneCapitalLetter),
        RegexPasswordLowerLetterValidator(RegexConstants.OneLowerLetter),
        RegexPasswordLeastNumberValidator(RegexConstants.OneNumberLetter),
        RegexPasswordOneSymbolValidator(
          RegexConstants.OneNonNumberLetterSymbol
        ),
      ]),
    });
    this.formSubmited();
  }

  formSubmited(): void {
    this.form.valueChanges.subscribe((_) => {
      if (this.submitted) {
        this.submitted = false;
      }
    });
  }

  onSubmit(): void {
    this.submitted = true;
    if (this.form.invalid) {
      return;
    }
    this.registration();
  }
}
