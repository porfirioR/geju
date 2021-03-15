import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-taps',
  templateUrl: './taps.component.html',
  styleUrls: ['./taps.component.css']
})
export class TapsComponent implements OnInit {
  navLinks = [
    {label: 'Tamaños', path: 'tamaños', icon: 'fas fa-expand-arrows-alt'},
    {label: 'Usuarios', path: 'usuarios', icon: 'fas fa-users'},
    {label: 'Marcas', path: 'marcas', icon: 'fas fa-tags'},
    {label: 'Color', path: 'colores', icon: 'fas fa-palette'},
    {label: 'Grupos', path: 'grupos', icon: 'far fa-object-group'},
    {label: 'Productos', path: 'productos', icon: 'fas fa-box-open'},
    {label: 'Sección', path: 'tamanio', icon: 'fas fa-puzzle-piece'},
    {label: 'Inventario', path: 'tamanio', icon: 'fas fa-archive'},
    {label: 'Compras', path: 'tamanio', icon: 'fas fa-shopping-cart'},
    {label: 'Roles', path: 'tamanio', icon: 'fas fa-expand-arrows-alt'},
    {label: 'Ventas', path: 'sell', icon: 'fas fa-comment-dollar'}
  ];
  constructor() { }

  ngOnInit(): void { }

}
