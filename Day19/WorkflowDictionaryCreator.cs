using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day19
{
    internal class WorkflowDictionaryCreator
    {
        public Dictionary<string, string[]> WorkFlowToPredicates { get; }

        private string _workFlows;

        public WorkflowDictionaryCreator(string workFlows)
        {
            _workFlows = workFlows;
            WorkFlowToPredicates = CreateDictionary(_workFlows);
        }

        private Dictionary<string, string[]> CreateDictionary(string workFlows)
        {
            var newDictionary = new Dictionary<string, string[]>();
            var splittedWorkflows = SplitWorkflows(workFlows);

            foreach (var workFlow in splittedWorkflows)
            {
                newDictionary.Add(GetKey(workFlow), GetValue(workFlow));
            }

            return newDictionary;
        }

        private string[] GetValue(string workFlow) => workFlow
            .Split("{")[1]
            .Replace("}", "")
            .Replace("\r", "")
            .Split(',');

        private string GetKey(string workFlow) => workFlow.Split("{")[0];

        private string[] SplitWorkflows(string workFlows) => workFlows.Split("\n");
    }
}
