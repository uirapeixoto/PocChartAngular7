import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BarchartComponent } from './components/barchart/barchart.component';
import { BoardComponent } from './components/board/board.component';
import { DashboardRoutingModule } from './dashboard.routing';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { SignalRService } from './services/signal-r.service';
import { ChartComponent } from './components/chart/chart.component';

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    DashboardRoutingModule,
    HttpClientModule
  ],
  declarations: [
    BarchartComponent,
    BoardComponent,
    ChartComponent
  ],
  exports:[
    BoardComponent
  ],
  providers:[SignalRService]
})
export class DashboardModule { }
