namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        private int _completionCount;

        public EternalGoal(string name, string description, int points) 
            : base(name, description, points)
        {
            _completionCount = 0;
        }

        // Constructor for loading
        public EternalGoal(string name, string description, int points, bool isComplete, int completionCount)
            : base(name, description, points, isComplete)
        {
            _completionCount = completionCount;
        }

        public override int RecordCompletion()
        {
            _completionCount++;
            return _points; // Always return points for eternal goals
        }

        public override bool IsComplete() => false; // Eternal goals are never complete

        public override string GetProgress()
        {
            return $"[∞] {_name} - {_description} ({_points} points each) - Completed {_completionCount} times";
        }

        public override string GetSaveString()
        {
            return $"EternalGoal|{_name}|{_description}|{_points}|{_isComplete}|{_completionCount}";
        }

        public int GetCompletionCount() => _completionCount;
    }
}