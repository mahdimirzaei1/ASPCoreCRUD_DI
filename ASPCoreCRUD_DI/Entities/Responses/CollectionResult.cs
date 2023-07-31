namespace ASPCoreCRUD_DI.Entities.Responses
{
    public record CollectionResult<T>
    {
        public List<T>? Collection { get; set; }
    }
}
