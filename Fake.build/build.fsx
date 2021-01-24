#r "paket:
nuget Fake.IO.FileSystem
nuget Fake.DotNet.MSBuild
nuget Fake.Core.Target //"
#load "./.fake/build.fsx/intellisense.fsx"

open Fake.IO
open Fake.IO.Globbing.Operators
open Fake.DotNet
open Fake.Core

// Properties
let buildDirRoot = "./build/"
let sourcesDirRoot = "./src/"

// Targets
Target.create "Clean" (fun p ->
    let args = p.Context.Arguments
    printfn "Cleaning output for: %A" args
    let buildDir = buildDirRoot + args.Head
    Shell.cleanDir buildDir
)

Target.create "BuildApp" (fun p ->
    let firstArg = p.Context.Arguments.Head
    printfn "Building app for : %s" firstArg
    let searchPattern = sourcesDirRoot + firstArg + ".sln"
    let buildDirApp = buildDirRoot + firstArg + "/"
    !! searchPattern
        |> MSBuild.runRelease id buildDirApp "Build"
        |> Trace.logItems "AppBuild-Output: "
)

Target.create "Default" (fun p ->
    let firstArg = p.Context.Arguments.Head
    let message = "Completed the build for argument: " + firstArg
    Trace.trace message
)

open Fake.Core.TargetOperators

"Clean"
    ==> "BuildApp"
    ==> "Default"

// start build
Target.runOrDefaultWithArguments "Default"