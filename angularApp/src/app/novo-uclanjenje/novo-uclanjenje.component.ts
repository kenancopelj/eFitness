import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MojConfig } from '../moj-konfig';
import { AutentifikacijaHelper } from '../_helpers/autentifikacija-helper';
import { NotificationService } from '../notification.service';
import { ClanarineService } from '../clanarine/clanarine.service';



@Component({
  selector: 'app-novo-uclanjenje',
  templateUrl: './novo-uclanjenje.component.html',
  styleUrls: ['./novo-uclanjenje.component.css']
})
export class NovoUclanjenjeComponent implements OnInit {

  constructor(
  private router: Router,
  private route: ActivatedRoute,
  private httpKlijent : HttpClient,
  private notificationService : NotificationService,
  private clanarineService : ClanarineService
  ){}

  korisnikId: any;
  korisnikImePrezime:any;
  clanarinaId : any;
  clanarinaNaziv :any;
  clanarinaCijena :any;

  ngOnInit(): void {
    var korisnik = AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.korisnickiNalog;
    this.korisnikImePrezime = `${korisnik.ime} ${korisnik.prezime}`;
    this.clanarinaId = this.route.snapshot.paramMap.get('id');
    this.getVrstaClanarineById(this.clanarinaId);
    this.korisnikId = AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.korisnickiNalogId;
  }

  getVrstaClanarineById(clanarinaId: any) {
    this.clanarineService.GetVrstaById(clanarinaId).subscribe((x:any)=>{
      this.clanarinaNaziv = x.naziv;
      this.clanarinaCijena = x.cijena;
      console.log(x)
    },(err)=>this.notificationService.showError(err.error,'Greška'));
  }

  Spasi() {
    const novaClanarina = {
      vrsta_clanarine_id : this.clanarinaId,
      korisnik_id:this.korisnikId,
      datumIsteka : new Date(new Date().getFullYear(),new Date().getMonth()+1, new Date().getDay()),
    };
    this.clanarineService.novaClanarina(novaClanarina).subscribe((x:any)=>{
        this.notificationService.showSuccess("Uspješno učlanjenje",'Success')
        this.closeModal();
    },(err)=>this.notificationService.showError(err.error,'Greška'));
  }
  closeModal() {
    this.router.navigateByUrl("/clanarine");
  }


}
