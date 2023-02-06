namespace FourthWeb.Models
{
    [Serializable]
    public class AppartmentCollectionModel
    {
    public List<AppartmentModel> Collection { get; set; }
    public AppartmentCollectionModel()
    {
        Collection = new List<AppartmentModel>();
    }
    public AppartmentCollectionModel(List<AppartmentModel> collection)
    {
        Collection = collection;
    }
}
}