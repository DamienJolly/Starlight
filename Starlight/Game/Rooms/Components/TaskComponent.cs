using Starlight.API.Game.Rooms.Models;
using Starlight.Game.Rooms.Tasks;
using Starlight.Tasks;
using System.Collections.Generic;

namespace Starlight.Game.Rooms.Components
{
	public class TaskComponent
	{
		private readonly IRoom _room;

		public List<BaseTask> Tasks { get; }

		public TaskComponent(IRoom room)
		{
			_room = room;
			Tasks = new List<BaseTask>();
		}

		public void StartTasks()
		{
			RegisterTasks();
			Tasks.ForEach(x => x.StartTask());
		}

		private void RegisterTasks()
		{
			Tasks.Add(new EntityTask(_room));
		}

		public void StopTasks()
		{
			foreach (var task in Tasks)
			{
				task.StopTask();
			}
		}
	}
}
