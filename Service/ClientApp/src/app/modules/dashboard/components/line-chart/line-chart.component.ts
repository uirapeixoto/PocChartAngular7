import { Component, OnInit } from '@angular/core';
import { Chart, ChartData } from 'chart.js';
import { ChartService } from '../../services/chart.service';
import { Color } from 'ng2-charts';

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
  public lineChartLegend = true;
  public lineChartLabels: string[] = ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun'];
  public lineChartColor: any[] = [
    { 
      backgroundColor: [
        'rgba(94, 181, 239, 0.79)',
        'rgba(255, 130, 157, 0.71)',
        'rgba(239, 236, 93, 0.71)',
        'rgba(221, 60, 60, 0.71)',
        'rgba(255, 128, 155, 0.71)',
        'rgba(132, 93, 239, 0.71)',
        'rgba(239, 93, 93, 0.71)',
        'rgba(33, 196, 60, 0.71)'
      ],
      borderColor: 'white',
      pointBackgroundColor: 'rgba(225,10,24,0.2)',
      pointBorderColor: '#fff',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(225,10,24,0.2)'
    }];

    public barChartColors: Color[] = [
      { backgroundColor: 'red' },
      { backgroundColor: 'green' },
      { backgroundColor: 'yellow' },
    ]

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
      let counter: number = 0;
      res.forEach((x)=> {
        x.backgroundColor = this.lineChartColor[0].backgroundColor[counter];
        counter++;
      })
      let lineChartData: ChartData = {
        labels: this.lineChartLabels,
        datasets: res
      };
      this.linechart.data = lineChartData;
      this.linechart.update();
      
    });
  }
}
