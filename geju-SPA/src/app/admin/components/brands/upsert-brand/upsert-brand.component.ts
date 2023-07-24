import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BrandModel } from '../../../../core/models/brand-model';
import { BrandService } from '../../../../core/services/brand.service';
import { SingletonService } from '../../../../core/services/singleton/singleton.service';
import swal from 'sweetalert2';

@Component({
  selector: 'app-upsert-brand',
  templateUrl: './upsert-brand.component.html',
  styleUrls: ['./upsert-brand.component.scss'],
})
export class UpsertBrandComponent implements OnInit {
  brandForm: FormGroup;
  brand: BrandModel;
  brandId: string;
  positionName = 'Crear';

  constructor(
    private fb: FormBuilder,
    private readonly router: Router,
    private readonly activatedRoute: ActivatedRoute,
    public singleton: SingletonService,
    private readonly brandService: BrandService
  ) {}

  ngOnInit(): void {
    this.createBrandForm();
    this.activatedRoute.params.subscribe((params) => {
      this.brandId = params.id;
      if (this.brandId) {
        this.brandService.getById(this.brandId).subscribe(
          (response) => {
            this.brand = response;
            this.brandForm.patchValue({ name: this.brand.name });
            this.brandForm.patchValue({ description: this.brand.description });
            this.positionName = 'Modificar';
          },
          (error) => {
            swal.fire('Error...', 'Marca no encontrada.', 'error');
            this.close();
          }
        );
      }
    });
  }

  createBrandForm = () => {
    this.brandForm = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(25)]],
      description: ['', [Validators.required, Validators.maxLength(100)]]
    });
  }

  save = () => {
    if (this.brandId) {
      this.brand = this.valueChanged();
      this.brand.id = this.brandId;
      this.brandService.update(this.brand).subscribe(
        (response) => {
          swal.fire({ icon: 'success', title: 'Marca actualizada con éxito' });
          this.close();
        }, (err) => {
          swal.fire({ icon: 'error', title: 'Error...', text: 'Error al actualizar la marca.' });
        }
      );
    } else {
      this.brand = this.valueChanged();
      this.brandService.create(this.brand).subscribe(
        (response) => {
          swal.fire({ icon: 'success', title: 'Marca registrada con éxito' });
          this.close();
        },
        (err) => {
          swal.fire({ icon: 'error', title: 'Error...', text: 'Error al guardar.' });
        }
      );
    }
  }

  valueChanged = (): BrandModel => Object.assign( new BrandModel(), this.brandForm.value);

  close = () => {
    this.router.navigate(['administracion/marcas']);
  }
}
