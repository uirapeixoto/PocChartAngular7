import { Component, OnInit } from '@angular/core';
import { ChartModel } from '../../interfaces/chartmodel';
import { ChartService } from '../../services/chart.service';
import { Chart } from 'chart.js';

@Component({
  selector: 'app-barchart',
  templateUrl: './barchart.component.html',
  styleUrls: ['./barchart.component.css']
})
export class BarchartComponent implements OnInit {
  title: string;
  chart: Chart;
  chartData: ChartModel[] = [{data: [], label: "Init"},{data: [], label: "Init"}];
  chartLabels:string[] = ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun'];
  chartOptions = {
    responsive: true
  };

  constructor(private service: ChartService) { }

  ngOnInit() {
    this.service.getBarChartData().toPromise().then(res => {
        this.chartData = res;
        //console.log(this.chartData);
    });
    //this.getDataChart();
    this.title = "BarChart Works!";
  }

  getDataChart(){
    this.service.getBarChartData().subscribe( res => {
        this.chartData = res;
        //console.log(this.chartData);
    });
  }

  onChartClick(event) {
    this.service.getBarChartData().subscribe( res => {
      this.chart = new Chart('canvas', {
        type: 'bar',
        data: {
          labels: this.chartLabels,
          datasets:res
        },
        options: this.chartOptions
      });
    });
  }

}
