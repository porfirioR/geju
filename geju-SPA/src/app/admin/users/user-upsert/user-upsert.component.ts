import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserModel } from 'src/app/core/models/user-model';
import { UserService } from 'src/app/core/services/user.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-user-upsert',
  templateUrl: './user-upsert.component.html',
  styleUrls: ['./user-upsert.component.scss']
})
export class UserUpsertComponent implements OnInit {
  userForm: FormGroup;
  user: UserModel;
  constructor(private fb: FormBuilder, private readonly userService: UserService) { }

  ngOnInit(): void {
    this.createUserForm();
  }

  createUserForm = () => {
    this.userForm = this.fb.group({
      name: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', Validators.required, Validators.email],
      phone: ['', Validators.required, Validators.min(10), Validators.max(10)],
      rol: ['', Validators.required],
      birthDate: ['', Validators.required]
    });
  }

  save = () => {
    if (this.userForm.invalid) { return; }
    this.user = Object.assign({}, this.userForm.value);
    this.userService.create(this.user).subscribe(response => {
      Swal.fire({icon: 'success'});
    });
  }
}
