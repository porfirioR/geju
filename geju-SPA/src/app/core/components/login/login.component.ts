import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { LoginRequest } from '../../models/api/login-request';
import { AccountService } from '../../services/api/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit, OnDestroy {
  public loginForm: FormGroup;
  public loginInvalid: boolean;
  private subscriptions: Subscription[] = [];

  constructor(
    private readonly accountService: AccountService,
    private readonly router: Router
  ) {}

  ngOnInit(): void {
    this.subscriptions.push(
      this.accountService.currentUser$.pipe(
        map(user => {
          if (user) {
            this.router.navigate(['administracion']);
          }
        })
      ).subscribe()
    );
    this.loginForm = new FormGroup({
      email: new FormControl('', Validators.email),
      password: new FormControl('', Validators.required),
    });
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach((x) => x.unsubscribe());
  }

  public onSubmit = (): void => {
    this.loginInvalid = false;
    if (this.loginForm.valid) {
      const loginRequest: LoginRequest = this.loginForm.value;
      this.accountService.login(loginRequest).pipe(
        map((x) => this.router.navigate(['administracion'])),
        catchError((err) => {
          this.loginInvalid = true;
          return err.error;
        })
      ).subscribe();
    }
  }

  public close = () => {
    this.router.navigate(['']);
  }
}
