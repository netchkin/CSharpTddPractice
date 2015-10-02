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
        public void DetectVariants_TwoSamePartsOneWithOneStar_ReturnsOnePossibility()
        {
            var sut = new VariantsDetector();
            int variants = sut.DetectVariants("AAAA*A");
            Assert.Equal(1, variants);
        }

        [Fact]
        public void DetectVariants_TwoDifferentPartsOneWithOneStar_ReturnsNoPossibilities()
        {
            var sut = new VariantsDetector();
            int variants = sut.DetectVariants("AAAA*B");
            Assert.Equal(0, variants);
        }

        [Fact]
        public void DetectVariants_TwoSamePartsBothWithOneStarOnSamePosition_ReturnsTwoPossibilities()
        {
            var sut = new VariantsDetector();
            int variants = sut.DetectVariants("A*AA*A");
            Assert.Equal(2, variants);
        }

        [Fact]
        public void DetectVariants_TwoSamePartsBothWithTwoStarsOnSamePosition_ReturnsFourPossibilities()
        {
            var sut = new VariantsDetector();
            int variants = sut.DetectVariants("A**A**");
            Assert.Equal(4, variants);
        }

        [Fact]
        public void DetectVariants_TwoSamePartsWithOneStarOnDifferentPositions_ReturnsOnePossibility()
        {
            var sut = new VariantsDetector();
            int variants = sut.DetectVariants("AA*A*B");
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
            int variants = 1;

            for (int i = 0; i < codePartOne.Length; i++)
            {
                char currentInPartOne = codePartOne[i];
                char currentInPartTwo = codePartTwo[i];
                if (currentInPartOne != '*' && currentInPartTwo != '*' && currentInPartOne != currentInPartTwo)
                {
                    variants = 0;
                    break;
                }
                else if (currentInPartOne == '*' && currentInPartTwo == '*')
                {
                    variants *= 2;
                }
            }

            return variants;
        }
    }
}
