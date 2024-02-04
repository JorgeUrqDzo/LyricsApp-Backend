import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { NavMenuComponent } from 'src/app/nav-menu/nav-menu.component';

@Component({
  selector: 'app-main-layout',
  standalone: true,
  imports: [RouterModule, NavMenuComponent ],
  templateUrl: './main-layout.component.html',
  styleUrl: './main-layout.component.css'
})
export class MainLayoutComponent {

}
