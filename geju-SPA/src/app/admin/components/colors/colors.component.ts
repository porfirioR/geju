import { Component, OnInit } from '@angular/core';
import { GridApi } from 'ag-grid-community';
import { ColorModel } from 'src/app/core/models/color-model';
import { ColorService } from 'src/app/core/services/color.service';
import { SingletonService } from 'src/app/core/services/singleton/singleton.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-colors',
  templateUrl: './colors.component.html',
  styleUrls: ['./colors.component.css']
})
export class ColorsComponent implements OnInit {
  private gridApi: GridApi;
  rowData: ColorModel[];
  selectedRow: ColorModel;
  rowSelection = 'single';
  getRowNodeId;
  columnTypes = {
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

  columnDefs = [
    { headerName: 'Id', field: 'id', sortable: true, filter: true, resizable: true, width: 500 },
    { headerName: 'Código', field: 'code', sortable: true, filter: true, resizable: true, width: 600 },
    { headerName: 'Descripción', field: 'description', sortable: true, resizable: true, filter: true, width: 620 }
  ];

  constructor(private readonly colorService: ColorService, public singleton: SingletonService) { }

  ngOnInit(): void {
    this.getAll();
  }

  getAll(): void {
    this.colorService.getAll().subscribe(response => {
      this.rowData = response;
      this.selectedRow = undefined;
    });
  }

  onSelectionChanged(): void {
    this.selectedRow = this.gridApi.getSelectedRows()[0];
  }

  onGridReady(params): void {
    this.gridApi = params.api;
  }

  remove = () => {
    Swal.fire({
      title: 'Estas seguro que desea eliminar el color',
      text: 'Estos cambios es permanente',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Borrar',
      cancelButtonText: 'Cancelar'
      }).then(result => {
      if (result.isConfirmed) {
        this.colorService.delete(this.selectedRow.id).subscribe(response => {
          Swal.fire('Exito', 'Marca borrada con éxito', 'success');
          this.getAll();
        }, err => {
          Swal.fire('Error', 'Error al borrar el color', 'error');
        });
      }
    });
  }
}