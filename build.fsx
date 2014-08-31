#r @"tools\FAKE\tools\FakeLib.dll"

open Fake

RestorePackages()

let name ="Twainsoft.PagedCollectionView"

let buildAssembly = name + ".dll"
let outputDir = "./output"
let publishDir = outputDir + "/publish"
let buildDir = outputDir + "/build"
let testDir = outputDir + "/test"
let version = "0.1"

Target "Clean" (fun _ -> 
    CleanDirs [buildDir; testDir; publishDir]
)

Target "BuildLibrary" (fun _ ->
    !! "./src/**/*.csproj"
    |> MSBuildRelease buildDir "Build"
    |> Log "Building app: "
)

"Clean"
    ==> "BuildLibrary"

RunTargetOrDefault "BuildLibrary"
