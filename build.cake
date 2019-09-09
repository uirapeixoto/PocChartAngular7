#tool "nuget:?package=OpenCover"
#tool "nuget:?package=ReportGenerator"
#tool nuget:?package=xunit.runner.console

var configuration = Argument("Configuration", "Debug");
var solutionFile = "./PocAspNetCoreChart.sln";

 Task("BuildTest")
    .Does(() => 
    {
        MSBuild("./RepositoryTest/RepositoryTest.csproj", 
            new MSBuildSettings {
                Verbosity = Verbosity.Minimal,
                Configuration = "Debug"
            }
        );
    });
	
Task("OpenCover")
    .IsDependentOn("BuildTest")
    .Does(() => 
    {
        var openCoverSettings = new OpenCoverSettings()
        {
            Register = "user",
            SkipAutoProps = true,
            ArgumentCustomization = args => args.Append("-coverbytest:*.Tests.dll").Append("-mergebyhash")
        };
 
        var outputFile = new FilePath("./GeneratedReports/CalculadoraReport.xml");
 
        OpenCover(tool => {
                var testAssemblies = GetFiles("./Calculadora.Tests/bin/Debug/Calculadora.Tests.dll");
                tool.xUnit2(testAssemblies);
            },
            outputFile,
            openCoverSettings
                .WithFilter("+[Calculadora*]*")
                .WithFilter("-[Calculadora.Tests]*")
        );
    });

