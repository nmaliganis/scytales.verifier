using System.Collections.Generic;

namespace mdoc.ui.Models.PidPresentationDefinitions;

public class Field
{
    public List<string> path { get; set; }
    public Filter filter { get; set; }
    public bool? intent_to_retain { get; set; }
}