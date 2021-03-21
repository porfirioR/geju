import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserModel } from 'src/app/core/models/user-model';
import { PathService } from 'src/app/core/services/others/path.service';
import { UserService } from 'src/app/admin/services/api/user.service';
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
              public singleton: PathService,
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
      country: ['', Validators.required],
      birthdate: ['', Validators.required],
      rol: [''],
    });
  }

  save = () => {
    this.loadValueForm();
    if (this.userId) {
      this.user.id = this.userId;
      this.userService.update(this.user).subscribe(response => {
        swal.fire({icon: 'success', title: 'Usuario actualizado con exito'});
        this.close();
      }, err => {
        swal.fire({icon: 'error', title: 'Error...', text: 'Error al actualizar.'});
      });
    } else {
      this.userService.create(this.user).subscribe(response => {
        swal.fire({icon: 'success', title: 'Usuario Registrado con exito'});
        this.close();
      }, err => {
        swal.fire({icon: 'error', title: 'Error...', text: 'Error al guardar.'});
      });
    }
  }

  loadValueForm = (): void => {
    this.user = Object.assign(new UserModel(), this.userForm.value);
    this.user.country = parseInt(this.userForm.get('country').value, 10);
  }


  close = () => {
    this.router.navigate(['administracion/usuarios']);
  }
}
