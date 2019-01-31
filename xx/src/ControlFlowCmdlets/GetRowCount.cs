using ALE.ETLBox.ConnectionManager;
using ALE.ETLBox.ControlFlow;
using System;
using System.Management.Automation;

namespace ALE.ETLBoxCmdlets.ControlFlowCmdlets {
    [Cmdlet(VerbsCommon.Get,"RowCount")]
    [OutputType(typeof(int?))]
    public class GetRowCount : PSCmdlet {
        [Parameter]
        public string TableName { get; set; }
        [Parameter]
        public string Condition { get; set; }
        //[Parameter]
        //public RowCountOptions RowCountOptions { get; set; } 

        protected override void BeginProcessing() {
            base.BeginProcessing();
        }


        protected override void ProcessRecord() {
            base.ProcessRecord();
        }

        protected override void EndProcessing() {
            ControlFlow.CurrentDbConnection = new SqlConnectionManager(new ETLBox.ConnectionString("Data Source=.;Integrated Security=SSPI;Initial Catalog=ETLBox;"));
            int? result = RowCountTask.Count(TableName, Condition);//, RowCountOptions);
            WriteObject(result);
            base.EndProcessing();
        }

        protected override void StopProcessing() {
            base.StopProcessing();
        }

    }
}
