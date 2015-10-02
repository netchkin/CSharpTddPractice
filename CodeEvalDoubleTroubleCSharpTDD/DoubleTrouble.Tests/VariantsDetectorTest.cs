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

        [Fact]
        public void ComputeVariantsForCodeParts_TwoSamePartsFullParts_ReturnsOnePossibility()
        {
            var sut = new VariantsDetector();
            int variants = sut.ComputeVariantsForCodeParts("AAA", "AAA");
            Assert.Equal(1, variants);
        }

        [Fact]
        public void ComputeVariantsForCodeParts_TwoDifferentPartsFullParts_ReturnsOnePossibility()
        {
            var sut = new VariantsDetector();
            int variants = sut.ComputeVariantsForCodeParts("AAA", "ABA");
            Assert.Equal(0, variants);
        }

        [Fact]
        public void ComputeVariantsForCodeParts_TwoSamePartsOneWithOneStar_ReturnsOnePossibility()
        {
            var sut = new VariantsDetector();
            int variants = sut.ComputeVariantsForCodeParts("AAA", "A*A");
            Assert.Equal(1, variants);
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

            variants = ComputeVariantsForCodeParts(ancientCodePartOne, ancientCodePartTwo);

            return variants;
        }

        internal int ComputeVariantsForCodeParts(string codePartOne, string codePartTwo)
        {
            int variants = 0;

            if (codePartOne == codePartTwo)
            {
                variants = 1;
            }

            return variants;
        }
    }
}
