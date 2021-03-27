import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { NavigationExtras, Router } from '@angular/router';
import { DisplayModalService } from '../services/shared/display-modal.service';
import { catchError } from 'rxjs/operators';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private router: Router, private displayModalService: DisplayModalService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError(error => {
        if (error) {
          switch (error.status) {
            case 400:
              if (error.error.errors) {
                const modalStateError = [];
                for (const key in error.error.errors) {
                  if (error.error.errors[key]) {
                    modalStateError.push(error.error.errors[key]);
                  }
                }
                throw modalStateError.flat();
              } else {
                this.displayModalService.showErrorModal(error.statusText, error.status);
              }
              break;
            case 401:
              this.displayModalService.showErrorModal(error.error.message, error.status);
              break;
            case 404:
              this.router.navigateByUrl('no-encontrado');
              break;
            case 500:
              const navigationExtras: NavigationExtras = {state: { error: error.error}};
              this.router.navigateByUrl('/error-del-sistema', navigationExtras);
              break;
            default:
              this.displayModalService.showErrorModal('Algo anda mal, error inesperado');
              break;
          }
        }
        return throwError(error);
      })
    );
  }
}
