//Create a chart inside a canvas
function createChart(canvas, uniqueVisitorData, siteVisitData, newAccountData) {
    return new Chart(canvas, {
        type: 'line',
        data: {
            datasets:
                [
                    {
                        label: 'Unique Visitor',
                        data: uniqueVisitorData,
                        borderColor: 'rgba(50,100,150)'
                    },
                    {
                        label: 'Site Visit',
                        data: siteVisitData,
                        borderColor: 'rgba(100,50,50)'
                    },
                    {
                        label: 'New Account',
                        data: newAccountData,
                        borderColor: 'rgba(150, 90, 150)'
                    }
                ]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }],
                xAxes: [{
                    ticks: {
                        autoSkip: true,
                        maxRotation: 0,
                        minRotation: 0
                    }
                }]
            },
            plugins:
            {
                zoom:
                {
                    pan:
                    {
                        enabled: true,
                        mode: 'x',
                        threshold: 1
                    },
                    zoom:
                    {
                        wheel:
                        {
                            enabled: true
                        },
                        mode: 'x'
                    }
                    
                }
            }
        }
    })
}

//Update a chart's data
function updateChart(chart, newUniqueVisitorData, newSiteVisitData, newNewAccountData)
{
    chart.data.datasets[0].data = newUniqueVisitorData
    chart.data.datasets[1].data = newSiteVisitData
    chart.data.datasets[2].data = newNewAccountData

    chart.update()
}

//Test updaetChartfunction
function updateChart2(chart, d)
{
    chart.data.datasets[0].data = d

    chart.update()
}