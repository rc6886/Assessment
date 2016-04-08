using Assessment.Domain.Ohm;
using Assessment.Domain.Resistor.Repository;
using NUnit.Framework;
using Shouldly;

namespace Assessment.Tests
{
    // Added a test for each multipler value, with a variety of color codes picked at random, 
    // to ensure that the final ohm value is correct.
    [TestFixture]
    public class OhmValueCalculatorTests
    {
        private IOhmValueCalculator _ohmValueCalculator;

        [SetUp]
        public void Setup()
        {
            _ohmValueCalculator = new OhmValueCalculator(new ResistorColorCodeRepository());
        }

        [Test]
        public void Calculate_YellowVioletBlackGold_ReturnsCorrectOhmValue()
        {
            var ohmValue = _ohmValueCalculator.CalculateOhmValues("Yellow", "Violet", "Black", "Gold");
            ohmValue.ShouldBe(47);
        }

        [Test]
        public void Calculate_GreenRedBrownSilver_ReturnsCorrectOhmValue()
        {
            var ohmValue = _ohmValueCalculator.CalculateOhmValues("Green", "Red", "Brown", "Silver");
            ohmValue.ShouldBe(520);
        }

        [Test]
        public void Calculate_VioletGrayRedYellow_ReturnsCorrectOhmValue()
        {
            var ohmValue = _ohmValueCalculator.CalculateOhmValues("Violet", "Gray", "Red", "Yellow");
            ohmValue.ShouldBe(7800);
        }

        [Test]
        public void Calculate_WhiteRedOrangeYellow_ReturnsCorrectOhmValue()
        {
            var ohmValue = _ohmValueCalculator.CalculateOhmValues("White", "Red", "Orange", "Yellow");
            ohmValue.ShouldBe(92000);
        }

        [Test]
        public void Calculate_BlueOrangeYellowGray_ReturnsCorrectOhmValue()
        {
            var ohmValue = _ohmValueCalculator.CalculateOhmValues("Blue", "Orange", "Yellow", "Gray");
            ohmValue.ShouldBe(630000);
        }

        [Test]
        public void Calculate_RedOrangeGreenBlue_ReturnsCorrectOhmValue()
        {
            var ohmValue = _ohmValueCalculator.CalculateOhmValues("Red", "Orange", "Green", "Blue");
            ohmValue.ShouldBe(2300000);
        }

        [Test]
        public void Calculate_BrownBrownBlueBlue_ReturnsCorrectOhmValue()
        {
            var ohmValue = _ohmValueCalculator.CalculateOhmValues("Brown", "Brown", "Blue", "Blue");
            ohmValue.ShouldBe(11000000);
        }

        [Test]
        public void Calculate_YellowRedVioletBrown_ReturnsCorrectOhmValue()
        {
            var ohmValue = _ohmValueCalculator.CalculateOhmValues("Yellow", "Red", "Violet", "Brown");
            ohmValue.ShouldBe(420000000);
        }

        [Test]
        public void Calculate_GreenGrayGrayBlack_ReturnsCorrectOhmValue()
        {
            var ohmValue = _ohmValueCalculator.CalculateOhmValues("Green", "Gray", "Gray", "Black");
            ohmValue.ShouldBe(5800000000);
        }

        [Test]
        public void Calculate_WhiteBlackWhiteBlack_ReturnsCorrectOhmValue()
        {
            var ohmValue = _ohmValueCalculator.CalculateOhmValues("White", "Black", "White", "Black");
            ohmValue.ShouldBe(90000000000);
        }

        [Test]
        public void Calculate_YellowBlueGoldBlack_ReturnsCorrectOhmValue()
        {
            var ohmValue = _ohmValueCalculator.CalculateOhmValues("Yellow", "Blue", "Gold", "Black");
            ohmValue.ShouldBe(4.6);
        }

        [Test]
        public void Calculate_OrangeVioletSilverBlack_ReturnsCorrectOhmValue()
        {
            var ohmValue = _ohmValueCalculator.CalculateOhmValues("Orange", "Violet", "Silver", "Black");
            ohmValue.ShouldBe(.37);
        }
    }
}
