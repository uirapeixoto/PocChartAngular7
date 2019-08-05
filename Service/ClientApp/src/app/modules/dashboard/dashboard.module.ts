import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChartsModule } from 'ng2-charts';
import { BarchartComponent } from './components/barchart/barchart.component';
import { BoardComponent } from './components/board/board.component';
import { DashboardRoutingModule } from './dashboard.routing';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { SignalRService } from './services/signal-r.service';
import { ChartComponent } from './components/chart/chart.component';
import { ChartService } from './services/chart.service';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    FormsModule,
    DashboardRoutingModule,
    HttpClientModule,
    ChartsModule
  ],
  declarations: [
    BarchartComponent,
    BoardComponent,
    ChartComponent
  ],
  exports:[
    ChartsModule
  ],
  providers:[SignalRService, ChartService]
})
export class DashboardModule { }
