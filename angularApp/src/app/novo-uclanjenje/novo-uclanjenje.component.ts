import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MojConfig } from '../moj-konfig';
import { AutentifikacijaHelper } from '../_helpers/autentifikacija-helper';

@Component({
  selector: 'app-novo-uclanjenje',
  templateUrl: './novo-uclanjenje.component.html',
  styleUrls: ['./novo-uclanjenje.component.css']
})
export class NovoUclanjenjeComponent implements OnInit {
  
  constructor(private router: Router,private route: ActivatedRoute,private httpKlijent : HttpClient)
  {}
  
  korisnikId: any;
  clanarinaId : any;
  clanarinaNaziv :any;
  clanarinaCijena :any;
  clanIme:any;
  clanPrezime :any;
  clanSpol: any;
  clanDatumRodjenja : any;
  
  ngOnInit(): void {
    this.clanarinaId = this.route.snapshot.paramMap.get('id');
    console.log(this.clanarinaId)
    this.getVrstaClanarineById(this.clanarinaId);
    this.korisnikId = AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.korisnickiNalogId;
    console.log(this.korisnikId)
  }

  getVrstaClanarineById(clanarinaId: any) {
    this.httpKlijent.get(MojConfig.adresa_servera+`/VrstaClanarine/GetById/${clanarinaId}`,MojConfig.http_opcije()).subscribe((x:any)=>{
      this.clanarinaNaziv = x.naziv;
      this.clanarinaCijena = x.cijena;
      console.log(x)
    },(err)=>alert(err.error));
  }

  Spasi() {
    const novaClanarina = {
      vrsta_clanarine_id : this.clanarinaId,
      korisnik_id:this.korisnikId,
      datumIsteka : new Date(new Date().getFullYear(),new Date().getMonth()+1, new Date().getDay()),
      ime : this.clanIme,
      prezime : this.clanPrezime,
      datumRodjenja : this.clanDatumRodjenja,
      spol : +this.clanSpol
    };
    this.httpKlijent.post(`${MojConfig.adresa_servera}/Clanarina/Add`,novaClanarina,MojConfig.http_opcije()).subscribe((x:any)=>{
        this.closeModal();
    },(err)=>alert(err.error));
  }
  closeModal() {
    this.router.navigateByUrl("/clanarine");
  }


}
