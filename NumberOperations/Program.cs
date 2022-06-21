/*
 * Упражнение 12.2 Создать класс рациональных чисел. В классе два поля 
– числитель и знаменатель. Предусмотреть конструктор. Определить операторы 
==, != (метод Equals()), <, >, <=, >=, +, – , ++, --. Переопределить метод 
ToString() для вывода дроби. Если останется время, то определить операторы 
преобразования типов между типом дробь, float, int. Определить операторы *, /, %.
 private readonly float _numerator;
        private readonly float _denominator;
 */

using NumberOperations;

var firstValueNumerator = 15;
var secondValueNumerator = 12;

var firstValueDeniminator = 7;
var secondValueDeniminator = 9;

var firstNumber = new RationalNumbers(firstValueNumerator, firstValueDeniminator);
var secondNumber = new RationalNumbers(secondValueNumerator, secondValueDeniminator);

Console.WriteLine(firstNumber * secondNumber);

Console.WriteLine(secondNumber % firstNumber);