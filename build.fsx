#r @"tools\FAKE\tools\FakeLib.dll"

open Fake

RestorePackages()

let name ="Twainsoft.PCV"

let buildAssembly = name + ".dll"
let outputDir = "./output"
let buildDir = outputDir + "/build"
let testDir = outputDir + "/test"
let publishDir = outputDir + "/publish"
let version = "0.1"

Target "Clean" (fun _ -> 
    CleanDirs [buildDir; testDir; publishDir]
)

Target "BuildLibrary" (fun _ ->
    !! "./src/Twainsoft.PCV/**/*.csproj"
    |> MSBuildRelease buildDir "Build"
    |> Log "Building app: "
)

Target "BuildTest" (fun _ ->
    !! "./src/Twainsoft.PCV.Tests/**/*.csproj"
    |> MSBuildDebug testDir "Build"
    |> Log "Building test: "
)

Target "MSpecTest" (fun _ ->
    !! (testDir @@ "*.Tests.dll" )
        |> MSpec (fun p -> 
            {p with 
                ExcludeTags = ["LongRunning"]
                HtmlOutputDir = testDir})
)

"Clean"
    ==> "BuildLibrary"
    ==> "BuildTest"
    ==> "MSpecTest"

RunTargetOrDefault "MSpecTest"
