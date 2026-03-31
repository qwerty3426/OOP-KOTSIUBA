using System;

namespace lab24
{
    class Program
    {
        static void Main(string[] args)
        {
            var publisher = new ResultPublisher();

            var consoleObserver = new ConsoleLoggerObserver();
            var historyObserver = new HistoryLoggerObserver();
            var thresholdObserver = new ThresholdNotifierObserver(10);

            consoleObserver.Subscribe(publisher);
            historyObserver.Subscribe(publisher);
            thresholdObserver.Subscribe(publisher);

            var processor = new NumericProcessor(new SquareOperationStrategy());

            double[] inputs = { 2, 3, 4 };

            foreach (var input in inputs)
            {
                double result = processor.Process(input);
                publisher.PublishResult(result, processor.CurrentOperationName);
            }

            processor.SetStrategy(new CubeOperationStrategy());

            foreach (var input in inputs)
            {
                double result = processor.Process(input);
                publisher.PublishResult(result, processor.CurrentOperationName);
            }

            processor.SetStrategy(new SquareRootOperationStrategy());

            foreach (var input in inputs)
            {
                double result = processor.Process(input);
                publisher.PublishResult(result, processor.CurrentOperationName);
            }

            Console.WriteLine("\nHistory:");
            foreach (var entry in historyObserver.History)
            {
                Console.WriteLine(entry);
            }
        }
    }
}
