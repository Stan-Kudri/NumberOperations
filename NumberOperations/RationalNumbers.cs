namespace NumberOperations
{
    public class RationalNumbers
    {
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


        public bool Equals(RationalNumbers number)
        {
            return _numerator == number._numerator && _denominator == number._denominator;
        }

        public static RationalNumbers operator +(RationalNumbers firstNumber, RationalNumbers secondNumber)
        {
            return AdditionOrSubtractionOperations(firstNumber, secondNumber, '+');
        }

        public static RationalNumbers operator -(RationalNumbers firstNumber, RationalNumbers secondNumber)
        {
            return AdditionOrSubtractionOperations(firstNumber, secondNumber, '-');
        }

        private static RationalNumbers AdditionOrSubtractionOperations(RationalNumbers firstNumber, RationalNumbers secondNumber, char operation)
        {
            if (firstNumber._denominator == secondNumber._denominator)
            {
                if (operation == '+')
                {
                    return new RationalNumbers(firstNumber._numerator + secondNumber._numerator, firstNumber._denominator);
                }
                if (operation == '-')
                {
                    return new RationalNumbers(firstNumber._numerator - secondNumber._numerator, firstNumber._denominator);
                }
                throw new ArgumentException("Операция недоступна!");
            }
            else
            {
                var numberGCM = GreatestCommonMultiple.NumberGCM(firstNumber._denominator, secondNumber._denominator);

                var firstDenominatorMultiplier = numberGCM / firstNumber._denominator;
                var secondDenominatorMultiplier = numberGCM / secondNumber._denominator;

                var firstNumerator = firstDenominatorMultiplier * firstNumber._numerator;
                var secondNumerator = secondDenominatorMultiplier * secondNumber._numerator;
                if (operation == '+')
                {
                    return new RationalNumbers(firstNumerator + secondNumerator, numberGCM);
                }
                if (operation == '-')
                {
                    return new RationalNumbers(firstNumerator - secondNumerator, numberGCM);
                }
                throw new ArgumentException("Операция недоступна!");
            }
        }

        public static RationalNumbers operator *(RationalNumbers firstNumber, RationalNumbers secondNumber)
        {
            return new RationalNumbers(firstNumber._numerator * secondNumber._numerator, firstNumber._denominator * secondNumber._denominator);
        }

        public static RationalNumbers operator /(RationalNumbers firstNumber, RationalNumbers secondNumber)
        {
            return new RationalNumbers(firstNumber._numerator * secondNumber._denominator, firstNumber._denominator * secondNumber._numerator);
        }

        public static RationalNumbers operator ++(RationalNumbers number) => new RationalNumbers(number._numerator + number._denominator, number._denominator);

        public static RationalNumbers operator --(RationalNumbers number) => new RationalNumbers(number._numerator - number._denominator, number._denominator);

        public static bool operator ==(RationalNumbers firstNumber, RationalNumbers secondNumber)
        {
            return firstNumber.ValueNumber() == secondNumber.ValueNumber();
        }

        public static bool operator !=(RationalNumbers firstNumber, RationalNumbers secondNumber)
        {
            return !(firstNumber == secondNumber);
        }

        public static bool operator >(RationalNumbers firstNumber, RationalNumbers secondNumber)
        {
            return firstNumber.CompareTo(secondNumber) > 0;
        }

        public static bool operator <(RationalNumbers firstNumber, RationalNumbers secondNumber)
        {
            return secondNumber.CompareTo(firstNumber) > 0;
        }

        public static bool operator >=(RationalNumbers firstNumber, RationalNumbers secondNumber)
        {
            return firstNumber.CompareTo(secondNumber) >= 0;
        }

        public static bool operator <=(RationalNumbers firstNumber, RationalNumbers secondNumber)
        {
            return secondNumber.CompareTo(firstNumber) >= 0;
        }

        public float CompareTo(RationalNumbers? other)
        {
            if (ReferenceEquals(other, null))
                return 1;
            return ValueNumber() - other.ValueNumber();
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
