import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import Swal, { SweetAlertResult } from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class DisplayModalService {
  constructor() { }

  public showErrorModal = (text: string = '', error: HttpErrorResponse) => {
    Swal.fire({
      icon: 'error',
      title: 'Error...',
      text: `${text} ${error.message}`,
    });
  }

  public showSuccessModal = (text: string = ''): void => {
    Swal.fire({
      icon: 'success',
      title: 'Operación exitosa.',
      text
    });
  }

  public showInfoModal = (text: string = ''): void => {
    Swal.fire({
      icon: 'info',
      title: text,
    });
  }

  public showQuestionModal = async (question: string): Promise<SweetAlertResult<unknown>> => {
    const result = await Swal.fire({
      title: `${question}`,
      text: 'Estos cambios son permanentes.',
      icon: 'warning',
      showCancelButton: true,
      reverseButtons: true,
      confirmButtonText: 'Borrar',
      cancelButtonText: 'Cancelar'
    });
    return result;
  }
}
