namespace NumberOperations
{
    public class RationalNumbers
    {
        private const string FirstNullNumber = "Первое число равно null";
        private const string SecondNullNumber = "Второе число равно null";
        private const string NumberIsNull = "Число равно null";

        private readonly float _numerator;
        private readonly float _denominator;

        private float ValueNumber() => _numerator / _denominator;

        public RationalNumbers(float numerator, float denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Ошибка, знаменатель не может быть равен нулю.");
            _numerator = numerator;
            _denominator = denominator;
        }

        public static RationalNumbers operator +(RationalNumbers firstNumber, RationalNumbers secondNumber)
        {
            ArgumentNullException.ThrowIfNull(firstNumber, FirstNullNumber);
            ArgumentNullException.ThrowIfNull(secondNumber, SecondNullNumber);

            var typleNumber = ExtractCommonDenominator(firstNumber, secondNumber);

            var numerator = typleNumber.firstValueNumbertor + typleNumber.secondValueNumbertor;
            var denominator = typleNumber.valueDenominator;

            return new RationalNumbers(numerator, denominator);
        }

        public static RationalNumbers operator -(RationalNumbers firstNumber, RationalNumbers secondNumber)
        {
            ArgumentNullException.ThrowIfNull(firstNumber, FirstNullNumber);
            ArgumentNullException.ThrowIfNull(secondNumber, SecondNullNumber);

            var typleNumber = ExtractCommonDenominator(firstNumber, secondNumber);

            var numerator = typleNumber.firstValueNumbertor - typleNumber.secondValueNumbertor;
            var denominator = typleNumber.valueDenominator;

            return new RationalNumbers(numerator, denominator);
        }

        private static (float firstValueNumbertor, float secondValueNumbertor, float valueDenominator) ExtractCommonDenominator(RationalNumbers firstNumber, RationalNumbers secondNumber)
        {
            if (firstNumber._denominator == secondNumber._denominator)
            {
                return (firstNumber._numerator, secondNumber._numerator, firstNumber._denominator);
            }
            else
            {
                var valueDenominator = GreatestCommonMultiple.NumberGCM(firstNumber._denominator, secondNumber._denominator);

                var firstDenominatorMultiplier = valueDenominator / firstNumber._denominator;
                var secondDenominatorMultiplier = valueDenominator / secondNumber._denominator;

                var firstValueNumbertor = firstDenominatorMultiplier * firstNumber._numerator;
                var secondValueNumbertor = secondDenominatorMultiplier * secondNumber._numerator;

                return (firstValueNumbertor, secondValueNumbertor, valueDenominator);
            }
        }

        public static RationalNumbers operator *(RationalNumbers firstNumber, RationalNumbers secondNumber)
        {
            ArgumentNullException.ThrowIfNull(firstNumber, FirstNullNumber);
            ArgumentNullException.ThrowIfNull(secondNumber, SecondNullNumber);

            return new RationalNumbers(firstNumber._numerator * secondNumber._numerator, firstNumber._denominator * secondNumber._denominator);
        }

        public static RationalNumbers operator /(RationalNumbers firstNumber, RationalNumbers secondNumber)
        {
            ArgumentNullException.ThrowIfNull(firstNumber, FirstNullNumber);
            ArgumentNullException.ThrowIfNull(secondNumber, SecondNullNumber);

            return new RationalNumbers(firstNumber._numerator * secondNumber._denominator, firstNumber._denominator * secondNumber._numerator);
        }

        public static float operator %(RationalNumbers firstNumber, RationalNumbers secondNumber)
        {
            ArgumentNullException.ThrowIfNull(firstNumber, FirstNullNumber);
            ArgumentNullException.ThrowIfNull(secondNumber, SecondNullNumber);

            var numerator = firstNumber._numerator * secondNumber._denominator;
            var denominator = firstNumber._denominator * secondNumber._numerator;

            while (numerator > denominator)
                numerator -= denominator;

            return numerator;
        }

        public static RationalNumbers operator ++(RationalNumbers number)
        {
            ArgumentNullException.ThrowIfNull(number, NumberIsNull);

            return new RationalNumbers(number._numerator + number._denominator, number._denominator);
        }

        public static RationalNumbers operator --(RationalNumbers number)
        {
            ArgumentNullException.ThrowIfNull(number, NumberIsNull);

            return new RationalNumbers(number._numerator - number._denominator, number._denominator);
        }

        public static bool operator ==(RationalNumbers firstNumber, RationalNumbers secondNumber)
        {
            ArgumentNullException.ThrowIfNull(firstNumber, FirstNullNumber);
            ArgumentNullException.ThrowIfNull(secondNumber, SecondNullNumber);

            return firstNumber.ValueNumber() == secondNumber.ValueNumber();
        }

        public static bool operator !=(RationalNumbers firstNumber, RationalNumbers secondNumber)
        {
            ArgumentNullException.ThrowIfNull(firstNumber, FirstNullNumber);
            ArgumentNullException.ThrowIfNull(secondNumber, SecondNullNumber);

            return !(firstNumber == secondNumber);
        }

        public static bool operator >(RationalNumbers firstNumber, RationalNumbers secondNumber)
        {
            ArgumentNullException.ThrowIfNull(firstNumber, FirstNullNumber);
            ArgumentNullException.ThrowIfNull(secondNumber, SecondNullNumber);

            return firstNumber.CompareTo(secondNumber) > 0;
        }

        public static bool operator <(RationalNumbers firstNumber, RationalNumbers secondNumber)
        {
            ArgumentNullException.ThrowIfNull(firstNumber, FirstNullNumber);
            ArgumentNullException.ThrowIfNull(secondNumber, SecondNullNumber);

            return secondNumber.CompareTo(firstNumber) > 0;
        }

        public static bool operator >=(RationalNumbers firstNumber, RationalNumbers secondNumber)
        {
            ArgumentNullException.ThrowIfNull(firstNumber, FirstNullNumber);
            ArgumentNullException.ThrowIfNull(secondNumber, SecondNullNumber);

            return firstNumber.CompareTo(secondNumber) >= 0;
        }

        public static bool operator <=(RationalNumbers firstNumber, RationalNumbers secondNumber)
        {
            ArgumentNullException.ThrowIfNull(firstNumber, FirstNullNumber);
            ArgumentNullException.ThrowIfNull(secondNumber, SecondNullNumber);

            return secondNumber.CompareTo(firstNumber) >= 0;
        }

        public float CompareTo(RationalNumbers? other)
        {
            if (ReferenceEquals(other, null))
                return 1;
            return ValueNumber() - other.ValueNumber();
        }

        public bool Equals(RationalNumbers number)
        {
            return _numerator == number._numerator && _denominator == number._denominator;
        }

        public override bool Equals(object? obj)
        {
            if (obj is RationalNumbers number)
                return Equals(number);
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_numerator, _denominator);
        }

        public override string ToString()
        {
            return $"{_numerator} / {_denominator}";
        }
    }
}
