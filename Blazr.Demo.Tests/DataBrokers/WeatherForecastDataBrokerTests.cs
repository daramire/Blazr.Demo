﻿/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================

using Blazr.Demo.Data;
using Blazr.Demo.Data.DataStores;
using Xunit;

namespace Blazr.Demo.Tests.DataBrokers
{
    public partial class WeatherForecastDataBrokerTests
    {

        [Theory]
        [InlineData(55, 55)]
        [InlineData(1000, 1000)]
        [InlineData(0, 0)]
        public async void DataBrokerShouldGetXWeatherForecastsAsync(int noOfRecords, int expectedCount)
        {
            // define
            var weatherForecastDataStore = new WeatherForecastDataStore();
            var records = WeatherForecastDataStore.CreateTestForecasts(noOfRecords);
            weatherForecastDataStore.OverrideWeatherForecastDateSet(records);
            var dataBroker = new WeatherForecastServerDataBroker(weatherForecastDataStore: weatherForecastDataStore);

            // test
            var retrievedRecords = await dataBroker.GetWeatherForecastsAsync();
            var retrievedRecordCount = retrievedRecords.Count;

            // assert
            Assert.Equal(expectedCount, retrievedRecordCount);
        }
    }
}
