import { Component, OnDestroy, OnInit } from '@angular/core';
import { GridOptions } from 'ag-grid-community';
import { ColorModel } from 'src/app/core/models/color-model';
import { ColorService } from 'src/app/admin/services/api/color.service';
import { PathService } from 'src/app/core/services/shared/path.service';
import { Subscription } from 'rxjs';
import { AgGridService } from 'src/app/core/services/shared/ag-grid.service';
import { DisplayModalService } from 'src/app/core/services/shared/display-modal.service';

@Component({
  selector: 'app-colors',
  templateUrl: './colors.component.html',
  styleUrls: ['./colors.component.css']
})
export class ColorsComponent implements OnInit, OnDestroy {
  public gridOptions: GridOptions;
  public selectedRow: ColorModel;
  private columnDefs = [
    { headerName: 'Código', field: 'code', sortable: true, filter: true, resizable: true, width: 600 },
    { headerName: 'Descripción', field: 'description', sortable: true, resizable: true, filter: true, width: 620 }
  ];
  private subscriptions: Subscription[] = [];

  constructor(private readonly colorService: ColorService,
              public pathService: PathService,
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
    this.displayModalService.showQuestionModal('Estas seguro que desea eliminar el color?').then(x => {
      if (x.isConfirmed) {
        this.subscriptions.push(this.colorService.delete(this.selectedRow.id).subscribe(() => this.getAll()));
      }
    });
  }

  private getAll = (): void => {
    this.subscriptions.push(
      this.colorService.getAll().subscribe(response => {
        this.gridOptions.api.setRowData(response);
        this.selectedRow = undefined;
        this.gridOptions.api.sizeColumnsToFit();
      })
    );
  }

}
