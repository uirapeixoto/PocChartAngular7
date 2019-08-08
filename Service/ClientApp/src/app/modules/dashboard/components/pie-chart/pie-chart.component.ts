import { Component, OnInit } from '@angular/core';
import { Chart, ChartOptions, ChartType } from 'chart.js';
import { ChartService } from '../../services/chart.service';
import { HttpErrorResponse } from '@angular/common/http/http';


@Component({
  selector: 'app-pie-chart',
  templateUrl: './pie-chart.component.html',
  styleUrls: ['./pie-chart.component.css']
})
export class PieChartComponent implements OnInit {
  piechart: Chart;

  public pieChartData:any = [{data: []}];
  public pieChartLabels: string[] = [];
  // Pie
  public pieChartType: ChartType = 'pie';
  public pieChartLegend = true;
  public pieChartOptions: ChartOptions = {
    responsive: true,
    legend: {
      position: 'right',
    }
  };

  public pieChartColor:any = [
    'rgba(30, 169, 224, 0.8)',
    'rgba(255,165,0,0.9)',
    'rgba(139, 136, 136, 0.9)',
    'rgba(255, 161, 181, 0.9)',
    'rgba(255, 102, 0, 0.9)'
  ];

  constructor(private service: ChartService) { }

  ngOnInit() {

    let values: number[] = [];
    this.service.getPieChartData().subscribe( res => {
      res.forEach(x => {
        this.pieChartLabels.push(x.label);
        values.push(x.data[0]);
      });
      this.pieChartData = values;
      console.log(this.pieChartLabels);
      console.log(this.pieChartData);
      this.pieChartData = [
        {
          labels: this.pieChartLabels,
          data: values
        }];
      this.piechart = new Chart('piecanvas', {
        type: 'pie',
        
        data: {
            labels: this.pieChartLabels,
            datasets: [{
            backgroundColor: this.pieChartColor,
            data: this.pieChartData
          }]
        },
        options: this.pieChartOptions
      });

    },
    (err: HttpErrorResponse) => {
      console.log (err.message);
    });
  }

}
