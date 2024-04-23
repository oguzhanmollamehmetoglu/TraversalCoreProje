namespace TraversalCoreProje.CQRS.Commands.DestinationCommands
{
    public class DeleteDestinationCommand
    {
        public DeleteDestinationCommand(int id)
        {
            İd = id;
        }

        public int İd { get; set; }
    }
}