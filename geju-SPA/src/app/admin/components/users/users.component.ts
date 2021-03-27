import { Component, OnInit } from '@angular/core';
import { GridApi } from 'ag-grid-community/dist/lib/gridApi';
import Swal from 'sweetalert2';

import { UserModel } from 'src/app/core/models/user-model';
import { PathService } from 'src/app/core/services/shared/path.service';
import { UserService } from '../../services/api/user.service';
import { DisplayModalService } from 'src/app/core/services/shared/display-modal.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css'],
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
        comparator(filterLocalDateAtMidnight, cellValue: string): number {
          const cellDate = cellValue ? new Date(cellValue) : '';
          if (cellDate < filterLocalDateAtMidnight) {
            return -1;
          } else if (cellDate > filterLocalDateAtMidnight) {
            return 1;
          } else {
            return 0;
          }
        },
      },
    },
  };
  columnDefs = [
    {
      headerName: 'Id',
      field: 'id',
      sortable: true,
      filter: true,
      resizable: true,
      width: 300,
    },
    {
      headerName: 'Nombre',
      field: 'name',
      sortable: true,
      filter: true,
      resizable: true,
      width: 300,
    },
    {
      headerName: 'Apellido',
      field: 'lastName',
      sortable: true,
      resizable: true,
      filter: true,
      width: 300,
    },
    {
      headerName: 'Correo',
      field: 'email',
      sortable: true,
      resizable: true,
      filter: true,
      width: 325,
    },
    {
      headerName: 'Activo',
      field: 'active',
      sortable: true,
      filter: true,
      resizable: true,
      width: 100,
      cellRenderer: this.activeFormatter,
    },
    {
      headerName: 'Fecha de nacimiento',
      field: 'birthdate',
      sortable: true,
      filter: 'agDateColumnFilter',
      resizable: true,
      type: 'dateColumn',
      cellRenderer: this.dateFormatter,
    },
    {
      headerName: 'Fecha de creación',
      field: 'lastActive',
      sortable: true,
      filter: 'agDateColumnFilter',
      resizable: true,
      type: 'dateColumn',
      cellRenderer: this.dateFormatter,
    },
  ];
  /* { headerName: 'Año', field: 'year', sortable: true, filter: 'agNumberColumnFilter', resizable: true, maxWidth: 140,
      valueGetter(params) { return Number(params.data.year); }, cellRenderer: this.numberFormatter },
    { headerName: 'Formato', field: 'format', sortable: true, filter: true, resizable: true */

  constructor(
    private readonly userService: UserService,
    public readonly singleton: PathService,
    private readonly displayModalService: DisplayModalService
  ) {}

  ngOnInit(): void {
    this.getAll();
  }

  private getAll(): void {
    this.userService.getAll().subscribe((response) => {
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

  dateFormatter(data): string {
    return data.value ? new Date(data.value).toLocaleDateString() : '';
  }

  numberFormatter(cell): any {
    return cell.value ? Number(cell.value) : '';
  }

  activeFormatter(cell): string {
    return cell.value ? 'Si' : 'No';
  }

  public remove = () => {
    this.displayModalService.showQuestionModal('Estas seguro que desea eliminar el usuario').then((result) => {
      if (result.isConfirmed) {
        this.userService.delete(this.selectedRow.id).subscribe(() => {
          this.displayModalService.showSuccessModal(`Usuario borrado con éxito.`);
          this.getAll();
        });
      }
    });
  }
}
