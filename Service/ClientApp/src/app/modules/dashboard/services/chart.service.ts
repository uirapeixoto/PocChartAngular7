import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { ChartModel } from '../interfaces/chartmodel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ChartService {
  dataChart: ChartModel[];
  apiUrl: string = 'http://localhost:60967/api/data-chart';
  constructor(private httpClient: HttpClient) { }

  public getChartData(): any{
    
    const  params = new  HttpParams().set('ndata', "6").set('amount', "2");
    const dataObservable = new Observable(observer => {
      this.httpClient.get<ChartModel[]>(this.apiUrl, {params})
      .subscribe(
        res => {
            this.dataChart = res;
            console.log(this.dataChart);
        }, err => {
            console.log(err);
            observer.next(this.dataChart);
        });
    });

    return dataObservable;
  }
}
