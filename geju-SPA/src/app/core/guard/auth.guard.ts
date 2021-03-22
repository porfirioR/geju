import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AccountService } from '../services/api/account.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private accounService: AccountService, private readonly router: Router) {  }

  canActivate(): Observable<boolean> {
    return this.accounService.currentUser$.pipe(
      map(user => {
        if (user) {
          return true;
        }
        this.router.navigateByUrl('/página-no-encontrada');
      })
    );
  }

}
