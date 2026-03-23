using System;

namespace StrategyDiscountExample
{
    public interface IStrategy
    {
        float Algorithm(float orderAmount);
    }

    // 1 стратегия: без скидки
    public class NoDiscountStrategy : IStrategy
    {
        public float Algorithm(float orderAmount)
        {
            return orderAmount;
        }
    }

    // 2 стратегия: процентная скидка
    public class PercentageDiscountStrategy : IStrategy
    {
        private readonly float _percent;

        public PercentageDiscountStrategy(float percent)
        {
            _percent = percent;
        }

        public float Algorithm(float orderAmount)
        {
            float discount = orderAmount * _percent / 100m;
            return orderAmount - discount;
        }
    }

    // 3 стратегия фиксированная скидка
    public class FixedDiscountStrategy : IStrategy
    {
        private readonly float _discountAmount;

        public FixedDiscountStrategy(float discountAmount)
        {
            _discountAmount = discountAmount;
        }

        public float Algorithm(float orderAmount)
        {
            float result = orderAmount - _discountAmount;
            return result < 0 ? 0 : result;
        }
    }
    
    public class Context
    {
        public IStrategy ContextStrategy { get; set; }

        public Context(IStrategy strategy)
        {
            ContextStrategy = strategy;
        }

        public float ExecuteAlgorithm(float orderAmount)
        {
            return ContextStrategy.Algorithm(orderAmount);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            float orderAmount = 5000m;

            // Без скидки
            Context context = new Context(new NoDiscountStrategy());
            Console.WriteLine("Сумма заказа: " + orderAmount);
            Console.WriteLine("Без скидки: " + context.ExecuteAlgorithm(orderAmount));

            // Смена стратегии на 10% скидку
            context.ContextStrategy = new PercentageDiscountStrategy(10);
            Console.WriteLine("Скидка 10%: " + context.ExecuteAlgorithm(orderAmount));

            // Смена стратегии на фиксированную скидку 700
            context.ContextStrategy = new FixedDiscountStrategy(700);
            Console.WriteLine("Фиксированная скидка 700: " + context.ExecuteAlgorithm(orderAmount));
        }
    }
}