import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AutentifikacijaHelper } from 'src/app/_helpers/autentifikacija-helper';
import { NotificationService } from 'src/app/notification.service';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate {

  constructor(private router: Router, private notificationService: NotificationService){}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

      if (AutentifikacijaHelper.getLoginInfo().isLogiran && AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.korisnickiNalog.isAdmin)
      return true;

      this.notificationService.showError("Niste administrator!","Greška");
      this.router.navigate(['/home']);
      return false;
  }
  
}
