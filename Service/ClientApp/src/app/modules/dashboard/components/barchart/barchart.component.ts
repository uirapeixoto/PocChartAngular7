import { Component, OnInit } from '@angular/core';
import { ChartModel } from '../../interfaces/chartmodel';
import { ChartService } from '../../services/chart.service';

@Component({
  selector: 'app-barchart',
  templateUrl: './barchart.component.html',
  styleUrls: ['./barchart.component.css']
})
export class BarchartComponent implements OnInit {
  dataChart: ChartModel[];

  constructor(private service: ChartService) { 
    this.service.getChartData().subscribe( 
      res => {
      this.dataChart = res;
    },err =>{
      console.log("Deu Erro");
    });
  }

  ngOnInit() {
    this.service.getChartData().subscribe( res => {
      this.dataChart = res;
    },err => {
      console.log("Deu Erro");
    });
  }

}
