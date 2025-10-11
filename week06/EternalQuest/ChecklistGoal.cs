namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _targetCount;
        private int _currentCount;
        private int _bonusPoints;

        public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints) 
            : base(name, description, points)
        {
            _targetCount = targetCount;
            _currentCount = 0;
            _bonusPoints = bonusPoints;
        }

        // Constructor for loading
        public ChecklistGoal(string name, string description, int points, bool isComplete, int targetCount, int currentCount, int bonusPoints)
            : base(name, description, points, isComplete)
        {
            _targetCount = targetCount;
            _currentCount = currentCount;
            _bonusPoints = bonusPoints;
        }

        public override int RecordCompletion()
        {
            if (_currentCount < _targetCount)
            {
                _currentCount++;
                
                if (_currentCount == _targetCount)
                {
                    _isComplete = true;
                    return _points + _bonusPoints; // Points + bonus when completed
                }
                return _points; // Regular points before completion
            }
            return 0; // Already completed
        }

        public override string GetProgress()
        {
            string status = _isComplete ? "X" : " ";
            return $"[{status}] {_name} - {_description} ({_points} points each) - Completed {_currentCount}/{_targetCount} times" + 
                   (_isComplete ? $" + {_bonusPoints} bonus points!" : "");
        }

        public override string GetSaveString()
        {
            return $"ChecklistGoal|{_name}|{_description}|{_points}|{_isComplete}|{_targetCount}|{_currentCount}|{_bonusPoints}";
        }
    }
}