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

namespace RepositoryTest
{
    public class ReposirotyChartTest
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

        public ReposirotyChartTest()
        {
            ChartContext = new DataContext();
            _mockChartRepository = new DataChartRepository();
        }

        public IQueryable<ChartModel> GetDataMock()
        {
            return new List<ChartModel>
                {
                    new ChartModel { Data = new List<int>{ 10, 20, 30, 40, 40, 30, 20, 10 },Label  = "Label 1"  },
                    new ChartModel { Data = new List<int>{ 20, 30, 40, 30, 30, 40, 30, 20 },Label  = "Label 2"  },
                    new ChartModel { Data = new List<int>{ 30, 40, 30, 20, 20, 30, 40, 30 },Label  = "Label 3"  },
                    new ChartModel { Data = new List<int>{ 40, 30, 20, 10, 10, 20, 30, 40 },Label  = "Label 4"  },
                }.AsQueryable();
        }

        [Fact]
        public void Test1()
        {

            // create some mock products to play with
            var data = GetDataMock();

            var mockSet = new Mock<DbSet<ChartModel>>();
            mockSet.As<IQueryable<ChartModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<ChartModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<ChartModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<ChartModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<DataContext>();
            mockContext.Setup(c => c.ChartModel).Returns(mockSet.Object);

            var repository = new ChartRepository(mockContext.Object);
            var dataChart = repository.GetData(1);

            // Mock the dataChart Repository using Moq
            Mock<IDataChartRepository> mockChartRepository = new Mock<IDataChartRepository>();

            // Return various dataCharts
            mockChartRepository.Setup(mr => mr.GetVariousData(It.IsAny<int>(), It.IsAny<int>()));

            // return a dataChart
            mockChartRepository.Setup(mr => mr.GetData(It.IsAny<int>())).Returns((string l) => dataChart.Where(x => x.Label.Equals(l)).ToList());

        }

        [Fact]
        public void TestGet()
        {
            //Arrange
            var chartModel = new ChartModel();
            var context = new Mock<DataContext>();
            var dbSetMock = new Mock<DbSet<ChartModel>>();

            context.Setup(x => x.Set<ChartModel>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Find(It.IsAny<int>())).Returns(chartModel);

            //Act
            var repository = new RepositoryBase<ChartModel>(context.Object);
            repository.Get(1);

            //Assert
            context.Verify(x => x.Set<ChartModel>());
            dbSetMock.Verify(x => x.Find(It.IsAny<int>()));

        }

        [Fact]
        public void TestGetVariousDataType()
        {
            //Arrange
            var result = _mockChartRepository.GetVariousData(2, 2);

            //Act
            var expected = typeof(List<ChartModel>);

            //Assert

            Assert.IsType(expected, result);

        }

        [Fact]
        public void TestGetVariousDataException()
        {
            //Assert
            Assert.Throws<Exception>(() => _mockChartRepository.GetVariousData(0, 0));

        }

        [Fact]
        public void TestGetGetAllException()
        {
            //Arrange
            var chartModel = new ChartModel();
            var context = new Mock<DataContext>();
            var dbSetMock = new Mock<DbSet<ChartModel>>();

            context.Setup(x => x.Set<ChartModel>()).Returns(dbSetMock.Object);
            
            //Act
            var repository = new RepositoryBase<ChartModel>(context.Object);

            //Assert
            Assert.Throws<ArgumentException>(() => repository.Get(0));

        }

        [Fact]
        public void TryGetValue_NullKeyIsPassed_ArgumentNullExceptionIsThrown()
        {
            //Arrange
            var chartModel = new ChartModel();
            var context = new Mock<DataContext>();
            var dbSetMock = new Mock<DbSet<ChartModel>>();

            context.Setup(x => x.Set<ChartModel>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Find(It.IsAny<int>())).Returns(chartModel);

            //Act
            var repository = new RepositoryBase<ChartModel>(context.Object);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => repository.Get(0));
        }
    }
}
