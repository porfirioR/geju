import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserModel } from 'src/app/core/models/user-model';
import { PathService } from 'src/app/core/services/shared/path.service';
import { UserService } from 'src/app/admin/services/api/user.service';
import swal from 'sweetalert2';
import { FormControl } from '@angular/forms';
import { DisplayModalService } from 'src/app/core/services/shared/display-modal.service';

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

  constructor(private readonly router: Router,
              private readonly activatedRoute: ActivatedRoute,
              public readonly singleton: PathService,
              private readonly userService: UserService,
              private readonly displayModalService: DisplayModalService) { }

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

  private createUserForm = () => {
    this.userForm = new FormGroup({
      name: new FormControl('', Validators.required),
      lastName: new FormControl('', Validators.required),
      email: new FormControl('', Validators.required),
      country: new FormControl('', Validators.required),
      birthdate: new FormControl('', Validators.required),
      rol: new FormControl('')
    });
  }

  public save = () => {
    this.loadValueForm();
    if (this.userId) {
      this.user.id = this.userId;
      this.userService.update(this.user).subscribe(response => {
        this.displayModalService.showSuccessModal('Usuario registrado con éxito');
        this.close();
      });
    } else {
      this.userService.create(this.user).subscribe(() => {
        this.displayModalService.showSuccessModal('Usuario actualizado con éxito');
        this.close();
      });
    }
  }

  private loadValueForm = (): void => {
    this.user = Object.assign(new UserModel(), this.userForm.value);
    this.user.country = parseInt(this.userForm.get('country').value, 10);
  }

  public close = () => {
    this.router.navigate(['administracion/usuarios']);
  }
}
