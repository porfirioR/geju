import { Component, OnDestroy, OnInit } from '@angular/core';
import { AgGridService } from '../../../core/services/shared/ag-grid.service';
import { DisplayModalService } from '../../../core/services/shared/display-modal.service';
import { PathService } from '../../../core/services/shared/path.service';
import { PermissionService } from '../../services/api/permission.service';
import { ColDef, GridOptions } from 'ag-grid-community';
import { Subscription } from 'rxjs';
import { PermissionModel } from 'src/app/core/models/view/permission-model';

@Component({
  selector: 'app-permissions',
  templateUrl: './permissions.component.html',
  styleUrls: ['./permissions.component.css']
})
export class PermissionComponent implements OnInit, OnDestroy {
  public gridOptions: GridOptions;
  public selectedRow: PermissionModel;
  private columnDefs: ColDef[] = [
    { headerName: 'Nombre', field: 'name', sortable: true, filter: true, resizable: true, width: 600 },
    { headerName: 'Descripción', field: 'description', sortable: true, resizable: true, filter: true, width: 620 }
  ];
  private subscriptions: Subscription[] = [];

  constructor(private readonly permissionService: PermissionService,
              public readonly pathService: PathService,
              private readonly agGridService: AgGridService,
              private readonly displayModalService: DisplayModalService)
  {
    this.gridOptions = this.agGridService.getGridOptions();
  }

  ngOnInit(): void {
    this.gridOptions.columnDefs = this.gridOptions.columnDefs.concat(this.columnDefs);
    this.getAll();
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(x => x.unsubscribe());
  }

  public onSelectionChanged = (): void => {
    this.selectedRow = this.gridOptions.api.getSelectedRows()[0];
  }

  public remove = () => {
    this.displayModalService.showQuestionModal('¿Estas seguro que desea desactivar el permiso?').then(x => {
      if (x.isConfirmed) {
        this.subscriptions.push(this.permissionService.delete(this.selectedRow.id).subscribe(() => this.getAll()));
      }
    });
  }

  public active = () => this.subscriptions.push(this.permissionService.active(this.selectedRow.id).subscribe(() => this.getAll()));

  private getAll = (): void => {
    this.subscriptions.push(
      this.permissionService.getAll().subscribe(response => {
        this.gridOptions.api.setRowData(response);
        this.selectedRow = undefined;
        this.gridOptions.api.sizeColumnsToFit();
      })
    );
  }
}
