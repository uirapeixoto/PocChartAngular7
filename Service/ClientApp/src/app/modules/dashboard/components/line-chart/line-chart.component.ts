import { Component, OnInit } from '@angular/core';
import { Chart } from 'chart.js';
import { ChartService } from '../../services/chart.service';

@Component({
  selector: 'app-line-chart',
  templateUrl: './line-chart.component.html',
  styleUrls: ['./line-chart.component.css']
})
export class LineChartComponent implements OnInit {
  linechart: Chart;

  public linechartOptions = {
    responsive: true
  };

  public lineChartLabels: string[] = ['January', 'February', 'March', 'April', 'May', 'June', 'July'];

  constructor(private service: ChartService) { }

  ngOnInit() {
    this.service.getLineChartData().subscribe( res => {
      this.linechart = new Chart('linecanvas', {
        type: 'line',
        data: {
          labels: this.lineChartLabels,
          datasets:res
        },
        options: this.linechartOptions
      });
    });
  }

  onChartClick(event) {
    this.service.getLineChartData().subscribe( res => {
      this.linechart = new Chart('linecanvas', {
        type: 'line',
        data: {
          labels: this.lineChartLabels,
          datasets:res
        },
        options: this.linechartOptions
      });
    });
  }
}
