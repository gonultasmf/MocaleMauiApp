using Mocale;
using Mocale.Abstractions;
using Mocale.Extensions;
using System.Globalization;

namespace Project2;

public partial class MainPage(ILocalizationManager localizationManager, ITranslatorManager translatorManager) : FmgLibContentPage
{
    public override void Build()
    {
        this
        .Content(
            new ScrollView()
            .Content(
                new Grid()
                .RowDefinitions(e => e.Star(90).Star(10))
                .Children(
                    (IView)new StackLayout()
                    .Spacing(25)
                    .Children(
                        new Label()
                        .Text("Hello, World!")
                        .FontSize(32)
                        .CenterHorizontal()
                        .SemanticHeadingLevel(SemanticHeadingLevel.Level1),

                        new Label()
                        .Text(e => e.Path("[LocalizationCurrentProviderIs]").Source(MocaleLocator.TranslatorManager).BindingMode(BindingMode.OneWay))
                        .FontSize(18)
                        .CenterHorizontal()
                        .SemanticDescription("Welcome to dot net Multi platform App U I")
                        .SemanticHeadingLevel(SemanticHeadingLevel.Level1),

                        new Label()
                        .Text("Current count: 0")
                        .FontSize(18)
                        .FontAttributes(Bold)
                        .CenterHorizontal(),

                        new Button()
                        .Text("Click me")
                        .CenterHorizontal()
                        .InvokeOnElement(btn => btn.Clicked += OnCounterClicked)
                        .SemanticHint("Counts the number of times you click"),

                        new Image()
                        .Source("dotnet_bot.png")
                        .WidthRequest(250)
                        .HeightRequest(310)
                        .CenterHorizontal()
                        .SemanticDescription("Cute dot net bot waving hi to you!")
                    )
                )
            )
        );
    }
    private async void OnCounterClicked(object? sender, EventArgs e)
    {
        var french = new CultureInfo("fr-FR");
        var english = new CultureInfo("en-GB");
        var newLang = localizationManager.CurrentCulture.Name == french.Name ? english : french;
        var changed = await localizationManager.SetCultureAsync(newLang);
    }
}
