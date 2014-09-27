using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace CodeCamp.Helpers
{
	public class Grouping<K, T> : ObservableCollection<T>
	{
		public K Key { get; private set; }

		public Grouping(K key, IEnumerable<T> items)
		{
			Key = key;
			foreach (var item in items)
				this.Items.Add(item);
		}
	}
	//- See more at: http://motzcod.es/#sthash.QlKNtfa4.dpuf
}

