import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { GroupModel } from 'src/app/core/models/group-model';
import { GroupService } from 'src/app/admin/services/api/group.service';
import { PathService } from '../../../../core/services/shared/path.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-upsert-group',
  templateUrl: './upsert-group.component.html',
  styleUrls: ['./upsert-group.component.css']
})
export class UpsertGroupComponent implements OnInit, OnDestroy {
  public groupForm: FormGroup;
  public positionName = 'Crear';
  public loading = true;

  private group: GroupModel;
  private groupId: string;
  private subscriptions: Subscription[] = [];

  constructor(
    private readonly router: Router,
    private readonly activatedRoute: ActivatedRoute,
    public readonly pathService: PathService,
    private readonly groupService: GroupService
  ) {}

  ngOnInit(): void {
    this.initialValues();
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(x => x.unsubscribe());
  }

  public save = (): void => {
    this.group = this.valueChanged();
    if (this.groupId) {
      this.group.id = this.groupId;
      this.subscriptions.push(this.groupService.update(this.group).subscribe(() => this.close()));
    } else {
      this.subscriptions.push(this.groupService.create(this.group).subscribe(() => this.close()));
    }
  }

  public close = (): void => {
    this.router.navigate(['administracion/grupos']);
  }

  private initialValues = (): void => {
    this.subscriptions.push(
      this.activatedRoute.params.subscribe((params: Params) => {
        this.groupId = params.id;
        if (this.groupId) {
          this.groupService.getById(this.groupId).subscribe(
            (response) => {
              this.group = response;
              this.valuesForm();
              this.positionName = 'Modificar';
              this.loading = false;
            },
            () => this.close()
          );
        } else {
          this.valuesForm();
          this.loading = false;
        }
      })
    );
  }

  private valuesForm = () => {
    this.groupForm = new FormGroup({
      name: new FormControl(this.group ? this.group.name : '', [Validators.required, Validators.maxLength(25)]),
      description: new FormControl(this.group ? this.group.description : '', [Validators.required, Validators.maxLength(100)])
    });
  }

  private valueChanged = (): GroupModel => Object.assign( new GroupModel(), this.groupForm.value);

}
