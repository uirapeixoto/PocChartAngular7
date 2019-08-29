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

  public pieChartColor: any[] = [
    { 
      backgroundColor: [
        'rgba(94, 181, 239, 0.79)',
        'rgba(33, 196, 60, 0.79)',
        'rgba(239, 236, 93, 0.79)',
        'rgba(221, 60, 60, 0.79)',
        'rgba(255, 128, 155, 0.79)',
        'rgba(132, 93, 239, 0.71)',
        'rgba(239, 93, 93, 0.71)',
        'rgba(239, 146, 93, 0.71)'
      ],
      borderColor: 'white',
      pointBackgroundColor: 'rgba(225,10,24,0.2)',
      pointBorderColor: '#fff',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(225,10,24,0.2)'
    }];

  constructor(private service: ChartService) { }

  ngOnInit() {

    let values: number[] = [];
    this.service.getPieChartData().subscribe( res => {
      res.forEach(x => {
        this.pieChartLabels.push(x.label);
        values.push(x.data[0]);
      });
      this.pieChartData = values;
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

  onPieChartClick(event) {
    this.RefreshChart();
  }
  
  RefreshChart(){
      let values: number[] = [];
      let labels: string[] = [];
      this.service.getPieChartData().subscribe( res => {
        res.forEach(x => {
          labels.push(x.label);
          values.push(x.data[0]);
        });
        this.pieChartLabels = labels;
        this.pieChartData = values;
        this.pieChartData = [
          {
            labels: this.pieChartLabels,
            data: values
          }];
      },
      (err: HttpErrorResponse) => {
        console.log (err.message);
      });
    }
}
