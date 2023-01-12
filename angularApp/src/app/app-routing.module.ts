import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HomeComponent} from "./home/home.component";
import {ShopComponent} from "./shop/shop.component";
import {LoginComponent} from "./login/login.component";
import {ClanarineComponent} from "./clanarine/clanarine.component";
import {GrupniTreningComponent} from "./grupni-trening/grupni-trening.component";
import {KorpaComponent} from "./korpa/korpa.component";


const routes: Routes = [
  {path:'',redirectTo:'home',pathMatch:'full'},
  {path:'home',component:HomeComponent},
  {path:'shop',component:ShopComponent},
  {path:'login',component:LoginComponent},
  {path:'clanarine',component:ClanarineComponent},
  {path:'grupniTrening',component:GrupniTreningComponent},
  {path:'korpa',component:KorpaComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
