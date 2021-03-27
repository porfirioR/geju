import { Component, OnDestroy, OnInit } from '@angular/core';
import { PathService } from '../../../core/services/shared/path.service';
import { BrandModel } from '../../../core/models/brand-model';
import { BrandService } from '../../services/api/brand.service';
import { GridOptions } from 'ag-grid-community';
import { Subscription } from 'rxjs';
import { AgGridService } from 'src/app/core/services/shared/ag-grid.service';
import { DisplayModalService } from 'src/app/core/services/shared/display-modal.service';

@Component({
  selector: 'app-brands',
  templateUrl: './brands.component.html',
  styleUrls: ['./brands.component.css']
})
export class BrandsComponent implements OnInit, OnDestroy {
  public gridOptions: GridOptions;
  public selectedRow: BrandModel;
  private columnDefs = [
    { headerName: 'Nombre', field: 'name', sortable: true, filter: true, resizable: true, width: 600 },
    { headerName: 'Descripción', field: 'description', sortable: true, resizable: true, filter: true, width: 620 }
  ];
  private subscriptions: Subscription[] = [];

  constructor(private readonly brandService: BrandService,
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

  public remove = (): void => {
    this.displayModalService.showQuestionModal('¿Estas seguro que desea eliminar la marca?').then(x => {
      if (x.isConfirmed) {
        this.subscriptions.push(this.brandService.delete(this.selectedRow.id).subscribe(() => this.getAll()));
      }
    });
  }

  private getAll(): void {
    this.subscriptions.push(
      this.brandService.getAll().subscribe(response => {
        this.gridOptions.api.setRowData(response);
        this.selectedRow = undefined;
        this.gridOptions.api.sizeColumnsToFit();
      })
    );
  }

}
