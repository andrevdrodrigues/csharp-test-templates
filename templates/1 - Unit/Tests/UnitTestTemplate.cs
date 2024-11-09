using FluentAssertions;
using Moq;
using System.Data;
using System.Data.SqlClient;
using TestTemplates._1___Unit.Classes;
using TestTemplates._1___Unit.Classes.Business;
using TestTemplates._1___Unit.Interfaces;
using TestTemplates._1___Unit.Util;
using TestTemplates.Unit.Classes;
using TestTemplates.Unit.Interfaces;
using Xunit;
using Assert = Xunit.Assert;

namespace TestTemplates.Experimentation._1___Unit.Tests
{
    public class UnitTestTemplate
    {
        #region Business Tests

        [Fact]
        public void CheckSumOfNumbersWithSuccess()
        {
            // Arrange
            Moq.Mock<ICalculator> mock = new Moq.Mock<ICalculator>();
            mock.Setup(x => x.Calcular(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>())).Returns(("sum", 7.7));
            CalculatorMachine maqCalc = new CalculatorMachine(mock.Object);

            // Act
            (string operation, double result) op = maqCalc.Calc("sum", 3.2, 4.5);

            // Assert
            Assert.Equal("sum", op.operation);
            Assert.Equal(7.7, op.result);
        }

        [Fact]
        public void CheckSumOfNumbersWithError()
        {
            // Arrange
            Moq.Mock<ICalculator> mock = new Moq.Mock<ICalculator>();
            mock.Setup(x => x.Calcular(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>())).Returns(("sum", 7.7));
            CalculatorMachine maqCalc = new CalculatorMachine(mock.Object);

            // Act
            (string operation, double result) op = maqCalc.Calc("sum", 3.2, 4.5);

            // Assert
            Assert.NotEqual(7.8, op.result);
        }

        [Fact]
        public void CheckSumOfNumbersOperationError()
        {
            // Arrange
            Moq.Mock<ICalculator> mock = new Moq.Mock<ICalculator>();
            mock.Setup(x => x.Calcular(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>())).Returns(("somar", 7.7));
            CalculatorMachine maqCalc = new CalculatorMachine(mock.Object);

            // Act
            (string operacao, double resultado) op = maqCalc.Calc("subtract", 3.2, 4.5);

            // Assert
            Assert.NotEqual("subtract", op.operacao);
        }

        #endregion

        #region Data Access Tests

        Customer customer = new Customer();

        [Fact]
        public void CheckSQLSelectOperationWithSuccess()
        {
            //Arrange
            var readerMock = new Mock<IDataReader>();

            readerMock.SetupSequence(_ => _.Read())
                .Returns(true)
                .Returns(false);

            readerMock.Setup(reader => reader.GetOrdinal("Id")).Returns(0);
            readerMock.Setup(reader => reader.GetOrdinal("Name")).Returns(1);

            readerMock.Setup(reader => reader.GetInt32(It.IsAny<int>())).Returns(1);
            readerMock.Setup(reader => reader.GetString(It.IsAny<int>())).Returns("André");

            var commandMock = new Mock<IDbCommand>();
            commandMock.Setup(m => m.ExecuteReader()).Returns(readerMock.Object).Verifiable();

            var connectionMock = new Mock<IDbConnection>();
            connectionMock.Setup(m => m.CreateCommand()).Returns(commandMock.Object);

            var connectionFactoryMock = new Mock<IDbConnectionFactory>();
            connectionFactoryMock
                .Setup(m => m.CreateConnection())
                .Returns(connectionMock.Object);

            var data = new MyDataAccessClass(connectionFactoryMock.Object);

            //Act
            var result = data.selectAll();

            //Assert
            result.Should().HaveCount(1);
            commandMock.Verify();
        }

        [Fact]
        public void CheckSQLInsertOperationWithSuccess()
        {
            //Arrange
            var commandMock = new Mock<IDbCommand>();
            commandMock
                .Setup(m => m.ExecuteNonQuery())
                .Verifiable();

            var connectionMock = new Mock<IDbConnection>();
            connectionMock
                .Setup(m => m.CreateCommand())
                .Returns(commandMock.Object);

            var connectionFactoryMock = new Mock<IDbConnectionFactory>();
            connectionFactoryMock
                .Setup(m => m.CreateConnection())
                .Returns(connectionMock.Object);

            var sut = new MyDataAccessClass(connectionFactoryMock.Object);
            var firstName = "John";
            var lastName = "Doe";

            //Act
            sut.Insert(firstName, lastName);

            //Assert
            commandMock.Verify();
        }

        [Fact]
        public void CheckSQLDeleteOperationWithSuccess()
        {
            //Arrange
            var commandMock = new Mock<IDbCommand>();
            commandMock
                .Setup(m => m.ExecuteNonQuery())
                .Verifiable();

            var connectionMock = new Mock<IDbConnection>();
            connectionMock
                .Setup(m => m.CreateCommand())
                .Returns(commandMock.Object);

            var connectionFactoryMock = new Mock<IDbConnectionFactory>();
            connectionFactoryMock
                .Setup(m => m.CreateConnection())
                .Returns(connectionMock.Object);

            var sut = new MyDataAccessClass(connectionFactoryMock.Object);
            var id = 1;

            //Act
            sut.Delete(1);

            //Assert
            commandMock.Verify();
        }

        [Fact]
        public void CheckSQLUpdateOperationWithSuccess()
        {
            //Arrange
            var commandMock = new Mock<IDbCommand>();
            commandMock
                .Setup(m => m.ExecuteNonQuery())
                .Verifiable();

            var connectionMock = new Mock<IDbConnection>();
            connectionMock
                .Setup(m => m.CreateCommand())
                .Returns(commandMock.Object);

            var connectionFactoryMock = new Mock<IDbConnectionFactory>();
            connectionFactoryMock
                .Setup(m => m.CreateConnection())
                .Returns(connectionMock.Object);

            var sut = new MyDataAccessClass(connectionFactoryMock.Object);
            var id = 1;

            //Act
            sut.Update(1, "André");

            //Assert
            commandMock.Verify();
        }

        [Fact]
        public void CheckAnyReturnedSQLException()
        {
            //Arrange

            var sqlException = new SqlExceptionBuilder().WithErrorNumber(50000)
                               .WithErrorMessage("Database exception occured...")
                               .Build();

            var commandMock = new Mock<IDbCommand>();
            commandMock
                .Setup(m => m.ExecuteNonQuery())
                .Verifiable();

            var connectionMock = new Mock<IDbConnection>();
            connectionMock
                .Setup(m => m.CreateCommand())
                .Returns(commandMock.Object);

            var connectionFactoryMock = new Mock<IDbConnectionFactory>();
            connectionFactoryMock
                .Setup(m => m.CreateConnection())
                .Throws(sqlException);

            var sut = new MyDataAccessClass(connectionFactoryMock.Object);

            //Act
            var ex = Assert.Throws<SqlException>(() => sut.selectAll());

            //Assert
            Assert.Equal("Database exception occured...", ex.Message);


        }

        #endregion

    }
}
