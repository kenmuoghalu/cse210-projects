using System;

namespace EternalQuest
{
    public abstract class Goal
    {
        protected string _name;
        protected string _description;
        protected int _points;
        protected bool _isComplete;

        public Goal(string name, string description, int points)
        {
            _name = name;
            _description = description;
            _points = points;
            _isComplete = false;
        }

        // Abstract methods that must be implemented by derived classes
        public abstract int RecordCompletion();
        public abstract string GetProgress();
        public abstract string GetSaveString();

        // Virtual methods with default implementation
        public virtual bool IsComplete() => _isComplete;
        public virtual string GetName() => _name;
        public virtual string GetDescription() => _description;
        public virtual int GetPoints() => _points;

        // Constructor for loading from save data
        protected Goal(string name, string description, int points, bool isComplete)
        {
            _name = name;
            _description = description;
            _points = points;
            _isComplete = isComplete;
        }
    }
}