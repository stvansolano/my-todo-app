﻿using System;
using Newtonsoft.Json;

namespace Shared
{
	public class Item
	{
		public string Id { get; set; }

		[JsonProperty("Title")]
		public string Title { get; set; }

		public string Description { get; set; } = "This is the description";

		public bool IsCompleted { get; set; }

		[JsonProperty(nameof(DateCreated))]
		public DateTime DateCreated { get; set; }
	}
}