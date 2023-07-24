import { Component, Input, OnInit } from '@angular/core';
import { NavigationModel } from '../../../core/models/navigation-model';
@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent implements OnInit {
  @Input() navigation: Array<NavigationModel> = new Array<NavigationModel>();
  @Input() actualPosition: string;

  constructor() { }

  ngOnInit(): void {
   }

}
