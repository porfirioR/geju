import { Component, Input, OnInit } from '@angular/core';
import { NavegationModel } from './../../../core/models/navegation-model';
@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent implements OnInit {
  @Input() navigation: Array<NavegationModel> = new Array<NavegationModel>();
  @Input() actualPosition: string;

  constructor() { }

  ngOnInit(): void { }

}
