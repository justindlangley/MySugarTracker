using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;

namespace MySugarTracker.Models
{
    // create a highcharts graph ready to pass to the view
    public class SugarGraph
    {
        public Highcharts CreateSugarChart(DateTime[] xdata, object[][] ydata, int lowBand, int highBand)
        {
            
            var xdataString = new string[xdata.Count()];
            for (int i = 0; i < xdata.Count(); i++)
            {
                xdataString[i] = xdata[i].ToShortDateString();
            }

            var myTitle = "Glucose Level From " + xdata[0].ToShortDateString() + " To " + xdata[xdata.Count()-1].ToShortDateString();

            var plotBand = new YAxisPlotBands();
            plotBand.Color = System.Drawing.Color.LightGreen;
            plotBand.From = lowBand;
            plotBand.To = highBand;

            var yAxis = new YAxis();
            yAxis.PlotBands = new[] { plotBand };
            var yTitle = new YAxisTitle();
            yTitle.Text = "mg/dl";
            yAxis.Title = yTitle;

            var chart = new Highcharts("chart");
            chart.InitChart(new Chart { DefaultSeriesType = ChartTypes.Line, BorderWidth = 2, BorderRadius = 20 });
            chart.SetTitle(new Title { Text = myTitle });
            
            var xAxis = new XAxis();
            xAxis.TickInterval = 4;
            xAxis.Categories = xdataString;
            chart.SetXAxis(xAxis);

            chart.SetYAxis(yAxis);
            chart.SetSeries(new[] { new Series { Name = "Glucose Reading", Data = new Data(ydata), } });

            return chart;
        }
    }
}