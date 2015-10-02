using Xunit;

namespace DoubleTrouble.Tests
{
    public class VariantsDetectorTest
    {
        [Fact]
        public void DetectVariants_ValidCodeWithoutStars_ReturnsOnePossibility()
        {
            var sut = new VariantsDetector();
            int variants = sut.DetectVariants("AAAAAA");
            Assert.Equal(1, variants);
        }

        [Fact]
        public void DetectVariants_InvalidCodeWithoutStars_ReturnsZeroPossibilities()
        {
            var sut = new VariantsDetector();
            int variants = sut.DetectVariants("AAAAAB");
            Assert.Equal(0, variants);
        }
    }

    internal class VariantsDetector
    {
        public VariantsDetector()
        {
        }

        public int DetectVariants(string ancientCode)
        {
            int variants = 0;

            var ancientCodePartLength = ancientCode.Length / 2;
            string ancientCodePartOne = ancientCode.Substring(0, ancientCodePartLength);
            string ancientCodePartTwo = ancientCode.Substring(ancientCodePartLength);

            if (ancientCodePartOne == ancientCodePartTwo)
            {
                variants = 1;
            }

            return variants;
        }
    }
}
