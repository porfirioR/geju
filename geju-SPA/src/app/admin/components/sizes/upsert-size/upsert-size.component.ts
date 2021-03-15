import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { SizeModel } from 'src/app/core/models/size-model';
import { SingletonService } from 'src/app/core/services/singleton/singleton.service';
import { SizeService } from 'src/app/admin/services/api/size.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-upsert-size',
  templateUrl: './upsert-size.component.html',
  styleUrls: ['./upsert-size.component.css']
})
export class UpsertSizeComponent implements OnInit {
  public sizeForm: FormGroup;
  public positionName = 'Crear';
  private size: SizeModel;
  private sizeId: string;

  constructor(
    private readonly router: Router,
    private readonly activatedRoute: ActivatedRoute,
    public singleton: SingletonService,
    private readonly sizeService: SizeService
  ) {}

  ngOnInit(): void {
    this.createSizeForm();
    this.activatedRoute.params.subscribe((params) => {
      this.sizeId = params.id;
      if (this.sizeId) {
        this.sizeService.getById(this.sizeId).subscribe(
          (response) => {
            this.size = response;
            this.sizeForm.patchValue({ code: this.size.code });
            this.sizeForm.patchValue({ description: this.size.description });
            this.positionName = 'Modificar';
            this.sizeForm.controls.code.disable();
            // const ele = this.sizeForm.value;
          },
          (error) => {
            Swal.fire('Error...', 'Marca no encontrada.', 'error');
            this.close();
          }
        );
      }
    });
  }

  private createSizeForm = () => {
    this.sizeForm = new FormGroup({
      code:  new FormControl('', [Validators.required, Validators.maxLength(25)]),
      description: new FormControl('', [Validators.required, Validators.maxLength(100)])
    });
  }

  save = () => {
    this.size = this.valueChanged();
    if (this.sizeId) {
      this.size.id = this.sizeId;
      this.sizeService.update(this.size).subscribe(
        (response) => {
          Swal.fire({ icon: 'success', title: 'Marca actualizada con éxito' });
          this.close();
        }, (err) => {
          Swal.fire({ icon: 'error', title: 'Error...', text: 'Error al actualizar la marca.' });
        }
      );
    } else {
      this.sizeService.create(this.size).subscribe(
        (response) => {
          Swal.fire({ icon: 'success', title: 'Marca registrada con éxito' });
          this.close();
        },
        (err) => {
          Swal.fire({ icon: 'error', title: 'Error...', text: 'Error al guardar.' });
        }
      );
    }
  }

  valueChanged = (): SizeModel => Object.assign( new SizeModel(), this.sizeForm.getRawValue());

  close = () => {
    this.router.navigate(['administracion/tamaños']);
  }

}
