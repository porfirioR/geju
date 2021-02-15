import { Component, OnInit } from '@angular/core';
import { GridApi } from 'ag-grid-community';
import { SizeModel } from 'src/app/core/models/size-model';
import { SingletonService } from 'src/app/core/services/singleton/singleton.service';
import { SizeService } from 'src/app/core/services/size.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-sizes',
  templateUrl: './sizes.component.html',
  styleUrls: ['./sizes.component.css']
})
export class SizesComponent implements OnInit {
  private gridApi: GridApi;
  public rowData: SizeModel[];
  public selectedRow: SizeModel;
  public rowSelection = 'single';
  public getRowNodeId;
  public columnTypes = {
    dateColumn: {
      filter: 'agDateColumnFilter',
      filterParams: {
        comparator(filterLocalDateAtMidnight, cellValue: string): number {
          const cellDate = cellValue ? (new Date(cellValue)) : '';
          if (cellDate < filterLocalDateAtMidnight) { return -1;
          } else if (cellDate > filterLocalDateAtMidnight) { return 1;
          } else { return 0; }
        },
      }
    }
  };

  public columnDefs = [
    { headerName: 'Id', field: 'id', sortable: true, filter: true, resizable: true, width: 500 },
    { headerName: 'Código', field: 'code', sortable: true, filter: true, resizable: true, width: 600 },
    { headerName: 'Descripción', field: 'description', sortable: true, resizable: true, filter: true, width: 620 }
  ];

  constructor(private readonly groupService: SizeService, public singleton: SingletonService) { }

  ngOnInit(): void {
    this.getAll();
  }

  private getAll(): void {
    this.groupService.getAll().subscribe(response => {
      this.rowData = response;
      this.selectedRow = undefined;
    });
  }

  public onSelectionChanged(): void {
    this.selectedRow = this.gridApi.getSelectedRows()[0];
  }

  public onGridReady(params): void {
    this.gridApi = params.api;
  }

  public remove = () => {
    Swal.fire({
      title: 'Estas seguro que desea eliminar el tamaño',
      text: 'Estos cambios es permanente',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Borrar',
      cancelButtonText: 'Cancelar'
      }).then(result => {
      if (result.isConfirmed) {
        this.groupService.delete(this.selectedRow.id).subscribe(response => {
          Swal.fire('Exito', 'Tamaño borrado con éxito', 'success');
          this.getAll();
        }, err => {
          Swal.fire('Error', 'Error al borrar la marca', 'error');
        });
      }
    });
  }

}
