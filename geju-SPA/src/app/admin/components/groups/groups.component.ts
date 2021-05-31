import { Component, OnDestroy, OnInit } from '@angular/core';
import { ColDef, GridOptions } from 'ag-grid-community';
import { GroupModel } from 'src/app/core/models/group-model';
import { GroupService } from 'src/app/admin/services/api/group.service';
import { PathService } from '../../../core/services/shared/path.service';
import { AgGridService } from '../../../core/services/shared/ag-grid.service';
import { DisplayModalService } from '../../../core/services/shared/display-modal.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-groups',
  templateUrl: './groups.component.html',
  styleUrls: ['./groups.component.css']
})
export class GroupsComponent implements OnInit, OnDestroy {
  public gridOptions: GridOptions;
  public selectedRow: GroupModel;
  private columnDefs: ColDef[] = [
    { headerName: 'Nombre', field: 'name', sortable: true, filter: true, resizable: true, width: 600 },
    { headerName: 'Descripción', field: 'description', sortable: true, resizable: true, filter: true, width: 620 }
  ];
  private subscriptions: Subscription[] = [];

  constructor(private readonly groupService: GroupService,
              public readonly pathService: PathService,
              private readonly agGridService: AgGridService,
              private readonly displayModalService: DisplayModalService) { }

  ngOnInit(): void {
    this.gridOptions = this.agGridService.getGridOptions();
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
    this.displayModalService.showQuestionModal('¿Estas seguro que desea eliminar el grupo?').then(x => {
      if (x.isConfirmed) {
        this.subscriptions.push(this.groupService.delete(this.selectedRow.id).subscribe(() => this.getAll()));
      }
    });
  }

  private getAll(): void {
    this.subscriptions.push(
      this.groupService.getAll().subscribe(response => {
        this.gridOptions.api.setRowData(response);
        this.selectedRow = undefined;
        this.gridOptions.api.sizeColumnsToFit();
      })
    );
  }

}
