module ProjectInfo

open Fake.Core

let project = "FsODE"

let testProjects = 
    [
        "tests/FsODE.Tests/FsODE.Tests.fsproj"
        "tests/FsODE.CSharp.Tests/FsODE.CSharp.Tests.csproj"
    ]

let solutionFile  = $"{project}.sln"

let configuration = "Release"

let gitOwner = "CSBiology"

let gitHome = $"https://github.com/{gitOwner}"

let projectRepo = $"https://github.com/{gitOwner}/{project}"

let pkgDir = "pkg"

let release = ReleaseNotes.load "RELEASE_NOTES.md"

let stableVersion = SemVer.parse release.NugetVersion

let stableVersionTag = (sprintf "%i.%i.%i" stableVersion.Major stableVersion.Minor stableVersion.Patch )

let mutable prereleaseSuffix = ""

let mutable prereleaseTag = ""

let mutable isPrerelease = false