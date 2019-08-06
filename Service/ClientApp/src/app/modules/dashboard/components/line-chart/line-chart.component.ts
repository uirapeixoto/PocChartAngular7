import { Component, OnInit } from '@angular/core';
import { Chart } from 'chart.js';
import { ChartService } from '../../services/chart.service';

@Component({
  selector: 'app-line-chart',
  templateUrl: './line-chart.component.html',
  styleUrls: ['./line-chart.component.css']
})
export class LineChartComponent implements OnInit {
  chart: Chart;

  public chartOptions = {
    responsive: true
  };

  public lineChartLabels: string[] = ['January', 'February', 'March', 'April', 'May', 'June', 'July'];

  constructor(private service: ChartService) { }

  ngOnInit() {
    this.service.getChartData().subscribe( res => {
      this.chart = new Chart('canvas', {
        type: 'line',
        data: {
          labels: this.lineChartLabels,
          datasets:res
        },
        options: this.chartOptions
      });
    });
  }

  onChartClick(event) {
    this.service.getChartData().subscribe( res => {
      this.chart = new Chart('canvas', {
        type: 'line',
        data: {
          labels: this.lineChartLabels,
          datasets:res
        },
        options: this.chartOptions
      });
    });
  }
}
