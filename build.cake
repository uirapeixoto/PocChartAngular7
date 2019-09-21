#tool "nuget:?package=OpenCover"
#tool "nuget:?package=ReportGenerator"
#tool nuget:?package=xunit.runner.console

var configuration = Argument("Configuration", "Debug");
var solutionFile = "./PocAspNetCoreChart.sln";
var target = Argument("target", "Default");

// Define directories.
var artifactsDir  = Directory("./GeneratedReports/artifacts/");
var rootAbsoluteDir = MakeAbsolute(Directory("./")).FullPath;


//Tasks
Task("Clean")
    .Does(() =>
{
    CleanDirectory(artifactsDir);
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
	{
		NuGetRestore(solutionFile);
	});
	


Task("BuildTests")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
	var parsedSolution = ParseSolution(solutionFile);

	foreach(var project in parsedSolution.Projects)
	{
	
	if(project.Name.EndsWith("Test"))
		{
        Information("Start Building Test: " + project.Name);

		var outputdir = rootAbsoluteDir + @"\GeneratedReports\artifacts\";
		
        MSBuild(project.Path, new MSBuildSettings()
                .SetConfiguration("Debug")
                .SetMSBuildPlatform(MSBuildPlatform.Automatic)
                .SetVerbosity(Verbosity.Minimal)
                .WithProperty("SolutionDir", @".\")
                .WithProperty("OutDir", outputdir));
		}
	
	}    

});

Task("RunTests")
    .IsDependentOn("BuildTests")
    .Does(() =>
{
    Information("Start Running Tests");
	var projects = GetFiles("./test/**/*Test.csproj");
    foreach(var project in projects)
    {
	  Information("Directory run test: " + project.ToString());
      DotNetCoreTest(
        project.FullPath,
        new DotNetCoreTestSettings()
          {
            // Set configuration as passed by command line
            Configuration = configuration
          });
    }
	//DotNetCoreTest("./RepositoriTest/RepositoryTest.csproj");
    //XUnit2("./artifacts/_tests/**/*Test.dll");
});
	
Task("OpenCover")
    .IsDependentOn("RunTests")
    .Does(() => 
    {
		try 
        {
				var success = true;
				var outputFile = new FilePath("./GeneratedReports/TestReport.xml");
				var outputDir = Directory("./GeneratedReports/Report/");
				var testAssemblies = GetFiles("./GeneratedReports/artifacts/RepositoryTest.dll");
				
				var openCoverSettings = new OpenCoverSettings()
				{
					Register = "user",
					SkipAutoProps = true,
					ArgumentCustomization = args => args.Append("-coverbytest:*Tests.dll").Append("-mergebyhash")
				};
			 
				foreach(var project in testAssemblies)
				{
					try 
					{
						var projectFile = MakeAbsolute(project).ToString();
						var dotNetTestSettings = new DotNetCoreTestSettings
						{
							Configuration = configuration,
							NoBuild = true
						};
			 
						OpenCover(context => context.DotNetCoreTest(projectFile, dotNetTestSettings), outputFile, openCoverSettings);
					}
					catch(Exception ex)
					{
						success = false;
						Error("There was an error while running the tests", ex);
					}
				}
			
			Information("Start Report Generator");
			ReportGenerator(outputFile, outputDir);
 
		
        }catch(Exception ex){
			throw new CakeException($"There was an error while running the opencover. {ex.Message}");
		}
		
	});
	
	//Task Target
Task("Default")
    .IsDependentOn("OpenCover");
	
	
//Execution
RunTarget(target);

