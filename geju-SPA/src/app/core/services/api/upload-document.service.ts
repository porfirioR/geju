import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UploadDocumentService {
  private baseUrl = `${environment.uploadUrl}`;

constructor(private http: HttpClient) { }

public saveDocument = (files: Array<File> = null): Observable<any> => {
  const formDataInput = {};
  formDataInput['Amount'] = '123';
  formDataInput['BankReference'] = '12334';
  const formData = new FormData();
  formData.append('formData', JSON.stringify(formDataInput));
  if (files) {
    for (let i = 0; files.length > i; i++) {
      formData.append(`template`, files[i]);
    }
  }
  // tslint:disable-next-line: max-line-length
  return this.http.post<any>(`${this.baseUrl}`, formData);
}
}
