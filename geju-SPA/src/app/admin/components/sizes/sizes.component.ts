import { Component, OnDestroy, OnInit } from '@angular/core';
import { ColDef, GridOptions } from 'ag-grid-community';
import { SizeModel } from 'src/app/core/models/size-model';
import { PathService } from '../../../core/services/shared/path.service';
import { SizeService } from '../../../admin/services/api/size.service';
import { Subscription } from 'rxjs';
import { AgGridService } from '../../../core/services/shared/ag-grid.service';
import { DisplayModalService } from '../../../core/services/shared/display-modal.service';

@Component({
  selector: 'app-sizes',
  templateUrl: './sizes.component.html',
  styleUrls: ['./sizes.component.css']
})
export class SizesComponent implements OnInit, OnDestroy {
  public gridOptions: GridOptions;
  public selectedRow: SizeModel;
  private columnDefs: ColDef[] = [
    { headerName: 'Código', field: 'code', sortable: true, filter: true, resizable: true, width: 600 },
    { headerName: 'Descripción', field: 'description', sortable: true, resizable: true, filter: true, width: 620 }
  ];
  private subscriptions: Subscription[] = [];

  constructor(private readonly groupService: SizeService,
              public readonly singleton: PathService,
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

  public onSelectionChanged(): void {
    this.selectedRow = this.gridOptions.api.getSelectedRows()[0];
  }

  public remove = () => {
    this.displayModalService.showQuestionModal('¿Estas seguro que desea eliminar el permiso?').then(x => {
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
