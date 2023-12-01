// See https://aka.ms/new-console-template for more information
var file = File.OpenText("./input.txt");
var text = await file.ReadToEndAsync();
var split = text.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

var numbers = new Dictionary<string, string>{
    { "one", "o1e" },
    { "two", "t2o" },
    { "three", "t3e" },
    { "four", "f4r" },
    { "five", "f5e" },
    { "six", "s6x" },
    { "seven", "s7n" },
    { "eight", "e8t" },
    { "nine", "n9e" }
};

var sum = split.Select(x =>
                {
                    foreach (var (Key, Value) in numbers)
                        x = x.Replace(Key, Value);

                    var first = x.FirstOrDefault(c => char.IsDigit(c));
                    var last = x.LastOrDefault(c => char.IsDigit(c));
                    var combined = first.ToString() + last.ToString();
                    return int.Parse(combined);
                })
                .Sum();

Console.WriteLine($"The sum is {sum}");
