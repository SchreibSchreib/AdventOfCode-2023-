using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day19
{

    internal class PredicateEvaluator
    {
        public int Result { get; }

        private string _entryPoint;
        private Dictionary<string, int> _parts;
        private Dictionary<string, string[]> _allPredicatesForEntry;
        private Func<int, int, bool> _greaterThan = (x, y) => x > y;
        private Func<int, int, bool> _lessThan = (x, y) => x < y;

        public PredicateEvaluator(string entryPoint,
            Dictionary<string, int> parts,
            Dictionary<string, string[]> allWorkflows)
        {
            _entryPoint = entryPoint;
            _parts = parts;
            _allPredicatesForEntry = allWorkflows;
            Result = NavigateThroughWorkflowsAndEvaluate();
        }

        private int NavigateThroughWorkflowsAndEvaluate()
        {
            if(IsAccepted())
            {
                return SumPartsUp();
            }
            return 0;
        }

        private int SumPartsUp() => _parts.Values.Sum();

        private bool IsAccepted() => GetLastEntry() == "A";

        private string GetLastEntry()
        {
            while (_entryPoint != "A" && _entryPoint != "R")
            {
                _entryPoint = GetNextEntryPoint();
            }

            return _entryPoint;
        }

        private string GetNextEntryPoint()
        {
            string result = _entryPoint;
            foreach (var entry in _allPredicatesForEntry[_entryPoint])
            {
                if (IsValidEvaluation(entry))
                {
                    var afterEvaluation = Evaluate(entry);
                    if (_entryPoint != afterEvaluation)
                    {
                        return afterEvaluation;
                    }  
                }
                else
                {
                    result = entry;
                }
            }
            return result;
        }

        private string Evaluate(string predicate)
        {
            int partsNumber = _parts[Convert.ToString(predicate[0])];
            int predicateNumber = int.Parse(predicate.Substring(2).Split(":")[0]);
            string newResult = predicate.Split(":")[1];

            if (predicate.Contains(">"))
            {
                if(_greaterThan.Invoke(partsNumber, predicateNumber)) return newResult;
            }
            if (predicate.Contains("<"))
            {
                if (_lessThan.Invoke(partsNumber, predicateNumber)) return newResult;
            }

            return _entryPoint;
        }

        private bool IsValidEvaluation(string entry) => entry.Contains(":");
    }
}
