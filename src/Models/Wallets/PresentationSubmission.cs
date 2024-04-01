using System.Collections.Generic;

namespace mdoc.ui.Models.Wallets;

public class PresentationSubmission
{
    public string id { get; set; }
    public string definition_id { get; set; }
    public List<DescriptorMap> descriptor_map { get; set; }
}