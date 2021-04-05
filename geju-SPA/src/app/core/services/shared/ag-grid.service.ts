import { Injectable } from '@angular/core';
import { ColDef, GridOptions } from 'ag-grid-community';

@Injectable({
  providedIn: 'root'
})
export class AgGridService {
  private columnDef: ColDef[] = [
    { headerName: 'Id', field: 'id', sortable: true, filter: true, resizable: true, width: 500 }
  ];
  private columnDefUser: ColDef[] = [
    { headerName: 'Nombre', field: 'name', sortable: true, filter: true, resizable: true, width: 300 },
    { headerName: 'Apellido', field: 'lastName', sortable: true, resizable: true, filter: true, width: 300 },
    { headerName: 'Correo', field: 'email', sortable: true, resizable: true, filter: true, width: 325 },
    { headerName: 'Activo', field: 'active', sortable: true, filter: true, resizable: true, width: 100,
      cellRenderer: this.activeFormatter},
    { headerName: 'Fecha de nacimiento', field: 'birthdate', sortable: true, filter: 'agDateColumnFilter', resizable: true,
      type: 'dateColumn', cellRenderer: this.dateFormatter },
    { headerName: 'Fecha de creación', field: 'lastActive', sortable: true, filter: 'agDateColumnFilter', resizable: true,
      type: 'dateColumn', cellRenderer: this.dateFormatter },
  ];


  private productColumnDefs: ColDef[] = [
    { headerName: 'Nombre', field: 'name', sortable: true, filter: true, resizable: true, width: 300 },
    { headerName: 'Cantidad', field: 'count', sortable: true, resizable: true, filter: true, width: 300,
    type: 'numberColumn', cellRenderer: this.numberFormatter },
    { headerName: 'Precio', field: 'price', sortable: true, filter: true, resizable: true, width: 300,
    type: 'numberColumn', cellRenderer: this.numberFormatter },
    { headerName: 'Existencia', field: 'existence', sortable: true, filter: true, resizable: true, width: 300,
     cellRenderer: this.activeFormatter }
  ];

  constructor() { }

  public getGridOptions = (): GridOptions => {
    const gridOptions: GridOptions = {
      rowSelection: 'single',
      overlayLoadingTemplate: '<span class="ag-overlay-loading-center">Porfavor espere mientras cargue las filas.</span>',
      overlayNoRowsTemplate:
        '<span style="padding: 10px; border: 2px solid #444; background: lightgoldenrodyellow;">Sin filas que mostrar.</span>',
      paginationAutoPageSize: true,
      enableCellChangeFlash: true,
      columnDefs: this.columnDef,
      pagination: true,
      columnTypes: {
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
      },
    };
    return gridOptions;
  }


  private activeFormatter(cell): string {
    return cell.value ? 'Si' : 'No';
  }

  private numberFormatter(cell): any {
    return cell.value ? Number(cell.value) : '';
  }

  private dateFormatter(data): string {
    return data.value ? new Date(data.value).toLocaleDateString() : '';
  }

  get columnDefUserList(): ColDef[] {
    this.columnDef[0].width = 300;
    return this.columnDef.concat(this.columnDefUser);
  }

  get columnDefProductList(): ColDef[] {
    this.columnDef[0].width = 300;
    return this.columnDef.concat(this.productColumnDefs);
  }
}
