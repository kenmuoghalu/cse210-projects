namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        public SimpleGoal(string name, string description, int points) 
            : base(name, description, points) { }

        // Constructor for loading
        public SimpleGoal(string name, string description, int points, bool isComplete)
            : base(name, description, points, isComplete) { }

        public override int RecordCompletion()
        {
            if (!_isComplete)
            {
                _isComplete = true;
                return _points;
            }
            return 0;
        }

        public override string GetProgress()
        {
            return $"[{(_isComplete ? "X" : " ")}] {_name} - {_description} ({_points} points)";
        }

        public override string GetSaveString()
        {
            return $"SimpleGoal|{_name}|{_description}|{_points}|{_isComplete}";
        }
    }
}