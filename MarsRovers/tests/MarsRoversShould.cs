namespace MarsRovers.tests;

public class MarsRoversShould
{
    [Fact]
    public void MoveToAFinalPositionGivenACommand()
    {
        var marsRover = new MarsRover();
        var finalPointAndOrientation = marsRover.Execute("RMMLM");

        finalPointAndOrientation.Should().Be("2 1 N");
    }

    [Fact]
    public void HaveAMapWithADefaultSize()
    {
        var marsRover = new MarsRover();
        var mapSize = marsRover.Map.Length;

        mapSize.Should().Be(25);
    }

    [Fact]
    public void HaveAnInitialOrientation()
    {
        var marsRover = new MarsRover();
        marsRover.Orientation.Should().Be("E");
    }

    [Fact]
    public void HaveInitialPosition()
    {
        var marsRover = new MarsRover();
        var expectedPosition = new[]{0,0};
        
        marsRover.Position.Should().Equal(expectedPosition);
    }
    
    [Theory]
    [InlineData("R", "S")]
    [InlineData("L", "N")]
    public void CalculateNewOrientation(string rotation, string expectedOrientation)
    {
        var marsRover = new MarsRover();
        marsRover.Execute(rotation);

        marsRover.Orientation.Should().Be(expectedOrientation);
    }

    [Theory]
    [InlineData("R", "S")]
    [InlineData("L", "N")]
    [InlineData("RRR", "N")]
    [InlineData("LLL", "S")]
    [InlineData("RRLRLLR", "S")]
    public void CalculateNewOrientationFromSeveralRotations(string rotations, string expectedOrientation)
    {
        var marsRover = new MarsRover();
        marsRover.Execute(rotations);
        
        marsRover.Orientation.Should().Be(expectedOrientation);
    }
}