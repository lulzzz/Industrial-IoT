param(
    [Parameter(Mandatory=$True)] [string] $edgeKey
)
Write-Host ""$script:edgeKey""
$path = "${PSScriptRoot}\initialize-edge.ps1"
Write-Host $path
$trigger = New-JobTrigger -AtStartup -RandomDelay 00:00:30
$out = Register-ScheduledJob -Trigger $trigger –Name "IotEdge" -FilePath $path -ArgumentList @($script:edgeKey)
Write-Host $out.Command

. {Invoke-WebRequest -useb https://aka.ms/iotedge-win} | Invoke-Expression; `
Deploy-IoTEdge -RestartIfNeeded

Restart-Computer
