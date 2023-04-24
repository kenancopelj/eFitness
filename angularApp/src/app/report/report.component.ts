import { Component, OnInit } from '@angular/core';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {

  constructor(private datePipe:DatePipe){

  }


  ngOnInit(): void {

  }

  UcitajReport() {

    // const dateParser = new NgbDateCustomParserFormatter('DD.MM.YYYY');
    // var dateFrom = new Date(dateParser.parse(this.filterForm.get('dateFrom').value).year, dateParser.parse(this.filterForm.get('dateFrom').value).month - 1, dateParser.parse(this.filterForm.get('dateFrom').value).day);
    // var dateTo = new Date(dateParser.parse(this.filterForm.get('dateTo').value).year, dateParser.parse(this.filterForm.get('dateTo').value).month - 1, dateParser.parse(this.filterForm.get('dateTo').value).day);

    // var queryParams = "?df=" + dateFrom.toISOString() + "&dt=" + dateTo.toISOString();
    // document.getElementById("reportViewer").setAttribute("src", "https://localhost:7148/report/Export_Data" + queryParams)
    // this.servicesService.ucitajReport(queryParams).subscribe(res=>{
    // });
  }

}
