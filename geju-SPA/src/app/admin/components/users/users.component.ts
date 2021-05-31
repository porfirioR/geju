import { Component, OnDestroy, OnInit } from '@angular/core';
import { UserModel } from 'src/app/core/models/user-model';
import { PathService } from '../../../core/services/shared/path.service';
import { UserService } from '../../services/api/user.service';
import { DisplayModalService } from '../../../core/services/shared/display-modal.service';
import { GridOptions } from 'ag-grid-community';
import { Subscription } from 'rxjs';
import { AgGridService } from '../../../core/services/shared/ag-grid.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css'],
})
export class UsersComponent implements OnInit, OnDestroy {
  public gridOptions: GridOptions;
  public selectedRow: UserModel;
  private subscriptions: Subscription[] = [];

  constructor(
    private readonly userService: UserService,
    public readonly pathService: PathService,
    private readonly displayModalService: DisplayModalService,
    private readonly agGridService: AgGridService,
  ) {}

  ngOnInit(): void {
    this.gridOptions = this.agGridService.getGridOptions();
    this.gridOptions.columnDefs = this.agGridService.columnDefUserList;
    this.getAll();
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(x => x.unsubscribe());
  }

  private getAll(): void {
    this.subscriptions.push(
      this.userService.getAll().subscribe(response => {
        this.gridOptions.api.setRowData(response);
        this.selectedRow = undefined;
        this.gridOptions.api.sizeColumnsToFit();
      })
    );
  }

  public onSelectionChanged = (): void => {
    this.selectedRow = this.gridOptions.api.getSelectedRows()[0];
  }

  public remove = () => {
    this.displayModalService.showQuestionModal('Estas seguro que desea eliminar el usuario').then(result => {
      if (result.isConfirmed) {
        this.subscriptions.push(
          this.userService.delete(this.selectedRow.id).subscribe(() => {
            this.displayModalService.showSuccessModal(`Usuario borrado con éxito.`);
            this.getAll();
          })
        );
      }
    });
  }
}
