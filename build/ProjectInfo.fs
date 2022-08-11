module ProjectInfo

open Fake.Core

/// Contains relevant information about a project (e.g. version info, project location)
type ProjectInfo = {
    Name: string
    ProjFile: string
    ReleaseNotes: ReleaseNotes.ReleaseNotes Option
    PackageVersionTag: string
    mutable PackagePrereleaseTag: string
    AssemblyVersion: string
    AssemblyInformationalVersion: string
} with 
    /// creates a ProjectInfo given a name, project file path, and release notes file path.
    /// version info is created from the version header of the uppermost release notes entry.
    /// Assembly version is set to X.0.0, where X is the major version from the releas enotes.
    static member create(
        name: string,
        projFile: string,
        releaseNotesPath: string
    ): ProjectInfo = 
        let release = releaseNotesPath |> ReleaseNotes.load
        let stableVersion = release.NugetVersion |> SemVer.parse
        let stableVersionTag = $"{stableVersion.Major}.{stableVersion.Minor}.{stableVersion.Patch}"
        let assemblyVersion = $"{stableVersion.Major}.0.0"
        let assemblyInformationalVersion = stableVersionTag
        {
            Name = name
            ProjFile = projFile
            ReleaseNotes = Some release
            PackagePrereleaseTag = ""
            PackageVersionTag = stableVersionTag
            AssemblyVersion = assemblyVersion
            AssemblyInformationalVersion = assemblyInformationalVersion
        }    
    static member create(
        name: string,
        projFile: string
    ): ProjectInfo = 
        {
            Name = name
            ProjFile = projFile
            ReleaseNotes = None
            PackagePrereleaseTag = ""
            PackageVersionTag = ""
            AssemblyVersion = ""
            AssemblyInformationalVersion = ""
        }

let projectName = "FsODE"

let solutionFile  = $"{projectName}.sln"

let configuration = "Release"

let gitOwner = "CSBiology"

let gitHome = $"https://github.com/{gitOwner}"

let projectRepo = $"https://github.com/{gitOwner}/{projectName}"

let pkgDir = "pkg"

let AltaxoCoreTestProject = ProjectInfo.create("AltaxoCoreTest", "src/AltaxoCore/AltaxoCore/Altaxo/CoreTest/AltaxoCoreTest.csproj")
let FsODETestProject = ProjectInfo.create("FsODE.Tests", "tests/FsODE.Tests/FsODE.Tests.fsproj")

/// contains project info about all test projects
let testProjects = [
    AltaxoCoreTestProject
    FsODETestProject
]

let AltaxoCoreProject = ProjectInfo.create("AltaxoCore.Redist", "src/AltaxoCore/AltaxoCore/Altaxo/Core/AltaxoCore.Redist.csproj", "src/AltaxoCore/AltaxoCore/Altaxo/Core/RELEASE_NOTES.md")
let FsODEProject = ProjectInfo.create("FsODE", "src/FsODE/FsODE.fsproj", "src/FsODE/RELEASE_NOTES.md")

/// contains project info about all projects
let projects = [
    AltaxoCoreProject
    FsODEProject
]

/// docs are always targeting the version of the core project
let stableDocsVersionTag = FsODEProject.PackageVersionTag

/// branch tag is always the version of the core project
let branchTag = FsODEProject.PackageVersionTag

/// prerelease suffix used by prerelease buildtasks
let mutable prereleaseSuffix = ""

/// prerelease tag used by prerelease buildtasks
let mutable prereleaseTag = ""

/// mutable switch used to signal that we are building a prerelease version, used in prerelease buildtasks
let mutable isPrerelease = false