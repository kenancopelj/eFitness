import { Component, OnInit } from '@angular/core';
import { NgbDateCustomParserFormatter } from '../_helpers/NgbDateCustomParserFormatter';
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
    const dateFromTransformed = this.datePipe.transform(new Date(), 'dd.MM.yyyy');
    const dateToTransformed = this.datePipe.transform(new Date(), 'dd.MM.yyyy');
  }

  UcitajReport() {
    // var now = new Date();
    // now.setFullYear(2021);
    //console.log(this.datumOd, this.datumDo);
    //var dateFrom = new Date(this.filterForm.get('dateFrom').value.getFullYear(), this.filterForm.get('dateFrom').value.getMonth() + 1, this.filterForm.get('dateFrom').value.getDate()).toISOString();
    //var dateTo = new Date(this.filterForm.get('dateTo').value.getFullYear(), this.filterForm.get('dateTo').value.getMonth() + 1, this.filterForm.get('dateTo').value.getDate()).toISOString();
    //var dateFrom;// = new Date(this.filterForm.get('dateFrom').value.getFullYear(), this.filterForm.get('dateFrom').value.getMonth() + 1, this.filterForm.get('dateFrom').value.getDate())
    //var dateTo// = new Date(this.filterForm.get('dateTo').value.getFullYear(), this.filterForm.get('dateTo').value.getMonth() + 1, this.filterForm.get('dateTo').value.getDate())

    // const dateParser = new NgbDateCustomParserFormatter('DD.MM.YYYY');
    // var dateFrom = new Date(dateParser.parse(this.filterForm.get('dateFrom').value).year, dateParser.parse(this.filterForm.get('dateFrom').value).month - 1, dateParser.parse(this.filterForm.get('dateFrom').value).day);
    // var dateTo = new Date(dateParser.parse(this.filterForm.get('dateTo').value).year, dateParser.parse(this.filterForm.get('dateTo').value).month - 1, dateParser.parse(this.filterForm.get('dateTo').value).day);

    // var queryParams = "?df=" + dateFrom.toISOString() + "&dt=" + dateTo.toISOString();
    // document.getElementById("reportViewer").setAttribute("src", "https://localhost:7148/report/Export_Data" + queryParams)
    // this.servicesService.ucitajReport(queryParams).subscribe(res=>{
    // });
  }

}
