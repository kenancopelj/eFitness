import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AutentifikacijaHelper } from '../_helpers/autentifikacija-helper';
import { NotificationService } from '../notification.service';

@Injectable({
  providedIn: 'root'
})
export class AuthguardGuard implements CanActivate {

  constructor(private router: Router, private notificationService: NotificationService){}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

      if (AutentifikacijaHelper.getLoginInfo().isLogiran)
        return true;

      this.notificationService.showError("Niste logirani!","Greška");
      return false;
    }
  
}
