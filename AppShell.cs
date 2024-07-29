namespace Project2
{
    public partial class AppShell : Shell
    {
        public AppShell(IServiceProvider service)
        {
            this
            .FlyoutBehavior(FlyoutBehavior.Disabled)
            .Items(
                new ShellContent()
                .Title("Home")
                .ContentTemplate(() => service.GetService<MainPage>())
                .Route(nameof(MainPage))
            );
        }
    }
}
