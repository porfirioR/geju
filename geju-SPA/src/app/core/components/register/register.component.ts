import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { UserModel } from '../../models/user-model';
import { AccountService } from '../../services/api/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit, OnDestroy {
  public registerForm: FormGroup;
  public registerInvalid: boolean;
  private subscriptions: Subscription[] = [];

  constructor(private readonly accountService: AccountService, private readonly router: Router) { }

  ngOnInit(): void {
    this.createRegisterForm();
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(x => x.unsubscribe());
  }

  private createRegisterForm = () => {
    this.registerForm = new FormGroup({
      name: new FormControl('', Validators.required),
      lastName: new FormControl('', Validators.required),
      email: new FormControl('', [Validators.required, Validators.email]),
      country: new FormControl('', Validators.required),
      document: new FormControl('', Validators.required),
      birthdate: new FormControl(null, Validators.required),
      password: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(16)]),
      confirmPassword: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(16)])
    }, { validators: this.passwordMatchValidator });
  }

  private passwordMatchValidator = (fg: FormGroup) => {
    return fg.get('password').value === fg.get('confirmPassword').value ? null : { mismatch: true };
  }

  public onSubmit = () => {
      const loginRequest: UserModel = this.registerForm.value;
      this.registerForm.disable();
      this.subscriptions.push(
      this.accountService.register(loginRequest).pipe(
        map(x =>  this.router.navigate(['administracion'])),
        catchError(err => {
          this.registerInvalid = true;
          this.registerForm.enable();
          return err.error.erros;
        })
      ).subscribe()
    );
  }

  public close = () => {
    this.router.navigate(['']);
  }
}
