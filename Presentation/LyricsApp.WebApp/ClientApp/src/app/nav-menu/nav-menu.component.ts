import { Component } from '@angular/core';
import menus from './menus.json'
import { RouterModule } from '@angular/router';
@Component({
  selector: 'app-nav-menu',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  menuList = menus;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
