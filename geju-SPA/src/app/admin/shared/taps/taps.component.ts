import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-taps',
  templateUrl: './taps.component.html',
  styleUrls: ['./taps.component.css']
})
export class TapsComponent implements OnInit {
  list = [
    'Tamaños', 'Marcas', 'Color', 'Grupos', 'Productos', 'Sección', 'Inventario' , 'Compras', 'Roles', 'Ventas', 'Usuarios'
  ];
  selected = new FormControl(0);
  constructor() { }

  ngOnInit(): void { }

}
