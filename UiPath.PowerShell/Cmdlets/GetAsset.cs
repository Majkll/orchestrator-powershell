﻿using System.Management.Automation;
using UiPath.PowerShell.Models;
using UiPath.PowerShell.Util;
using UiPath.Web.Client20181;

namespace UiPath.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, Nouns.Asset)]
    public class GetAsset: FilteredBaseCmdlet
    {
        [Filter]
        [Parameter(ParameterSetName = "Filter")]
        public string Name { get; set; }

        protected override void ProcessRecord()
        {
            ProcessImpl(
                filter => Api.Assets.GetAssets(filter: filter, expand: "RobotValues").Value,
                dto => Asset.FromDto(dto));
        }
    }
}
