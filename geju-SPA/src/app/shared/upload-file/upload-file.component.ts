import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { NgxDropzoneChangeEvent } from 'ngx-dropzone';
import { UploadFileConfigModel } from '../../core/models/view/upload-file-config-model';

@Component({
  selector: 'app-upload-file',
  templateUrl: './upload-file.component.html',
  styleUrls: ['./upload-file.component.scss'],
})
export class UploadFileComponent implements OnInit, OnDestroy {
  @Input() uploadFileConfig: UploadFileConfigModel;
  public files: Array<File> = [];

  constructor() {
  }

  ngOnInit(): void { }

  public onSelect = (event: NgxDropzoneChangeEvent ): void => {
    if (event.addedFiles.length > 0) {
      this.files.push(...event.addedFiles);
      if (!this.uploadFileConfig.multiple && this.files.length > 1) {
        this.files.splice(0, 1);
      }
    }
    if (event.rejectedFiles.length > 0) {
      let messageError = '';
      event.rejectedFiles.forEach((file, i) => {
        // tslint:disable-next-line: no-string-literal
        if (file['reason'] === 'size') {
          // tslint:disable-next-line: max-line-length
          messageError = `${messageError}Attachment "${file.name}" needs to be less than ${(this.uploadFileConfig.maxFileSize / 1000000)} Mb`;
          // tslint:disable-next-line: no-string-literal
        } else if (file['reason'] === 'type') {
          messageError = `${messageError}Invalid attachment "${file.name}" please make sure it's a valid type`;
        }
        messageError = event.rejectedFiles.length === (i + 1) ? messageError : `${messageError}. `;
      });
    }
  }

  ngOnDestroy() {
  }

  public onRemove = (event): void => {
    this.files.splice(this.files.indexOf(event), 1);
  }
}
