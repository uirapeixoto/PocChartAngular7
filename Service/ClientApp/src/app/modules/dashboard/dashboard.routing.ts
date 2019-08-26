import { Routes, RouterModule } from "@angular/router";
import { BoardComponent } from "./components/board/board.component";
import { BarchartComponent } from "./components/barchart/barchart.component";
import { NgModule } from "@angular/core";

const routes: Routes = [
    // App routes goes here here
    {
        path: 'dashboard',
        component: BoardComponent,
        children: [
            { path: '', component: BoardComponent },
            //{ path: 'barchart', component: BarchartComponent },
        ]
    }
]

@NgModule({
    declarations: [],
    imports: [ RouterModule.forChild(routes) ],
    exports: [ RouterModule ],
    providers: [],
})


export class DashboardRoutingModule {}