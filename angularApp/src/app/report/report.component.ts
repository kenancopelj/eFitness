import { Component, OnInit } from '@angular/core';
import { AutentifikacijaHelper } from '../_helpers/autentifikacija-helper';
import { MojConfig } from '../moj-konfig';
import { ReportService } from './report.service';
import { NotificationService } from '../notification.service';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {
  openModal : any = false;
  racuni: any;
  racuniDropdown: any;
  odabraniRacun : any;

  disableDefaultOption: boolean = false;
  placeholder: string = '';
  preselectedValue:string = '';

  constructor(private reportservice : ReportService, private notificationService:NotificationService){

  }


  ngOnInit(): void {
    this.loadNarudzbe();
  }




  loadNarudzbe() {
    this.reportservice.GetAllRacuni().subscribe((x:any)=>{
      this.racuni = x;
      console.log(this.racuni)
    },(err)=>this.notificationService.showError("Došlo je do greške!","Greška"))
  }

  UcitajReport() {
    this.openModal = true;
    setTimeout(() => {

      var narId = this.odabraniRacun == null ? 1 : this.odabraniRacun;
      var userID = AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.korisnickiNalog.id.toString();

      var queryParams ="?u=" + userID + "&k=" + narId;
      document.getElementById("reportViewer").setAttribute("src",
          `${MojConfig.adresa_report}/report/Export_Data` + queryParams
        );
        console.log(`${MojConfig.adresa_report}/report/Export_Data${queryParams}`)
    }, 500);
  }

}
