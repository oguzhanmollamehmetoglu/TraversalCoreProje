﻿namespace TraversalCoreProje.CQRS.Commands.DestinationCommands
{
    public class UpdateDestinationCommand
    {
        public int Destinationİd { get; set; }
        public string City { get; set; }
        public string DayNight { get; set; }
        public double Price { get; set; }
        public int Capacity { get; set; }
    }
}