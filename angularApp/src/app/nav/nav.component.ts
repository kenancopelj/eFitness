import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { MojConfig } from "../moj-konfig";
import { AutentifikacijaHelper } from "../_helpers/autentifikacija-helper";
import { LoginInformacije } from "../_helpers/login-informacije";
import { NotificationService } from '../notification.service';

declare function porukaSuccess(a: string): any;
declare function porukaError(a: string): any;

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  admin: any;
  username: any;
  constructor(
    private httpKlijent: HttpClient,
    private router: Router,
    private notificationService: NotificationService
  ) {
  }

  ngOnInit(): void {
  }
  
  JeLiAdmin() {
    this.admin = AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.korisnickiNalog.isAdmin;
    if (this.admin)
      return {'display':'block'};
    else
      return {'display':'none'};
  }

  logoutButton() {
    AutentifikacijaHelper.setLoginInfo(null);

    this.httpKlijent.post(MojConfig.adresa_servera + "/Autentifikacija/Logout/", null, MojConfig.http_opcije())
      .subscribe((x: any) => {
        this.router.navigateByUrl("/login");
      });
    this.notificationService.showSuccess("Uspješan logout!", 'Success')
  }

  loginInfo(): LoginInformacije {
    return AutentifikacijaHelper.getLoginInfo();
  }

  redirectNaLogin() {
    this.router.navigateByUrl("/login");
  }

  redirectNaAdminPanel() {
    this.router.navigateByUrl("/admin-panel");
  }
}
