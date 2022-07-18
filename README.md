# FsODE
Ordinary Differential Equation (ODE) Models in F#

# Development

_Note:_ The `release` and `prerelease` build targets assume that there is a `NUGET_KEY` environment variable that contains a valid Nuget.org API key.

### build

Check the [build project](https://github.com/CSBiology/FsODE/blob/main/build) to take a look at the  build targets. Here are some examples:

```shell
# Windows

# Build only
./build.cmd

# Full release buildchain: build, test, pack, build the docs, push a git tag, publish thze nuget package, release the docs
./build.cmd release

# The same for prerelease versions:
./build.cmd prerelease


# Linux/mac

# Build only
build.sh

# Full release buildchain: build, test, pack, build the docs, push a git tag, publísh the nuget package, release the docs
build.sh release

# The same for prerelease versions:
build.sh prerelease

```

### docs

The docs are contained in `.fsx` and `.md` files in the `docs` folder. To develop docs on a local server with hot reload, run the following in the root of the project:

```shell
# Windows
./build.cmd watchdocs

# Linux/mac
./build.sh watchdocs
```