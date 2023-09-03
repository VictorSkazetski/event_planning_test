import {
  AfterViewInit,
  Component,
  TemplateRef,
  ViewChild,
  ViewContainerRef,
  ViewRef,
} from '@angular/core';
import { FormGroup } from '@angular/forms';
import { DynamicFormModel, DynamicFormService } from '@ng-dynamic-forms/core';
import { JsonEditorComponent, JsonEditorOptions } from 'ang-jsoneditor';

@Component({
  selector: 'admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css'],
})
export class AdminComponent implements AfterViewInit {
  editorOptions: JsonEditorOptions;
  data: any;
  @ViewChild(JsonEditorComponent, { static: false })
  editor: JsonEditorComponent;
  jsonSampleFrom: string = `[
    {
        "type": "INPUT",
        "id": "sampleInput",
        "label": "Sample Input",
        "maxLength": 42,
        "placeholder": "Sample input"
    },
    {
        "type": "RADIO_GROUP",
        "id": "sampleRadioGroup",
        "label": "Sample Radio Group",
        "options": [
            {
                "label": "Option 1",
                "value": "option-1"
            },
            {
                "label": "Option 2",
                "value": "option-2"
            },
            {
                "label": "Option 3",
                "value": "option-3"
            }
        ],
        "value": "option-3"    
    }
]`;
  formModel: DynamicFormModel;
  form: FormGroup;
  @ViewChild('containerСustomForm', { read: ViewContainerRef })
  containerCustomForm: ViewContainerRef;
  @ViewChild('customForm', { read: TemplateRef }) customForm: TemplateRef<any>;
  customFormViewRef: ViewRef;

  constructor(private formService: DynamicFormService) {
    this.editorOptions = new JsonEditorOptions();
    this.editorOptions.mode = 'text';
    this.editor = new JsonEditorComponent();
    this.data = {};
  }

  ngAfterViewInit(): void {
    this.customFormViewRef = this.customForm?.createEmbeddedView(null);
  }

  createForm() {
    try {
      this.formModel = this.formService.fromJSON(this.editor.getText());
      this.form = this.formService.createFormGroup(this.formModel);
      this.containerCustomForm?.insert(this.customFormViewRef as ViewRef);
    } catch (error) {
      alert('Ошибка, создай заного!');
      this.containerCustomForm?.detach();
    }
  }

  eventCreated(isEventCreated: boolean) {
    if (isEventCreated) {
      this.containerCustomForm?.detach();
      this.data = {};
    }
  }
}
