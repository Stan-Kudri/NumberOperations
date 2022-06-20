namespace NumberOperations
{
    public class GreatestCommonMultiple
    {
        public static float NumberGCM(float firstValue, float secondValue)
        {
            return firstValue * secondValue / GreatestCommonDivisor(firstValue, secondValue);
        }

        private static float GreatestCommonDivisor(float firstValue, float secondValue)
        {
            if (firstValue != secondValue)
            {
                if (firstValue > secondValue)
                    return GreatestCommonDivisor(firstValue - secondValue, secondValue);
                return GreatestCommonDivisor(secondValue, secondValue - firstValue);
            }
            return firstValue;
        }
    }
}
