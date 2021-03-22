import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { UserAuthResponse } from 'src/app/core/models/api/user-auth-response';
import { UserModel } from 'src/app/core/models/user-model';
import { AccountService } from 'src/app/core/services/api/account.service';

@Component({
  selector: 'app-configuration',
  templateUrl: './configuration.component.html',
  styleUrls: ['./configuration.component.css']
})
export class ConfigurationComponent implements OnInit {
  public user: UserModel;

  constructor(private router: Router,
              public accountService: AccountService) { }

  ngOnInit(): void {
    this.accountService.currentUser$.subscribe(x => this.user = x.user);
  }

  public logOut = (): void => {
    this.accountService.logOut();
    this.router.navigate(['']);
  }

}
