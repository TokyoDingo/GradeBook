using System;

namespace GradeBook
{
    public class Statistics
    {
        public double Average
        {
            get{
                return sum / count;
            }
        }

        public char Letter
        {
            get
            {
                switch(Average)
                {
                    case var d when d >= 90.0:
                        return 'A';
                    case var d when d >= 80.0:
                        return 'B';
                    case var d when d >= 70.0:
                        return 'C';
                    case var d when d >= 60.0:
                        return 'D';
                    default:
                        return 'F';              
                }
            }
        }

        public double High;
        public double Low;

        private double sum;

        private int count;

        public Statistics()
        {
            sum = 0.0;
            count = 0;
            Low = double.MaxValue;
            High = double.MinValue;
        }

        public void Add(double number)
        {
            sum += number;
            count ++;
            Low = Math.Min( number, Low );
            High = Math.Max( number, High );
        }
    }
}