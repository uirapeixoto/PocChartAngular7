import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams, HttpErrorResponse  } from '@angular/common/http';
import { ChartModel } from '../interfaces/chartmodel';
import { Observable, throwError } from 'rxjs';
import { map, catchError, tap, retry } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ChartService {
  apiUrl: string = 'http://localhost:60967/api/data-chart';

  constructor(private httpClient: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    }),
    params: new  HttpParams().set('ndata', "6").set('amount', "2")
  };

  getChartData():Observable<ChartModel[]>{
    return this.httpClient.get<ChartModel[]>(this.apiUrl, this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.handleError)
    )};

   // Error handling 
   handleError(error) {
    let errorMessage = '';
    if(error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    window.alert(errorMessage);
    return throwError(errorMessage);
 }
}