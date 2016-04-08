using System;
using Assessment.Domain.Resistor;
using Assessment.Domain.Resistor.Enum;
using NUnit.Framework;
using Shouldly;

namespace Assessment.Tests
{
    [TestFixture]
    public class ResistorColorCodeTests
    {
        [Test]
        public void Parse_StringResistorColor_ReturnsCorrectResistorColorEnum()
        {
            var resistorColor = ResistorColorCode.ParseResistorColor("Black");
            resistorColor.ShouldBe(ResistorColor.Black);
        }

        [Test]
        public void Parse_InvalidStringResistorColor_ShouldThrowException()
        {
            Assert.Throws<Exception>(() =>
            {
                ResistorColorCode.ParseResistorColor("InvalidColor");
            });
        }
    }
}