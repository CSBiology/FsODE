(*** hide ***)

(*** condition: prepare ***)
// reference external package dependencies here
// #r "nuget: Newtonsoft.JSON, 13.0.1"

#I "../src/FsODE.CSharp/bin/Release/netstandard2.0"
#I "../src/FsODE/bin/Release/netstandard2.0"
#r "FsODE.CSharp.dll"
#r "FsODE.dll"

(*** condition: ipynb ***)
#if IPYNB
#r "nuget: FsODE.CSharp, {{fsdocs-package-version}}"
#r "nuget: FsODE, {{fsdocs-package-version}}"
#endif // IPYNB

(**
# FsODE

Intro goes here
*)

open FsODE

FsODE.Say.hello "jooo"
(***include-output***)