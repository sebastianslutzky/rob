
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

public interface IDisplayableObject { }

public class IsisObject:IDisplayableObject {
    private IEnumerable<dynamic> _rawObject;
    public IList<JToken> ResultObjects{get;private set;}

    public string Title{get;private set;}
    public IList<string> Columns {get; private set;}


    public bool IsEmpty => ResultObjects.Count == 0;

    public IsisObject(IEnumerable<dynamic> objects,string title)
    {
        Title = title;
        _rawObject = objects;
        ResultObjects = objects.OfType<JToken>()
        .Where( x => x["$$ro"] == null).ToList() ;
        Columns = ExtractColumns();
    }

    public IList<string> ExtractColumns(){
        if(IsEmpty){
            return new string[]{};
        }
        var sampleRow = ResultObjects[0];
        var asJobj = sampleRow as JObject;
        return asJobj.Properties()
            .Select(x=>x.Name)
            .Where(x => !x.StartsWith("$$"))
            .ToList();
    }
}
