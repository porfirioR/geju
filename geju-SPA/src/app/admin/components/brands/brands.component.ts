import { Component, OnInit } from '@angular/core';
import { GridApi } from 'ag-grid-community/dist/lib/gridApi';
import { SingletonService } from 'src/app/core/services/singleton/singleton.service';
import Swal from 'sweetalert2';
import { BrandModel } from '../../../core/models/brand-model';
import { BrandService } from '../../../core/services/brand.service';
@Component({
  selector: 'app-brands',
  templateUrl: './brands.component.html',
  styleUrls: ['./brands.component.css']
})
export class BrandsComponent implements OnInit {
  private gridApi: GridApi;
  rowData: BrandModel[];
  selectedRow: BrandModel;
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
    { headerName: 'Id', field: 'id', sortable: true, filter: true, resizable: true },
    { headerName: 'Nombre', field: 'name', sortable: true, filter: true, resizable: true },
    { headerName: 'Apellido', field: 'lastName', sortable: true, resizable: true, filter: true },
    { headerName: 'Correo', field: 'email', sortable: true, resizable: true, filter: true },
    { headerName: 'Activo', field: 'active', sortable: true, filter: true, resizable: true, cellRenderer: this.activeFormatter },
    { headerName: 'Fecha de nacimiento', field: 'birthdate', sortable: true, filter: 'agDateColumnFilter', resizable: true,
      type: 'dateColumn', cellRenderer: this.dateFormatter},
    { headerName: 'Fecha de creación', field: 'lastActive', sortable: true, filter: 'agDateColumnFilter', resizable: true,
      type: 'dateColumn', cellRenderer: this.dateFormatter}
    ];

  constructor(private readonly brandService: BrandService, public singleton: SingletonService) { }

  ngOnInit(): void {
    this.getAll();
  }

  getAll(): void {
    this.brandService.getAll().subscribe(response => {
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
    return data.value ? (new Date(data.value)).toLocaleDateString() : '';
  }

  numberFormatter(cell): any {
    return cell.value ? Number(cell.value) : '';
  }

  activeFormatter(cell): string {
    return cell.value ? 'Si' : 'No';
  }
  remove = () => {
    Swal.fire({
      title: 'Estas seguro que desea eliminar el usuario',
      text: 'Estos cambios es permanente',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Borrar',
      cancelButtonText: 'Cancelar'
      }).then(result => {
      if (result.isConfirmed) {
        this.brandService.delete(this.selectedRow.id).subscribe(response => {
          Swal.fire('Exito', 'Usuario borrado con exito', 'success');
          this.getAll();
        }, err => {
          Swal.fire('Error', 'Error al borrar usuario', 'error');
        });
      }
    });
  }
}
