import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-taps',
  templateUrl: './taps.component.html',
  styleUrls: ['./taps.component.css']
})
export class TapsComponent implements OnInit {
  navLinks = [
    {label: 'Tamaños', path: 'tamanio'}, {label: 'Usuarios', path: 'usuarios'}, {label: 'Marcas', path: 'marcas'}, {label: 'Color', path: 'tamanio'},
    {label: 'Grupos', path: 'tamanio'}, {label: 'Productos', path: 'productos'}, {label: 'Sección', path: 'tamanio'},
    {label: 'Inventario', path: 'tamanio'}, {label: 'Compras', path: 'tamanio'}, {label: 'Roles', path: 'tamanio'},
    {label: 'Ventas', path: 'sell'}
  ];
  constructor() { }

  ngOnInit(): void { }

}
