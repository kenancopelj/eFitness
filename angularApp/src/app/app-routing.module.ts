import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HomeComponent} from "./home/home.component";
import {ShopComponent} from "./shop/shop.component";
import {LoginComponent} from "./login/login.component";
import {ClanarineComponent} from "./clanarine/clanarine.component";
import {GrupniTreningComponent} from "./grupni-trening/grupni-trening.component";
import {KorpaComponent} from "./korpa/korpa.component";
import {RegistracijaComponent} from "./registracija/registracija.component";
import {PostavkeProfilaComponent} from "./postavke-profila/postavke-profila.component";
import {AdminPanelComponent} from "./admin-panel/admin-panel.component";
import {KorisniciPanelComponent} from "./korisnici-panel/korisnici-panel.component";
import {SuplementiPanelComponent} from "./suplementi-panel/suplementi-panel.component";
import {TreninziPanelComponent} from "./treninzi-panel/treninzi-panel.component";
import { NovoUclanjenjeComponent } from './novo-uclanjenje/novo-uclanjenje.component';
import { KontaktComponent } from './kontakt/kontakt.component';
import { ReportComponent } from './report/report.component';
import { AuthguardGuard } from './_guards/authguard.guard';
import { AdminGuard } from './_guards/admin/admin.guard';


const routes: Routes = [
  {path:'',redirectTo:'home',pathMatch:'full'},
  {path:'home',component:HomeComponent,},
  {path:'shop',component:ShopComponent,},
  {path:'login',component:LoginComponent},
  {path:'clanarine',component:ClanarineComponent,},
  {path:'grupniTrening',component:GrupniTreningComponent,},
  {path:'korpa/:id',component:KorpaComponent, canActivate:[AuthguardGuard]},
  {path:'registracija',component:RegistracijaComponent},
  {path:'postavke-profila',component:PostavkeProfilaComponent, canActivate:[AuthguardGuard]},
  {path:'admin-panel',component:AdminPanelComponent, canActivate:[AdminGuard]},
  {path:'korisnici-panel',component:KorisniciPanelComponent, canActivate:[AdminGuard]},
  {path:'suplementi-panel',component:SuplementiPanelComponent, canActivate:[AdminGuard]},
  {path:'treninzi-panel',component:TreninziPanelComponent, canActivate:[AdminGuard]},
  {path:'novo-uclanjenje/:id',component:NovoUclanjenjeComponent, canActivate:[AuthguardGuard]},
  {path:'kontakt',component:KontaktComponent},
  {path:'report',component:ReportComponent, canActivate:[AdminGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
