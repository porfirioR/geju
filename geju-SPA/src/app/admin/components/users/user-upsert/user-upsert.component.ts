import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserModel } from 'src/app/core/models/user-model';
import { PathService } from '../../../../core/services/shared/path.service';
import { UserService } from 'src/app/admin/services/api/user.service';
import swal from 'sweetalert2';
import { FormControl } from '@angular/forms';
import { DisplayModalService } from '../../../../core/services/shared/display-modal.service';
import { Country } from 'src/app/core/enums/country.enum';

@Component({
  selector: 'app-user-upsert',
  templateUrl: './user-upsert.component.html',
  styleUrls: ['./user-upsert.component.scss']
})
export class UserUpsertComponent implements OnInit {
  public userForm: FormGroup;
  public positionName = 'Crear';
  public countryTypes = new Map<Country, string>();
  private user: UserModel;
  private userId: string;

  constructor(private readonly router: Router,
              private readonly activatedRoute: ActivatedRoute,
              public readonly singleton: PathService,
              private readonly userService: UserService,
              private readonly displayModalService: DisplayModalService) { }

  ngOnInit(): void {
    Object.keys(Country).forEach(x => this.countryTypes.set(Country[x], x));
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
          this.userForm.patchValue({ birthDate: this.user.birthDate});
          this.userForm.patchValue({ document: this.user.document});
          this.positionName = 'Modificar';
        }, () => {
          swal.fire('Error...', 'Usuario no encontrado.', 'error');
          this.close();
        });
      }
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

  public close = () => {
    this.router.navigate(['administracion/usuarios']);
  }

  private createUserForm = () => {
    this.userForm = new FormGroup({
      name: new FormControl('', Validators.required),
      lastName: new FormControl('', Validators.required),
      email: new FormControl('', Validators.required),
      country: new FormControl('', Validators.required),
      birthDate: new FormControl('', Validators.required),
      document: new FormControl('', [Validators.required, Validators.maxLength(15)]),
      rol: new FormControl('')
    });
  }

  private loadValueForm = (): void => {
    this.user = Object.assign(new UserModel(), this.userForm.value);
  }

}
