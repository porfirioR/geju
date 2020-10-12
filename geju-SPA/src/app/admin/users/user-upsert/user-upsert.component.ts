import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserModel } from 'src/app/core/models/user-model';
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
  constructor(private fb: FormBuilder,
              private readonly router: Router,
              private readonly userService: UserService) { }

  ngOnInit(): void {
    this.createUserForm();
  }

  createUserForm = () => {
    this.userForm = this.fb.group({
      name: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', Validators.required, Validators.email],
      phone: ['', Validators.required, Validators.max(10)],
      rol: ['', Validators.required],
      birthdate: ['', Validators.required]
    });
  }

  save = () => {
    if (this.userForm.invalid) { return; }
    this.user = Object.assign({}, this.userForm.value);
    console.log('hola');
    this.userService.create(this.user).subscribe(response => {
      swal.fire({icon: 'success', title: 'Usuario Registrado con exito'});
      this.close();
    }, err => {
      swal.fire({icon: 'error', title: 'Error...', text: 'Error al guardar.'});
    });
  }

  close = () => {
    this.router.navigate(['administracion/usuarios']);
  }
}
