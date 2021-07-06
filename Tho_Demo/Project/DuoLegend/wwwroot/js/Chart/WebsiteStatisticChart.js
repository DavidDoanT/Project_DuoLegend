function createChart(container, uniqueVisitorData, siteVisitData, newAccountData)
    {
        return new Chart(container, {
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
                    }]
                }
            }
        })
    }