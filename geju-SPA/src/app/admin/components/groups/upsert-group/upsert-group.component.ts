import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { GroupModel } from '../../../../core/models/group-model';
import { GroupService } from '../../../../core/services/group.service';
import { SingletonService } from '../../../../core/services/singleton/singleton.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-upsert-group',
  templateUrl: './upsert-group.component.html',
  styleUrls: ['./upsert-group.component.css']
})
export class UpsertGroupComponent implements OnInit {
  groupForm: FormGroup;
  group: GroupModel;
  groupId: string;
  positionName = 'Crear';

  constructor(
    private fb: FormBuilder,
    private readonly router: Router,
    private readonly activatedRoute: ActivatedRoute,
    public singleton: SingletonService,
    private readonly groupService: GroupService
  ) {}

  ngOnInit(): void {
    this.createBrandForm();
    this.activatedRoute.params.subscribe((params) => {
      this.groupId = params.id;
      if (this.groupId) {
        this.groupService.getById(this.groupId).subscribe(
          (response) => {
            this.group = response;
            this.groupForm.patchValue({ name: this.group.name });
            this.groupForm.patchValue({ description: this.group.description });
            this.positionName = 'Modificar';
          },
          (error) => {
            Swal.fire('Error...', 'Marca no encontrada.', 'error');
            this.close();
          }
        );
      }
    });
  }

  createBrandForm = () => {
    this.groupForm = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(25)]],
      description: ['', [Validators.required, Validators.maxLength(100)]]
    });
  }

  save = () => {
    if (this.groupId) {
      this.group = this.valueChanged();
      this.group.id = this.groupId;
      this.groupService.update(this.group).subscribe(
        (response) => {
          Swal.fire({ icon: 'success', title: 'Marca actualizada con éxito' });
          this.close();
        }, (err) => {
          Swal.fire({ icon: 'error', title: 'Error...', text: 'Error al actualizar la marca.' });
        }
      );
    } else {
      this.group = this.valueChanged();
      this.groupService.create(this.group).subscribe(
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

  valueChanged = (): GroupModel => Object.assign( new GroupModel(), this.groupForm.value);

  close = () => {
    this.router.navigate(['administracion/grupos']);
  }
}
