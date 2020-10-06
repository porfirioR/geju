import { Component, OnInit } from '@angular/core';
import { GridApi } from 'ag-grid-community/dist/lib/gridApi';
import { UserModel } from 'src/app/core/models/user-model';
import { UserService } from '../../core/services/user.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  private gridApi: GridApi;
  rowData: UserModel[];
  selectedRow: UserModel;
  rowSelection = 'single';
  getRowNodeId;
  columnTypes = {
    dateColumn: {
      filter: 'agDateColumnFilter',
      filterParams: {
        comparator(filterLocalDateAtMidnight, cellValue: string) {
          const cellDate = cellValue ? (new Date(cellValue)) : '';
          if (cellDate < filterLocalDateAtMidnight) { return -1;
          } else if (cellDate > filterLocalDateAtMidnight) { return 1;
          } else { return 0; }
        },
      }
    }
  };
  columnDefs = [
    { headerName: 'Id', field: 'id', sortable: true, filter: true, resizable: true, hidden: true },
    { headerName: 'Nombre', field: 'nombre', sortable: true, filter: true, resizable: true },
    { headerName: 'Apellido', field: 'apellido', sortable: true, resizable: true, filter: true },
    { headerName: 'Correo', field: 'correo', sortable: true, resizable: true, filter: true },
    { headerName: 'Activo', field: 'activo', sortable: true, filter: true, resizable: true, cellRenderer: this.activeFormatter },
    { headerName: 'Fecha de nacimiento', field: 'fechaNaciento', sortable: true, filter: 'agDateColumnFilter', resizable: true,
      type: 'dateColumn', cellRenderer: this.dateFormatter},
    { headerName: 'Fecha de creación', field: 'lastActive', sortable: true, filter: 'agDateColumnFilter', resizable: true,
      type: 'dateColumn', cellRenderer: this.dateFormatter}
    ];
    /* { headerName: 'Año', field: 'year', sortable: true, filter: 'agNumberColumnFilter', resizable: true, maxWidth: 140,
      valueGetter(params) { return Number(params.data.year); }, cellRenderer: this.numberFormatter },
    { headerName: 'Formato', field: 'format', sortable: true, filter: true, resizable: true */ 
  
  constructor(private readonly userService: UserService) { }

  ngOnInit(): void {
    console.log('hola');
    this.userService.getAll().subscribe(response => {
      this.rowData = response;
    });
  }

  onSelectionChanged(): void {
    this.selectedRow = this.gridApi.getSelectedRows()[0];
  }

  onGridReady(params): void {
    this.gridApi = params.api;
  }

  dateFormatter(data): string {
    return data.value ? (new Date(data.value)).toLocaleDateString() : '';
  }

  numberFormatter(cell) {
    return cell.value ? Number(cell.value) : '';
  }

  activeFormatter(cell): string {
    return cell.value ? 'Si' : 'No';
  }
}
