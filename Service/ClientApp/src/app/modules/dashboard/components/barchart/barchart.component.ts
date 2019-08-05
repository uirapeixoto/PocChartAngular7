import { Component, OnInit } from '@angular/core';
import { ChartModel } from '../../interfaces/chartmodel';
import { ChartService } from '../../services/chart.service';

@Component({
  selector: 'app-barchart',
  templateUrl: './barchart.component.html',
  styleUrls: ['./barchart.component.css']
})
export class BarchartComponent implements OnInit {
  title: string;
  chartLabels:string[] = ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun'];
  chartOptions = {
    responsive: true
  };

  chartData = [
    { data: [], label: '' },
  ];

  constructor(private service: ChartService) { }

  ngOnInit() {
    this.getDataChart();
    this.title = "BarChart Works!";
  }

  getDataChart(){
    this.service.getChartData().subscribe( res => {
      res.forEach(x => {
        this.chartData.push(x);
      });
      console.log(this.chartData);
    });
  }

  onChartClick(event) {
    this.chartData = new Array();
    this.service.getChartData().subscribe( res => {
      res.forEach(x => {
        this.chartData.push(x);
      });
      console.log(this.chartData);
    });
    console.log(event);
  }

}
