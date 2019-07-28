import { Component, OnInit } from '@angular/core';
import { SignalRService } from '../../services/signal-r.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.css']
})
export class ChartComponent implements OnInit {

  constructor(public signalRService: SignalRService, private http: HttpClient) { }
 
  ngOnInit() {
    this.signalRService.startConnection();
    this.signalRService.addTransferChartDataListener();   
    this.startHttpRequest();
  }
 
  private startHttpRequest = () => {
    this.http.get('http://localhost:60967/api/chart')
      .subscribe(res => {
        console.log(res);
      })
  }

}
