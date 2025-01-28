using Xunit;
using QuadraticEquationSolver;

namespace QuadraticSolverTests
{
    public class QuadraticSolverUnitTests
    {
        [Theory]
        [InlineData(1, 0, 1)] // Brak pierwiastków rzeczywistych
        public void Solve_NoRealRoots_ReturnsZeroRoots(double a, double b, double c)
        {
            var result = QuadraticSolver.Solve(a, b, c);
            Assert.Equal(0, result.NumberOfRoots);
            Assert.Null(result.Root1);
            Assert.Null(result.Root2);
        }

        [Theory]
        [InlineData(1, 2, 1, -1)] // Jeden pierwiastek rzeczywisty
        public void Solve_OneRealRoot_ReturnsOneRoot(double a, double b, double c, double expectedRoot)
        {
            var result = QuadraticSolver.Solve(a, b, c);
            Assert.Equal(1, result.NumberOfRoots);
            Assert.Equal(expectedRoot, (double)result.Root1, precision: 5);
            Assert.Null(result.Root2);
        }

        [Theory]
        [InlineData(1, -3, 2, 2, 1)] // Dwa pierwiastki rzeczywiste
        [InlineData(1, 0, -4, 2, -2)]
        public void Solve_TwoRealRoots_ReturnsTwoRoots(double a, double b, double c, double expectedRoot1, double expectedRoot2)
        {
            var result = QuadraticSolver.Solve(a, b, c);
            Assert.Equal(2, result.NumberOfRoots);
            Assert.Contains(result.Root1.Value, new[] { expectedRoot1, expectedRoot2 });
            Assert.Contains(result.Root2.Value, new[] { expectedRoot1, expectedRoot2 });
        }

        [Fact]
        public void Solve_CoefficientAIsZero_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => QuadraticSolver.Solve(0, 2, 1));
        }
    }
}
