using System.Timers;

namespace Starlight.Tasks
{
	public abstract class BaseTask
	{
        public Timer Task { get; private set; }
        public abstract int Interval { get; }

        public void StartTask()
        {
            if (Task != null)
                return;

            Task = new Timer();
            Task.Interval = Interval;
            Task.Elapsed += Run;
            Task.Enabled = true;
            Task.Start();
        }

        public void StopTask()
        {
            if (Task == null)
                return;

            Task.Dispose();
            Task = null;
        }

        public abstract void Run(object sender, ElapsedEventArgs e);
    }
}
