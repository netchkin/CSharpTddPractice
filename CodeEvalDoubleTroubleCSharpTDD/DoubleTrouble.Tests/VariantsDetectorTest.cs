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
}
