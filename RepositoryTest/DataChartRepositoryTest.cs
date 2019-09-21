using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using Repository.Domain;
using Repository.Entity;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Repository.Tests
{
    public class DataChartRepositoryTest
    {
        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        ///</summary>
        public DataContext ChartContext { get; set; }

        /// <summary>
        /// Our Mock Products Repository for use in testing
        /// </summary>
        public readonly DataChartRepository _mockChartRepository;

        public DataChartRepositoryTest()
        {
            var data = GetDataMock();

            //Mock os dataCharts usando moq
            Mock<DataChartRepository> mockDataChartRepository = new Mock<DataChartRepository>();

            var mockSet = new Mock<DbSet<DataChart>>();
            mockSet.As<IQueryable<DataChart>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<DataChart>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<DataChart>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<DataChart>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<DataContext>();
            mockContext.Setup(c => c.DataChart).Returns(mockSet.Object);

            _mockChartRepository = new DataChartRepository(mockContext.Object);
        }

        public IQueryable<DataChart> GetDataMock()
        {
            return new List<DataChart>
                {
                    new DataChart { Id = 1, Label = "Label 1", CriadoEm = DateTime.Now, Data = new List<Data>{ new Data { Id = 1, Mes = 1, Ano = 2019, Valor = 100, CriadoEm = DateTime.Now, IdDataChart = 1 } }},
                    new DataChart { Id = 2, Label = "Label 2", CriadoEm = DateTime.Now, Data = new List<Data>{ new Data { Id = 1, Mes = 2, Ano = 2019, Valor = 110, CriadoEm = DateTime.Now, IdDataChart = 1 } }},
                    new DataChart { Id = 3, Label = "Label 3", CriadoEm = DateTime.Now, Data = new List<Data>{ new Data { Id = 1, Mes = 3, Ano = 2019, Valor = 120, CriadoEm = DateTime.Now, IdDataChart = 1 } }},
                }.AsQueryable();
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
        public void TestGetAll()
        {
            //Arrange
            IEnumerable<ChartDataModel> testChart = _mockChartRepository.GetAll();

            Assert.NotNull(testChart); // Test if null
            Assert.IsType<List<ChartDataModel>>(testChart.ToList()); // Test type
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
                Data = new List<DataModel>{
                    new DataModel { Id = 1, Mes = 1, Ano = 2019, Valor = 130.0m, CriadoEm = DateTime.Now },
                    new DataModel { Id = 2, Mes = 2, Ano = 2019, Valor = 140.0m, CriadoEm = DateTime.Now  },
                    new DataModel { Id = 3, Mes = 3, Ano = 2019, Valor = 150.0m, CriadoEm = DateTime.Now  }
                }
            };

            //Arrange
            ChartDataModel testChart = _mockChartRepository.Add(newDataChart);

            Assert.NotNull(testChart); // Test if null
            Assert.IsType<ChartDataModel>(testChart); // Test type
            Assert.Equal(4,testChart.Id); // Test type
        }

        [Fact]
        public void TestUpdate()
        {
            var data = GetDataMock();

            //permite que o teste insira um novo dataChart
            var newDataChart = new ChartDataModel
            {
                Label = $"Label 5",
                Data = new List<DataModel>{
                    new DataModel { Id = 1, Mes = 1, Ano = 2019, Valor = 120.0m, AlteradoEm = DateTime.Now  },
                    new DataModel { Id = 2, Mes = 2, Ano = 2019, Valor = 130.0m, AlteradoEm = DateTime.Now  },
                    new DataModel { Id = 3, Mes = 3, Ano = 2019, Valor = 140.0m, AlteradoEm = DateTime.Now  }
                }
            };

            //Arrange
            ChartDataModel testChart = _mockChartRepository.Update(1, newDataChart);

            Assert.NotNull(testChart); // Test if null
            Assert.IsType<ChartDataModel>(testChart); // Test type
            Assert.Equal("Label 5", testChart.Label); // Test type
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
