import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BoardComponent } from './board/board.component';
import { BarchartComponent } from './barchart/barchart.component';
import { LineComponent } from './line/line.component';
import { LinechartComponent } from './linechart/linechart.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [BoardComponent, BarchartComponent, LineComponent, LinechartComponent]
})
export class DashboardModule { }
