import { Component, OnDestroy, OnInit } from '@angular/core';
import { PathService } from 'src/app/core/services/shared/path.service';
import { ProductModel } from './../../../core/models/product-model';
import { ProductService } from '../../services/api/product.service';
import { GridOptions } from 'ag-grid-community';
import { Subscription } from 'rxjs';
import { AgGridService } from 'src/app/core/services/shared/ag-grid.service';
import { DisplayModalService } from 'src/app/core/services/shared/display-modal.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit, OnDestroy {
  public gridOptions: GridOptions;
  public selectedRow: ProductModel;
  private subscriptions: Subscription[] = [];

  constructor(private readonly productService: ProductService,
              private readonly agGridService: AgGridService,
              private readonly displayModalService: DisplayModalService,
              public readonly pathService: PathService) { }

  ngOnInit(): void {
    this.gridOptions = this.agGridService.getGridOptions();
    this.gridOptions.columnDefs = this.agGridService.columnDefProductList;
    this.getAll();
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(x => x.unsubscribe());
  }

  public onSelectionChanged(): void {
    this.selectedRow = this.gridOptions.api.getSelectedRows()[0];
  }

  public remove = () => {
    this.displayModalService.showQuestionModal('¿Estas seguro que desea eliminar el producto?').then(x => {
      if (x.isConfirmed) {
        this.subscriptions.push(this.productService.delete(this.selectedRow.id).subscribe(() => {
          this.displayModalService.showSuccessModal(`Producto borrado con éxito.`);
          this.getAll();
        }));
      }
    });
  }

  private getAll(): void {
    this.subscriptions.push(
      this.productService.getAll().subscribe(response => {
        this.gridOptions.api.setRowData(response);
        this.selectedRow = undefined;
        this.gridOptions.api.sizeColumnsToFit();
      })
    );
  }

}
