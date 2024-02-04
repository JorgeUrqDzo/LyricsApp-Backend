import { Inject, inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { SecurityService } from './security.service';

export const authGuard: CanActivateFn = async (route, state) => {
  const _securityService: SecurityService = inject(SecurityService);
  const router = inject(Router);

  const isAuthenticated = await _securityService.isAuthenticated();

  if (!isAuthenticated) {
    router.navigate(['/login'])
    // return false;
  }

  return true;
};
