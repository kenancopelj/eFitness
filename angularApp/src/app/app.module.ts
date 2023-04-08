import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import {HttpClientModule} from "@angular/common/http";
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import {FormsModule} from "@angular/forms";
import { ShopComponent } from './shop/shop.component';
import { LoginComponent } from './login/login.component';
import {AutorizacijaLoginProvjera} from "./_guards/autorizacija-login-provjera.service";
import { ClanarineComponent } from './clanarine/clanarine.component';
import { GrupniTreningComponent } from './grupni-trening/grupni-trening.component';
import { KorpaComponent } from './korpa/korpa.component';
import { NovaClanarinaComponent } from './nova-clanarina/nova-clanarina.component';
import { SuplementComponent } from './suplement/suplement.component';
import { NoviTreningComponent } from './novi-trening/novi-trening.component';
import { RegistracijaComponent } from './registracija/registracija.component';
import { PostavkeProfilaComponent } from './postavke-profila/postavke-profila.component';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';
import { KorisniciPanelComponent } from './korisnici-panel/korisnici-panel.component';
import { SuplementiPanelComponent } from './suplementi-panel/suplementi-panel.component';
import { TreninziPanelComponent } from './treninzi-panel/treninzi-panel.component';
import { FooterComponent } from './footer/footer.component';
import { NovoUclanjenjeComponent } from './novo-uclanjenje/novo-uclanjenje.component';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    ShopComponent,
    LoginComponent,
    ClanarineComponent,
    GrupniTreningComponent,
    KorpaComponent,
    NovaClanarinaComponent,
    SuplementComponent,
    NoviTreningComponent,
    RegistracijaComponent,
    PostavkeProfilaComponent,
    AdminPanelComponent,
    KorisniciPanelComponent,
    SuplementiPanelComponent,
    TreninziPanelComponent,
    FooterComponent,
    NovoUclanjenjeComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserModule,
    ToastrModule.forRoot()

  ],
  providers: [
    AutorizacijaLoginProvjera
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
