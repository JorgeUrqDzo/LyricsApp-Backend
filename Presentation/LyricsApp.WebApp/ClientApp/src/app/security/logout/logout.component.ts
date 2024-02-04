import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SecurityService } from 'src/app/services/security.service';

@Component({
  selector: 'app-logout',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './logout.component.html',
  styleUrl: './logout.component.css'
})
export class LogoutComponent {
  constructor(private _securityService: SecurityService)
  {
    _securityService.logout();
  }
}
