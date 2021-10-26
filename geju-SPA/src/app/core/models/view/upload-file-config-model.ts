export class UploadFileConfigModel {
    title: string;
    multiple: boolean;
    accept: string;
    removable: boolean;
    maxFileSize: number;

    constructor(title: string, multiple: boolean = true, accept: string = '*', removable: boolean = true, maxFileSize: number = undefined) {
        this.title = title;
        this.multiple = multiple;
        this.accept = accept;
        this.removable = removable;
        this.maxFileSize = maxFileSize;
    }
}
