﻿function loadRadialBarChart(id, data) {
    let chartColors = getChartColor(id);

    let options = {
        fill: {
            colors: chartColors
        },
        chart: {
            height: 90,
            width: 90,
            type: "radialBar",           
            sparkline: {
                enabled: true
            },

        },

        series: data.series,

        plotOptions: {
            radialBar: {
                dataLabels: {
                    value: {
                        offsetY: -10,
                    }
                }
            }
        },
        labels: [""]
    };

    let chart = new ApexCharts(document.querySelector("#" + id), options);
    chart.render();


}

function getChartColor(id) {
    if (document.getElementById(id) != null) {
        let colors = document.getElementById(id).getAttribute("data-colors");

        if (colors) {
            colors = JSON.parse(colors);
            return colors.map(function (value) {
                let new_color = value.replace(" ", "");
                if (new_color.indexOf(",") === -1) {
                    var color = getComputedStyle(document.documentElement).getPropertyValue(new_color);
                    if (color) return color;
                    else return new_color;
                }
            });
        }

    }

}