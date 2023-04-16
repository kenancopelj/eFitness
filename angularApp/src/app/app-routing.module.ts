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


const routes: Routes = [
  {path:'',redirectTo:'home',pathMatch:'full'},
  {path:'home',component:HomeComponent},
  {path:'shop',component:ShopComponent},
  {path:'login',component:LoginComponent},
  {path:'clanarine',component:ClanarineComponent},
  {path:'grupniTrening',component:GrupniTreningComponent},
  {path:'korpa',component:KorpaComponent},
  {path:'registracija',component:RegistracijaComponent},
  {path:'postavke-profila',component:PostavkeProfilaComponent},
  {path:'admin-panel',component:AdminPanelComponent},
  {path:'korisnici-panel',component:KorisniciPanelComponent},
  {path:'suplementi-panel',component:SuplementiPanelComponent},
  {path:'treninzi-panel',component:TreninziPanelComponent},
  {path:'novo-uclanjenje/:id',component:NovoUclanjenjeComponent},
  {path:'kontakt',component:KontaktComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
