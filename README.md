# log-counter

The log-counter is a concole application to count the number by the day from log file.

___
## Build
#### Requirement
* .NET Framework 4.0 or later

#### Procedure
1. Clone or download this repository.
2. Run "log-counter.bat" file. <br>
  (change "MSBuild.exe" path in "log-counter.bat" file as necessary)<br>
=> "dist/LogCounter.exe" is output.

___
## Usage
#### Procedure
    LogCounter.exe [input file path]

After the execution, the result file are output in the same folder of input file.

###### Note
The each line of the input file must start with date format (yyyymmdd).

___
## License
MIT
