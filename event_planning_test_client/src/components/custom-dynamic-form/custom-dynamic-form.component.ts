import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { DynamicFormModel } from '@ng-dynamic-forms/core';
import * as moment from 'moment';
import { AdminService } from 'src/services/admini.service';

@Component({
  selector: 'custom-dynamic-form',
  templateUrl: './custom-dynamic-form.component.html',
  styleUrls: ['./custom-dynamic-form.component.css'],
})
export class CustomDynamicFormComponent {
  @Input() form: FormGroup;
  @Input() formModel: DynamicFormModel;
  date: Date;
  dateTime: string;
  isDateSelected: boolean;
  @Output() eventCreated = new EventEmitter<boolean>();

  constructor(
    private adminService: AdminService,
    private route: ActivatedRoute
  ) {}

  onSubmit(): void {
    if (this.isDateSelected) {
      this.form.addControl('date', new FormControl(this.date?.toString()));
      this.adminService
        .createEvent(
          this.route.snapshot.routeConfig?.path || '',
          JSON.stringify(this.form.value)
        )
        .subscribe((event: string) => {
          this.eventCreated.emit(true);
        });
      console.log(this.form.value);
    } else {
      alert('Выберети дату!');
    }
  }

  onDataChange(newdate: any) {
    this.isDateSelected = true;
    const _moment = moment();
    const date = moment(newdate).add({
      hours: _moment.hour(),
      minutes: _moment.minute(),
      seconds: _moment.second(),
    });
    this.date = date.toDate();
  }
}
