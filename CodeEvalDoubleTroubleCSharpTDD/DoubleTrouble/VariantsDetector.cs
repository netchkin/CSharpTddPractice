using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleTrouble
{
    public class VariantsDetector
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

        private int ComputeVariantsForCodeParts(string codePartOne, string codePartTwo)
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
