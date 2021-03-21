import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { SizeModel } from 'src/app/core/models/size-model';
import { PathService } from 'src/app/core/services/others/path.service';
import { SizeService } from 'src/app/admin/services/api/size.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-upsert-size',
  templateUrl: './upsert-size.component.html',
  styleUrls: ['./upsert-size.component.css']
})
export class UpsertSizeComponent implements OnInit, OnDestroy {
  public sizeForm: FormGroup;
  public positionName = 'Crear';
  public loading = true;

  private size: SizeModel;
  private sizeId: string;
  private subscriptions: Subscription[] = [];

  constructor(
    private readonly router: Router,
    private readonly activatedRoute: ActivatedRoute,
    public readonly pathService: PathService,
    private readonly sizeService: SizeService
  ) {}

  ngOnInit(): void {
    this.initialValues();
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(x => x.unsubscribe());
  }

  public save = () => {
    this.size = this.valueChanged();
    this.sizeForm.disable();
    if (this.sizeId) {
      this.size.id = this.sizeId;
      this.subscriptions.push(this.sizeService.update(this.size).subscribe(() => this.close()));
    } else {
      this.subscriptions.push(this.sizeService.create(this.size).subscribe(() => this.close()));
    }
  }

  public close = () => {
    this.router.navigate(['administracion/tamaños']);
  }

  private initialValues = (): void => {
    this.subscriptions.push(
      this.activatedRoute.params.subscribe((params: Params) => {
        this.sizeId = params.id;
        if (this.sizeId) {
          this.sizeService.getById(this.sizeId).subscribe(
            (response) => {
              this.size = response;
              this.valuesForm();
              this.positionName = 'Modificar';
              this.loading = false;
            },
            () => this.close()
          );
        } else {
          this.valuesForm();
          this.loading = false;
        }
      })
    );
  }

  private valuesForm = () => {
    this.sizeForm = new FormGroup({
      code:  new FormControl(this.size ? {value: this.size.code, disabled: true} : '', [Validators.required, Validators.maxLength(25)]),
      description: new FormControl(this.size ? this.size.description : '', [Validators.required, Validators.maxLength(100)])
    });
  }

  private valueChanged = (): SizeModel => Object.assign(new SizeModel(), this.sizeForm.getRawValue());

}
