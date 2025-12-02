function Get-NextDayNumber {
    $lastDayNumber = (Get-ChildItem -Path "..\src\AdventOfCode.Console\Challenges" -Directory |
            Select-Object -ExpandProperty Name |
            ForEach-Object { [int]($_ -replace '\D', '') } |
            Sort-Object |
            Select-Object -Last 1)
    return "{0:D2}" -f ($lastDayNumber + 1)
}

function New-File {
    param (
        [string]$Path,
        [string]$Content = ""
    )
    New-Item -Path $Path -ItemType File -Force | Out-Null
    if ($Content) {
        $formattedContent = $Content -replace "`r?`n", "`r`n"
        Set-Content -Path $Path -Value $formattedContent -Encoding UTF8
    }
}

Write-Output "--- Advent of Code - Challenge generator ---`r`n"

$DayNumber = Get-NextDayNumber
$ChallengeDirectory = "..\src\AdventOfCode.Console\Challenges\Day$DayNumber"
$TestDirectory = "..\src\AdventOfCode.Tests"

if (Test-Path $ChallengeDirectory) {
    Write-Warning "Challenge Day$DayNumber already exists."
    Read-Host -Prompt "Press Enter to exit"
    return
}

New-Item -Path $ChallengeDirectory -ItemType Directory | Out-Null
Write-Output "Generated directory: $ChallengeDirectory`r`n"

$challengeCode = (Get-Content -Path "templates/Challenge.template" -Raw) -replace "{{day_number}}", $DayNumber
New-File -Path "$ChallengeDirectory\Day$DayNumber.cs" -Content $challengeCode
Write-Output "Generated code file: Day$DayNumber.cs`r`n"

New-File -Path "$ChallengeDirectory\Input1.txt"
Write-Output "Generated input files: Input1.txt`r`n"

New-File -Path "$ChallengeDirectory\.solution"
Write-Output "Generated solution file: .solution`r`n"

$testCode = (Get-Content -Path "templates/Tests.template" -Raw) -replace "{{day_number}}", $DayNumber
New-File -Path "$TestDirectory\Day${DayNumber}Tests.cs" -Content $testCode
Write-Output "Generated test file: Day${DayNumber}Tests.cs`r`n"

Write-Output "Added new Day$DayNumber to the project file`r`n"
Write-Output "--- Completed generation for day $DayNumber ---`r`n"
Read-Host -Prompt "Press Enter to exit"
