import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ColorService } from 'src/app/admin/services/api/color.service';
import { ColorModel } from 'src/app/core/models/color-model';
import { PathService } from 'src/app/core/services/shared/path.service';

@Component({
  selector: 'app-upsert-color',
  templateUrl: './upsert-color.component.html',
  styleUrls: ['./upsert-color.component.css']
})
export class UpsertColorComponent implements OnInit, OnDestroy {
  public colorForm: FormGroup;
  public positionName = 'Crear';
  public loading = true;
  public readonly maxLengthDescription = 100;
  public readonly maxLengthCode = 100;
  private subscriptions: Subscription[] = [];
  private colorId: string;
  private color: ColorModel;

  constructor(
    private readonly router: Router,
    private readonly activatedRoute: ActivatedRoute,
    private readonly colorService: ColorService,
    public readonly pathService: PathService,
  ) { }

  ngOnInit(): void {
    this.initialValues();
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(x => x.unsubscribe());
  }

  public save = (): void => {
    this.color = this.valueChanged();
    if (this.colorId) {
      this.subscriptions.push(this.colorService.update(this.color).subscribe(() => this.close()));
    } else {
      this.subscriptions.push(this.colorService.create(this.color).subscribe(() => this.close()));
    }
  }

  public close = (): void => {
    this.router.navigate(['administracion/colores']);
  }

  private initialValues = () => {
    this.subscriptions.push(
      this.activatedRoute.params.subscribe((params: Params) => {
        this.colorId = params.id;
        if (this.colorId) {
          this.subscriptions.push(
            this.colorService.getById(this.colorId).subscribe(response => {
              this.color = response;
              this.valuesForm();
              this.positionName = 'Modificar';
              this.loading = false;
            }, () => this.close())
          );
        } else {
          this.valuesForm();
          this.loading = false;
        }
      })
    );
  }

  private valuesForm = () => {
    this.colorForm = new FormGroup({
      id: new FormControl(this.color ? { value: this.color.id, disabled: true } : ''),
      code: new FormControl(this.color ? this.color.code : '', [Validators.required, Validators.maxLength(this.maxLengthCode)]),
      description: new FormControl(this.color ? this.color.description : '',
        [Validators.required, Validators.maxLength(this.maxLengthDescription)])
    });
  }

  private valueChanged = (): ColorModel => Object.assign(new ColorModel(), this.colorForm.getRawValue());

}
