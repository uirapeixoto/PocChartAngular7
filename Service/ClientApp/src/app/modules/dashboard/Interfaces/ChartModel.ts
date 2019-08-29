import { ChartColor } from "chart.js";

export interface ChartModel {
    data: any[];
    label: string;
    backgroundColor?: ChartColor | ChartColor[];
}