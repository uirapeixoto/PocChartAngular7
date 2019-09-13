using Microsoft.EntityFrameworkCore;
using Moq;
using Repository.Context;
using Repository.Contract;
using Repository.Domain;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Repository.Tests
{
    public class DataChartReposirotyTest
    {
        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        ///</summary>
        public DataContext ChartContext { get; set; }

        /// <summary>
        /// Our Mock Products Repository for use in testing
        /// </summary>
        public readonly IDataChartRepository _mockChartRepository;

        public DataChartReposirotyTest()
        {
            var data = GetDataMock();

            //Mock os dataCharts usando moq
            Mock<IDataChartRepository> mockDataChartRepository = new Mock<IDataChartRepository>();

            //retorna todos os dados
            mockDataChartRepository.Setup(x => x.GetAll()).Returns(data);

            //retorna um dataChart por Id
            mockDataChartRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns((int i) =>
                {
                    if (i == 0)
                        throw new ArgumentException("error");
                    return data.Where(x => x.Id == i).Single();
                }
            );

            //permite que o teste insira um novo dataChart
            var newDataChart = new ChartDataModel
            {
                Id = data.Max(x => x.Id),
                Label = $"Label {data.Max(x => x.Id)}",
                Data = new List<Data>{
                    new Data { Id = 1, Mes = 1, Ano = 2019, LabelId = data.Max(x => x.Id),  Valor = 120.0m },
                    new Data { Id = 2, Mes = 2, Ano = 2019, LabelId = data.Max(x => x.Id),  Valor = 130.0m },
                    new Data { Id = 3, Mes = 3, Ano = 2019, LabelId = data.Max(x => x.Id),  Valor = 140.0m }
                }
            };

            mockDataChartRepository.Setup(x => x.Add(It.IsAny<ChartDataModel>())).Returns(
                (ChartDataModel target) =>
                {
                    if (target != null)
                    {
                        data.ToList().Add(target);
                        return target;
                    }
                    else
                    {
                        return null;
                    }
                }
            );


            _mockChartRepository = mockDataChartRepository.Object;

        }

        public IList<ChartDataModel> GetDataMock()
        {
            return new List<ChartDataModel>
                {
                    new ChartDataModel { Id = 1, Label = "Label 1", Data = new List<Data>{ new Data{Id = 1, Mes = 1, Ano = 2019, Valor = 100, LabelId = 1 }}},
                    new ChartDataModel { Id = 2, Label = "Label 2", Data = new List<Data>{ new Data{Id = 1, Mes = 2, Ano = 2019, Valor = 110, LabelId = 2 }}},
                    new ChartDataModel { Id = 3, Label = "Label 3", Data = new List<Data>{ new Data{Id = 1, Mes = 3, Ano = 2019, Valor = 120, LabelId = 3 }}},
                };
        }

        [Fact]
        public void TestGet()
        {
            //Arrange
            var chartModel = new ChartDataModel();
            var context = new Mock<DataContext>();
            var dbSetMock = new Mock<DbSet<ChartDataModel>>();

            context.Setup(m => m.AddRange(GetDataMock()));

            context.Setup(x => x.Set<ChartDataModel>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Find(It.IsAny<int>())).Returns(chartModel);

            //Act
            var repository = new RepositoryBase<ChartDataModel>(context.Object);
            repository.Get(1);

            //Assert
            context.Verify(x => x.Set<ChartDataModel>());
            dbSetMock.Verify(x => x.Find(It.IsAny<int>()));

        }

        [Fact]
        public void CanReturnDataChartById()
        {
            // Try finding a product by id
            ChartDataModel testChart = _mockChartRepository.GetById(1);

            Assert.NotNull(testChart); // Test if null
            Assert.IsType<ChartDataModel>(testChart); // Test type
            Assert.Equal("Label 1", testChart.Label); // Verify it is the right product
        }

        [Fact]
        public void TestGetByIdException()
        {
            //Assert
            Assert.Throws<ArgumentException>(() => _mockChartRepository.GetById(0));

        }

        [Fact]
        public void TestGetGetAll()
        {
            //Arrange
            IEnumerable<ChartDataModel> testChart = _mockChartRepository.GetAll();

            Assert.NotNull(testChart); // Test if null
            Assert.IsType<List<ChartDataModel>>(testChart); // Test type
        }

        [Fact]
        public void TestAdd()
        {
            var data = GetDataMock();

            //permite que o teste insira um novo dataChart
            var newDataChart = new ChartDataModel
            {
                Id = data.Max(x => x.Id) + 1,
                Label = $"Label {data.Max(x => x.Id) + 1}",
                Data = new List<Data>{
                    new Data { Id = 1, Mes = 1, Ano = 2019, LabelId = data.Max(x => x.Id) + 1,  Valor = 120.0m },
                    new Data { Id = 2, Mes = 2, Ano = 2019, LabelId = data.Max(x => x.Id) + 1,  Valor = 130.0m },
                    new Data { Id = 3, Mes = 3, Ano = 2019, LabelId = data.Max(x => x.Id) + 1,  Valor = 140.0m }
                }
            };

            //Arrange
            ChartDataModel testChart = _mockChartRepository.Add(newDataChart);

            Assert.NotNull(testChart); // Test if null
            Assert.IsType<ChartDataModel>(testChart); // Test type
            Assert.Equal(4,testChart.Id); // Test type
        }

        [Fact]
        public void TryGetValue_NullKeyIsPassed_ArgumentNullExceptionIsThrown()
        {
            //Arrange
            var chartModel = new ChartDataModel();
            var context = new Mock<DataContext>();
            var dbSetMock = new Mock<DbSet<ChartDataModel>>();

            context.Setup(x => x.Set<ChartDataModel>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Find(It.IsAny<int>())).Returns(chartModel);

            //Act
            var repository = new RepositoryBase<ChartDataModel>(context.Object);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => repository.Get(0));
        }
    }
}
