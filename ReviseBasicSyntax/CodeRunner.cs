namespace ReviseBasicSyntax;

static class CodeRunner
{
    public static void Run(Action action, bool shallRun = true)
    {
        if (shallRun)
        {
            action();
        }
    }
}
