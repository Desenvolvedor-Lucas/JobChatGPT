using Microsoft.ML;
using Microsoft.ML.Data;
using Spectre.Console;
using Console = Spectre.Console.AnsiConsole;

namespace JobCheckerMl.VagaMl
{
    public class MlVacancies
    {
        private readonly MLContext ctx;
        private readonly IDataView dataView;

        public MlVacancies()
        {
            ctx = new();
            dataView = ctx.Data.LoadFromTextFile<VacancyData>("vacancy.txt");
        }

        public ITransformer TrainMl()
        {
            // split data into testing set
            var splitDataView = ctx.Data
                .TrainTestSplit(dataView, testFraction: 0.2);

            // build model
            var estimator = ctx.Transforms.Text
                .FeaturizeText(
                    outputColumnName: "Features",
                    inputColumnName: nameof(VacancyData.Text)
                ).Append(ctx.BinaryClassification.Trainers.SdcaLogisticRegression(featureColumnName: "Features"));

            // Train model
            ITransformer model = default!;
            var rule = new Spectre.Console.Rule("Create and Train Model");
            Console
                .Live(rule)
                .Start(console =>
                {
                    // training happens here
                    model = estimator.Fit(splitDataView.TrainSet);
                    var predictions = model.Transform(splitDataView.TestSet);
                    rule.Title = "🏁 Training Complete, Evaluating Accuracy.";
                    console.Refresh();
                    // evaluate the accuracy of our model
                    var metrics = ctx.BinaryClassification.Evaluate(predictions);
                    var table = new Table()
                        .MinimalBorder()
                        .Title("💯 Model Accuracy");
                    table.AddColumns("Accuracy", "Auc", "F1Score");
                    table.AddRow($"{metrics.Accuracy:P2}", $"{metrics.AreaUnderRocCurve:P2}", $"{metrics.F1Score:P2}");
                    console.UpdateTarget(table);
                    console.Refresh();
                });
            return model;
        }

        public void ExecuteMl(ITransformer model)
        {
            while (true)
            {
                var text = Console.Ask<string>("[red]Qual o seu [/][green]texto para revisão[/]?");
                var engine = ctx.Model.CreatePredictionEngine<VacancyData, VacancyPrediction>(model);
                var input = new VacancyData { Text = text };
                var result = engine.Predict(input);
                var (color, vacancy) = result.Prediction
                    ? (color: "green", emoji: "É uma vaga")
                    : (color: "red", emoji: "Não é uma vaga");
                Console.MarkupLine($"{vacancy} [{color}]\"{text}\" ({result.Probability:P00})[/] ");
            }
        }
    }

    public class VacancyData
    {
        [LoadColumn(0)]
        public string? Text { get; set; }

        [LoadColumn(1), ColumnName("Label")]
        public bool Vacancy { get; set; }
    }

    public class VacancyPrediction : VacancyData
    {
        [ColumnName("PredictedLabel")] public bool Prediction { get; set; }
        public float Probability { get; set; }
        public float Score { get; set; }
    }
}
