import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { PermissionService } from '../../../../admin/services/api/permission.service';
import { PathService } from '../../../../core/services/shared/path.service';
import { PermissionModel } from '../../../../core/models/view/permission-model';

@Component({
  selector: 'app-upsert-permission',
  templateUrl: './upsert-permission.component.html',
  styleUrls: ['./upsert-permission.component.css']
})
export class UpsertPermissionComponent implements OnInit, OnDestroy {
  public permissionForm: FormGroup;
  public positionName = 'Modificar';
  public loading = true;

  private permission: PermissionModel;
  private permissionId: string;
  private subscriptions: Subscription[] = [];

  constructor(
    private readonly router: Router,
    private readonly activatedRoute: ActivatedRoute,
    public readonly pathService: PathService,
    private readonly permissionService: PermissionService
  ) { }

  ngOnInit(): void {
    this.initialValues();
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(x => x.unsubscribe());
  }

  public save = (): void => {
    this.permission = this.valueChanged();
    if (this.permissionId) {
      this.permission.id = this.permissionId;
      this.subscriptions.push(this.permissionService.update(this.permission).subscribe(() => this.close()));
    } else {
      this.close();
    }
  }

  public close = (): void => {
    this.router.navigate(['administracion/permisos']);
  }

  private initialValues = (): void => {
    this.subscriptions.push(
      this.activatedRoute.params.subscribe((params) => {
        this.permissionId = params.id;
        if (this.permissionId) {
          this.permissionService.getById(this.permissionId).subscribe(response => {
            this.permission = response;
            this.valuesForm();
            this.positionName = 'Modificar';
            this.loading = false;
          }, () => this.close());
        } else {
          this.close();
        }
      })
    );
  }

  private valuesForm = () => {
    this.permissionForm = new FormGroup({
      name: new FormControl(this.permission ? this.permission.name : '', [Validators.required, Validators.maxLength(25)]),
      description: new FormControl(this.permission ? this.permission.description : '', [Validators.required, Validators.maxLength(100)])
    });
  }

  private valueChanged = (): PermissionModel => Object.assign(new PermissionModel(), this.permissionForm.value);

}
