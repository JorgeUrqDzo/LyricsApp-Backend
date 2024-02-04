import { Component } from '@angular/core';
import menus from './menus.json';
import { RouterModule } from '@angular/router';
import { SecurityService } from '../services/security.service';
import { TitleCasePipe } from '@angular/common';
@Component({
  selector: 'app-nav-menu',
  standalone: true,
  imports: [RouterModule, TitleCasePipe],
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css'],
})
export class NavMenuComponent {
  isExpanded = false;

  menuList = menus;

  isAuth = false;
  displayName: string | null = '';

  constructor(private _securityService: SecurityService) {
    this.isAuth = _securityService.getIsAuth();
    this.displayName = _securityService.getDisplayName();
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
