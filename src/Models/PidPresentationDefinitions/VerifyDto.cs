using System.Collections.Generic;

namespace mdoc.ui.Models.PidPresentationDefinitions;

public class VerifyDto
{
    public string id { get; set; }
    public List<InputDescriptor> input_descriptors { get; set; }
}