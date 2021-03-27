import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BrandModel } from 'src/app/core/models/brand-model';
import { BrandService } from 'src/app/admin/services/api/brand.service';
import { PathService } from 'src/app/core/services/shared/path.service';
import swal from 'sweetalert2';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-upsert-brand',
  templateUrl: './upsert-brand.component.html',
  styleUrls: ['./upsert-brand.component.css'],
})
export class UpsertBrandComponent implements OnInit, OnDestroy {
  public brandForm: FormGroup;
  public positionName = 'Crear';
  public loading = true;

  private brand: BrandModel;
  private brandId: string;
  private subscriptions: Subscription[] = [];

  constructor(
    private readonly router: Router,
    private readonly activatedRoute: ActivatedRoute,
    public readonly pathService: PathService,
    private readonly brandService: BrandService
  ) {}

  ngOnInit(): void {
    this.initialValues();
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(x => x.unsubscribe());
  }

  public save = (): void => {
    this.brand = this.valueChanged();
    if (this.brandId) {
      this.brand.id = this.brandId;
      this.subscriptions.push(this.brandService.update(this.brand).subscribe(() => this.close()));
    } else {
      this.subscriptions.push(this.brandService.create(this.brand).subscribe(() => this.close()));
    }
  }

  public close = (): void => {
    this.router.navigate(['administracion/marcas']);
  }

  private initialValues = (): void => {
    this.subscriptions.push(
      this.activatedRoute.params.subscribe((params) => {
        this.brandId = params.id;
        if (this.brandId) {
          this.brandService.getById(this.brandId).subscribe(
            (response) => {
              this.brand = response;
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
    this.brandForm = new FormGroup({
      name: new FormControl(this.brand ? this.brand.name : '', [Validators.required, Validators.maxLength(25)]),
      description: new FormControl(this.brand ? this.brand.description : '', [Validators.required, Validators.maxLength(100)])
    });
  }

  private valueChanged = (): BrandModel => Object.assign( new BrandModel(), this.brandForm.value);

}
