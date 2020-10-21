import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserModel } from 'src/app/core/models/user-model';
import { SingletonService } from 'src/app/core/services/singleton/singleton.service';
import { UserService } from 'src/app/core/services/user.service';
import swal from 'sweetalert2';

@Component({
  selector: 'app-user-upsert',
  templateUrl: './user-upsert.component.html',
  styleUrls: ['./user-upsert.component.scss']
})
export class UserUpsertComponent implements OnInit {
  userForm: FormGroup;
  user: UserModel;
  userId: string;
  positionName = 'Crear';
  constructor(private fb: FormBuilder,
              private readonly router: Router,
              private readonly activatedRoute: ActivatedRoute,
              public singleton: SingletonService,
              private readonly userService: UserService) { }

  ngOnInit(): void {
    this.createUserForm();
    this.activatedRoute.params.subscribe(params => {
      this.userId = params.id;
      if (this.userId) {
          this.userService.getById(this.userId).subscribe(response => {
          this.user = response;
          this.userForm.patchValue({ name: this.user.name});
          this.userForm.patchValue({ lastName: this.user.lastName});
          this.userForm.patchValue({ email: this.user.email });
          this.userForm.patchValue({ country: this.user.country});
          this.userForm.patchValue({ birthdate: this.user.birthdate});
          this.positionName = 'Modificar';
        }, error => {
          swal.fire('Error...', 'Usuario no encontrado.', 'error');
          this.close();
        });
      }
    });
  }

  createUserForm = () => {
    this.userForm = this.fb.group({
      name: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', Validators.required],
      country: [''],
      rol: [''],
      birthdate: ['', Validators.required],
    });
  }

  save = () => {
    if (this.userForm.invalid) { return; }
    if (this.userId) {
      this.valueChanged();
      this.userService.update(this.user).subscribe(response => {
        swal.fire({icon: 'success', title: 'Usuario actualizado con exito'});
        this.close();
      }, err => {
        swal.fire({icon: 'error', title: 'Error...', text: 'Error al actualizar.'});
      });
    } else {
      this.user = Object.assign({}, this.userForm.value);
      this.userService.create(this.user).subscribe(response => {
        swal.fire({icon: 'success', title: 'Usuario Registrado con exito'});
        this.close();
      }, err => {
        swal.fire({icon: 'error', title: 'Error...', text: 'Error al guardar.'});
      });
    }
  }

  valueChanged = (): UserModel => {
    let aux = new UserModel();
    aux = Object.assign({}, this.userForm.value);
    this.user.name = aux.name;
    this.user.lastName = aux.lastName;
    this.user.email = aux.email;
    this.user.country = aux.country;
    this.user.birthdate = aux.birthdate;
    return aux;
  }

  close = () => {
    this.router.navigate(['administracion/usuarios']);
  }
}
